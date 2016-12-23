using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                var t = ini.GenerateChildren();
                foreach(var x in t)
                {
                    q.Enqueue(x);
                }
                const int maxi = 200000;
                Tuple<IEnumerable<Node>, int> res = new Tuple<IEnumerable<Node>, int>(null, maxi);
                IList<Task> tasks = new List<Task>();
                for (int i = 1; i <= 100; ++i)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        Node n;
                        while (q.TryDequeue(out n))
                        {
                            if (n.Cost >= res.Item2)
                                return;
                            if (n.IsFinal)
                            {
                                var ps = n.Parents;
                                int cnt = ps.Count;
                                if(cnt < res.Item2)
                                    Interlocked.Exchange(ref res, new Tuple<IEnumerable<Node>, int>(ps, cnt));
                                return;
                            }
                            t = n.GenerateChildren();
                            foreach (var x in t)
                            {
                                q.Enqueue(x);
                            }
                        }
                    }
                    ));
                }
                Task.WaitAll(tasks.ToArray());
                if (res.Item2 == maxi)
                    return new List<Node>();
                return res.Item1.ToList();
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
