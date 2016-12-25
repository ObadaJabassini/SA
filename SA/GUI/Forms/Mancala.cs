﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SA.GUI.Costum_Controls.Mancala;
using SA.Mancala;

namespace SA.GUI.Forms
{
    public partial class Mancala : Telerik.WinControls.UI.RadForm, IObserver<ResultMessage>,IObserver<byte>,IObserver<CuurentCell>,IObserver<GetOpositCell>
    {
        private const int TotalCellCount = 14;
        private readonly Point FirstOpCell = new Point(158, 33);
        private readonly Point FirstPlCell = new Point(158, 254);
        private const int StartIndex = 1;
        private const int EndIndex = 14;
        private ShapedForm1 pro;
        public static Game _game;
        public static List<Control> List = new List<Control>();
        private Game.DifficultyLevel m;
        public Mancala()
        {
            InitializeComponent();
            
        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void Mancala_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
           //_game.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Mask.Size = new Size(Mask.Size.Width, Mask.Size.Height - 4);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int id = 0;
            EarningsCell EarningsOPCell = new EarningsCell() {
                Name = "EarningsOPCell",
                Location = new Point(FirstOpCell.X - 130, FirstOpCell.Y),
                VirtualId = new Tuple<byte, int>(1,-1),
                id=id++
            };
            EarningsOPCell.Subscribe(this);
            Mancala.List.Add(EarningsOPCell);
            
            for (int i = 0; i < 6; i++)
            {
                Cell PLCell = new Cell()
                {
                    Name = "PLCell" + i,
                    Location = new Point(FirstPlCell.X + (i * 130), FirstPlCell.Y),
                    VirtualId = new Tuple<byte, int>(2, i),
                    id = id++
                };
                PLCell.Subscribe((IObserver<CuurentCell>) this);
                PLCell.Subscribe((IObserver<GetOpositCell>) this);
                Mancala.List.Add(PLCell);
            }
            EarningsCell EarningsPLCell = new EarningsCell
            {
                Name = "EarningsPLCell",
                Location = new Point(935, 135),
                VirtualId = new Tuple<byte, int>(2, -1),
                id = id++
            };
            EarningsPLCell.Subscribe(this);
            Mancala.List.Add(EarningsPLCell);

            for (int i = 5; i > -1; i--)
            {
                Cell OPCell = new Cell()
                {
                    Name = "OPCell" + i,
                    Location = new Point(FirstOpCell.X + (i * 130), FirstOpCell.Y),
                    VirtualId = new Tuple<byte, int>(1, i),
                    id = id++
                };
                OPCell.Subscribe((IObserver<CuurentCell>) this);
                OPCell.Subscribe((IObserver<GetOpositCell>) this);
                Mancala.List.Add(OPCell);
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Program.shapedForm1.Hide();
            //BoardPanel.Controls.AddRange(List.ToArray());
            foreach (var control in List)
            {
              BoardPanel.Controls.Add(control);  
                System.Windows.Forms.Application.DoEvents();
            }
            Play.Visible = true;
        }
 
        public void OnNext(ResultMessage value)
        {
            Control c = List.Find(
                control =>
                {
                    if (control is Cell)
                    {
                        Cell cell = control as Cell;
                        if (cell.VirtualId.Item1 == 1)
                            return cell.VirtualId.Item2 == value.VirtualId;
                    }
                    return false;
                }
                );
            (c as Cell).PerformClick();
            //Informant.Text = "Your Turn ";
        }

        public void OnNext(byte value)
        {
            this.Informant.Text = value == 1 ? "Computer Got an Extra Trun !!" : "You Got an Extra Trun !!";
        }

        public void OnNext(CuurentCell value)
        {
            Informant.Text = value.player == 1 ? "Your Turn" : "Computer's Turn";
        }

        public void OnNext(GetOpositCell value)
        {
            int target_index = 14 - value.id;
            if ((List[target_index] as Cell).ContainerCell.Controls.Count != 0)
            {
                if (value.player == 1)
                {
                    Control.ControlCollection stones = (List[value.id] as Cell).ContainerCell.Controls;
                    for (int i = 0; i < stones.Count; i++)
                    {
                        (List[0] as EarningsCell).AddStone(stones[i] as Stone);
                    }
                }
                else
                {
                    Control.ControlCollection stones = (List[value.id] as Cell).ContainerCell.Controls;
                    for (int i = 0; i < stones.Count; i++)
                    {
                        (List[7] as EarningsCell).AddStone(stones[i] as Stone);
                    }
                }
            }
            //(List[3-value.player] as EarningsCell).ContainerCell.Controls.Add(List[(value.id + 7) % 14]);

            //if (value.player == 1)
            //{
            //    Control.ControlCollection Collection = (List[(value.id + 7) % 14] as Cell).ContainerCell.Controls;

            //    Control.ControlCollection targeted = (List[0] as EarningsCell).ContainerCell.Controls;
            //    for (int i = 0; i < Collection.Count; i++)
            //    {
            //        targeted.Add(
            //            Collection[0]
            //            );
            //        Collection.Remove(
            //            Collection[0]
            //            );
            //    }
            //    //Control[] stones = (List[value.id] as Cell).ContainerCell.Controls;

            //    //(List[0] as EarningsCell).ContainerCell.Controls.AddRange(stones);
            //}
            //else
            //{
            //    Control.ControlCollection Collection = (List[(value.id + 7) % 14] as Cell).ContainerCell.Controls;

            //    EarningsCell targeted = (List[7] as EarningsCell);
            //    for (int i = 0; i < Collection.Count; i++)
            //    {
            //        targeted.AddStones(
            //            Collection[0]
            //            );
            //        Collection.Remove(
            //            Collection[0]
            //            );
            //    }
            //}
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        private void radRadioButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
           
        }

        private void radRadioButton3_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

        }

