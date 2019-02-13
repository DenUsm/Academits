﻿using System;

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
            mat4.SetLineVector(2, new Vector(5, new double[] { 5, 5, 5, 5, 5 }));
            Console.WriteLine(mat4.ToString());

            Matrix mat5 = new Matrix(new Vector[] { new Vector(5, new double[] { 1, 2, 3, 4, 5 }), new Vector(5, new double[] { 1, 2, 3, 4, 5 }),
                                                    new Vector(5, new double[] { 1, 2, 3, 4, 5 }), new Vector(5, new double[] { 1, 2, 3, 4, 5 }),
                                                    new Vector(5, new double[] { 1, 2, 3, 4, 5 })});
            Vector vec2 = mat5.GetColumVector(1);
            Console.WriteLine(vec2.ToString());

            mat5.Multiplication(2);
            Console.WriteLine("Multiplication" + mat5.ToString());

            Console.WriteLine();

            Matrix mat6 = new Matrix(new double[,] { { 4, 7, 2, 1}, { 3, 9, 8, 6 } });
            mat6.Transposition();
            Console.WriteLine("Transposition" + mat6.ToString());

            Console.WriteLine();

            Matrix mat7 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } });
            mat7.Transposition();
            Console.WriteLine("Transposition" + mat7.ToString());

            Matrix[] array = new Matrix[] { mat1, mat2, mat3, mat4 };
            foreach (Matrix val in array)
            {
                Console.WriteLine(val.ToString());
            }

            Console.ReadKey();
        }
    }
}
