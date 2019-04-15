using System;
using System.Collections.Generic;

namespace TreeTask
{
    class TreeTask
    {
        static void Main(string[] args)
        {
            Tree<int> test1 = new Tree<int>();
            test1.Add(8);
            test1.Add(8);
            test1.Add(3);

            //компаратор для сравнения строк по длине
            Comparer<string> strComparer = Comparer<string>.Create((v1, v2) =>
            {
                return v1.Length.CompareTo(v2.Length);
            });

            Tree<string> test2 = new Tree<string>(strComparer);
            test2.Add("aaaaaaaa");
            test2.Add("cccccccc");
            test2.Add("bbb");

            //компаратор для сравнения типа Int по дефолту
            Comparer<int> intComparer = Comparer<int>.Default;

            Tree<int> test3 = new Tree<int>(intComparer);
            test3.Add(8);
            test3.Add(8);
            test3.Add(3);

            Tree<string> test4 = new Tree<string>();
            test4.Add("aaa");
            test4.Add(null);
            test4.Add("bbbb");
            test4.Add(null);
            bool res = test4.FindNodeByValue(null);

            Console.WriteLine("------------------------------------------Test Add-----------------------------------");
            Tree<int> tree = new Tree<int>();
            tree.Add(8);
            tree.Add(3);
            tree.Add(13);
            tree.Add(14);
            tree.Add(12);
            tree.Add(11);
            tree.Add(9);
            tree.Add(10);
            tree.Add(15);
            tree.Add(2);
            tree.Add(5);
            tree.Add(6);
            tree.Add(4);
            tree.Add(7);

            Console.WriteLine(tree.ToString());
            Console.WriteLine("Количество элементов в дереве {0}", tree.Count);


            Console.WriteLine("------------------------------------------Test Find Node-----------------------------------");
            int value1 = 4;
            Console.WriteLine("Location status of value {0} in tree is {1}", value1, tree.FindNodeByValue(value1));

            int value2 = 8;
            Console.WriteLine("Location status of value {0} in tree is {1}", value2, tree.FindNodeByValue(value2));

            int value3 = 5;
            Console.WriteLine("Location status of value {0} in tree is {1}", value3, tree.FindNodeByValue(value3));

            Console.WriteLine("------------------------------------------Test Remove-----------------------------------");
            Console.WriteLine();
            //тест удаление листа
            int removeValue = 7;
            Console.WriteLine("Remove value: {0} status: {1}", removeValue, tree.Remove(removeValue));
            Console.WriteLine(tree.ToString());

            //тест удаление с одним ребенком 
            int removeValue1 = 14;
            Console.WriteLine("Remove value: {0} status: {1}", removeValue1, tree.Remove(removeValue1));
            Console.WriteLine(tree.ToString());

            //тест удаление с 2 детьми 
            int removeValue2 = 3;
            Console.WriteLine("Remove value: {0} status: {1}", removeValue2, tree.Remove(removeValue2));
            Console.WriteLine(tree.ToString());

            //тест удаление с 2 детьми 
            int removeValue3 = 16;
            Console.WriteLine("Remove value: {0} status: {1}", removeValue3, tree.Remove(removeValue3));
            Console.WriteLine(tree.ToString());

            //тест удаление только корня
            Tree<int> tree4 = new Tree<int>();
            int removeValue4 = 8;
            tree4.Add(removeValue4);
            tree4.Add(12);
            Console.WriteLine("Remove value: {0} status: {1}", removeValue4, tree4.Remove(removeValue4));
            Console.WriteLine(tree4.ToString());

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

            Console.WriteLine();
            Console.WriteLine("--------------------Test iterator depth recursion---------------");
            //итератор для обхода в глубину с реккурсией
            IEnumerator<int> iteratorDepthWithRecursion = tree.WayGoDepthWithRecursion().GetEnumerator();
            while (iteratorDepthWithRecursion.MoveNext())
            {
                Console.WriteLine(iteratorDepthWithRecursion.Current);
            }

            Console.ReadKey();
        }
    }
}