        private void radLabel2_Click(object sender, EventArgs e)
        {
            if(StratigyAlgorithm.SelectedItem==null)
            {StratigyAlgorithm.Select();  return;} 
            if(FirstPlayer.SelectedItem==null)
            {FirstPlayer.Select(); return;}
            Game.DifficultyLevel level = beginner.IsChecked
                ? Game.DifficultyLevel.Easy
                : medium.IsChecked
                    ? Game.DifficultyLevel.Meduim
                    : Game.DifficultyLevel.Difficult;

            IntelligentAgent agent = StratigyAlgorithm.SelectedItem.Index == 0 ? new MinMax() : new AlphaBetaMinMax();
            int player = FirstPlayer.SelectedItem.Index == 0 ? 1 : 2;
            _game = new Game(agent, level) {NextPlayer = player};
            _game.Subscribe(this);
            Informant.Text = FirstPlayer.SelectedItem.Index == 0 ? "Computer's Turn" : "Your Turn";
            Curten.Start();
        }

        private void Informant_Click(object sender, EventArgs e)
        {
            //if (List.All(control => (control as Cell).ContainerCell.Controls.Count == 0))
            //foreach (Control control in List)
            //{
            //    if (control is Cell)
            //    {
            //        if ((control as Cell).ContainerCell.Controls.Count != 0)
            //            break;
            //    }
            //    else continue;
            //    Informant.Text = "You Won !";
            //}
            //if(Informant.Text.Contains("!!"))
            //    Informant.Text = Informant.Text.EndsWith("You") ? "Computer Got an Extra Trun !!" : "You Got an Extra Trun !!";
            //else
            //    Informant.Text = Informant.Text.StartsWith("You") ? Informant.Text.Replace("You","Computer") : "Your Turn";
            //if (Informant.Text == "Computer's Turn")
            //    Informant.Text = "Your Turn";
            
           

            for (int i = 1; i <= 6; i++)
            {
                if ((List[i] as Cell).ContainerCell.Controls.Count != 0)
                        break;
                if (i == 6 && 
                    (List[7] as EarningsCell).ContainerCell.Controls.Count >
                    (List[0] as EarningsCell).ContainerCell.Controls.Count)
                    Informant.Text = "You Won !";
            }
            for (int i = 8; i <= 13; i++)
            {
                if ((List[i] as Cell).ContainerCell.Controls.Count != 0)
                    break;
                if (i == 13) 
                {if((List[7] as EarningsCell).ContainerCell.Controls.Count <
                    (List[0] as EarningsCell).ContainerCell.Controls.Count)
                    Informant.Text = "Computer Won !";
                    if((List[7] as EarningsCell).ContainerCell.Controls.Count ==
                    (List[0] as EarningsCell).ContainerCell.Controls.Count)
                        Informant.Text = "It is a Draw !";
                }
                
            }
           _game.Makeachoice();
             //if (Informant.Text == "Computer Got an Extra Trun !!")
             //   Informant.Text = "Your Turn";
        }
    }

}
