using SA.LightsOut;
using SA.LightsOut.LineraAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SA.Mancala;

namespace SA
{
    class Program
    {
        public static void Main(string[] args)
        {
            const int sz = 7;
            int[,] tt = new int[sz, sz];
            for (int i = 0; i < sz; i++)
            {
                for (int j = 0; j < sz; j++)
                {
                    tt[i, j] = 0;
                }
            }
            tt[0, 0] = 1;
            var t = new Board(tt);
            var b = new Board(new int[,] { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } });
            var bb = new Board(new int[,] { { 1, 1, 1 }, { 1, 0, 1 }, { 0, 0, 0 } });
            SolutionMethod method = new BFS() { Initial = b};
            var sol = method.Solve().ToList();
            if (sol.Count == 0)
                Console.WriteLine("No Solutions have been found");
            else
                sol.ForEach(Console.WriteLine);
            //Game g = new Game();
            //g.Play();
            Console.ReadKey();
        }
    }
}
