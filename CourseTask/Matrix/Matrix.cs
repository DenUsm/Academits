using System;
using System.Text;
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
            double[] row = new double[columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    row[j] = array[i, j];
                }
                Rows[i] = new Vector(row);
            }
        }

        public Matrix(Vector[] vectors)
        {
            int rows = vectors.Length;

            if (rows <= 0)
            {
                throw new ArgumentException("Array vectors count must be > 0", nameof(vectors));
            }

            int maxColumns = vectors[0].GetSize();
            for (int j = 1; j < rows; j++)
            {
                if (maxColumns < vectors[j].GetSize())
                {
                    maxColumns = vectors[j].GetSize();
                }
            }

            Rows = new Vector[rows];
            for (int i = 0; i < rows; i++)
            {
                Vector alignmentVector = new Vector(vectors[i]);
                alignmentVector.MakeAlignment(maxColumns);
                Rows[i] = alignmentVector;
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

        public Vector GetRow(int index)
        {
            if ((index < 0) || (index >= Rows.Length))
            {
                throw new IndexOutOfRangeException("Index must be >= 0 and <= rows count");
            }
            return new Vector(Rows[index]);
        }

        public void SetRow(int index, Vector vector)
        {
            if ((index < 0) || (index >= GetRowsCount()))
            {
                throw new IndexOutOfRangeException("Index must be >= 0 and <= rows count");
            }

            if (GetColumnsCount() != vector.GetSize())
            {
                throw new ArgumentException("Vector size must be <= columns count", nameof(vector));
            }

            Rows[index] = new Vector(vector);
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
            Vector[] arrayRows = new Vector[columsCount];

            for (int i = 0; i < columsCount; i++)
            {
                arrayRows[i] = GetColumn(i);
            }

            Rows = arrayRows;
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
            if (GetColumnsCount() != GetRowsCount())
            {
                throw new ArgumentException("Matrix must be square");
            }

            Vector[] copy = new Vector[GetRowsCount()];
            Array.Copy(Rows, copy, GetRowsCount());
            double resultMultiplication = 1;
            double epsilon = 1.0e-10;

            for (int i = 0; i < GetColumnsCount(); i++)
            {
                for (int j = i + 1; j < GetColumnsCount(); j++)
                {
                    double value2 = copy[i].GetComponent(i);

                    if ((value2 <= epsilon) || (value2 >= -epsilon))
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

                        if ((value2 <= epsilon) || (value2 >= -epsilon))
                        {
                            break;
                        }

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
            if (GetColumnsCount() != vector.GetSize())
            {
                throw new ArgumentException("Vector must be <= columns count", nameof(vector));
            }

            double[] value = new double[GetRowsCount()];
            for (int i = 0; i < GetRowsCount(); i++)
            {
                value[i] = Vector.ScalarMultiplication(vector, Rows[i]);
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
                throw new ArgumentException("Matrix rows must be match", nameof(matrix));
            }

            if (columnsCount != currentColumnsCount)
            {
                throw new ArgumentException("Matrix columns must be match", nameof(matrix));
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
                throw new ArgumentException("Matrix rows must be match", nameof(matrix));
            }

            if (columnsCount != currentColumnsCount)
            {
                throw new ArgumentException("Matrix columns must be match", nameof(matrix));
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
                throw new Exception("Matrix rows must be match");
            }

            if (firstMatrix.GetColumnsCount() != secondMatrix.GetColumnsCount())
            {
                throw new Exception("Matrix columns must be match");
            }

            Matrix matrix = new Matrix(firstMatrix);
            matrix.Sum(secondMatrix);
            return matrix;
        }

        public static Matrix Difference(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetRowsCount() != secondMatrix.GetRowsCount())
            {
                throw new Exception("Matrix rows must be match");
            }

            if (firstMatrix.GetColumnsCount() != secondMatrix.GetColumnsCount())
            {
                throw new Exception("Matrix columns must be match");
            }

            Matrix matrix = new Matrix(firstMatrix);
            matrix.Difference(secondMatrix);
            return matrix;
        }

        public static Matrix Multiplication(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetColumnsCount() != secondMatrix.GetRowsCount())
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
            StringBuilder str = new StringBuilder();
            int length = GetRowsCount();
            str.Append("{ ");
            for (int i = 0; i < length - 1; i++)
            {
                str.Append(Rows[i].ToString());
                str.Append(", ");
            }
            str.Append(Rows[length - 1].ToString());
            str.Append(" }");
            return str.ToString();
        }
    }
}
