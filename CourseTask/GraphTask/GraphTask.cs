using System;
using System.Collections.Generic;

namespace GraphTask
{
    class GraphTask
    {
        /***********************Graph****************/
        /*                                          */
        /*                 (5)   (7)                */
        /*                 /|     |    (9)          */
        /*                / |     |    /            */
        /*               /  |     |   /             */
        /*       (1)---(4)  |     |  /              */
        /*        |    /|   |     | /               */
        /*        |   / |   |    (8)                */
        /*        |  /  |   |                       */
        /*        | /   |  (6)                      */
        /*        |/    |                           */
        /*       (2)---(3)                          */
        /*                                          */
        /********************************************/

        public static int[][] graph = {
            new int [] { 0, 1, 0, 1, 0, 0, 0, 0, 0 },
            new int [] { 1, 0, 1, 1, 0, 0, 0, 0, 0 },
            new int [] { 0, 1, 0, 1, 0, 0, 0, 0, 0 },
            new int [] { 1, 1, 1, 0, 1, 0, 0, 0, 0 },
            new int [] { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
            new int [] { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            new int [] { 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            new int [] { 0, 0, 0, 0, 0, 0, 1, 0, 1 },
            new int [] { 0, 0, 0, 0, 0, 0, 0, 1, 0 }
            };

        public static bool[] visited = new bool[graph.GetLength(0)];

        static void Main(string[] args)
        {
            WayGoWide(3);

            Console.WriteLine();
            WayGoDepth(3);


            Console.ReadKey();
        }

        public static void InitialVisited()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
        }

        public static void WayGoWide(int initialNode)
        {
            //Инициализируем массив пустыми значениями
            InitialVisited();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(initialNode);

            while (queue.Count != 0)
            {
                int nextNode = queue.Dequeue();
                int[] node = graph[nextNode];

                //проверяем посещали ли данный узел
                if (visited[nextNode] == false)
                {
                    visited[nextNode] = true;
                    Console.WriteLine(nextNode + 1);

                    for (int i = 0; i < node.Length; i++)
                    {
                        if (node[i] == 1 && visited[i] == false)
                        {
                            queue.Enqueue(i);
                        }
                    }
                }

                //проверяем остались ли какие либо не посещенные узлы
                if (queue.Count == 0)
                {
                    for (int i = 0; i < visited.Length; i++)
                    {
                        if (visited[i] != true)
                        {
                            queue.Enqueue(i);
                            continue;
                        }
                    }
                }
            }
        }

        public static void WayGoDepth(int initialNode)
        {
            //Инициализируем массив пустыми значениями
            InitialVisited();

            Stack<int> stack = new Stack<int>();
            stack.Push(initialNode);

            while (stack.Count != 0)
            {
                int nextNode = stack.Pop();
                int[] node = graph[nextNode];

                //проверяем посещали ли данный узел
                if (visited[nextNode] == false)
                {
                    visited[nextNode] = true;
                    Console.WriteLine(nextNode + 1);

                    for (int i = 0; i < node.Length; i++)
                    {
                        if (node[i] == 1 && visited[i] == false)
                        {
                            stack.Push(i);
                        }
                    }
                }

                //проверяем остались ли какие либо не посещенные узлы
                if (stack.Count == 0)
                {
                    for (int i = 0; i < visited.Length; i++)
                    {
                        if (visited[i] != true)
                        {
                            stack.Push(i);
                            continue;
                        }
                    }
                }
            }
        }
    }
}
