using System;

namespace ArrayListTask
{
    class ArrayListTask
    {
        static void Main(string[] args)
        {
            MyList<int> my = new MyList<int>();

            Console.WriteLine("---------------------------------------Test Add---------------------------------");
            my.Add(10);
            my.Add(20);
            my.Add(30);
            my.Add(40);
            my.Add(50);
            my.Add(60);
            Console.WriteLine("Values {0} - {1}", my.ToString(), my.Count);

            Console.WriteLine("---------------------------------------Test RemoveAt---------------------------------");
            my.RemoveAt(3);
            Console.WriteLine("Values {0} - {1}", my.ToString(), my.Count);

            Console.ReadKey();
        }
    }
}
