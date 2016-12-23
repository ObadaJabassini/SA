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
            var b = new Node.State[,] { { Node.State.ON, Node.State.ON, Node.State.OFF }, { Node.State.ON, Node.State.OFF, Node.State.OFF }, { Node.State.OFF, Node.State.OFF, Node.State.OFF } };
            new BFS() { Initial = b }.Solve().ToList().ForEach(e => Console.WriteLine(e.ToString()));
            //new Solver() { Initial = b}.Solve().ToList().ForEach(e => Console.WriteLine(e.ToString()));
            Game game = new Game();
            game.Play();
            Console.ReadKey();
        }
    }
}
