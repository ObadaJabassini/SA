using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Mancala
{
    public class Node
    {
        private Game _thisGame;
        public IList<Node> Children { get; private set; }
        public Node Parent { get; set; }
        public bool IsFinal => _thisGame.IsGameOver;
        public int SelectedBin { private set; get; }
        public bool GetExtraTurn { private set; get; }
        public int Eval
        {
            get
            {
                switch (_thisGame.Level)
                {
                    case Game.DifficultyLevel.Easy:
                        return H2;
                    case Game.DifficultyLevel.Meduim:
                        return H2 + H3;
                    default:
                        return H1 + H2 + H3;
                }

            }
        }
        private int H1 => _thisGame.Mancalas[0] - _thisGame.Mancalas[1];
        private int H2
        {
            get
            {
                int val = 0;
                var bins = _thisGame.Bins;
                for (int i = 0; i < bins[0].Count; i++)
                {
                    if (bins[0][i] % 13 == i + 1)
                        val++;
                    if (bins[1][i] % 13 == Game.BINS_NUM - i - 1)
                        val--;
                }

                return val;
            }
        }
        private int H3
        {
            get
            {
                int val = 0;
                var bins = _thisGame.Bins;
                for (int i = 0; i < bins[0].Count; i++)
                {
                    if (bins[0][i] == 0 && bins[1][i] > 0)
                    {
                        for (int j = i + 1; j < bins[0].Count; j++)
                        {
                            if (bins[0][j] == j - i)
                            {
                                val++;
                                break;
                            }
                        }

                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (bins[0][j] % 13 == i - j)
                            {
                                val++;
                                break;
                            }
                        }
                    }

                    if (bins[1][i] == 0 && bins[0][i] > 0)
                    {
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (bins[1][j] == i - j)
                            {
                                val--;
                                break;
                            }
                        }

                        for (int j = i + 1; j < bins[1].Count; j++)
                        {
                            if (bins[1][j] % 13 == j - i)
                            {
                                val--;
                                break;
                            }
                        }
                    }
                }

                return val;
            }
        }

        public Node(Game game)
        {
            _thisGame = new Game(game);
        }

        public Node() { }

        public IList<Node> GenerateChildren()
        {
            Children = new List<Node>();
            for (int i = 0; i < Game.BINS_NUM; i++)
            {
                if (_thisGame.Bins[_thisGame.NextPlayer - 1][i] != 0)
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
