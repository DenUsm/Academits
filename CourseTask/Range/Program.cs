using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Range firstIn = new Range(2, 6);
            Range secondIn = new Range(7, 9);

            Range inter = new Range().GetIntersection(firstIn, secondIn);

            Console.ReadKey();
        }
    }
}
