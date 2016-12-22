using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    class Game
    {
        public enum DifficultyLevel { Easy, Meduim, Difficult }
        private IList<int>[] _bins;
        public IList<int>[] Bins => _bins.Clone() as IList<int>[];
        private int[] _mancals;
        public int[] Mancalas => _mancals.Clone() as int[];
        public int NextPlayer { private set; get; } = 2;
        public bool IsGameOver => Bins.All(e => e.All(c => c == 0));
        public DifficultyLevel Level { get; }
        public IntelligentAgent Agent { set; get; }

        public Game(DifficultyLevel l = DifficultyLevel.Meduim)
        {
            _bins = new IList<int>[]
            {
                 Enumerable.Range(0, 6).Select(i => 4).ToList(),
                 Enumerable.Range(0, 6).Select(i => 4).ToList()
            };

            _mancals = new[] {0, 0};

            Level = l;

            Agent = new MinMax(l);
        }

        public Game(int firstPlayer) : this()
        {
            NextPlayer = firstPlayer;
        }

        public Game(Game other)
        {
            _bins = other.Bins;
            _mancals = other.Mancalas;
            NextPlayer = other.NextPlayer;
        }

        public Game(int[] m)
        {
            _mancals = m;
        }

        public void MakeMove(int bin)
        {
            Func<int, int, int> inc_dec = (i, k) => k == 1 ? i + 1 : i - 1;
            Func<int, int, bool> more_less = (i, k) => k == 1 ? i < _bins[0].Count : i > 0;
            Func<int, int> start = (k) => k == 1 ? _bins[1].Count : 0;

            int stones = _bins[NextPlayer - 1][bin], side = NextPlayer, idx = inc_dec(bin, side);
            bool getExtraTurn = false;
            while (stones > 0)
            {
                for (int i = idx; more_less(i, side); i = inc_dec(i, side))
                {
                    _bins[side - 1][i]++;

                    if (side == NextPlayer && stones - 1 == 0)
                    {
                        _bins[side - 1][i] += _bins[3 - side - 1][i];
                        _bins[3 - side - 1][i] = 0;
                    }

                    stones--;
                }

                if (stones <= 0) continue;

                _mancals[side - 1]++;

                if (side == NextPlayer && stones - 1 == 0)
                    getExtraTurn = true;

                stones--;
                idx = start(side);
                side = 3 - side;
            }

            NextPlayer = getExtraTurn ? NextPlayer : 3 - NextPlayer;
        }
    }
}
