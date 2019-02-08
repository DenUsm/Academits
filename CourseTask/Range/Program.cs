using System;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Range firstInterval = new Range(100, 200);
            Range secondInterval = new Range(200, 400);

            Range intersection = firstInterval.GetIntersection(secondInterval);
            if (intersection == null)
            {
                Console.WriteLine("Пересечение отсутствует");
            }
            else
            {
                Console.WriteLine("Пересечения [{0},{1}]", intersection.From, intersection.To);
            }

            Range[] unionInterval = firstInterval.GetUnion(secondInterval);
            for (int i = 0; i < unionInterval.Length; i++)
            {
                Console.WriteLine("{0} объединение [{1},{2}]", i + 1, unionInterval[i].From, unionInterval[i].To);
            }
            
            Range[] differenceInterval = secondInterval.GetDifference(firstInterval);
            
            for (int i = 0; i < differenceInterval.Length; i++)
            {
                Console.WriteLine("{0} разность [{1},{2}]", i + 1, differenceInterval[i].From, differenceInterval[i].To);
            }

            Console.ReadKey();
        }
    }
}
