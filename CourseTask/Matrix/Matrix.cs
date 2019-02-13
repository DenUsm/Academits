﻿using System;

namespace Matrix
{
    class Matrix
    {
        public Vector[] Vectors { get; set; }

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
            for (int i = 0; i < Vectors.Length; i++)
            {
                for (int j = i; j < Vectors[i].GetSize(); j++)
                {
                    double temp = Vectors[i].GetComponent(j);
                    Vectors[i].SetComponent(j, Vectors[j].GetComponent(i));
                    Vectors[j].SetComponent(i, temp);
                }
            }
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
