using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut
{
    public class Board : ICloneable
    {
        private BitArray _game;
        private int _rows;
        private int _cols;
        private int to1D(int v, int q) => v * _rows + q;

        public Board(int[,] game)
        {
            _rows = game.GetLength(0);
            _cols = game.GetLength(1);
            _game = new BitArray(_rows * _cols);
            int index = 0;
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _game[index++] = game[i, j] == 1;
                }
            }
        }

        public Board(bool[,] game)
        {
            _rows = game.GetLength(0);
            _cols = game.GetLength(1);
            _game = new BitArray(_rows * _cols);
            int index = 0;
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _game[index++] = game[i, j];
                }
            }
        }

        public Board(BitArray arr)
        {
            this._game = arr;
        }
        private bool _isValid(int i, int j) => i >= 0 && j >= 0 && i < _rows && j < _cols;
        public void Click(int i, int j)
        {
            var index = to1D(i, j);
             _game[index] = !_game[index];
            if (_isValid(i + 1, j))
            {
                index = to1D(i + 1, j);
                _game[index] = !_game[index];
            }
            if (_isValid(i - 1, j))
            {
                index = to1D(i - 1, j);
                _game[index] = !_game[index];
            }
            if (_isValid(i, j + 1))
            {
                index = to1D(i, j + 1);
                _game[index] = !_game[index];
            }
            if (_isValid(i, j - 1))
            {
                index = to1D(i, j - 1);
                _game[index] = !_game[index];
            }
        }

        public bool this[int i, int j]
        {
            get
            {
                return _game[to1D(i, j)];
            }
            set
            {
                _game[to1D(i, j)] = value;
            }
        }

        public bool IsFinal()
        {
            for (int i = 0; i < _game.Count; i++)
            {
                if (_game[i])
                    return false;
            }
            return true;
        }

        public double Evaluation()
        {
            int res = 0;
            for (int i = 0; i < _game.Count; i++)
            {
                if (_game[i])
                    res++;
            }
            return res / 5;
        }

        public object Clone()
        {
            BitArray arr = new BitArray(_rows * _cols);
            for (int i = 0; i < _game.Count; i++)
            {
                arr[i] = _game[i];
            }
            var b = new Board(arr);
            b._cols = this._cols;
            b._rows = this._rows;
            return b;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as Board;
            for (int i = 0; i < _game.Count; i++)
            {
                if (_game[i] != t._game[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int res = 17;
            for (int i = 0; i < _game.Count; i++)
            {
                res = res * 31 + (_game[i] ? 1 : 0) * (i + 100);
            }
            return res;
        }

        public int GetLength(int ii)
        {
            return ii == 0 ? _rows : _cols;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    builder.Append(_game[to1D(i, j)] ? "ON":"OFF").Append(" ");
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
