using System;
using System.Collections;
using System.Collections.Generic;

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
            tree.Add(12);
            tree.Add(14);
            tree.Add(10);
            tree.Add(9);
            tree.Add(13);
            tree.Add(1);
            tree.Add(6);
            tree.Add(4);
            tree.Add(7);

            //Console.WriteLine(tree.ToString());
            //Console.WriteLine("Количество элементов в дереве {0}", tree.Count);
            //
            //Console.WriteLine("------------------------------------------Test Find Node-----------------------------------");
            //TreeNode<int> node = tree.FindNodeByValue(1);
            //Console.WriteLine(node.ToString());
            //
            //TreeNode<int> node1 = tree.FindNodeByValue(8);
            //Console.WriteLine(node1.ToString());
            //
            //Console.WriteLine("------------------------------------------Test Remove-----------------------------------");
            //Console.WriteLine();
            ////тест удаление листа
            //int removeValue = 7;
            //Console.WriteLine("Remove value: {0} status: {1}", removeValue, tree.Remove(removeValue));
            //Console.WriteLine(tree.ToString());
            //
            ////тест удаление с одним ребенком 
            //int removeValue1 = 14;
            //Console.WriteLine("Remove value: {0} status: {1}", removeValue1, tree.Remove(removeValue1));
            //Console.WriteLine(tree.ToString());
            //
            ////тест удаление с одним ребенком 
            //int removeValue2 = 8;
            //Console.WriteLine("Remove value: {0} status: {1}", removeValue2, tree.Remove(removeValue2));
            //Console.WriteLine(tree.ToString());


            //делегат для получения даты узла
            Action<TreeNode<int>> getData = delegate (TreeNode<int> data)
            {
                Console.WriteLine(data.Data);
            };

            //делат для получения общей информации по узлу
            Action<TreeNode<int>> getInfoNode = delegate (TreeNode<int> node)
            {
                Console.WriteLine(node.ToString());
            };


            IEnumerator<TreeNode<int>> iteratorWide = tree.WayGoWide(getData).GetEnumerator();
            while(iteratorWide.MoveNext())
            {

            }

            IEnumerator<TreeNode<int>> iteratorDepth = tree.WayGoDepth(getInfoNode).GetEnumerator();
            while(iteratorDepth.MoveNext())
            {

            }

            IEnumerator<TreeNode<int>> iteratorDepthWithRecursion = tree.WayGoDepthWithRecursion(getInfoNode).GetEnumerator();
            while (iteratorDepthWithRecursion.MoveNext())
            {

            }


            //tree.ShowWayWithRecursion();

            Console.ReadKey();
        }
    }
}
