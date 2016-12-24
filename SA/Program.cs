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
        static void Main(string[] args)
        {

            var b = new Board() { Game = new int[,] { { 1, 1, 1 }, { 1, 0, 1 }, { 0, 0, 0 } } };
            SolutionMethod method = new BFS() { Initial = b, Method = BFS.SolveMethod.ASYNC };
            var sol = method.Solve().ToList();
            if (sol.Count == 0)
                Console.WriteLine("No Solutions have been found");
            else
                sol.ForEach(Console.WriteLine);
            Game g = new Game();
            g.Play();
            //Console.ReadKey();
        }
    }
}
