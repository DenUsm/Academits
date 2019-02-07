using System;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Range firstIn = new Range(1, 20);
            Range secondIn = new Range(5, 15);

            Range inter = firstIn.GetIntersection(secondIn);

            if (inter == null)
            {
                Console.WriteLine("Отрезки не пересекаются, нового интервал нет");
            }
            else
            {
                Console.WriteLine("Точки нового интервала {0}-{1}", inter.From, inter.To);
            }

            Console.ReadKey();
        }
    }
}
