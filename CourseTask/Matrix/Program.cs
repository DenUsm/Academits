using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(5, 5);
            Console.WriteLine(matrix.ToString());

            int n = matrix.N;
            int m = matrix.M;

            Console.ReadKey();
        }
    }
}
