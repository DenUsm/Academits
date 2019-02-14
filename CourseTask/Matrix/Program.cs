using System;
using VectorTask;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix mat1 = new Matrix(5, 5);
            Matrix mat2 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } });
            Matrix mat3 = new Matrix(mat2);
            Matrix mat4 = new Matrix(new Vector[] { new Vector(3, new double[] { 1 }), new Vector(5, new double[] { 1, 2 }), new Vector(4, new double[] { 1, 2, 3 }) });

            Vector vec1 = mat4.GetLineVector(2);
            Console.WriteLine(vec1.ToString());

            Console.WriteLine();

            Console.WriteLine(mat4.ToString());
            mat4.SetLineVector(2, new Vector(5, new double[] { 5, 5, 5, 5, 5, 5 }));
            Console.WriteLine(mat4.ToString());

            Matrix mat5 = new Matrix(new Vector[] { new Vector(5, new double[] { 1, 2, 3, 4, 5 }), new Vector(5, new double[] { 1, 2, 3, 4, 5 }),
                                                    new Vector(5, new double[] { 1, 2, 3, 4, 5 }), new Vector(5, new double[] { 1, 2, 3, 4, 5 }),
                                                    new Vector(5, new double[] { 1, 2, 3, 4, 5 })});
            Vector vec2 = mat5.GetColumVector(1);
            Console.WriteLine(vec2.ToString());

            mat5.Multiplication(2);
            Console.WriteLine("Multiplication" + mat5.ToString());

            Console.WriteLine();

            Matrix mat6 = new Matrix(new double[,] { { 4, 7, 2, 1 }, { 3, 9, 8, 6 } });
            mat6.Transposition();
            Console.WriteLine("Transposition" + mat6.ToString());

            Console.WriteLine();

            Matrix mat7 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } });
            mat7.Transposition();
            Console.WriteLine("Transposition" + mat7.ToString());

            Matrix mat8 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } });
            Matrix mat9 = new Matrix(new double[,] { { 1, 2, 3, 4, 5 }, { 5, 6, 7, 8, 5 }, { 9, 10, 11, 12, 5 } });
            mat9.Sum(mat8);
            Console.WriteLine("Sum" + mat9.ToString());

            Matrix mat10 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } });
            Matrix mat11 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } });
            mat10.Sum(mat11);

            Matrix mat12 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Vector vec3 = new Vector(new double[] { 1, 2, 3 });
            mat12.MatrixOnVectorMultiplication(vec3);
            Console.WriteLine("Multiplication" + mat12.ToString());

            Matrix mat13 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix mat14 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix matResult = Matrix.Multiplication(mat14, mat13);
            Console.WriteLine("Multiplication new matrix" + matResult.ToString());

            Matrix mat15 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
            Matrix mat16 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix matResult1 = Matrix.Multiplication(mat15, mat16);
            Console.WriteLine("Multiplication new matrix" + matResult1.ToString());

            Matrix mat17 = new Matrix(new double[,] { { 5, 7, 6 }, { 3, 16, 19 }, { 13, 10, 7 } });
            double res = mat17.GetDeterminant();
            Console.WriteLine("Determenet matrix " + res);

            Matrix mat18 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 10 } });
            double res1 = mat18.GetDeterminant();
            Console.WriteLine("Determenet matrix " + res1);


            Matrix[] array = new Matrix[] { mat1, mat2, mat3, mat4 };
            foreach (Matrix val in array)
            {
                Console.WriteLine(val.ToString());
            }

            Console.ReadKey();
        }
    }
}
