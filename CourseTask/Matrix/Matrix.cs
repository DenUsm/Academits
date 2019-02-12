﻿namespace Matrix
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
            int lengthHeugth = array.GetLength(1);

            Vectors = new Vector[lengthWigth];
            double[] line = new double[lengthHeugth];

            for (int i = 0; i < lengthWigth; i++)
            {
                for (int j = 0; j < lengthHeugth; j++)
                {
                    line[j] = array[i, j];
                }
                Vectors[i] = new Vector(line);
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


        //public Matrix(Vector [] vector)
        //{
        //    //TODO: find max vector
        //    for(int i = 0; i < vector.Length; i++)
        //    {
        //        for(int j = 0; j < vector[i].GetSize(); j++)
        //        {
        //            Components[i, j] = vector[i].Components[j].AlignVector(maxVector);
        //        }
        //    }
        //}

        public override string ToString()
        {
            int length = Vectors.Length;
            string[] strVectors = new string [length];
            for(int i = 0; i < length; i++)
            {
                strVectors[i] = Vectors[i].ToString();
            }
            return "{ " + string.Join(", ", strVectors) + " }";
        }
    }
}
