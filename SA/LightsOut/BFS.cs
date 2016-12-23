using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut
{
    class BFS
    {
        public Node.State[,] Initial { set; get; }

        public IList<Node> Solve()
        {
            Queue<Node> q = new Queue<Node>();
            HashSet<Tuple<int, int>> set = new HashSet<Tuple<int, int>>();
            for (int i = 0; i < Initial.GetLength(0); i++)
            {
                for (int j = 0; j < Initial.GetLength(1); j++)
                {
                    set.Add(new Tuple<int, int>(i, j));
                }
            }
            var ini = new Node(set) { Board = Initial };
            q.Enqueue(ini);
            ISet<Node> visited = new HashSet<Node>();
            while (q.Count != 0)
            {
                var n = q.Dequeue();
                if (n.IsFinal)
                {
                    return n.Parents;
                }
                visited.Add(n);
                n.GenerateChildren().Where(s => !visited.Contains(s)).ToList().ForEach(q.Enqueue);
            }
            return new List<Node>();
        }
    }
}
