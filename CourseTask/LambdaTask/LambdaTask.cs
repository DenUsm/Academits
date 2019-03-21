using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaTask
{
    class LambdaTask
    {
        static void Main(string[] args)
        {
            var items = new[] { "d2", "a2", "b1", "b3", "c" }
            .Select(s =>
            {
                Console.WriteLine("map: " + s);
                return s.ToUpper();
            })
            .Where(s =>
            {
                Console.WriteLine("filter: " + s);
            return s.StartsWith("A");
            });
            foreach (var s in items) { Console.WriteLine("forEach: " + s); }

            Console.ReadKey();
        }
    }
}
