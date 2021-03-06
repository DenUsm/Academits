﻿using System;
using System.Collections.Generic;

namespace GraphTask
{
    class Graph
    {
        private int[,] graph;

        public Graph(int[,] graph)
        {
            this.graph = graph;
        }

        public void WayGoWide(int initialNode, Action<int> work)
        {
            int length = graph.GetLength(0);

            bool[] visited = new bool[length];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(initialNode);

            while (queue.Count != 0)
            {
                int nextNode = queue.Dequeue();

                //проверяем посещали ли данный узел
                if (!visited[nextNode])
                {
                    visited[nextNode] = true;
                    work(nextNode);

                    for (int i = 0; i < length; i++)
                    {
                        if (graph[nextNode, i] == 1 && !visited[i])
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
                            break;
                        }
                    }
                }
            }
        }

        public void WayGoDepth(int initialNode, Action<int> work)
        {
            int length = graph.GetLength(0);

            bool[] visited = new bool[length];

            Stack<int> stack = new Stack<int>();
            stack.Push(initialNode);

            while (stack.Count != 0)
            {
                int nextNode = stack.Pop();

                //проверяем посещали ли данный узел
                if (!visited[nextNode])
                {
                    visited[nextNode] = true;
                    work(nextNode);

                    for (int i = length - 1; i >= 0; i--)
                    {
                        if (graph[nextNode, i] == 1 && !visited[i])
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
                            break;
                        }
                    }
                }
            }
        }

        public void WayGoDepthWithRecursion(int initialNode, Action<int> work)
        {
            int length = graph.GetLength(0);

            bool[] visited = new bool[length];

            Visit(visited, initialNode, work);

            for (int i = 0; i < length; i++)
            {
                if (!visited[i])
                {
                    Visit(visited, i, work);
                }
            }
        }

        private void Visit(bool[] visited, int initialNode, Action<int> work)
        {
            //проверяем посещали ли данный узел
            if (!visited[initialNode])
            {
                visited[initialNode] = true;
                work(initialNode);

                for (int i = 0; i < visited.Length; i++)
                {
                    if (graph[initialNode, i] == 1 && !visited[i])
                    {
                        Visit(visited, i, work);
                    }
                }
            }
        }
    }
}
