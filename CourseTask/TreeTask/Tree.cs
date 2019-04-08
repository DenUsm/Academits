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
            if (data == null || item == null)
            {
                throw new ArgumentNullException("Compared parameter must be not null");
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

            //поверка на корень
            if (Compare(Root.Data, item) == 0)
            {
                return true;
            }

            TreeNode<T> node = Root;

            while (node != null)
            {
                if (Compare(node.Data, item) > 0)
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

            while (Compare(node.Data, item) != 0)
            {
                parent = node;

                if (Compare(node.Data, item) > 0)
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

            //удаление листа
            if (node.Left == null && node.Right == null)
            {
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
            if ((node.Left != null && node.Right == null) || (node.Left == null && node.Right != null))
            {
                if (Compare(parent.Left.Data, node.Data) == 0)
                {
                    parent.Left = node.Left == null ? node.Right : node.Left;
                }
                else
                {
                    parent.Right = node.Right == null ? node.Left : node.Right;
                }
                Count--;
                return true;
            }

            //удаление узла с 2 детьми
            if (node.Left != null && node.Right != null)
            {
                TreeNode<T> minNode = node.Right;

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
                    return true;
                }

                if (Compare(parent.Left.Data, item) == 0)
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

            return false;
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
