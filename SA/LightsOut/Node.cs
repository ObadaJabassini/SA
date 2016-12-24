using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut
{
    public class Node
    {
        public Board Board{ get; set; }
        //public IList<Node> Children { get; private set; } = null;
        public ConcurrentBag<Node> Children { get; private set; } = null;
        public Node Parent { get; set; } = null;
        public HashSet<Tuple<int, int>> RemainingPositions { get; set; }
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
        public double Evaluation { get { return Board.Evaluation(); } }
        public int Cost { get; set; } = 0;
        public double TotalCost { get { return Cost + Evaluation; } }
        public bool IsFinal { get { return Board.IsFinal(); } }
        public Node(HashSet<Tuple<int, int>> set)
        {
            this.RemainingPositions = set;
        }

        public ConcurrentBag<Node> GenerateChildren()
        {
            var self = this;
            //Children = new List<Node>();
            Children = new ConcurrentBag<Node>();
            Parallel.ForEach(RemainingPositions, (pair) =>
            {
                var b = self.Board.Clone() as Board;
                int i = pair.Item1, j = pair.Item2;
                var set = self.RemainingPositions.Clone();
                set.Remove(new Tuple<int, int>(i, j));
                b.Click(i, j);
                var child = new Node(set) { Board = b, Cost = self.Cost + 1, Parent = self};
                self.Children.Add(child);
            });
            //foreach (var pair in RemainingPositions)
            //{
            //    var b = Board.Clone() as State[,];
            //    int i = pair.Item1, j = pair.Item2;
            //    var set = RemainingPositions.Clone();
            //    set.Remove(new Tuple<int, int>(i, j));
            //    _click(b, i, j);
            //    var child = new Node(set) { Board = b, Cost = this.Cost + 1, Parent = self };
            //    Children.Add(child);
            //}
            return Children;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as Node;
            return this.Board.Equals(t.Board);
        }

        public override int GetHashCode() => Board.GetHashCode();

        public override string ToString() => Board.ToString();
    }
}
