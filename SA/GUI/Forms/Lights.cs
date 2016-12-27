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
        //private List<Node> solution;
        private C5.LinkedList<Node> solution=new C5.LinkedList<Node>();
        public Lights()
        {
            InitializeComponent();
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.ColumnCount = 11;

            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    this.tableLayoutPanel1.SetCellPosition(new LightsCell()
                    {
                        Name = (tableLayoutPanel1.RowCount*i + j).ToString()
                    }, new TableLayoutPanelCellPosition(i,j));
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
            radLabel3.Text = "Number of Solutions :\n";
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
            Board = new Board(ints); 
            
            if (this.linearalgebra.IsChecked)
                method = new Solver() {Initial = Board};
            else if (this.bfs.IsChecked)
            {
                method = new BFS()
                {
                    Initial = Board, 
                    Method = async.IsChecked? BFS.SolveMethod.ASYNC : BFS.SolveMethod.SYNC
                };
            }
            else
                method = new AStar() {Initial = Board};

            List<Node> sol = method.Solve().ToList();
            solution.Clear();
            //this.radListView1.Items.Add(solution[0]);
            foreach (Node node in sol)
            {
                string s = node.ToString();
                string ss=s;
                //ss=ss.Replace('1', '*');
                this.moves.Text += "_____________________\n" + ss;
                solution.Add(node);
            }
           
            radLabel3.Text +=  solution.Count>0? (solution.Count - 1).ToString() : "There is no solutions !";
            radBindingNavigator1CountItem.Text = "of {"+solution.Count+"}";
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
            this.Refresh();
        }

        private void radPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radBindingNavigator1MoveNextItem_Click(object sender, EventArgs e)
        {

            togrid(Convert.ToInt16(radBindingNavigator1PositionItem.Text));
            radBindingNavigator1PositionItem.Text =
                (Convert.ToInt16(radBindingNavigator1PositionItem.Text) + 1).ToString();
        }
       
        

        void togrid(int nn)
        {
            //string ss = solution[nn].ToString();
            //string s = (string) ss.Replace("\n",String.Empty);
            Node node = solution[nn];
            int index = 0;
            for (int i = 0; i < m.Value; i++)
            {
                for (int j = 0; j < n.Value; j++)
                {
                    LightsCell cell = tableLayoutPanel1.GetControlFromPosition(j, i) as LightsCell;
                    if (node.Board[i,j]==false)
                    {
                        (cell).radButton1.ThemeName =
                            visualStudio2012DarkTheme1.ThemeName;
                        tableLayoutPanel1.Refresh();
                        Console.WriteLine("0");
                        Console.WriteLine("{0}",index);
                    }
                     else 
                    {
                        (cell).radButton1.ThemeName =
                            visualStudio2012LightTheme1.ThemeName;
                        tableLayoutPanel1.Refresh();
                        Console.WriteLine("1");
                        Console.WriteLine("{0}", index);
                    }
                    index++;
                }
            }
        }

        private void radBindingNavigator1PositionItem_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void radBindingNavigator1PositionItem_Click(object sender, EventArgs e)
        {

        }

        private void radBindingNavigator1MovePreviousItem_Click(object sender, EventArgs e)
        {

            radBindingNavigator1PositionItem.Text =
                (Convert.ToInt16(radBindingNavigator1PositionItem.Text) - 1).ToString();

            togrid(Convert.ToInt32(radBindingNavigator1PositionItem.Text));
   
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            foreach (LightsCell cell in tableLayoutPanel1.Controls)
            {
                cell.radButton1.ThemeName = visualStudio2012LightTheme1.ThemeName;
            }
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            
        }

        public void TurnAll(bool state)
        {
            foreach (LightsCell cell in tableLayoutPanel1.Controls)
            {
                cell.radButton1.ThemeName = state ? visualStudio2012LightTheme1.ThemeName : visualStudio2012DarkTheme1.ThemeName;
            }
        }
        private void radBindingNavigator1CountItem_Click(object sender, EventArgs e)
        {

        }

        private void radButton3_Click_1(object sender, EventArgs e)
        {
            TurnAll(false);
        }

        private void radButton4_Click_1(object sender, EventArgs e)
        {
            TurnAll(true);
        }
    }
}
