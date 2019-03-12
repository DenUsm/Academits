using System;

namespace ListTask
{
    class ListTask
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> my = new SinglyLinkedList<int>();
            my.Add(50);
            my.Add(40);
            my.Add(30);
            my.Add(20);
            my.Add(10);

            Console.WriteLine("Get size of list - {0}", my.Count);
            Console.WriteLine("Get first value - {0}", my.GetValue());

            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.Write("Get values by indexes ");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("----------------------------------ChangeValueAt--------------------------------------------------------------");
            int value = 500;
            Console.WriteLine("Change value by index old value - {0}, new value - {1}", my.ChangeValueAt(5, value), my.GetValueAt(5));

            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("------------------------------Test-Remove--------------------------------------------------------");
            Console.WriteLine("RemoveAt value {0}", my.RemoveAt(1));
            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("RemoveAt value {0}", my.RemoveAt(my.Count));
            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            my.Add(10);
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("RemoveAt value {0}", my.RemoveAt(1));
            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("------------------------------Test-Insert---------------------------------------------------------");
            my.Insert(1, 100);
            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            my.Insert(my.Count, 300);
            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            my.Insert(3, 200);
            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("------------------------------RemoveByValue---------------------------------------------------------");
            Console.WriteLine(my.RemoveByValue(400).ToString());
            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine(my.RemoveByValue(40).ToString());
            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("------------------------------CopyList---------------------------------------------------------");
            SinglyLinkedList<int> myNew = new SinglyLinkedList<int>();
            myNew = my.Copy();

            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", myNew.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", myNew.ToString(), myNew.Count);

            int value1 = 888;
            Console.WriteLine("Change value by index old value - {0}, new value - {1}", my.ChangeValueAt(5, value1), my.GetValueAt(5));

            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", myNew.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", myNew.ToString(), myNew.Count);

            Console.WriteLine("------------------------------Reverse---------------------------------------------------------");
            my.Reverse();
            Console.WriteLine("Get values by indexes");
            for (int i = 1; i <= my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.ReadKey();
        }
    }
}
