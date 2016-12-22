using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    abstract class IntelligentAgent
    {
        public int Lookahead { private set; get; }

        public IntelligentAgent(Game.DifficultyLevel level)
        {
            switch (level)
            {
                case Game.DifficultyLevel.Easy:
                    Lookahead = 5;
                    break;
                case Game.DifficultyLevel.Difficult:
                    Lookahead = 50;
                    break;
                default:
                    Lookahead = 25;
                    break;
            }
        }

        protected abstract Node GenerateBestMove(Node node, int depth, int player);

        public void TakeTurn(Game game)
        {
            game.MakeMove(GenerateBestMove(new Node(game), 0, 1).SelectedBin);
        }
    }
}
