﻿using System;
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
        public IList<Node> Parents { get { IList<Node> nn = new List<Node>(); nn.Add(this); Node temp = Parent; while (temp != null) { nn.Add(temp); temp = temp.Parent; } return nn.Reverse().ToList(); } }
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
                bool extra = Move(i, bins, mancalas);
                Bins[Player - 1].ToList().ForEach(e => Children.Add(new Node(Player, extra) { Bins = bins, Mancalas = mancalas, Parent = this }));
            }

            return Children;
        }

        public bool Move(int bin, IList<int>[] Bins, int[] Mancalas)
        {
            Func<int, int, int> inc_dec = (i, k) => k == 1 ? i+1 : i-1;
            Func<int, int, bool> more_less = (i, k) => k == 1 ? i < Bins[0].Count : i > 0;
            Func<int, int> start = (k) => k == 1 ? Bins[1].Count : 0;

            int stones = Bins[Player - 1][bin], t = Player, idx = bin;
            while (stones > 0)
            {
                for (int i = inc_dec(idx, t); more_less(i, t); i = inc_dec(i, t))
                {
                    Bins[t - 1][i]++;

                    if (t == Player && stones - 1 == 0)
                    {
                        Bins[t - 1][i] += Bins[3 - t - 1][i];
                        Bins[3 - t - 1][i] = 0;
                    }

                    stones--;
                }

                if (stones > 0)
                {
                    Mancalas[t - 1]++;

                    if (t == Player && stones - 1 == 0)
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