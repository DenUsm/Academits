﻿using System;
using System.Collections.Generic;

namespace ArrayListTask
{
    class ArrayListTask
    {
        static void Main(string[] args)
        {
            MyList<int> my = new MyList<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120 };

            Console.WriteLine("---------------------------------------Test Add---------------------------------");
            Console.WriteLine("Values {0} - {1}", my.ToString(), my.Count);

            Console.WriteLine();
            Console.WriteLine("---------------------------------------Test Get Set---------------------------------");
            Console.WriteLine("Get " + my[0].ToString());
            my[0] = 55;
            Console.WriteLine("Set 55");
            Console.WriteLine("Get " + my[0].ToString());

            Console.WriteLine();
            Console.WriteLine("---------------------------------------Test RemoveAt---------------------------------");
            int index = 3;
            my.RemoveAt(index);
            Console.WriteLine("Remove values by index {0} {1} {2}", index, my.ToString(), my.Count);
            int index1 = 5;
            my.RemoveAt(index1);
            Console.WriteLine("Remove values by index {0} {1} {2}", index1, my.ToString(), my.Count);

            Console.WriteLine();
            Console.WriteLine("---------------------------------------Test Contains---------------------------------");
            int value = 10;
            Console.WriteLine("Value {0} {1}", value, my.Contains(value).ToString());
            value = 40;
            Console.WriteLine("Value {0} {1}", value, my.Contains(value).ToString());

            Console.WriteLine();
            Console.WriteLine("---------------------------------------Test IndexOf---------------------------------");
            int value3 = 20;
            Console.WriteLine("Index by value {0} is {1}", value3, my.IndexOf(value3));

            Console.WriteLine();
            Console.WriteLine("---------------------------------------Test Insert---------------------------------");
            int value4 = 88;
            int index2 = 6;
            my.Insert(index2, value4);
            Console.WriteLine("Insert value {0} to index {1} {2} {3}", value4, index2, my.ToString(), my.Count);

            Console.WriteLine();
            Console.WriteLine("---------------------------------------Test Remove---------------------------------");
            int value5 = 88;
            Console.WriteLine("Remove value {0} {1} {2} {3}", value5, my.Remove(value5).ToString(), my.ToString(), my.Count);

            int value6 = 111;
            Console.WriteLine("Remove value {0} {1} {2} {3}", value6, my.Remove(value6).ToString(), my.ToString(), my.Count);

            Console.WriteLine();
            Console.WriteLine("---------------------------------------Test CopyTo---------------------------------");

            int [] array = new int[20];
            my.CopyTo(array, 5);

            foreach(int val in array)
            {
                Console.Write(val + " ");
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------------------Test Enumerator---------------------------------");
            IEnumerator<int> iterator = my.GetEnumerator();

            while (iterator.MoveNext())
            {
                int text = iterator.Current;
                Console.Write(text + " ");
            }

            Console.ReadKey();
        }
    }
}
