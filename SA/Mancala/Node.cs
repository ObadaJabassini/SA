using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    class Node
    {
        public IList<int>[] Bins;
        public int[] Mancalas;
        public int Player { get; }
        public IList<Node> Children { get; private set; } = null;
        public Node Parent { get; set; } = null;
        public IList<Node> Parents { get { IList<Node> nn = new List<Node>(); Node temp = Parent;while (temp != null) nn.Add(temp); var t = nn.Reverse(); var tt = t.ToList();tt.Insert(0, this); return tt; } }
        public int Eval => Mancalas[0] - Mancalas[1];
        public bool GameOver => Bins.All(e => e.All(c => c == 0));
        public bool GetExtraTurn { get; }

        public Node(int player, bool extra)
        {
            GetExtraTurn = extra;
            Player = player;
        }

        public IList<Node> GenerateChildren()
        {
            Children = new List<Node>();
            for (int i = 0; i < Bins[Player-1].Count; i++)
            {
                IList<int>[] bins = Bins.Clone() as IList<int>[];
                int[] mancalas = Mancalas.Clone() as int[];
                bool extra = _move(i, bins, mancalas);
                Bins[Player - 1].ToList().ForEach(e => Children.Add(new Node(Player, extra) { Bins = bins, Mancalas = mancalas, Parent = this }));
            }

            return Children;
        }

        private bool _move(int bin, IList<int>[] Bins, int[] Mancalas)
        {
            Func<int, int, int> inc_dec = (i, k) => k == 1 ? i+1 : i-1;
            Func<int, int, bool> more_less = (i, k) => k == 1 ? i < Bins[0].Count : i > 0;
            Func<int, int> start = (k) => k == 1 ? Bins[1].Count : 0;

            int stones = Bins[Player - 1][bin], side = Player, idx = bin;
            while (stones > 0)
            {
                for (int i = inc_dec(idx, side); more_less(i, side); i = inc_dec(i, side))
                {
                    Bins[side - 1][i]++;

                    if (side == Player && stones - 1 == 0)
                    {
                        Bins[side - 1][i] += Bins[3 - side - 1][i];
                        Bins[3 - side - 1][i] = 0;
                    }

                    stones--;
                }

                if (stones > 0)
                {
                    Mancalas[side - 1]++;

                    if (side == Player && stones - 1 == 0)
                        return true;

                    stones--;
                    idx = start(side);
                    side = 3 - side;
                }
            }
            return false;
        }
    }
}
