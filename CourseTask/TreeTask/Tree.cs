using System.Collections.Generic;

namespace TreeTask
{
    class Tree<T>
    {
        private TreeNode<T> Root { get; set; }

        public int Count { get; private set; }

        //стек для обхода в глубину
        private Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

        public Tree()
        {

        }

        public void Add(T item)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(item, null, null);
                return;
            }

            //stack.Push(Root);
            //TreeNode<T> children;
            //while((children = stack.Pop()) != null)
            //{
            //    if(Comparer<T>.Default.Compare(children.Data, item) > 0)
            //    {
            //
            //    }
            //}
        }
    }
}
