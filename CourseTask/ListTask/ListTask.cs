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

            Console.WriteLine(my.RemoveByValue(20).ToString());
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

            Console.WriteLine(my.RemoveByValue(100).ToString());
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

            SinglyLinkedList<string> testCopy = new SinglyLinkedList<string>();
            testCopy.AddFirst(null);
            testCopy.AddFirst("test");
            testCopy.AddFirst(null);

            SinglyLinkedList<string> testCopy1 = new SinglyLinkedList<string>();
            testCopy1 = testCopy.Copy();


            Console.WriteLine("------------------------------REMOVE---------------------------------------------------------");
            SinglyLinkedList<int> rem1 = new SinglyLinkedList<int>();
            rem1.AddFirst(50);
            rem1.AddFirst(40);
            rem1.AddFirst(30);
            rem1.AddFirst(20);
            rem1.AddFirst(10);

            for(int i = 0; i < rem1.Count; i = i + 2)
            {
                int param = rem1.GetValueAt(i);
                Console.WriteLine("Remove value {0} status {1} list {2} {3}", param, rem1.RemoveByValue(param), rem1.ToString(), rem1.Count);
                rem1.Insert(i, param);
            }

            SinglyLinkedList<string> rem2 = new SinglyLinkedList<string>();
            rem2.AddFirst("5");
            rem2.AddFirst("4");
            rem2.AddFirst("3");
            rem2.AddFirst("2");
            rem2.AddFirst("1");

            for (int i = 0; i < rem2.Count; i = i + 2)
            {
                string param1 = null;
                Console.WriteLine("Remove value {0} status {1} list {2} {3}", param1, rem2.RemoveByValue(param1), rem2.ToString(), rem2.Count);
                rem2.Insert(i, param1);
            }

            Console.ReadKey();
        }
    }
}
