using System;

namespace TreeTask
{
    class TreeTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------Test Add-----------------------------------");
            Tree<int> tree = new Tree<int>();
            tree.Add(8);
            tree.Add(3);
            tree.Add(10);
            tree.Add(14);
            tree.Add(13);
            tree.Add(1);
            tree.Add(6);
            tree.Add(4);
            tree.Add(7);

            Console.WriteLine(tree.ToString());
            Console.WriteLine("Количество элементов в дереве {0}", tree.Count);

            Console.WriteLine("------------------------------------------Test Find Node-----------------------------------");
            TreeNode<int> node = tree.FindNodeByValue(1);
            Console.WriteLine(node.ToString());

            TreeNode<int> node1 = tree.FindNodeByValue(8);
            Console.WriteLine(node1.ToString());

            //
            //Console.WriteLine("------------------------------------------Test Remove-----------------------------------");
            //Console.WriteLine();

            Console.ReadKey();
        }
    }
}
