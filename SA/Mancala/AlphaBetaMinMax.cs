using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    class AlphaBetaMinMax : MinMax
    {
        private int _alpha = int.MinValue, _beta = int.MaxValue;

        public AlphaBetaMinMax(Game.DifficultyLevel level = Game.DifficultyLevel.Meduim) : base(level) { }

        protected bool _cutOff() => _alpha >= _beta;

        protected void _setAdditionalParams(int val, int player)
        {
            _alpha = player == 1 && val > _alpha ? val : _alpha;
            _beta  = player == 2 && val < _beta ? val : _beta;
        }

    }
}
