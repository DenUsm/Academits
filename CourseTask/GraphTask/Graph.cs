using System;
using System.Collections.Generic;

namespace GraphTask
{
    class Graph
    {
        private int[,] graph;

        private bool[] visited;

        public Graph(int[,] graph)
        {
            this.graph = graph;
            visited = new bool[graph.GetLength(0)];
        }

        private void StatusVisitedInitial()
        {
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
        }

        public void WayGoWide(int initialNode, Action<int> work)
        {
            //Инициализируем массив пустыми значениями
            StatusVisitedInitial();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(initialNode);

            while (queue.Count != 0)
            {
                int nextNode = queue.Dequeue();

                int length = graph.GetLength(0);
                int[] node = new int[length];

                for (int i = 0; i < length; i++)
                {
                    node[i] = graph[nextNode, i];
                }

                //проверяем посещали ли данный узел
                if (!visited[nextNode])
                {
                    visited[nextNode] = true;
                    work(nextNode);

                    for (int i = 0; i < node.Length; i++)
                    {
                        if (node[i] == 1 && !visited[i])
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
                        if (!visited[i])
                        {
                            queue.Enqueue(i);
                        }
                    }
                }
            }
        }

        public void WayGoDepth(int initialNode, Action<int> work)
        {
            //Инициализируем массив пустыми значениями
            StatusVisitedInitial();

            Stack<int> stack = new Stack<int>();
            stack.Push(initialNode);

            while (stack.Count != 0)
            {
                int nextNode = stack.Pop();

                int length = graph.GetLength(0);
                int[] node = new int[length];

                for (int i = 0; i < length; i++)
                {
                    node[i] = graph[nextNode, i];
                }

                //проверяем посещали ли данный узел
                if (!visited[nextNode])
                {
                    visited[nextNode] = true;
                    work(nextNode);

                    for (int i = 0; i < node.Length; i++)
                    {
                        if (node[i] == 1 && !visited[i])
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
                        if (!visited[i])
                        {
                            stack.Push(i);
                        }
                    }
                }
            }
        }
    }
}
