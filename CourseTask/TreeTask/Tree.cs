using System;
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
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(Root);

            TreeNode<T> returnNode = null;

            while (stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();
        
                if (Equals(node.Data, item))
                {
                    returnNode = node;
                    return returnNode;
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
            }

            return returnNode;
        }

        //удаление первого вхождения узла
        public bool Remove(T item)
        {

        }
    }
}
