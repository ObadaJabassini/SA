using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut
{
    class BFS
    {
        public enum SolveMethod { SYNC, ASYNC}
        public Node.State[,] Initial { set; get; }
        public IList<Node> Solve(SolveMethod method = SolveMethod.SYNC)
        {
            HashSet<Tuple<int, int>> set = new HashSet<Tuple<int, int>>();
            for (int i = 0; i < Initial.GetLength(0); i++)
            {
                for (int j = 0; j < Initial.GetLength(1); j++)
                {
                    set.Add(new Tuple<int, int>(i, j));
                }
            }
            var ini = new Node(set) { Board = Initial };
            // async code
            if (method == SolveMethod.ASYNC)
            {
                ConcurrentQueue<Node> q = new ConcurrentQueue<Node>();
                ini.GenerateChildren().ToList().ForEach(q.Enqueue);
                ConcurrentBag<Tuple<List<Node>, int>> bag = new ConcurrentBag<Tuple<List<Node>, int>>();
                IList<Task> tasks = new List<Task>();
                for (int i = 0; i < 100; i++)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        Node n;
                        while (q.TryDequeue(out n))
                        {
                            if (n.IsFinal)
                            {
                                var ps = n.Parents;
                                bag.Add(new Tuple<List<Node>, int>(ps.ToList(), ps.Count));
                            }
                            n.GenerateChildren().ToList().ForEach(q.Enqueue);
                        }
                    }
                    ));
                }
                Task.WaitAll(tasks.ToArray());
                if (bag.IsEmpty)
                    return new List<Node>();
                return bag.OrderByDescending(x => x.Item2).First().Item1;
            }
            // sync code
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(ini);
            ISet<Node> visited = new HashSet<Node>();
            while (queue.Count != 0)
            {
                var n = queue.Dequeue();
                if (n.IsFinal)
                {
                    return n.Parents;
                }
                visited.Add(n);
                n.GenerateChildren().Where(s => !visited.Contains(s)).ToList().ForEach(queue.Enqueue);
            }
            return new List<Node>();
        }
    }
}
