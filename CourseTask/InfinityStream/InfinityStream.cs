using System;
using System.Collections.Generic;
using System.Linq;

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

            IEnumerable<int> stream = GetSquares();
            foreach (var value in stream.Take(quantity))
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

            IEnumerable<long> streamFibonacci = GetFibonacci();
            foreach (var value in streamFibonacci.Take(quantityFibonacci))
            {
                Console.WriteLine(value);
            }

            Console.ReadKey();
        }

        public static IEnumerable<long> GetFibonacci()
        {
            long fn = 0;
            long fn2 = 0;
            long fn1 = 1;

            yield return 0;
            yield return 1;

            while (true)
            {
                fn = fn1 + fn2;
                fn2 = fn1;
                fn1 = fn;
                yield return fn;
            }
        }


        public static IEnumerable<int> GetSquares()
        {
            int i = 0;
            while (true)
            {
                yield return i * i;
                i++;
            }
        }
    }
}
