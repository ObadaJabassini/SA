using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SA.GUI.Costum_Controls.Mancala
{
    public partial class NormalCell : SA.GUI.Costum_Controls.Mancala.MancalaCell
    {
        public NormalCell(int count = 4):base()
        {
            this.InitializeComponent();

            for (int i = 0; i < count; i++)
                this.ContainerCell.Controls.Add(new Stone());
            //this.ContainerCell.Controls.Add(new FlatStone());


            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
        }
    }
}
