using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut
{
    public class AStar
    {
        public Node.State[, ] Initial { set; get; }

        public IList<Node> Solve()
        {
            C5.IntervalHeap<Node> heap = new C5.IntervalHeap<Node>(Comparer<Node>.Create((Node f, Node s) => (f.TotalCost).CompareTo(s.TotalCost)));
            var ini = new Node() { Board = Initial };
            heap.Add(ini);
            ISet<Node> visited = new HashSet<Node>();
            while(!heap.IsEmpty)
            {
                var n = heap.DeleteMin();
                if (n.IsFinal)
                {
                    return n.Parents;
                }
                visited.Add(n);
                n.GenerateChildren().Where(e => !visited.Contains(e)).ToList().ForEach(e => heap.Add(e));
            }
            return new List<Node>();
        }
    }
}
