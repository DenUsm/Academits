using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix mat1 = new Matrix(5, 5);
            Matrix mat2 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } });
            Matrix mat3 = new Matrix(mat2);

            Matrix [] array = new Matrix[] { mat1, mat2, mat3 };
            foreach(Matrix val in array)
            {
                Console.WriteLine(val.ToString());
            }

            Console.ReadKey();
        }
    }
}
