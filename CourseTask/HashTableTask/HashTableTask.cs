using System;
using System.Collections.Generic;

namespace HashTableTask
{
    class HashTableTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------Test Add Key Value Pairs-----------------------------");
            HashTable<string> MyHash = new HashTable<string>();
            MyHash.Add("Мастер и Маргарита");
            MyHash.Add("Преступление и наказание");
            MyHash.Add("Война и мир");
            MyHash.Add("Братья Карамазовы");
            MyHash.Add("Мёртвые души");
            MyHash.Add("Евгений Онегин");
            MyHash.Add("Граф Монте-Кристо");
            MyHash.Add("Отцы и дети");

            Console.Write(MyHash.ToString());


            //Console.WriteLine();
            //Console.WriteLine("--------------------------------Get Hash after resize HashTable-----------------------------");
            //IEnumerator<string> iterator = MyHash.GetEnumerator();
            //while(iterator.MoveNext())
            //{
            //    Console.WriteLine("Hash: {0} Value: {1}", MyHash.GetHashCode(iterator.Current), iterator.Current);
            //}

            Console.ReadKey();
        }
    }
}
