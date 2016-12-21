using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    class Node
    {
        public List<int>[] Bins;
        public int[] Mancalas;
        public int Eval => Mancalas[0] - Mancalas[1];

        public bool Move(int bin, int player)
        {
            Func<int, int, int> inc_dec = (i, k) => k == 1 ? i+1 : i-1;
            Func<int, int, bool> more_less = (i, k) => k == 1 ? i < Bins[0].Count : i > 0;
            Func<int, int> start = (k) => k == 1 ? Bins[1].Count : 0;

            int stones = Bins[player - 1][bin], t = player, idx = bin;
            while (stones > 0)
            {
                for (int i = inc_dec(idx, t); more_less(i, t); i = inc_dec(i, t))
                {
                    Bins[t - 1][i]++;

                    if (t == player && stones - 1 == 0)
                    {
                        Bins[t - 1][i] += Bins[3 - t - 1][i];
                        Bins[3 - t - 1][i] = 0;
                    }

                    stones--;
                }

                if (stones > 0)
                {
                    Mancalas[t - 1]++;

                    if (t == player && stones - 1 == 0)
                        return true;

                    stones--;
                    idx = start(t);
                    t = 3 - t;
                }
            }

            return false;
        }
    }
}
