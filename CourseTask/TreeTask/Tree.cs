using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TreeTask
{
    class Tree<T> where T : IComparable<T>
    {
        private TreeNode<T> Root { get; set; }

        public int Count { get; private set; }

        public Tree()
        {
            Count = 0;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(Root);

            while (stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();

                if (node.Data != null)
                {
                    str.Append(node.ToString());
                    str.AppendLine();
                }

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
            return str.ToString();
        }

        //вставка элемента в дерево
        public void Add(T item)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(item, null, null);
                Count++;
                return;
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(Root);

            while (stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();

                if (node.Data.CompareTo(item) == 1)
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode<T>(item, null, null);
                        Count++;
                    }
                    else
                    {
                        stack.Push(node.Left);
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new TreeNode<T>(item, null, null);
                        Count++;
                    }
                    else
                    {
                        stack.Push(node.Right);
                    }
                }
            }

        }

        //поиск узла по значению
        public TreeNode<T> FindNodeByValue(T item)
        {
            //поверка на корень
            if (Equals(Root.Data, item))
            {
                return Root;
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(Root);

            TreeNode<T> returnNode = null;

            while (stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();

                if (node.Data.CompareTo(item) == 1)
                {
                    if (node.Left == null)
                    {
                        return null;
                    }
                    else if (Equals(node.Left.Data, item))
                    {
                        return node.Left;
                    }
                    else
                    {
                        stack.Push(node.Left);
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        return null;
                    }
                    else if (Equals(node.Right.Data, item))
                    {
                        return node.Right;
                    }
                    else
                    {
                        stack.Push(node.Right);
                    }
                }
            }

            return returnNode;
        }

        //удаление первого вхождения узла
        public bool Remove(T item)
        {
            if (Root == null)
            {
                return false;
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(Root);

            TreeNode<T> parent = null;
            while (stack.Count != 0)
            {
                TreeNode<T> child = stack.Pop();

                //если нашли узел рассматриваем 3 варианта
                if (Equals(child.Data, item))
                {
                    //удаление листа
                    if (child.Left == null && child.Right == null)
                    {
                        if (parent.Data.CompareTo(item) == 1)
                        {
                            parent.Left = null;
                        }
                        else
                        {
                            parent.Right = null;
                        }
                        Count--;
                        return true;
                    }
                    //удаление узла с одним ребенком
                    else if ((child.Left != null && child.Right == null) || (child.Left == null && child.Right != null))
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
                        return true;
                    }
                    //удаление узла с 2 детьми
                    else
                    {
                        Stack<TreeNode<T>> findMin = new Stack<TreeNode<T>>();
                        findMin.Push(child.Right);

                        //находим минимальный элемент слева
                        TreeNode<T> parentMinNode = null;
                        TreeNode<T> minNode = null;
                        while (findMin.Count != 0)
                        {
                            minNode = findMin.Pop();

                            if (minNode.Left != null)
                            {
                                findMin.Push(minNode.Left);
                                parentMinNode = minNode;
                            }
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
                        return true;
                    }
                }
                else
                {
                    if (child.Data.CompareTo(item) == 1)
                    {
                        if (child.Left == null)
                        {
                            return false;
                        }
                        else
                        {
                            stack.Push(child.Left);
                        }
                    }
                    else
                    {
                        if (child.Right == null)
                        {
                            return false;
                        }
                        else
                        {
                            stack.Push(child.Right);
                        }
                    }
                }

                parent = child;
            }

            return false;
        }

        //выовод узлов с исопльзованием обхода в ширину
        public string ShowWayByWide()
        {
            StringBuilder str = new StringBuilder();
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                TreeNode<T> node = queue.Dequeue();
                str.Append(node);
                str.AppendLine();

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            return str.ToString();
        }

        //выовод узлов с исопльзованием обхода в глубину с рекурсией
        public void ShowWayWithRecursion()
        {
            Visit(Root);
        }

        private void Visit(TreeNode<T> node)
        {
            Console.WriteLine(node);

            if (node.GetChildren() != null)
            {
                TreeNode<T>[] nodes = node.GetChildren();
                foreach (TreeNode<T> child in nodes)
                {
                    Visit(child);
                }
            }
            return;
        }
    }
}
