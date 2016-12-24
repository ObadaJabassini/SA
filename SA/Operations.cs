using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SA.GUI.Costum_Controls.Mancala;

namespace SA
{
    interface IOperations
    {
        void AddStone(Stone stone);
        void CarryStones(List<Stone> stones);
    }
}
