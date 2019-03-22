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
            MyHash.Add("Воскресение");
            MyHash.Add("Анна Каренина");
            MyHash.Add("Золотой теленок");
            MyHash.Add("Капитанская дочка");
            MyHash.Add("Горе от ума");
            MyHash.Add("Обломов");
            MyHash.Add("Старик и море");
            MyHash.Add("Три мушкетера");

            //MyHash.Add(null);
            //MyHash.Add("Преступление и наказание");
            //MyHash.Add("Война и мир");
            //MyHash.Add("Братья Карамазовы");
            //MyHash.Add("Мёртвые души");
            //MyHash.Add("Евгений Онегин");
            //MyHash.Add("Граф Монте-Кристо");
            //MyHash.Add(null);
            //MyHash.Add("Воскресение");
            //MyHash.Add("Анна Каренина");
            //MyHash.Add(null);
            //MyHash.Add("Капитанская дочка");
            //MyHash.Add("Горе от ума");
            //MyHash.Add("Обломов");
            //MyHash.Add("Старик и море");
            //MyHash.Add("Три мушкетера");
            Console.Write(MyHash.ToString());

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------Test Contains---------------------------------");
            string value1 = "Золотой теленок";
            Console.WriteLine("Value: {0} Result: {1}", value1, MyHash.Contains(value1));

            string value2 = "Три мушкетера";
            Console.WriteLine("Value: {0} Result: {1}", value2, MyHash.Contains(value2));

            string value3 = "Евгений Онегин";
            Console.WriteLine("Value: {0} Result: {1}", value3, MyHash.Contains(value3));

            string value4 = "Робинзон Крузо";
            Console.WriteLine("Value: {0} Result: {1}", value4, MyHash.Contains(value4));

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------Test Remove------------------------------------");
            string value5 = "Золотой теленок";
            Console.WriteLine("Value: {0} Result: {1}", value5, MyHash.Remove(value5));
            Console.Write(MyHash.ToString());

            Console.WriteLine();
            string value6 = "Робинзон Крузо";
            Console.WriteLine("Value: {0} Result: {1}", value6, MyHash.Remove(value6));
            Console.Write(MyHash.ToString());

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------Test CopyTo------------------------------------");
            string[] array = new string[20];
            MyHash.CopyTo(array, 2);

            foreach (string value in array)
            {
                Console.WriteLine((value == null) ? "null" : value);
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------Test Iterator-----------------------------");
            IEnumerator<string> iterator = MyHash.GetEnumerator();
            while (iterator.MoveNext())
            {
                Console.WriteLine("Value: {0}", iterator.Current);
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------Test Clear------------------------------------");
            MyHash.Clear();
            Console.Write(MyHash.ToString());

            Console.ReadKey();
        }
    }
}
