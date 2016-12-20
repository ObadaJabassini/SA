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
            heap.Add(new Node() {Board = Initial});
            ISet<Node> visited = new HashSet<Node>();
            while(!heap.IsEmpty)
            {
                var n = heap.FindMin();
                if(n.IsFinal)
                {
                    return n.Parents;
                }
                visited.Add(n);
                heap.AddAll(n.GenerateChildren().Where(s => !visited.Contains(s)));
            }
            return new List<Node>();
        }
    }
}
