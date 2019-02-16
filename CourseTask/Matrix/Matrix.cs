using System;
using VectorTask;

namespace Matrix
{
    class Matrix
    {
        private Vector[] Rows { get; set; }

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentException("Rows count must be > 0", nameof(rowsCount));
            }

            int rows = rowsCount;
            Rows = new Vector[rows];
            for (int i = 0; i < rows; i++)
            {
                Rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            int rows = matrix.GetRowsCount();
            Rows = new Vector[rows];
            for (int i = 0; i < rows; i++)
            {
                Rows[i] = new Vector(matrix.Rows[i]);
            }
        }

        public Matrix(double[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            if (columns <= 0)
            {
                throw new ArgumentException("Columns must be > 0", nameof(array));
            }

            Rows = new Vector[rows];
            double[] line = new double[columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    line[j] = array[i, j];
                }
                Rows[i] = new Vector(line);
            }
        }

        public Matrix(Vector[] vector)
        {
            int rows = vector.Length;

            if (rows <= 0)
            {
                throw new ArgumentException("Array vectors must be > 0", nameof(vector));
            }

            Vector[] copy = new Vector[rows];
            Array.Copy(vector, copy, rows);

            Vector maxColumns = copy[0];
            for (int j = 1; j < rows; j++)
            {
                if (maxColumns.GetSize() < copy[j].GetSize())
                {
                    maxColumns = copy[j];
                }
            }

            Rows = new Vector[rows];
            for (int i = 0; i < rows; i++)
            {
                Vector aligmentVector = new Vector(vector[i]);
                aligmentVector.VectorAligment(maxColumns);
                Rows[i] = new Vector(aligmentVector);
            }
        }

        public int GetRowsCount()
        {
            return Rows.Length;
        }

        public int GetColumnsCount()
        {
            return Rows[0].GetSize();
        }

        public Vector GetLine(int index)
        {
            if ((index < 0) || (index >= Rows.Length))
            {
                throw new ArgumentOutOfRangeException("Index must be range [0; Matrix Line count - 1]", nameof(index));
            }
            return new Vector(Rows[index]);
        }

        public void SetLine(int index, Vector vector)
        {
            if ((index < 0) || (index >= GetRowsCount()))
            {
                throw new IndexOutOfRangeException("Index must be >= 0 and <= rows count");
            }

            if (Rows[0].GetSize() < vector.GetSize())
            {
                throw new ArgumentException("Vector size must be <= columns count", nameof(vector));
            }

            Vector aligmentVector = new Vector(vector);
            Rows[index] = new Vector(aligmentVector);
        }

        public Vector GetColumn(int index)
        {
            if ((index < 0) || (index >= GetColumnsCount()))
            {
                throw new IndexOutOfRangeException("Index must be range >= 0 and <= rows count");
            }
            double[] copyValue = new double[Rows.Length];
            for (int i = 0; i < Rows.Length; i++)
            {
                copyValue[i] = Rows[i].GetComponent(index);
            }
            return new Vector(copyValue);
        }

        public void Transposition()
        {
            int columsCount = GetColumnsCount();
            int rowsCount = GetRowsCount();

            Vector[] copy = new Vector[rowsCount];
            Array.Copy(Rows, copy, rowsCount);

            Rows = new Vector[columsCount];

            for (int k = 0; k < columsCount; k++)
            {
                Rows[k] = new Vector(rowsCount);
            }

            for (int i = 0; i < rowsCount; i++)
            {
                Vector line = copy[i];
                for (int j = 0; j < columsCount; j++)
                {
                    Rows[j].SetComponent(i, copy[i].GetComponent(j));
                }
            }
        }

        public void Multiplication(int value)
        {
            foreach (Vector vector in Rows)
            {
                vector.Multiplication(value);
            }
        }

        public double GetDeterminant()
        {
            Vector[] copy = new Vector[GetRowsCount()];
            Array.Copy(Rows, copy, GetRowsCount());
            double resultMultiplication = 1;

            for (int i = 0; i < GetColumnsCount(); i++)
            {
                for (int j = i + 1; j < GetColumnsCount(); j++)
                {
                    double value2 = copy[i].GetComponent(i);

                    if (value2 == 0)
                    {
                        int rowMaxValue = 0;
                        for (int t = 1; t < GetRowsCount(); t++)
                        {
                            if (Math.Abs(copy[t - 1].GetComponent(i)) < Math.Abs(copy[t].GetComponent(i)))
                            {
                                rowMaxValue = t;
                            }
                        }
                        Vector temp = new Vector(copy[i]);
                        copy[i] = copy[rowMaxValue];
                        copy[rowMaxValue] = temp;
                        value2 = copy[i].GetComponent(i);
                        resultMultiplication *= -1;
                    }

                    Vector vector = new Vector(copy[i]);
                    double value1 = -copy[j].GetComponent(i);

                    double value = value1 / value2;
                    copy[i].Multiplication(value);
                    copy[j].Sum(copy[i]);
                    copy[i] = vector;
                }
            }

            for (int i = 0; i < GetColumnsCount(); i++)
            {
                resultMultiplication *= copy[i].GetComponent(i);
            }
            return resultMultiplication;
        }

