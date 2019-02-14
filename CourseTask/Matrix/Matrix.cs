using System;
using VectorTask;

namespace Matrix
{
    class Matrix
    {
        private Vector[] Vectors { get; set; }

        public Matrix(int n, int m)
        {
            int legth = n;
            Vectors = new Vector[legth];
            for (int i = 0; i < legth; i++)
            {
                Vectors[i] = new Vector(m);
            }
        }

        public Matrix(Matrix matrix)
        {
            int length = matrix.GetN();
            Vectors = new Vector[length];
            for (int i = 0; i < length; i++)
            {
                Vectors[i] = new Vector(matrix.Vectors[i]);
            }
        }

        public Matrix(double[,] array)
        {
            int lengthWigth = array.GetLength(0);
            int lengthHeight = array.GetLength(1);

            Vectors = new Vector[lengthWigth];
            double[] line = new double[lengthHeight];

            for (int i = 0; i < lengthWigth; i++)
            {
                for (int j = 0; j < lengthHeight; j++)
                {
                    line[j] = array[i, j];
                }
                Vectors[i] = new Vector(line);
            }
        }

        public Matrix(Vector[] vector)
        {
            int length = vector.Length;
            Vector[] copy = new Vector[length];
            Array.Copy(vector, copy, length);
            Array.Sort(copy, new VectorSizeComparer());

            Vectors = new Vector[length];
            for (int i = 0; i < length; i++)
            {
                Vector aligmentVector = new Vector(vector[i]);
                aligmentVector.VectorAligment(copy[0]);
                Vectors[i] = new Vector(aligmentVector);
            }
        }

        public int GetN()
        {
            return Vectors.Length;
        }

        public int GetM()
        {
            return Vectors[0].GetSize();
        }

        public Vector GetLineVector(int index)
        {
            if ((index < 0) || (index >= Vectors.Length))
            {
                throw new ArgumentOutOfRangeException("Index must be range [0; Matrix Line count - 1]", nameof(index));
            }
            return Vectors[index];
        }

        public void SetLineVector(int index, Vector vector)
        {
            if ((index < 0) || (index >= Vectors.Length))
            {
                throw new ArgumentOutOfRangeException("Index must be range [0; Matrix Line count - 1]", nameof(index));
            }
            Vectors[index] = new Vector(vector);
        }

        public Vector GetColumVector(int index)
        {
            if ((index < 0) || (index >= GetM()))
            {
                throw new ArgumentOutOfRangeException("Index must be range [0; Matrix Line count - 1]", nameof(index));
            }
            double[] copyValue = new double[Vectors.Length];
            for (int i = 0; i < Vectors.Length; i++)
            {
                copyValue[i] = Vectors[i].GetComponent(index);
            }
            return new Vector(copyValue);
        }

        public void Transposition()
        {
            Matrix copy = new Matrix(Vectors);
            Vectors = new Vector[GetM()];

            for (int k = 0; k < Vectors.Length; k++)
            {
                Vectors[k] = new Vector(copy.Vectors.Length);
            }

            for (int i = 0; i < GetM(); i++)
            {
                Vector line = copy.GetLineVector(i);
                for (int j = 0; j < Vectors.Length; j++)
                {
                    Vectors[j].SetComponent(i, copy.Vectors[i].GetComponent(j));
                }
            }
        }

        public void Multiplication(int value)
        {
            foreach (Vector vector in Vectors)
            {
                vector.Multiplication(value);
            }
        }

        public double GetDeterminant()
        {
            for (int i = 0; i < GetM(); i++)
            {
                for (int j = i + 1; j < GetN(); j++)
                {
                    Vector vector = new Vector(Vectors[i]);
                    double value = -Vectors[j].GetComponent(i) / Vectors[i].GetComponent(i);
                    Vectors[i].Multiplication(value);
                    Vectors[j].Sum(Vectors[i]);
                    Vectors[i] = vector;
                }
            }

            double resultMultiplication = 0;
            for (int i = 0; i < GetN(); i++)
            {

            }
            return 1;
        }

        public void MatrixOnVectorMultiplication(Vector vector)
        {
            int length = vector.GetSize();
            double[] value = new double[length];
            for (int i = 0; i < length; i++)
            {
                value[i] = Vector.ScalarMultiplication(vector, GetColumVector(i));
            }
            Vectors = new Vector[] { new Vector(value) };
        }

        public void Sum(Matrix matrix)
        {
            int currentLength = Vectors.Length;
            int length = matrix.Vectors.Length;

            if (length != currentLength)
            {
                throw new ArgumentOutOfRangeException("Parameter N by matrices must be equals", nameof(matrix.Vectors.Length));
            }
            for (int j = 0; j < Vectors.Length; j++)
            {
                Vectors[j].Sum(matrix.Vectors[j]);
            }
        }

        public void Difference(Matrix matrix)
        {
            int currentLength = Vectors.Length;
            int length = matrix.Vectors.Length;

            if (length != currentLength)
            {
                throw new ArgumentOutOfRangeException("Parameter N by matrices must be equals", nameof(matrix.Vectors.Length));
            }
            for (int j = 0; j < Vectors.Length; j++)
            {
                Vectors[j].Difference(matrix.Vectors[j]);
            }
        }

        public static Matrix Sum(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix matrix = new Matrix(firstMatrix);
            matrix.Sum(secondMatrix);
            return matrix;
        }

        public static Matrix Difference(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix matrix = new Matrix(firstMatrix);
            matrix.Difference(secondMatrix);
            return matrix;
        }

        public static Matrix Multiplication(Matrix firstMatrix, Matrix secondMatrix)
        {
            int columsCount = Math.Max(firstMatrix.GetM(), secondMatrix.GetM());
            int rowsCount = Math.Max(firstMatrix.Vectors.Length, secondMatrix.Vectors.Length);

            if (columsCount != rowsCount)
            {
                throw new Exception("Colums count first matrix must be equals rows count second matrix");
            }

            Matrix matrix = new Matrix(rowsCount, columsCount);
            double[] value = new double[columsCount];
            for (int i = 0; i < matrix.GetN(); i++)
            {
                for (int j = 0; j < matrix.GetM(); j++)
                {
                    value[j] = Vector.ScalarMultiplication(firstMatrix.Vectors[i], secondMatrix.GetColumVector(j));
                }
                matrix.Vectors[i] = new Vector(value);
            }
            return matrix;
        }

        public override string ToString()
        {
            int length = Vectors.Length;
            string[] strVectors = new string[length];
            for (int i = 0; i < length; i++)
            {
                strVectors[i] = Vectors[i].ToString();
            }
            return "{ " + string.Join(", ", strVectors) + " }";
        }
    }
}
