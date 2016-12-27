using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.GUI.Costum_Controls.Mancala
{
    public partial class FlatStone : UserControl
    {
        public FlatStone()
        {
            InitializeComponent();

            this.BackColor = CustomPallete.GetRandomColor();
            Thread.Sleep(20);
            Random randomX = new Random((int)DateTime.Now.Ticks);
            Thread.Sleep(190);
            Random randomY = new Random((int)DateTime.Now.Ticks);
            this.Location=new Point(randomX.Next(),randomY.Next());


        }
    }
}
