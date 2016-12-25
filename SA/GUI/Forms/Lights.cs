using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SA.GUI.Costum_Controls;
using SA.LightsOut;
using SA.LightsOut.LineraAlgebra;

namespace SA.GUI.Forms
{
    public partial class Lights : Telerik.WinControls.UI.RadForm
    {
        private LightsCell[,] LightsCells;
        private SolutionMethod method;
        private Board Board;
        private List<Node> solution;

        public Lights()
        {
            InitializeComponent();
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.ColumnCount = 11;

            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    this.tableLayoutPanel1.Controls.Add(new LightsCell()
                    {
                        Name = (tableLayoutPanel1.RowCount*i + j).ToString()
                    });
                    tableLayoutPanel1.AutoSize = true;
                }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Lights_Load(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {


            this.moves.Clear();
            int[,] ints = new int[tableLayoutPanel1.RowCount, tableLayoutPanel1.ColumnCount];
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    if (
                        (this.tableLayoutPanel1.Controls[(i*tableLayoutPanel1.RowCount + j).ToString()] as LightsCell)
                            .radButton1.ThemeName ==
                        visualStudio2012DarkTheme1.ThemeName

                        )
                    {
                        ints[i, j] = 0;
                    }
                    else
                    {
                        ints[i, j] = 1;
                    }
                }
            }
            Board = new Board() {Game = ints};
            
            if (this.linearalgebra.IsChecked)
                method = new Solver() {Initial = Board};
            else if (this.bfs.IsChecked)
                method = new BFS() {Initial = Board};
            else
                method = new AStar() {Initial = Board};
            solution = method.Solve().ToList();

            //this.radListView1.Items.Add(solution[0]);
            foreach (Node node in solution)
            {
                this.moves.Text += "_____________________\n" + node;
            }
            
        }

        private void bfs_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

        }

        private void m_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            this.moves.Clear();
            tableLayoutPanel1.RowCount = (int) m.Value;
            tableLayoutPanel1.ColumnCount = (int) n.Value;

            for (int i = 0; i < m.Value; i++)
            {
                for (int j = 0; j < n.Value; j++)
                {

                    this.tableLayoutPanel1.Controls.Add(new LightsCell()
                    {
                        Name = (m.Value*i + j).ToString()
                    });


                }
            }

            tableLayoutPanel1.AutoSize = true;

        }

        private void radTextBoxControl1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(tableLayoutPanel1.Size.Width + side.Size.Width + moves.Size.Width+6, this.Size.Height);
        }
    }
}
