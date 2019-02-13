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
            int legth = matrix.GetN();
            Vectors = new Vector[legth];
            for (int i = 0; i < legth; i++)
            {
                Vectors[i] = new Vector(matrix.Vectors[i]);
            }
        }

        public Matrix(double[,] array)
        {
            int lengthWigth = array.GetLength(0);
            int lengthHeigth = array.GetLength(1);

            Vectors = new Vector[lengthWigth];
            double[] line = new double[lengthHeigth];

            for (int i = 0; i < lengthWigth; i++)
            {
                for (int j = 0; j < lengthHeigth; j++)
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
            if (vector.GetSize() > Vectors[index].GetSize())
            {
                throw new ArgumentOutOfRangeException("Vector must be less or equals line size matrix", nameof(vector));
            }
            Vectors[index] = new Vector(vector);
        }

        public Vector GetColumVector(int index)
        {
            if ((index < 0) || (index >= Vectors[0].GetSize()))
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
            Vectors = new Vector[Vectors[0].GetSize()];

            for (int k = 0; k < Vectors.Length; k++)
            {
                Vectors[k] = new Vector(copy.Vectors.Length);
            }

            for (int i = 0; i < Vectors[i].GetSize(); i++)
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
            for (int i = 0; i < Vectors.Length; i++)
            {
                for (int j = 0; j < Vectors[i].GetSize(); j++)
                {
                    double temp = Vectors[i].GetComponent(j);
                    Vectors[i].SetComponent(j, temp * value);
                }
            }
        }

        //TODO: Доделать детерменант
        public double GetDeterminant()
        {
            return 1;
        }

        //TODO: Доделать матрицу на вектор
        public void MatrixOnVectorMultiplication(Vector vector)
        {

        }

        public void Sum(Matrix matrix)
        {
            for (int j = 0; j < Vectors.Length; j++)
            {
                Vectors[j].Sum(matrix.Vectors[j]);
            }
        }

        public void Difference(Matrix matrix)
        {
            for (int j = 0; j < Vectors.Length; j++)
            {
                Vectors[j].Difference(matrix.Vectors[j]);
            }
        }

        public static Matrix Sum(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix matrix = new Matrix(firstMatrix.Vectors.Length, secondMatrix.Vectors.Length);
            for(int i = 0; i < matrix.Vectors.Length; i++)
            {
                matrix.Vectors[i] = Vector.Sum(firstMatrix.Vectors[i], secondMatrix.Vectors[i]);
            }
            return matrix;
        }

        public static Matrix Difference(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix matrix = new Matrix(firstMatrix.Vectors.Length, secondMatrix.Vectors.Length);
            for (int i = 0; i < matrix.Vectors.Length; i++)
            {
                matrix.Vectors[i] = Vector.Difference(firstMatrix.Vectors[i], secondMatrix.Vectors[i]);
            }
            return matrix;
        }

        //TODO: Доделать умножение суть понятна
        public static Matrix Multiplication(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix matrix = new Matrix(firstMatrix.Vectors.Length, secondMatrix.Vectors.Length);
            for (int i = 0; i < matrix.Vectors.Length; i++)
            {
                Vector vec2 = firstMatrix.GetColumVector(1);
                matrix.Vectors[i] = Vector.Sum(firstMatrix.GetColumVector(i), secondMatrix.GetColumVector(i));
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
