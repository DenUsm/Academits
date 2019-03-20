using System;

namespace TreeTask
{
    class TreeNode<T>
    {
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public T Data { get; set; }

        public TreeNode(T data, TreeNode<T> left, TreeNode<T> right)
        {
            Data = data;
            Left = left;
            Right = right; 
        }

        public override string ToString()
        {
            return string.Format("Data: {0} Left: {1} Right: {2}", (Data == null) ? "null" : Data.ToString(), (Left == null) ? "null" : Left.ToString(), (Right == null) ? "null" : Right.ToString());
        }

    }
}
