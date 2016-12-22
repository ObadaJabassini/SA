using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut.LineraAlgebra
{
    public class Solver
    {
        public Node.State[,] Initial { set; get; }
        private bool _isValid(Node.State[,] m, int i, int j) => i >= 0 && i < m.GetLength(0) && j >= 0 && j < m.GetLength(1);
        private bool _isValid(Matrix<double> m, int i, int j) => i >= 0 && i < m.RowCount && j >= 0 && j < m.ColumnCount;
        private Node.State _flip(Node.State state) => state == Node.State.ON ? Node.State.OFF : Node.State.ON;
        private void _reduce(Matrix<double> d)
        {
            int firstRow = 0;
            Action<Matrix<double>, int, int> swapRows = (m, i, j) =>
            {
                for (int y = 0; y < m.ColumnCount; y++)
                {
                    var t = m[i, y];
                    m[i, y] = m[j, y];
                    m[j, y] = t;
                }
            };
            for (int c = 0; c < d.ColumnCount; c++)
            {
                int nonZeroRow = -1;
                for (int r = firstRow; r < d.RowCount; r++)
                {
                    if (d[r, c] != 0)
                    {
                        nonZeroRow = r;
                        break;
                    }
                }
                if (nonZeroRow == -1)
                    continue;
                swapRows(d, nonZeroRow, firstRow);
                double factor = 1 / d[firstRow, c];
                d.SetRow(firstRow, d.Row(firstRow) * factor);
                Action<Matrix<double>, int, int, double> tt = (mm, row1, row2, fact) =>
                {
                    for (int cc = 0; cc < mm.ColumnCount; cc++)
                    {
                        d[row2, cc] += d[row1, cc] * factor;
                    }
                };
                for (int r = 0; r < d.RowCount; r++)
                {
                    if (r == firstRow)
                        continue;
                    if (d[r, c] != 0)
                    {
                        double multFactor = -d[r, c] / d[firstRow, c];
                        tt(d, firstRow, r, multFactor);
                    }
                }
                firstRow++;
            }
        }

        private Matrix<double>[] _createRow(int index, Matrix<double> O, Matrix<double> I, Matrix<double> B)
        {
            IList<Matrix<double>> list = new List<Matrix<double>>();
            if(index == 0)
            {
                list.Add(B);
                list.Add(I);
                for (int i = 0; i < Initial.GetLength(1) - 2; i++)
                {
                    list.Add(O);
                }
                return list.ToArray();
            }
            if(index == Initial.GetLength(0))
            {
                for (int i = 0; i < Initial.GetLength(1) - 2; i++)
                {
                    list.Add(O);
                }
                list.Add(I);
                list.Add(B);
                return list.ToArray();
            }
            for (int i = 1; i <= index - 1; i++)
            {
                list.Add(O);
            }
            list.Add(I);
            list.Add(B);
            list.Add(I);
            for (int i = 1; i < Initial.GetLength(1) - index - 2; i++)
            {
                list.Add(O);
            }
            return list.ToArray();
        }

        public IList<Node> Solve()
        {
            int r = Initial.GetLength(0), c = Initial.GetLength(1);
            Matrix<double> O = Matrix<double>.Build.Dense(r, c, 0),
                           I = Matrix<double>.Build.DenseDiagonal(r, c, 1),
                           B = Matrix<double>.Build.Dense(r, c, 0);
            for (int i = 0; i < r; i++)
            {
                B[i, i] = 1;
                if (_isValid(B, i + 1, i))
                    B[i + 1, i] = 1;
                if (_isValid(B, i, i + 1))
                    B[i, i + 1] = 1;
            }
            IList<Matrix<double>[]> list = new List<Matrix<double>[]>();
            for (int i = 0; i < r; i++)
            {
                list.Add(_createRow(i, O, I, B));
            }
            var A = Matrix<double>.Build.DenseOfMatrixArray(_createRectangularArray(list));
            var copy = Matrix<double>.Build.DenseOfMatrix(A);
            _reduce(A);
            Matrix<double> R = copy * A.Inverse();
            var result = Matrix<int>.Build.Dense(r, c, 0);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0;  j < c;  j++)
                {
                    result[i, j] = (int)(Math.Round(R[i, j]) * (Initial[i, j] == Node.State.ON ? 1 : 0));
                }
            }
            IList<Node> nodes = new List<Node>();
            var last = new Node() { Board = Initial };
            nodes.Add(last);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if(result[i, j] == 1)
                    {
                        var b = last.Board.Clone() as Node.State[,];
                        _click(b, i, j);
                        var node = new Node() { Board = b };
                        nodes.Add(node);
                        last = node;
                    }
                }
            }
            return nodes;
        }

        public void _click(Node.State[,] b, int i, int j)
        {
            b[i, j] = _flip(b[i, j]);
            if (_isValid(b, i - 1, j))
                b[i - 1, j] = _flip(b[i - 1, j]);
            if (_isValid(b, i + 1, j))
                b[i + 1, j] = _flip(b[i + 1, j]);
            if (_isValid(b, i, j - 1))
                b[i, j - 1] = _flip(b[i, j - 1]);
            if (_isValid(b, i, j + 1))
                b[i, j + 1] = _flip(b[i, j + 1]);
        }

        private T[,] _createRectangularArray<T>(IList<T[]> arrays)
        {
            int minorLength = arrays[0].Length;
            T[,] ret = new T[arrays.Count, minorLength];
            for (int i = 0; i < arrays.Count; i++)
            {
                var array = arrays[i];
                if (array.Length != minorLength)
                {
                    throw new ArgumentException
                        ("All arrays must be the same length");
                }
                for (int j = 0; j < minorLength; j++)
                {
                    ret[i, j] = array[j];
                }
            }
            return ret;
        }
    }
}
