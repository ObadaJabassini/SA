using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    class MinMax
    {
        public enum DifficultyLevel { Easy, Meduim, Difficult }
        public DifficultyLevel Level { get; }

        public int Lookahead
        {
            get
            {
                switch (Level)
                {
                        case DifficultyLevel.Easy:
                        return 5;
                        case DifficultyLevel.Difficult:
                        return 50;
                    default:
                        return 25;
                }
            }
        }

        public MinMax(DifficultyLevel level = DifficultyLevel.Meduim)
        {
            Level = level;
        }

        public Node BestMove(Node node, int depth, int player)
        {
            if (depth == Lookahead || node.IsGameOver) return node;

            Node bestNode = player == 1
                ? new Node() {Mancalas = new int[] {Int32.MinValue, Int32.MaxValue}}
                : new Node() {Mancalas = new int[] {Int32.MaxValue, Int32.MinValue}};

            node.GenerateChildren();
            for (int i = 0; i < node.Children.Count; i++)
            {
                Node n = node.Children[i];
                int turn = 3 - player;
                if (n.GetExtraTurn) turn = player;
                Node newN = BestMove(n, depth + 1, turn);
                bestNode = player == 1 ? (newN > bestNode ? newN : bestNode) : (newN < bestNode ? newN : bestNode);
            }
            return bestNode;
        }
    }
}
