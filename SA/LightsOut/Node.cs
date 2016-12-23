using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut
{
    public class Node
    {
        public enum State { ON, OFF }
        public State[,] Board { get; set; }
        public IList<Node> Children { get; private set; } = null;
        public Node Parent { get; set; } = null;
        public HashSet<Tuple<int, int>> RemainingPositions { get; set; } = new HashSet<Tuple<int, int>>();
        public IList<Node> Parents
        {
            get
            {
                IList<Node> nn = new List<Node>();
                Node temp = this;
                while (temp != null)
                {
                    nn.Add(temp);
                    temp = temp.Parent;
                }
                return nn.Reverse().ToList();
            }
        }
        private int _eval = -1;
        public double Evaluation { get { return _eval != -1 ? _eval : (_eval = Board.Cast<State>().Where(state => state == State.ON).Count() / 5); } }
        public int Cost { get; set; } = 0;
        public double TotalCost { get { return Cost + Evaluation; } }
        public bool IsFinal { get { return Board.Cast<State>().All(state => state == State.OFF); } }
        private bool _isValid(int x, int y) => x >= 0 && y >= 0 && x < Board.GetLength(0) && y < Board.GetLength(1);
        private State _flip(State state) => state == State.ON ? State.OFF : State.ON;

        public Node(HashSet<Tuple<int, int>> set)
        {
            this.RemainingPositions = set;
        }

        public IList<Node> GenerateChildren()
        {
            var self = this;
            Children = new List<Node>();
            foreach (var pair in RemainingPositions)
            {
                var b = Board.Clone() as State[,];
                int i = pair.Item1, j = pair.Item2;
                var set = RemainingPositions.Clone();
                set.Remove(new Tuple<int, int>(i, j));
                _click(b, i, j);
                var child = new Node(set) { Board = b, Cost = this.Cost + 1, Parent = self};
                Children.Add(child);
            }
            return Children;
        }

        public void _click(State[,] b, int i, int j)
        {
            b[i, j] = _flip(b[i, j]);
            if (_isValid(i - 1, j))
                b[i - 1, j] = _flip(b[i - 1, j]);
            if (_isValid(i + 1, j))
                b[i + 1, j] = _flip(b[i + 1, j]);
            if (_isValid(i, j - 1))
                b[i, j - 1] = _flip(b[i, j - 1]);
            if (_isValid(i, j + 1))
                b[i, j + 1] = _flip(b[i, j + 1]);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as Node;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] != t.Board[i, j])
                        return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return Board.Cast<State>().Aggregate(17, (f, s) => f * 31 + s.GetHashCode());
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    builder.Append(Board[i, j]).Append(" ");
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
