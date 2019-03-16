using System;

namespace ListTask
{
    class ListTask
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> my = new SinglyLinkedList<int>();
            my.AddFirst(50);
            my.AddFirst(40);
            my.AddFirst(30);
            my.AddFirst(20);
            my.AddFirst(10);

            Console.WriteLine("Get size of list - {0}", my.Count);
            Console.WriteLine("Get first value - {0}", my.GetFirstValue());

            Console.WriteLine("------------------------------------------------------------------------------------------------");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("----------------------------------ChangeValueAt------------------------------------------");
            int value = 500;
            Console.WriteLine("Change value by index old value - {0}, new value - {1}", my.ChangeValueAt(my.Count - 1, value), my.GetValueAt(my.Count - 1));

            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("------------------------------Test-Remove-------------------------------------------------");
            Console.WriteLine("RemoveAt value {0}", my.RemoveAt(0));
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("RemoveAt value {0}", my.RemoveAt(my.Count - 1));
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            my.AddFirst(10);
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("RemoveAt value {0}", my.RemoveAt(2));
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("------------------------------Test-Insert---------------------------------------------------");
            my.Insert(0, 100);
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            my.Insert(my.Count - 1, 300);
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            my.Insert(2, 200);
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("------------------------------RemoveByValue--------------------------------------------------");
            Console.WriteLine(my.RemoveByValue(400).ToString());
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine(my.RemoveByValue(40).ToString());
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine();
            Console.WriteLine("------------------------------RemoveByValue with null value-----------------------------------");
            SinglyLinkedList<string> testNull = new SinglyLinkedList<string>();

            testNull.AddFirst(null);
            testNull.AddFirst("test");
            testNull.AddFirst(null);

            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < testNull.Count; i++)
            {
                Console.Write("{0} ", testNull.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", testNull.ToString(), testNull.Count);

            Console.WriteLine(testNull.RemoveByValue(null).ToString());
            Console.WriteLine(testNull.RemoveByValue("test").ToString());

            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < testNull.Count; i++)
            {
                Console.Write("{0} ", testNull.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", testNull.ToString(), testNull.Count);

            Console.WriteLine("------------------------------CopyList---------------------------------------------------------");
            SinglyLinkedList<int> myNew = new SinglyLinkedList<int>();
            myNew = my.Copy();

            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", myNew.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", myNew.ToString(), myNew.Count);

            int value1 = 888;
            Console.WriteLine("Change value by index old value - {0}, new value - {1}", my.ChangeValueAt(my.Count - 1, value1), my.GetValueAt(my.Count - 1));

            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", myNew.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", myNew.ToString(), myNew.Count);

            Console.WriteLine("------------------------------Reverse---------------------------------------------------------");
            my.Reverse();
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.Count; i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.Count);

            SinglyLinkedList<int> test = new SinglyLinkedList<int>();
            test.Insert(0, 5);
            Console.WriteLine("{0} = {1}", test.ToString(), test.Count);

            Console.ReadKey();
        }
    }
}
