using System;
using System.Collections.Generic;

namespace GraphTask
{
    class GraphTask
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(new int[,]
            {
                { 0, 1, 0, 1, 0, 0, 0, 0, 0 },
                { 1, 0, 1, 1, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 0 }
            });

            Action<int> printActionDel = i => Console.WriteLine(i);

            graph.WayGoWide(3, printActionDel);

            Console.WriteLine();

            graph.WayGoDepth(3, printActionDel);

            Console.WriteLine();

            graph.WayGoDepthWithRecursion(3, printActionDel);

            Console.ReadKey();
        }
    }
}
