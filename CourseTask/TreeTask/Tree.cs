using System;
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
                str.AppendLine(value == null ? "null" : value.ToString());
            }

            return str.ToString();
        }

        private int Compare(T data, T item)
        {
            if (data == null && item == null)
            {
                return 0;
            }
            else if (data == null && item != null)
            {
                return -1;
            }
            else if (data != null && item == null)
            {
                return 1;
            }

            if (Comparer != null)
            {
                return Comparer.Compare(data, item);
            }

            return ((IComparable<T>)data).CompareTo(item);
        }

        //вставка элемента в дерево
        public void Add(T item)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(item);
                Count++;
                return;
            }

            TreeNode<T> node = Root;

            while (node != null)
            {
                if (Compare(node.Data, item) > 0)
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
            if (Root == null)
            {
                return false;
            }

            TreeNode<T> node = Root;

            while (node != null)
            {
                int resultCompare = Compare(node.Data, item);

                if (resultCompare == 0)
                {
                    return true;
                }

                if (resultCompare > 0)
                {
                    if (node.Left == null)
                    {
                        return false;
                    }

                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        return false;
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

            int resultCompare = Compare(node.Data, item);

            while (resultCompare != 0)
            {
                parent = node;

                if (resultCompare > 0)
                {
                    if (node.Left == null)
                    {
                        return false;
                    }

                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        return false;
                    }

                    node = node.Right;
                }

                resultCompare = Compare(node.Data, item);
            }

            //удаление листа
            if (node.Left == null && node.Right == null)
            {
                //случай когда удаляем корень
                if (parent == null)
                {
                    Root = null;
                    Count--;
                    return true;
                }

                if (Compare(parent.Data, item) > 0)
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
            if (node.Left == null || node.Right == null)
            {
                //случай когда удаляем корень
                if (parent == null)
                {
                    if (Root.Left != null)
                    {
                        Root = Root.Left;
                    }
                    else
                    {
                        Root = Root.Right;
                    }
                    Count--;
                    return true;
                }

                if (Compare(parent.Data, item) > 0)
                {
                    if (node.Left != null)
                    {
                        parent.Left = node.Left;
                    }
                    else
                    {
                        parent.Left = node.Right;
                    }
                }
                else
                {
                    if (node.Left != null)
                    {
                        parent.Right = node.Left;
                    }
                    else
                    {
                        parent.Right = node.Right;
                    }
                }

                Count--;
                return true;
            }

            //удаление узла с 2 детьми
            TreeNode<T> minNode = node.Right;

            //находим минимальный элемент слева
            TreeNode<T> parentMinNode = null;

            while (minNode.Left != null)
            {
                parentMinNode = minNode;
                minNode = minNode.Left;
            }

            //проверяем есть ли у него праввый сын
            if (minNode.Right != null)
            {
                parentMinNode.Left = minNode.Right;
            }
            else
            {
                parentMinNode.Left = null;
            }

            //если parent null значит искомый элемент корень
            if (parent == null)
            {
                minNode.Left = Root.Left;
                minNode.Right = Root.Right;
                Root = minNode;
                Count--;
                return true;
            }

            minNode.Left = node.Left;
            minNode.Right = node.Right;

            if (Compare(parent.Left.Data, item) == 0)
            {
                parent.Left = minNode;
            }
            else
            {
                parent.Right = minNode;
            }

            Count--;
            return true;
        }

        //метод для обхода дерева в ширину
        public IEnumerable<T> WayGoWide()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            while (queue.Count != 0)
            {
                TreeNode<T> node = queue.Dequeue();

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
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            if (Root != null)
            {
                stack.Push(Root);
            }

            while (stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();

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
            if (Root != null)
            {
                foreach (var value in WayGoChildrens(Root))
                {
                    yield return value;
                }
            }
        }

        private IEnumerable<T> WayGoChildrens(TreeNode<T> node)
        {
            yield return node.Data;

            if (node.Left != null)
            {
                foreach (var value in WayGoChildrens(node.Left))
                {
                    yield return value;
                }
            }

            if (node.Right != null)
            {
                foreach (var value in WayGoChildrens(node.Right))
                {
                    yield return value;
                }
            }
        }
    }
}
