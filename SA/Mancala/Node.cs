using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    class Node
    {
        private Game _thisGame;
        public IList<Node> Children { get; private set; }
        public Node Parent { get; set; }
        public IList<Node> Parents { get { IList<Node> nn = new List<Node>(); Node temp = Parent; while (temp != null) nn.Add(temp); var t = nn.Reverse(); var tt = t.ToList(); tt.Insert(0, this); return tt; } }
        public int Eval => _thisGame.Mancalas[0] - _thisGame.Mancalas[1];
        public bool IsFinal => _thisGame.IsGameOver;
        public int SelectedBin { private set; get; }
        public bool GetExtraTurn { private set; get; }

        public Node(Game game)
        {
            _thisGame = new Game(game);
        }

        public Node() { }

        public IList<Node> GenerateChildren()
        {
            Children = new List<Node>();
            for (int i = 0; i < 6; i++)
            {
                Game newGame = new Game(_thisGame);
                newGame.MakeMove(i);
                Children.Add(new Node(newGame)
                {
                    Parent = this,
                    SelectedBin = i,
                    GetExtraTurn = _thisGame.NextPlayer == newGame.NextPlayer
                });
            }

            return Children;
        }

        public static bool operator <(Node n1, Node n2)
        {
            return n1.Eval < n2.Eval;
        }

        public static bool operator >(Node n1, Node n2)
        {
            return n1.Eval > n2.Eval;
        }

    }
}
