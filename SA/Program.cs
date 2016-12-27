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
            //var b = new Node.State[,] { { Node.State.ON, Node.State.ON, Node.State.ON}, { Node.State.ON, Node.State.OFF, Node.State.ON }, { Node.State.OFF, Node.State.OFF, Node.State.OFF } };
            ////var b = new Node.State[,] { { Node.State.OFF, Node.State.ON, Node.State.ON}, { Node.State.OFF, Node.State.OFF, Node.State.ON }, { Node.State.OFF, Node.State.OFF, Node.State.OFF } };
            //var sol = new BFS() { Initial = b }.Solve(BFS.SolveMethod.ASYNC).ToList();
            //if(sol.Count == 0)
            //    Console.WriteLine("No Solutions have been found");
            //else
            //    sol.ForEach(Console.WriteLine);
            //Console.ReadKey();

            Game g = new Game(new MinMax());
            g.Play();
        }
    }
}
