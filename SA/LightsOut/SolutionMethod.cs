using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut
{
    public abstract class SolutionMethod
    {
        public Board Initial { get; set; }
        public abstract IList<Node> Solve();
    }
}
