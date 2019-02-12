using System;
using System.Text;


namespace Matrix
{
    class Matrix
    {
        public double[,] Components { get; set; }

        public int N => Components.GetLength(0);

        public int M => Components.GetLength(1);

        public Matrix(int n, int m)
        {
            Components = new double[n, m];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Components[i, j] = 0;
                }
            }
        }

        public Matrix(Matrix matrix)
        {
            Components = new double[matrix.N, matrix.M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Components[i, j] = matrix.Components[i, j];
                }
            }
        }

        public Matrix(double [,] array)
        {
            Components = new double[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Components[i, j] = array[i, j];
                }
            }
        }


        public override string ToString()
        {
            string strReturn = "{ ";
            double[] line = new double[Components.GetLength(1)];
            for (int i = 0; i < Components.GetLength(0); i++)
            {
                for (int j = 0; j < Components.GetLength(1); j++)
                {
                    line[j] = Components[i, j];
                }
                if (i != Components.GetLength(0) - 1)
                {
                    strReturn += "{" + string.Join(",", line) + "}, ";
                }
            }
            strReturn += "{" + string.Join(",", line) + "}";
            return strReturn + " }";
        }
    }
}
