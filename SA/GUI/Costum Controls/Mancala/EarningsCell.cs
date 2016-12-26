using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;
using SA.Properties;

namespace SA.GUI.Costum_Controls.Mancala
{
    public partial class EarningsCell :UserControl,IOperations,IObservable<byte>
    {
        public int id;
        SoundPlayer player = new SoundPlayer(SA.Properties.Resources.button12);
        SoundPlayer player2 = new SoundPlayer(SA.Properties.Resources.Click_SoundBible_com_1387633738);
        public Tuple<byte, int> VirtualId;
        public EarningsCell()
        {
            InitializeComponent();
            
        }

        public void AddStone(Stone stone)
        {

            ContainerCell.Controls.Add(stone);
            player.Play();
            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
        }

        public void CarryStones(List<Stone> stones)
        {
            if (stones.Count > 0)
            {
                Func<int, int> next = (int current) => (current + 1) % 14;
                this.AddStone(stones[0]);
                stones.RemoveAt(0);
                if (stones.Count != 0)
                {
                    if ((Forms.Mancala.List[next(id)]) is Cell)
                    {
                        var nextcell = (Forms.Mancala.List[next(id)]) as Cell;
                        nextcell.CarryStones(stones);
                    }
                    if ((Forms.Mancala.List[next(id)]) is EarningsCell)
                    {
                        var nextcell = (Forms.Mancala.List[next(id)]) as EarningsCell;
                        nextcell.CarryStones(stones);
                    }
                }
               // else
                   // _observers[0].OnNext(this.VirtualId.Item1);
            }
        }

        public void AddStones(List<Stone> stones)
        {

            ContainerCell.Controls.AddRange(stones.ToArray());
            player2.Play();
            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
        }

        private List<IObserver<byte>> _observers = new List<IObserver<byte>>();

        public  IDisposable Subscribe(IObserver<byte> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return null;
        }
    }
}
