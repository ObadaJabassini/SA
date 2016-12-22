using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LightsOut.LineraAlgebra
{
    class MMatrix
    {
        private int[][] values;
        public int[][] bVector;

        public MMatrix(int rows, int cols)
        {
            values = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                values[i] = new int[cols];
            }
            bVector = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                bVector[i] = new int[1];
            }
        }

        public int rowCount()
        {
            return values.Length;
        }
        public int columnCount()
        {
            return values[0].Length;
        }

        public int get(int row, int col)
        {
            return values[row][col];
        }

        public int getBVector(int row, int col)
        {
            return bVector[row][col];
        }

        public void set(int row, int col, int val)
        {
            values[row][col] = val;
        }

        public void setBVector(int row, int col, int val)
        {
            bVector[row][0] = val;
        }

        public MMatrix clone()
        {
            int rows = rowCount();
            int cols = columnCount();
            var result = new MMatrix(rows, cols);
            for (int i = 0; i < rowCount(); i++)
            {
                for (int j = 0; j < columnCount(); j++)
                {
                    result.values[i][j] = values[i][j];
                }
            }
            return result;
        }

        public void swapRows(int row0, int row1)
        {
            int[] temp = values[row0];
            values[row0] = values[row1];
            values[row1] = temp;
            // change identity matrix
            int[] temp2 = bVector[row0];
            bVector[row0] = bVector[row1];
            bVector[row1] = temp2;
        }

        public void multiplyRow(int row, int factor)
        {
            for (int j = 0, cols = columnCount(); j < cols; j++)
            {
                set(row, j, (get(row, j) * factor) % 2);
            }
            setBVector(row, 0, (getBVector(row, 0) * factor) % 2);
        }

        public void addRows(int srcRow, int destRow, int factor)
        {
            for (int j = 0, cols = columnCount(); j < cols; j++)
            {
                set(destRow, j, (get(destRow, j) + (get(srcRow, j) * factor) % 2) % 2);
            }
            setBVector(destRow, 0, (getBVector(destRow, 0) + (getBVector(srcRow, 0) * factor) % 2) % 2);
        }

        public MMatrix multiply(MMatrix other)
        {
            int rows = rowCount();
            int cols = other.columnCount();
            int cells = columnCount();
            var result = new MMatrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cells; k++)
                        sum = (sum + (get(i, k) * other.get(k, j)) % 2) % 2;
                    result.set(i, j, sum);
                }
            }
            return result;
        }

        public void reducedRowEchelonForm()
        {
            Func<int, int, int> reciprocal = (x, n) =>
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    if ((x * i) % n == 1)
                    {
                        return i;
                    }
                }
                return 0;
            };
            int rows = rowCount();
            int cols = columnCount();

            int numPivots = 0;
            for (int j = 0; j < cols; j++)
            {
                int pivotRow = numPivots;
                while (pivotRow < rows && get(pivotRow, j) == 0)
                    pivotRow++;
                if (pivotRow == rows)
                    continue;

                swapRows(numPivots, pivotRow);
                pivotRow = numPivots;
                numPivots++;
                multiplyRow(pivotRow, reciprocal(get(pivotRow, j), 2)); 

                for (int i = pivotRow + 1; i < rows; i++)

                    addRows(pivotRow, i, get(i, j) % 2);
            }

            for (int i = rows - 1; i >= 0; i--)
            {
                int pivotCol = 0;
                while (pivotCol < cols && get(i, pivotCol) == 0)
                    pivotCol++;
                if (pivotCol == cols)
                    continue;
                for (int j = i - 1; j >= 0; j--)
                {

                    addRows(i, j, get(j, pivotCol) % 2);
                }
            }
        }

        public int[][] getBVector()
        {
            return bVector;
        }
    }
}
