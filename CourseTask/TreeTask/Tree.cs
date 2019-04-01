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
                str.AppendLine(value.ToString());
            }

            return str.ToString();
        }

        //вставка элемента в дерево
        public void Add(T item)
        {
            if(Comparer != null)
            {
                Comparer.Compare(Root.Data, item);
            }
            else
            {
                T:IComparable<T>
            }



            //if (Root == null)
            //{
            //    Root = new TreeNode<T>(item);
            //    Count++;
            //    return;
            //}
            //
            //TreeNode<T> node = Root;
            //
            //while (node != null)
            //{
            //    if (node.Data.CompareTo(item) > 0)
            //    {
            //        if (node.Left == null)
            //        {
            //            node.Left = new TreeNode<T>(item);
            //            Count++;
            //            return;
            //        }
            //        else
            //        {
            //            node = node.Left;
            //        }
            //    }
            //    else
            //    {
            //        if (node.Right == null)
            //        {
            //            node.Right = new TreeNode<T>(item);
            //            Count++;
            //            return;
            //        }
            //        else
            //        {
            //            node = node.Right;
            //        }
            //    }
            //}

        }

        //поиск узла по значению
        /*public bool FindNodeByValue(T item)
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
        }*/

        //удаление первого вхождения узла
        /*public bool Remove(T item)
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
        }*/

        //метод для обхода дерева в ширину
        public IEnumerable<T> WayGoWide()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(Root);

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
            stack.Push(Root);

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
            
            if(Root.Left != null)
            {
              
            }
            //foreach (var node in Root.Left)
            //{
                foreach (var value in WayGoDepthWithRecursion())
                {
                    yield return value;
                }
            //}
        }

      
        //private TreeNode<T>[] DepthRecursion(TreeNode<T> node)
        //{
        //    if (node.Left != null && node.Right != null)
        //    {
        //        return new TreeNode<T>[] { node.Left, node.Right };
        //    }
        //
        //    if (node.Left != null && node.Right == null)
        //    {
        //        return new TreeNode<T>[] { node.Left };
        //    }
        //
        //    if (node.Left == null && node.Right != null)
        //    {
        //        return new TreeNode<T>[] { node.Left };
        //    }
        //
        //    return null;
        //}
    }
}
