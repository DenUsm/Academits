﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TreeTask
{
    class Tree<T>
    {
        public TreeNode<T> Root { get; private set; }

        public int Count { get; private set; }

        public IComparer<T> Comparer { get; }

        public Tree()
        {

        }

        public Tree(IComparer<T> comparer)
        {
            Comparer = comparer;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            IEnumerable<T> iteratorWayGoWide = WayGoWide();
            foreach (var value in iteratorWayGoWide)
            {
                str.AppendLine(value.ToString());
            }

            return str.ToString();
        }

        private int modCount = 0;

        private int GetStatusCompare(TreeNode<T> node, T item)
        {
            if (Comparer != null)
            {
                return Comparer.Compare(node.Data, item);
            }

            if (!(node.Data is IComparable<T>))
            {
                throw new ArgumentException("T is not a comparable type");
            }

            var value = node.Data as IComparable<T>;

            return value.CompareTo(item);
        }

        //вставка элемента в дерево
        public void Add(T item)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(item);
                Count++;
                modCount++;
                return;
            }

            TreeNode<T> node = Root;

            while (node != null)
            {
                if (GetStatusCompare(node, item) > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode<T>(item);
                        Count++;
                        return;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new TreeNode<T>(item);
                        Count++;
                        return;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
            }
        }

        //поиск узла по значению
        public bool FindNodeByValue(T item)
        {
            //поверка на корень
            if (Equals(Root.Data, item))
            {
                return true;
            }

            TreeNode<T> node = Root;

            while (node != null)
            {
                if (GetStatusCompare(node, item) > 0)
                {
                    if (node.Left == null)
                    {
                        return false;
                    }

                    if (Equals(node.Left.Data, item))
                    {
                        return true;
                    }

                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        return false;
                    }

                    if (Equals(node.Right.Data, item))
                    {
                        return true;
                    }

                    node = node.Right;
                }
            }

            return false;
        }

        //удаление первого вхождения узла
        public bool Remove(T item)
        {
            if (Root == null)
            {
                return false;
            }

            TreeNode<T> parent = null;
            TreeNode<T> node = Root;

            while (node != null)
            {
                TreeNode<T> child = node;

                //если нашли узел рассматриваем 3 варианта
                if (Equals(child.Data, item))
                {
                    //удаление листа
                    if (child.Left == null && child.Right == null)
                    {
                        if (GetStatusCompare(parent, item) > 0)
                        {
                            parent.Left = null;
                        }
                        else
                        {
                            parent.Right = null;
                        }
                        Count--;
                        modCount++;
                        return true;
                    }

                    //удаление узла с одним ребенком
                    if ((child.Left != null && child.Right == null) || (child.Left == null && child.Right != null))
                    {
                        if (Equals(parent.Left.Data, child.Data))
                        {
                            parent.Left = child.Left == null ? child.Right : child.Left;
                        }
                        else
                        {
                            parent.Right = child.Right == null ? child.Left : child.Right;
                        }
                        Count--;
                        modCount++;
                        return true;
                    }

                    //удаление узла с 2 детьми
                    if (child.Left != null && child.Right != null)
                    {
                        TreeNode<T> minNode = child.Right;

                        //находим минимальный элемент слева
                        TreeNode<T> parentMinNode = null;

                        while (minNode.Left != null)
                        {
                            parentMinNode = minNode;
                            minNode = minNode.Left;
                        }

                        T value = minNode.Data;
                        //проверяем есть ли у него праввый сын
                        if (minNode.Right != null)
                        {
                            minNode = minNode.Right;
                        }
                        else
                        {
                            parentMinNode.Left = null;
                        }

                        //если parent null значит искомый элемент корень
                        if (parent == null)
                        {
                            Root.Data = value;
                            Count--;
                            modCount++;
                            return true;
                        }

                        if (Equals(parent.Left.Data, item))
                        {
                            parent.Left.Data = value;
                        }
                        else
                        {
                            parent.Right.Data = value;
                        }

                        Count--;
                        modCount++;
                        return true;
                    }
                }
                else
                {
                    if (GetStatusCompare(child, item) > 0)
                    {
                        if (child.Left == null)
                        {
                            return false;
                        }

                        node = node.Left;
                    }
                    else
                    {
                        if (child.Right == null)
                        {
                            return false;
                        }

                        node = node.Right;
                    }
                }

                parent = child;
            }

            return false;
        }

        //метод для обхода дерева в ширину
        public IEnumerable<T> WayGoWide()
        {
            int modCountSave = modCount;

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            while (queue.Count != 0)
            {
                TreeNode<T> node = queue.Dequeue();

                if (modCount != modCountSave)
                {
                    throw new InvalidOperationException("There were changes in the collection");
                }

                yield return node.Data;

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        //метод для обхода дерева в ширину
        public IEnumerable<T> WayGoDepth()
        {
            int modCountSave = modCount;

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            if (Root != null)
            {
                stack.Push(Root);
            }

            while (stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();

                if (modCount != modCountSave)
                {
                    throw new InvalidOperationException("There were changes in the collection");
                }

                yield return node.Data;

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }

        //метод для обхода дерева в глубину с реккурсией
        public IEnumerable<T> WayGoDepthWithRecursion()
        {
            int modCountSave = modCount;

            if (Root != null)
            {
                foreach (var value in Recursion(Root))
                {
                    if (modCount != modCountSave)
                    {
                        throw new InvalidOperationException("There were changes in the collection");
                    }

                    yield return value;
                }
            }
        }

        private IEnumerable<T> Recursion(TreeNode<T> node)
        {
            yield return node.Data;

            if (node.Left != null)
            {
                foreach (var value in Recursion(node.Left))
                {
                    yield return value;
                }
            }

            if (node.Right != null)
            {
                foreach (var value in Recursion(node.Right))
                {
                    yield return value;
                }
            }
        }
    }
}
