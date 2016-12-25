using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SA.Mancala;
using SA.Properties;

namespace SA.GUI.Costum_Controls.Mancala
{
    public partial class Cell : UserControl, IOperations, IObservable<CuurentCell>,IObservable<GetOpositCell>
    {
        private bool _isloaded;
        public int id;
        static SoundPlayer player = new SoundPlayer(Resources.button12);
        public Tuple<byte,int >VirtualId;
        public Cell()
        {
            InitializeComponent();
        }
        
        private void Cell_Load(object sender, EventArgs e)
        {
            int count = 4;

            for (int i = 0; i < count; i++)
            {
                this.ContainerCell.Controls.Add(new Stone()
                {
                    Location = CustomLocations.GetRandomPoint()
                });
                System.Windows.Forms.Application.DoEvents();
            }
            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
            //StartAddto();
            //StartRemovefrom();
            _isloaded = true;
        }

        private void StartAddto()
        {
            int count = 4;

            for (int i = 0; i < count; i++)
                this.ContainerCell.Controls.Add(new Stone());
            //this.ContainerCell.Controls.Add(new FlatStone());

            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
        }

        private void StartRemovefrom()
        {
            int count = 3;
            
            Thread.Sleep(500);
            Random random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < count; i++)
            {
                this.ContainerCell.Controls.RemoveAt(random.Next(0, 3));
                
            }
            //this.ContainerCell.Controls.Add(new FlatStone());
            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
        }

        public void AddStone(Stone stone)
        {
            ContainerCell.Controls.Add(stone);
            player.Play();
            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
        }

        public List<Stone> Empty()
        {
            List<Stone> stones=new List<Stone>();
            foreach (var stone in this.ContainerCell.Controls)
            {
                stones.Add((Stone) stone);
            }
            ContainerCell.Controls.Clear();
            this.CountStones.Text = "0";
            return stones;
        }
        private void ContainerCell_ControlAdded(object sender, ControlEventArgs e)
        {
        }

        private void ContainerCell_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.CountStones.Text = ContainerCell.Controls.Count.ToString();
        }

        public void PerformClick()
        {
            CuurentCell cell=new CuurentCell(){
                player = this.VirtualId.Item1,
                virtualId = this.VirtualId.Item2

            };
            GetOpositCell opositCell = null;
            Func<int> index = () => (this.ContainerCell.Controls.Count + id) % 14;
            Func<int> target = () => 14 - index();
            if (Forms.Mancala.List[index()] is Cell)
            {
                Cell c = Forms.Mancala.List[index()] as Cell;
                Cell t = Forms.Mancala.List[target()] as Cell;
                if (VirtualId.Item1== c.VirtualId.Item1)
                {
                    if (c.ContainerCell.Controls.Count == 0 && t.ContainerCell.Controls.Count != 0)
                    {
                        Console.WriteLine(index());
                        Console.WriteLine(id);
                        Console.WriteLine("===" + c.ContainerCell.Controls.Count);
                        Console.WriteLine(target());
                        Console.WriteLine("===" + t.ContainerCell.Controls.Count);
                        opositCell = new GetOpositCell()
                        {
                            //id=index(),
                            Cell = c,
                            target = t,
                            player = VirtualId.Item1

                        };
                    }
                }
            }

            if (this.VirtualId.Item1 == 2 && this.ContainerCell.Controls.Count == 7 - id)
            {
                cell.ext = true;
            }
            if (this.VirtualId.Item1 == 1 && this.ContainerCell.Controls.Count == 14 - id)
            {
                cell.ext = true;
            }
            List<Stone> stones = Empty();
            if (stones.Count != 0)
            {
                Func<int, int> next = (int current) => (current + 1)%14;
                //this.AddStone(stones[0]);
                //stones.RemoveAt(0);
                if ((Forms.Mancala.List[next(id)]) is Cell)
                {
                    var nextcell = (Forms.Mancala.List[next(id)]) as Cell;
                    //nextcell.AddStone(stones[0]);
                    //stones.RemoveAt(0);
                    nextcell.CarryStones(stones);
                }
                if ((Forms.Mancala.List[next(id)]) is EarningsCell)
                {
                    var nextcell = (Forms.Mancala.List[next(id)]) as EarningsCell;
                    //nextcell.AddStone(stones[0]);
                    //stones.RemoveAt(0);
                    nextcell.CarryStones(stones);
                }

            }
            if(opositCell != null)
                _observers2[0].OnNext(opositCell);
            _observers[0].OnNext(cell);
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            _observers[0].OnNext(new CuurentCell()
            {
                player = this.VirtualId.Item1,
                virtualId = this.VirtualId.Item2
            });
            PerformClick();
            Forms.Mancala._game.NextPlayer = this.VirtualId.Item1;
            Forms.Mancala._game.MakeMove(this.VirtualId.Item2);
        }

        private void ContainerCell_Click(object sender, EventArgs e)
        {
            PerformClick();
            Forms.Mancala._game.NextPlayer = this.VirtualId.Item1;
            Forms.Mancala._game.MakeMove(this.VirtualId.Item2);
        }

        public void CarryStones(List<Stone> stones)
        {
            
            if (stones.Count != 0)
            {
                Func<int, int> next = (int current) => (current + 1)%14;
                this.AddStone(stones[0]);
                stones.RemoveAt(0);
                if (stones.Count == 0 && this.ContainerCell.Controls.Count == 1)
                {
                    //_observers2[0].OnNext(new GetOpositCell()
                    //{
                    //    id = this.id,
                    //    player = this.VirtualId.Item1
                    //});
                }
                else
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
            }


        }

        private void ContainerCell_MouseUp(object sender, MouseEventArgs e)
        {
            //Forms.Mancala._game.Makeachoice();
        }


        private List<IObserver<CuurentCell>> _observers = new List<IObserver<CuurentCell>>();
        public IDisposable Subscribe(IObserver<CuurentCell> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return null;
        }

        private List<IObserver<GetOpositCell>> _observers2 = new List<IObserver<GetOpositCell>>();
        public IDisposable Subscribe(IObserver<GetOpositCell> observer)
        {
            if (!_observers2.Contains(observer))
            {
                _observers2.Add(observer);
            }
            return null;
        }
    }
}
