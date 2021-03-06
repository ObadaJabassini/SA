﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    public partial class Game
    {
        public const int BINS_NUM   = 6;
        public int StonesNum { set; get; }
        public enum DifficultyLevel { Easy, Meduim, Difficult }
        private IList<int>[] _bins;
        private int[] _mancals;
        public int NextPlayer { set; get; } = 2;
        public bool IsGameOver => Bins.Any(e => e.All(c => c == 0));
        public DifficultyLevel Level { get; }
        public IntelligentAgent Agent { set; get; }
        public int Winner => Mancalas[0] > Mancalas[1] ? 1 : (Mancalas[0] < Mancalas[1] ? 2 : 3);
        public int[] Mancalas => _mancals.Clone() as int[];
        public IList<int>[] Bins
        {
            get
            {
                var temp = new IList<int>[]
                {
                    Enumerable.Range(0, BINS_NUM).Select(i => StonesNum).ToList(),
                    Enumerable.Range(0, BINS_NUM).Select(i => StonesNum).ToList()
                };
                for (int i = 0; i < BINS_NUM; i++)
                {
                    temp[0][i] = _bins[0][i];
                    temp[1][i] = _bins[1][i];
                }

                return temp;
            }
        }

        public Game(DifficultyLevel l = DifficultyLevel.Meduim, int stonesNum = 4)
        {
            StonesNum = stonesNum;
            _bins = new IList<int>[]
            {
                 Enumerable.Range(0, BINS_NUM).Select(i => StonesNum).ToList(),
                 Enumerable.Range(0, BINS_NUM).Select(i => StonesNum).ToList()
            };

            _mancals = new[] {0, 0};

            Level = l;

            Agent = new IntelligentAgent(l, false);
        }

        public Game(Game other) : this()
        {
            _bins = other.Bins;
            _mancals = other.Mancalas;
            NextPlayer = other.NextPlayer;
        }

        public Game(int[] m) : this()
        {
            _mancals = m;
        }

        public void MakeMove(int bin)
        {
            Func<int, int, int> inc_dec = (i, k) => k == 2 ? i + 1 : i - 1;
            Func<int, int, bool> more_less = (i, k) => k == 2 ? i < _bins[0].Count : i >= 0;
            Func<int, int> start = (k) => k == 2 ? _bins[1].Count - 1 : 0;

            int stones = _bins[NextPlayer - 1][bin], side = NextPlayer, idx = inc_dec(bin, side);

            bool getExtraTurn = false;
            _bins[NextPlayer - 1][bin] = 0;
            while (stones > 0)
            {
                for (int i = idx; more_less(i, side) && stones > 0; i = inc_dec(i, side))
                {
                    _bins[side - 1][i]++;

                    if (side == NextPlayer && stones - 1 == 0 && _bins[side - 1][i] == 1 && _bins[3 - side - 1][i] > 0)
                    {
                        _mancals[side - 1] += _bins[3 - side - 1][i] + _bins[side - 1][i]--;
                        _bins[3 - side - 1][i] = 0;
                    }

                    stones--;
                }

                if (stones <= 0) continue;

                if (side == NextPlayer)
                {
                    _mancals[side - 1]++;
                    stones--;

                    if(stones == 0)
                        getExtraTurn = true;
                }

                idx = start(side);
                side = 3 - side;
            }

            NextPlayer = getExtraTurn ? NextPlayer : 3 - NextPlayer;

            if (!IsGameOver) return;
            _mancals[0] += _bins[0].Sum();
            _mancals[1] += _bins[1].Sum();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < _bins[i].Count; j++)
                    _bins[i][j] = 0;
        }

        public override string ToString()
        {
            return "\n  My bins: " + Bins[0].AsEnumerable().Aggregate("", (current, i) => current + $"{i} ") + "\n" +
                   "Your bins: " + Bins[1].AsEnumerable().Aggregate("", (current, i) => current + $"{i} ") + "\n" +
                   "  My mancala: " + Mancalas[0] + "\n" + "Your mancala: " + Mancalas[1] + "\n" +
                   "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*\n";
        }

        public void Play()
        {
            Console.WriteLine("Choose who to play first 1-Computer 2-You");
            NextPlayer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(this);
            while (!IsGameOver)
            {
                if (NextPlayer == 2)
                {
                    Console.WriteLine("It's your turn, make a move..");
                    int bin_id = Convert.ToInt32(Console.ReadLine());
                    MakeMove(bin_id);
                    Console.WriteLine("You choose {0}, the result is :", bin_id);
                    Console.WriteLine(this);
                    while (NextPlayer == 2)
                    {
                        Console.WriteLine("You got an extra turn! make a move..");
                        bin_id = Convert.ToInt32(Console.ReadLine());
                        MakeMove(bin_id);
                        Console.WriteLine("You choose {0}, the result is :", bin_id);
                        Console.WriteLine(this);
                    }
                }
                else
                {
                    Console.WriteLine("My turn, let me make a move..");
                    int choice = Agent.TakeTurn(this);
                    Console.WriteLine("I choose {0}, the result is :", choice);
                    Console.WriteLine(this);
                    while (NextPlayer == 1)
                    {
                        Console.WriteLine("I got an extra turn! :p let me make a move..");
                        choice = Agent.TakeTurn(this);
                        Console.WriteLine("I choose {0}, the result is :", choice);
                        Console.WriteLine(this);
                    }
                }
            }

            if(Winner == 1) Console.WriteLine("Congrats you won!!..");
            else if(Winner == 2) Console.WriteLine("I won :p");
            else Console.WriteLine("Draw....");
        }
    }
}
