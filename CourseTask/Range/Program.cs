using System;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Range firstInterval = new Range(2, 6);
            Range secondInterval = new Range(5, 13);

            Range inte = firstInterval.GetIntersection(secondInterval);
            Range inte1 = secondInterval.GetIntersection(firstInterval);

            Range[] unionInterval = firstInterval.GetUnion(secondInterval);
            Range[] unionInterval2 = secondInterval.GetUnion(firstInterval);

            Console.ReadKey();
        }
    }
}
