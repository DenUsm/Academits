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

        public Matrix(Vector [] vector)
        {
            int maxSizeVector = 0;
            int length = vector.Length;
            for (int t = 1; t < length; t++)
            {
                if(vector[t].GetSize() > maxSizeVector)
                {
                    maxSizeVector = t;
                }
            }
            Vectors = new Vector[length];
            for (int i = 0; i < length; i++)
            {
                Vector copyVector = new Vector(vector[i]);
                copyVector.VectorAligment(vector[maxSizeVector]);
                Vectors[i] = new Vector(copyVector);
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
