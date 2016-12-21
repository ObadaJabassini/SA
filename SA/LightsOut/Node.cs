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
        public IList<Node> Parents { get { IList<Node> nn = new List<Node>(); Node temp = Parent;while (temp != null) nn.Add(temp); var t = nn.Reverse(); var tt = t.ToList();tt.Insert(0, this); return tt; } }
        private int _eval = -1;
        public int Evaluation { get { return _eval != -1 ? _eval : (_eval = Board.Cast<State>().Where(state => state == State.OFF).Count()); } }
        public int Cost { get; set; } = 0;
        public int TotalCost { get { return Cost + Evaluation; } }
        public bool IsFinal { get { return Board.Cast<State>().All(state => state == State.OFF); } }
        private bool _isValid(int x, int y) => x >= 0 && y >= 0 && x < Board.GetLength(0) && y < Board.GetLength(1);
        private State _flip(State state) => state == State.ON ? State.OFF : State.ON;
        public IList<Node> GenerateChildren()
        {
            var self = this;
            Children = new List<Node>();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    var b = Board.Clone() as State[, ];
                    _click(b, i, j);
                    Children.Add(new Node() { Board = b, Cost = this.Cost + 1, Parent = self});
                }
            }
            return Children;
        }

        private void _click(State[, ] b, int i, int j)
        {
            var that = this;
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
            return Board.Cast<State>().Equals(((Node)obj).Board.Cast<State>());
        }

        public override int GetHashCode()
        {
            return Board.Cast<State>().Aggregate(17, (f, s) => f * 31 + s == State.ON ? 1 : 2);
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
