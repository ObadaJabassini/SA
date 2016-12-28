using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    public class IntelligentAgent
    {
        public bool AlphaBeta { private set; get; }
        public int Lookahead { private set; get; }

        public IntelligentAgent(Game.DifficultyLevel level = Game.DifficultyLevel.Meduim, bool alphaBeta = false)
        {
            AlphaBeta = alphaBeta;
            switch (level)
            {
                case Game.DifficultyLevel.Easy:
                    Lookahead = 1;
                    break;
                case Game.DifficultyLevel.Difficult:
                    Lookahead = 3;
                    break;
                default:
                    Lookahead = 4;
                    break;
            }
        }

        private Tuple<int, int> MinMax(Node node, int depth, int player)
        {
            if (depth == Lookahead || node.IsFinal) return new Tuple<int, int>(node.Eval, node.SelectedBin);

            int bestVal = player == 1 ? int.MinValue : int.MaxValue, bestMove = -1;

            node.GenerateChildren();
            foreach (Node n in node.Children)
            {
                int turn = 3 - player;
                if (n.GetExtraTurn) turn = player;
                var newVal = MinMax(n, depth + 1, turn);
                bestVal = player == 1 ? (newVal.Item1 > bestVal ? newVal.Item1 : bestVal) : (newVal.Item1 < bestVal ? newVal.Item1 : bestVal);
                bestMove = newVal.Item1 == bestVal ? n.SelectedBin : bestMove;
            }
            return new Tuple<int, int>(bestVal, bestMove);
        }

        private Tuple<int, int> AlphaBetaMinMax(Node node, int depth, int player, Tuple<int, int> alpha, Tuple<int, int> beta)
        {
            if (depth == Lookahead || node.IsFinal) return new Tuple<int, int>(node.Eval, node.SelectedBin);

            node.GenerateChildren();
            foreach (Node n in node.Children)
            {
                int turn = 3 - player;
                if (n.GetExtraTurn) turn = player;
                var newVal = AlphaBetaMinMax(n, depth + 1, turn, alpha, beta);
                if (player == 1 && newVal.Item1 > alpha.Item1)
                    alpha = new Tuple<int, int>(newVal.Item1, newVal.Item2);
                if (player == 2 && newVal.Item1 < beta.Item1)
                    beta = new Tuple<int, int>(newVal.Item1, newVal.Item2);
                if (alpha.Item1 >= beta.Item1)
                    return player == 1 ? beta : alpha;
            }
            return player == 1 ? alpha : beta;
        }

        public int TakeTurn(Game game)
        {
            int b;
            if (AlphaBeta)
                b =
                    AlphaBetaMinMax(new Node(game), 0, 1, new Tuple<int, int>(int.MinValue, -1),
                        new Tuple<int, int>(int.MaxValue, -1)).Item2;
            else b = MinMax(new Node(game), 0, 1).Item2;
            game.MakeMove(b);
            return b;
        }

    }
}
