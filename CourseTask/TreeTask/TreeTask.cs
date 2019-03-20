using System;

namespace TreeTask
{
    class TreeTask
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(8);

            Console.WriteLine(tree.ToString());

            Console.ReadKey();
        }
    }
}