        public Vector MatrixOnVectorMultiplication(Vector vector)
        {
            int columns = vector.GetSize();
            double[] value = new double[columns];
            for (int i = 0; i < columns; i++)
            {
                value[i] = Vector.ScalarMultiplication(vector, GetColumn(i));
            }
            return new Vector(value);
        }

        public void Sum(Matrix matrix)
        {
            int currentRowsCount = GetRowsCount();
            int rowsCount = matrix.GetRowsCount();

            int currentColumnsCount = GetColumnsCount();
            int columnsCount = matrix.GetColumnsCount();

            if (rowsCount != currentRowsCount)
            {
                throw new ArgumentOutOfRangeException("Matrix rows must match", nameof(matrix));
            }

            if (columnsCount != currentColumnsCount)
            {
                throw new ArgumentOutOfRangeException("Matrix columns must match", nameof(matrix));
            }

            for (int j = 0; j < GetRowsCount(); j++)
            {
                Rows[j].Sum(matrix.Rows[j]);
            }
        }

        public void Difference(Matrix matrix)
        {
            int currentRowsCount = GetRowsCount();
            int rowsCount = matrix.GetRowsCount();

            int currentColumnsCount = GetColumnsCount();
            int columnsCount = matrix.GetColumnsCount();

            if (rowsCount != currentRowsCount)
            {
                throw new ArgumentOutOfRangeException("Matrix rows must match", nameof(matrix));
            }

            if (columnsCount != currentColumnsCount)
            {
                throw new ArgumentOutOfRangeException("Matrix columns must match", nameof(matrix));
            }

            for (int j = 0; j < GetRowsCount(); j++)
            {
                Rows[j].Difference(matrix.Rows[j]);
            }
        }

        public static Matrix Sum(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetRowsCount() != secondMatrix.GetRowsCount())
            {
                throw new ArgumentOutOfRangeException("Matrix rows must match");
            }

            if (firstMatrix.GetColumnsCount() != secondMatrix.GetColumnsCount())
            {
                throw new ArgumentOutOfRangeException("Matrix columns must match");
            }

            Matrix matrix = new Matrix(firstMatrix);
            matrix.Sum(secondMatrix);
            return matrix;
        }

        public static Matrix Difference(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetRowsCount() != secondMatrix.GetRowsCount())
            {
                throw new ArgumentOutOfRangeException("Matrix rows must match");
            }

            if (firstMatrix.GetColumnsCount() != secondMatrix.GetColumnsCount())
            {
                throw new ArgumentOutOfRangeException("Matrix columns must match");
            }

            Matrix matrix = new Matrix(firstMatrix);
            matrix.Difference(secondMatrix);
            return matrix;
        }

        public static Matrix Multiplication(Matrix firstMatrix, Matrix secondMatrix)
        {
            if ((firstMatrix.GetColumnsCount() != secondMatrix.GetRowsCount()) && (firstMatrix.GetRowsCount() != secondMatrix.GetColumnsCount()))
            {
                throw new Exception("Columns count 1 matrix must be equals rows count 2 matrix and rows count 1 matrix must be equals columns count 2 matrix");
            }

            Matrix matrix = new Matrix(firstMatrix.GetRowsCount(), secondMatrix.GetColumnsCount());
            double[] value = new double[matrix.GetColumnsCount()];
            for (int i = 0; i < matrix.GetRowsCount(); i++)
            {
                for (int j = 0; j < matrix.GetColumnsCount(); j++)
                {
                    value[j] = Vector.ScalarMultiplication(firstMatrix.Rows[i], secondMatrix.GetColumn(j));
                }
                matrix.Rows[i] = new Vector(value);
            }
            return matrix;
        }

        public override string ToString()
        {
            int length = GetRowsCount();
            string strVector = "{ ";
            for (int i = 0; i < length - 1; i++)
            {
                strVector += Rows[i].ToString() + ", ";
            }
            strVector += Rows[length - 1].ToString() + " }";
            return strVector;
        }
    }
}
