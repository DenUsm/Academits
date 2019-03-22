using System;
using System.Collections.Generic;

namespace InfinityStream
{
    class InfinityStream
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------Бесконечный поток корней чисел----------------");
            Console.Write("Введите количество элементов, которое необходимо вычислить:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("Количество элементов должно быть положительным");
            }


            foreach (int value in GetSquares(quantity))
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("------------Бесконечный поток чисел Фиббоначчи----------------");
            Console.Write("Введите количество элементов, которое необходимо вычислить:");
            int quantityFibonacci = Convert.ToInt32(Console.ReadLine());

            if (quantityFibonacci < 0)
            {
                throw new ArgumentOutOfRangeException("Количество элементов должно быть положительным");
            }

            foreach (int value in GetFibonacci(quantityFibonacci))
            {
                Console.WriteLine(value);
            }

            Console.ReadKey();
        }

        public static IEnumerable<long> GetFibonacci(int quantityFibonacci)
        {
            long fn = 0;
            long fn2 = 0;
            long fn1 = 1;
            int i = 0;

            while ((i < 2) && (i <= quantityFibonacci))
            {
                yield return fn + i;
                i++;
            }

            while (i <= quantityFibonacci)
            {
                fn = fn1 + fn2;
                fn2 = fn1;
                fn1 = fn;
                yield return fn;
                i++;
            }
        }


        public static IEnumerable<int> GetSquares(int quantity)
        {
            int i = 0;
            while (i <= quantity)
            {
                yield return i * i;
                i++;
            }
        }
    }
}
