using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    public abstract class IntelligentAgent
    {
        public int Lookahead { private set; get; }

        public IntelligentAgent(Game.DifficultyLevel level)
        {
            switch (level)
            {
                case Game.DifficultyLevel.Easy:
                    Lookahead = 1;
                    break;
                case Game.DifficultyLevel.Difficult:
                    Lookahead = 3;
                    break;
                default:
                    Lookahead = 2;
                    break;
            }
        }

        protected abstract Tuple<int, int> GenerateBestMove(Node node, int depth, int player);

        public int TakeTurn(Game game)
        {
            int b = GenerateBestMove(new Node(game), 0, 1).Item2;
            game.MakeMove(b);
            return b;
        }
    }
}
