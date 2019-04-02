using System;
using System.Collections;
using System.Collections.Generic;

namespace TreeTask
{
    class TreeTask
    {
        class MyComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x > y)
                {
                    return 1;
                }
                else if (x < y)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }


        static void Main(string[] args)
        {
            Tree<int> test1 = new Tree<int>();
            test1.Add(8);
            test1.Add(3);
            Tree<int> test2 = new Tree<int>(new MyComparer());
            test2.Add(8);
            test2.Add(3);


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

            Console.WriteLine(tree.ToString());
            Console.WriteLine("Количество элементов в дереве {0}", tree.Count);


            //Console.WriteLine("------------------------------------------Test Find Node-----------------------------------");
            //int value1 = 4;
            //Console.WriteLine("Location status of value {0} in tree is {1}", value1, tree.FindNodeByValue(value1));
            //
            //int value2 = 8;
            //Console.WriteLine("Location status of value {0} in tree is {1}", value2, tree.FindNodeByValue(value2));
            //
            //int value3 = 5;
            //Console.WriteLine("Location status of value {0} in tree is {1}", value3, tree.FindNodeByValue(value3));
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
            ////тест удаление с 2 детьми 
            //int removeValue2 = 8;
            //Console.WriteLine("Remove value: {0} status: {1}", removeValue2, tree.Remove(removeValue2));
            //Console.WriteLine(tree.ToString());


            Console.WriteLine();
            Console.WriteLine("--------------------Test iterator wide------------------------");
            //итератор для обхода в ширину
            IEnumerator<int> iteratorWide = tree.WayGoWide().GetEnumerator();
            while (iteratorWide.MoveNext())
            {
                Console.WriteLine(iteratorWide.Current);
            }

            Console.WriteLine();
            Console.WriteLine("--------------------Test iterator depth------------------------");
            //итератор для обхода в глубину
            IEnumerator<int> iteratorDepth = tree.WayGoDepth().GetEnumerator();
            while (iteratorDepth.MoveNext())
            {
                Console.WriteLine(iteratorDepth.Current);
            }

            //Console.WriteLine();
            //Console.WriteLine("--------------------Test iterator depth recursion---------------");
            ////итератор для обхода в глубину с реккурсией
            //IEnumerator<int> iteratorDepthWithRecursion = tree.WayGoDepthWithRecursion(tree.Root, getData).GetEnumerator();
            //while (iteratorDepthWithRecursion.MoveNext())
            //{
            //
            //}

            SortedSet<int> list = new SortedSet<int>();
            list.Add(8);
            list.Add(3);
            list.Add(8);

            Console.ReadKey();
        }
    }
}
