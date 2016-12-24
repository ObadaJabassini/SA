using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut.LineraAlgebra
{
    public class Solver : SolutionMethod
    {
        private int _temp = 0;
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

        private double[,] _reduce(double[,] matrix)
        {
            int lead = 0, rowCount = matrix.GetLength(0), columnCount = matrix.GetLength(1);
            for (int r = 0; r < rowCount; r++)
            {
                if (columnCount <= lead) break;
                int i = r;
                while (matrix[i, lead] == 0)
                {
                    i++;
                    if (i == rowCount)
                    {
                        i = r;
                        lead++;
                        if (columnCount == lead)
                        {
                            lead--;
                            break;
                        }
                    }
                }
                for (int j = 0; j < columnCount; j++)
                {
                    int temp = (int)matrix[r, j];
                    matrix[r, j] = matrix[i, j];
                    matrix[i, j] = temp;
                }
                int div = (int)matrix[r, lead];
                if (div != 0)
                    for (int j = 0; j < columnCount; j++) matrix[r, j] /= div;
                for (int j = 0; j < rowCount; j++)
                {
                    if (j != r)
                    {
                        int sub = (int)matrix[j, lead];
                        for (int k = 0; k < columnCount; k++) matrix[j, k] -= (sub * matrix[r, k]);
                    }
                }
                lead++;
            }
            return matrix;
        }

        private Matrix<double>[] _createRow(int index, Matrix<double> O, Matrix<double> I, Matrix<double> B)
        {
            IList<Matrix<double>> list = new List<Matrix<double>>();
            if(index == 0)
            {
                list.Add(B);
                list.Add(I);
                for (int i = 0; i < Initial.Game.GetLength(1) - 2; i++)
                {
                    list.Add(O);
                }
                _temp = list.Count;
                return list.ToArray();
            }
            if(index == Initial.Game.GetLength(0) - 1)
            {
                for (int i = 0; i < Initial.Game.GetLength(1) - 2; i++)
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
            for (int i = 1; i <= Initial.Game.GetLength(1) - index - 2; i++)
            {
                list.Add(O);
            }
            return list.ToArray();
        }

        public override IList<Node> Solve()
        { 
            int r = Initial.Game.GetLength(0), c = Initial.Game.GetLength(1);
            //Matrix<double> O = Matrix<double>.Build.Dense(r, c, 0),
            //               I = Matrix<double>.Build.DenseDiagonal(r, c, 1),
            //               B = Matrix<double>.Build.Dense(r, c, 0);
            //for (int i = 0; i < r; i++)
            //{
            //    B[i, i] = 1;
            //    if (_isValid(B, i + 1, i))
            //        B[i + 1, i] = 1;
            //    if (_isValid(B, i, i + 1))
            //        B[i, i + 1] = 1;
            //}
            //IList<Matrix<double>[]> list = new List<Matrix<double>[]>();
            //for (int i = 0; i < r; i++)
            //{
            //    list.Add(_createRow(i, O, I, B));
            //}
            //var A = Matrix<double>.Build.DenseOfMatrixArray(_createRectangularArray(list));
            //var b = Matrix<double>.Build.Dense(r, c, 0);
            //var copy = Matrix<double>.Build.DenseOfMatrix(A);
            //Console.WriteLine(A);
            ////_reduce(A);
            //A = Matrix<double>.Build.DenseOfArray(_reduce(A.ToArray()));
            //Console.WriteLine(A);
            //var R = copy * A.Inverse();
            //var result = Matrix<double>.Build.Dense(r, c, 0);
            //for (int i = 0; i < r; i++)
            //{
            //    for (int j = 0; j < c; j++)
            //    {
            //        result[i, j] = (int)(Math.Floor(R[i, j]) * (Initial[i, j] == Node.State.ON ? 1 : 0));
            //    }
            //}
            //IList<Node> nodes = new List<Node>();
            //var last = new Node() { Board = Initial };
            //nodes.Add(last);
            //result = result.Map(e => Math.Round(e));
            //for (int i = 0; i < r; i++)
            //{
            //    for (int j = 0; j < c; j++)
            //    {
            //        if (result[i, j] >= 1)
            //        {
            //            var bb = last.Board.Clone() as Node.State[,];
            //            _click(bb, i, j);
            //            var node = new Node() { Board = bb };
            //            nodes.Add(node);
            //            last = node;
            //        }
            //    }
            //}
            //return nodes;
            int[] b = new int[r * c];
            int index = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    b[index++] = Initial[i, j];
                }
            }
            var ASize = r * c;
            var A = new MMatrix(ASize, ASize);
            for (int Arow = 0; Arow < ASize; Arow++)
            {
                for (int Acol = 0; Acol < ASize; Acol++)
                {
                    int i, j, i_, j_ = 0;
                    i = Arow / c; 
                    j = Arow % c;
                    i_ = Acol / c;
                    j_ = Acol % c;
                    if (i_ >= 0 && i_ <= ASize && j_ >= 0 && j_ <= ASize)
                    {
                        if (Math.Abs(i - i_) + Math.Abs(j - j_) <= 1)
                        {
                            A.set(Arow, Acol, 1);
                        }
                        else
                        {
                            A.set(Arow, Acol, 0);
                        }
                    }
                }
            }
            for (int i = 0; i < b.Length; i++)
            {
                A.setBVector(i, 0, b[i]);
            }
            A.reducedRowEchelonForm();
            Func<MMatrix, bool> canBeSolved = (m) =>
            {
                for (int curr_Row = r * c - 1; curr_Row >= 0; curr_Row--)
                { 
                    for (int i = 0; i < r * c; i++)
                    {
                        if (m.get(curr_Row, i) != 0)
                        { 
                            return true;
                        }
                    }
                    if (m.getBVector(curr_Row, 0) != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
            if(canBeSolved(A))
            {
                int[][] solution = new int[r][];
                for (int i = 0; i < r; i++)
                {
                    solution[i] = new int[c];
                }
                for (int i = 0; i < ASize; i++)
                {
                    solution[i / r][i % c] = A.getBVector(i, 0);
                }
                IList<Node> nodes = new List<Node>();
                var last = new Node(new HashSet<Tuple<int, int>>()) { Board = Initial };
                nodes.Add(last);
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        if (solution[i][j] == 1)
                        {
                            var bb = last.Board.Clone() as Board;
                            bb.Click(i, j);
                            var node = new Node(null) { Board = bb };
                            nodes.Add(node);
                            last = node;
                        }
                    }
                }
                return nodes;
            }
            return new List<Node>();
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
