using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut
{
    public class Board : ICloneable
    {
        public int[,] Game { get; set; }
        private bool _isValid(int i, int j) => i >= 0 && j >= 0 && i < Game.GetLength(0) && j < Game.GetLength(1);
        public void Click(int i, int j)
        {
             Game[i, j] ^= 1;
            if (_isValid(i + 1, j))
                Game[i + 1, j] ^= 1;
            if (_isValid(i - 1, j))
                Game[i - 1, j] ^= 1;
            if (_isValid(i, j + 1))
                Game[i, j + 1] ^= 1;
            if (_isValid(i, j - 1))
                Game[i, j - 1] ^= 1;
        }

        public int this[int i, int j]
        {
            get
            {
                return Game[i, j];
            }
            set
            {
                Game[i, j] = value;
            }
        }

        public bool IsFinal()
        {
            for (int i = 0; i < Game.GetLength(0); i++)
            {
                for (int j = 0; j < Game.GetLength(1); j++)
                {
                    if (Game[i, j] == 1)
                        return false;
                }
            }
            return true;
        }

        public double Evaluation()
        {
            int res = 0;
            for (int i = 0; i < Game.GetLength(0); i++)
            {
                for (int j = 0; j < Game.GetLength(1); j++)
                {
                    if (Game[i, j] == 1)
                        ++res;
                }
            }
            return res / 5;
        }

        public object Clone()
        {
            int r = Game.GetLength(0), c = Game.GetLength(1);
            int[,] res = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    res[i, j] = Game[i, j];
                }
            }
            return new Board() { Game = res};
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as Board;
            for (int i = 0; i < Game.GetLength(0); i++)
            {
                for (int j = 0; j < Game.GetLength(1); j++)
                {
                    if (Game[i, j] != t.Game[i, j])
                        return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int res = 17;
            for (int i = 0; i < Game.GetLength(0); i++)
            {
                for (int j = 0; j < Game.GetLength(1); j++)
                {
                    res = res * 31 + Game[i, j] * (i + 150) * (j + 200);
                }
            }
            return res;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Game.GetLength(0); i++)
            {
                for (int j = 0; j < Game.GetLength(1); j++)
                {
                    builder.Append(Game[i, j]).Append(" ");
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
