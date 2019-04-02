using System;
using System.Text;

namespace TreeTask
{
    class TreeNode<T>
    {
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public T Data { get; set; }

        public TreeNode(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("Data: {0} ", (Data == null) ? "null" : Data.ToString().PadRight(2, ' '));
            str.AppendFormat("{0}  {1}", (Left == null) ? "null" : Left.Data.ToString().PadRight(4, ' '),
                                         (Right == null) ? "null" : Right.Data.ToString().PadRight(4, ' '));
            return str.ToString();
        }
    }
}
