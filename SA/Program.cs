using SA.LightsOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new Node.State[, ] { { Node.State.OFF, Node.State.ON, Node.State.OFF }, { Node.State.ON, Node.State.ON, Node.State.ON }, { Node.State.OFF, Node.State.ON, Node.State.OFF } };
            new BFS() { Initial = b}.Solve().ToList().ForEach(e => Console.WriteLine(e.ToString()));
            Console.ReadKey();
        }
    }
}
