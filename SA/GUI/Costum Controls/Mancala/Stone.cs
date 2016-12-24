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
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SA.GUI.Costum_Controls.Mancala
{
    public partial class Stone : UserControl
    {

        public Stone()
        {
            InitializeComponent();

            Thread.Sleep(190);
            Random random = new Random((int)DateTime.Now.Ticks);

            this.Location = new Point(random.Next(0, 70), random.Next(0, 70));

            GenerateRandomKnownColors();

        }

        void GenerateRandomColors()
        {
            int R = 0, G = 0, B = 0;
            int Channel, Value;
            Random random = new Random();
            Channel = random.Next(3);
            Value = random.Next(255);

            if (Channel == 1)
                R = Value;
            if (Channel == 2)
                G = Value;
            if (Channel == 3)
                B = Value;

            ((Telerik.WinControls.UI.RadButtonElement)(this._stone.RootElement.Children[0]))
                .BackColor = Color.FromArgb(R, G, B);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.RootElement.Children[0].Children[0]))
                .BackColor2 = Color.FromArgb(R, G, B);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.RootElement.Children[0].Children[0]))
                .BackColor3 = Color.FromArgb(R, G, B);
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.RootElement.Children[0].Children[0]))
                .BackColor4 = Color.FromArgb(R, G, B);
        }

        void GenerateRandomKnownColors()
        {
            Color color = CustomPallete.GetRandomColor();
            ((Telerik.WinControls.UI.RadButtonElement)(this._stone.RootElement.Children[0]))
                .BackColor = color;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.RootElement.Children[0].Children[0]))
                .BackColor2 = color;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.RootElement.Children[0].Children[0]))
                .BackColor3 = color;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this._stone.RootElement.Children[0].Children[0]))
                .BackColor4 = color;
        }
    }
}
