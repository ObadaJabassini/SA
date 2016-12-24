using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SA.GUI.Costum_Controls;

namespace SA.GUI.Forms
{
    public partial class Lights : Telerik.WinControls.UI.RadForm
    {
        private LightsCell[,] LightsCells;
        public Lights()
        {
            InitializeComponent();
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.ColumnCount = 12;
            
            for(int i=0;i<tableLayoutPanel1.RowCount;i++)
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    this.tableLayoutPanel1.Controls.Add(new LightsCell());
                    tableLayoutPanel1.AutoSize = true;
                }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Lights_Load(object sender, EventArgs e)
        {

        }
    }
}
