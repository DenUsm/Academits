using System;
using System.Collections.Generic;
using System.Text;

namespace TreeTask
{
    class Tree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; private set; }

        public int Count { get; private set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            //Хотим выводить информацию по узлу (Data , Left, Right)
            Action<TreeNode<T>> action = delegate (TreeNode<T> node)
            {
                str.AppendLine(node.ToString());
            };

            IEnumerable<TreeNode<T>> iteratorWayGoWide = WayGoWide(action);
            foreach (var value in iteratorWayGoWide)
            {

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

            TreeNode<T> node = Root;

            while (node != null)
            {
                if (node.Data.CompareTo(item) > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode<T>(item, null, null);
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
                        node.Right = new TreeNode<T>(item, null, null);
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
                if (node.Data.CompareTo(item) > 0)
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
                        return true;
                    }

                    //удаление узла с 2 детьми
                    if (child.Left != null && child.Right != null)
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
                    if (child.Data.CompareTo(item) > 0)
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
        public IEnumerable<TreeNode<T>> WayGoWide(Action<TreeNode<T>> action)
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                TreeNode<T> node = queue.Dequeue();
                action(node);
                yield return node;

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
        public IEnumerable<TreeNode<T>> WayGoDepth(Action<TreeNode<T>> action)
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(Root);

            while (stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();
                action(node);
                yield return node;

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
        public IEnumerable<TreeNode<T>> WayGoDepthWithRecursion(TreeNode<T> root, Action<TreeNode<T>> action)
        {
            if (root != null)
            {
                action(root);

                if (root.GetChildren() != null)
                {
                    foreach (var node in root.GetChildren())
                    {
                        foreach (var value in WayGoDepthWithRecursion(node, action))
                        {
                            action(value);
                            yield return value;
                        }
                    }
                }
            }
        }
    }
}
