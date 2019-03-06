using System;

namespace ListTask
{
    class ListTask
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> my = new SinglyLinkedList<int>();
            Console.WriteLine(my.GetCount());

            my.Add(3);
            Console.WriteLine(my.GetCount());

            int firstValue = my.GetValue();
            Console.WriteLine(firstValue);

            Console.ReadKey();
        }
    }
}
