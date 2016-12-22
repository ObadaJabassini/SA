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

        protected bool _cutOff() => false;
        protected void _setAdditionalParams(int val, int player) { }

        protected override Node GenerateBestMove(Node node, int depth, int player)
        {
            if (depth == Lookahead || node.IsFinal) return node;

            Node bestNode = player == 1
                ? new Node(new Game(new[] { int.MinValue, int.MaxValue }))
                : new Node(new Game(new[] { int.MaxValue, int.MinValue }));

            node.GenerateChildren();
            foreach (Node n in node.Children)
            {
                int turn = 3 - player;
                if (n.GetExtraTurn) turn = player;
                Node newN = GenerateBestMove(n, depth + 1, turn);
                _setAdditionalParams(newN.Eval, turn);
                if(_cutOff()) break;
                bestNode = player == 1 ? (newN > bestNode ? newN : bestNode) : (newN < bestNode ? newN : bestNode);
            }
            return bestNode;
        }
    }
}
