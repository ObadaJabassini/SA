using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    class AlphaBetaMinMax : MinMax
    {
        private Tuple<int, int> _alpha = new Tuple<int, int>(int.MinValue, -1), _beta = new Tuple<int, int>(int.MaxValue, -1);

        public AlphaBetaMinMax(Game.DifficultyLevel level = Game.DifficultyLevel.Meduim) : base(level) { }

        protected override Tuple<int, int> GenerateBestMove(Node node, int depth, int player)
        {
            if (depth == Lookahead || node.IsFinal) return new Tuple<int, int>(node.Eval, node.SelectedBin);

            node.GenerateChildren();
            foreach (Node n in node.Children)
            {
                int turn = 3 - player;
                if (n.GetExtraTurn) turn = player;
                var newVal = GenerateBestMove(n, depth + 1, turn);
                if (player == 1 && newVal.Item1 >= _alpha.Item1)
                    _alpha = new Tuple<int, int>(newVal.Item1, newVal.Item2);
                if (player == 2 && newVal.Item1 <= _beta.Item1)
                    _beta = new Tuple<int, int>(newVal.Item1, newVal.Item2);
                if (_alpha.Item1 >= _beta.Item1)
                    return player == 1 ? _beta : _alpha;
            }
            return player == 1 ? _alpha : _beta;
        }
    }
}
