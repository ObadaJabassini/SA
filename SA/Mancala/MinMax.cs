using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    class MinMax : IntelligentAgent
    {
        public MinMax(Game.DifficultyLevel level = Game.DifficultyLevel.Meduim) : base(level) { }

        protected override Tuple<int, int> GenerateBestMove(Node node, int depth, int player)
        {
            if (depth == Lookahead || node.IsFinal) return new Tuple<int, int>(node.Eval, node.SelectedBin);

            int bestVal = player == 1 ? int.MinValue : int.MaxValue, bestMove = -1;
            
            node.GenerateChildren();
            foreach (Node n in node.Children)
            {
                int turn = 3 - player;
                if (n.GetExtraTurn) turn = player;
                var newVal = GenerateBestMove(n, depth + 1, turn);
                bestVal = player == 1 ? (newVal.Item1 > bestVal ? newVal.Item1 : bestVal) : (newVal.Item1 < bestVal ? newVal.Item1 : bestVal);
                bestMove = newVal.Item1 == bestVal ? n.SelectedBin : bestMove;
            }
            return new Tuple<int, int>(bestVal, bestMove);
        }
    }
}
