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

            Console.WriteLine("Get size of list - {0}", my.GetCount());
            Console.WriteLine("Get first value - {0}", my.GetValue());

            Console.WriteLine("------------------------------------------------------------------------------------------------");
            Console.Write("Get values by indexes ");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            Console.WriteLine("------------------------------------------------------------------------------------------------");
            int value = 500;
            Console.WriteLine("Change value by index old value - {0}, new value - {1}", my.ChangeValueAt(4, value), my.GetValueAt(4));
            
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            Console.WriteLine("------------------------------Test-Remove--------------------------------------------------------");
            Console.WriteLine("RemoveAt value {0}", my.RemoveAt(0));
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            Console.WriteLine("RemoveAt value {0}", my.RemoveAt(my.GetCount() - 1));
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            my.Add(10);
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            Console.WriteLine("RemoveAt value {0}", my.RemoveAt(1));
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            Console.WriteLine("------------------------------Test-Insert---------------------------------------------------------");
            my.Insert(0, 100);
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            my.Insert(my.GetCount() - 1, 300);
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            my.Insert(3, 200);
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            Console.WriteLine("------------------------------RemoveAt(value)---------------------------------------------------------");
            Console.WriteLine(my.RemoveAtValue(400).ToString());
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            Console.WriteLine(my.RemoveAtValue(40).ToString());
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            Console.WriteLine("------------------------------CopyList---------------------------------------------------------");
            SinglyLinkedList<int> myNew = new SinglyLinkedList<int>();
            myNew = my.Copy();

            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < myNew.GetCount(); i++)
            {
                Console.Write("{0} ", myNew.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", myNew.ToString(), myNew.GetCount());

            int value1 = 888;
            Console.WriteLine("Change value by index old value - {0}, new value - {1}", my.ChangeValueAt(4, value1), my.GetValueAt(4));

            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < my.GetCount(); i++)
            {
                Console.Write("{0} ", my.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", my.ToString(), my.GetCount());

            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < myNew.GetCount(); i++)
            {
                Console.Write("{0} ", myNew.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", myNew.ToString(), myNew.GetCount());

            Console.WriteLine("------------------------------Reverse---------------------------------------------------------");
            myNew.Reverse();
            Console.WriteLine("Get values by indexes");
            for (int i = 0; i < myNew.GetCount(); i++)
            {
                Console.Write("{0} ", myNew.GetValueAt(i));
            }
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", myNew.ToString(), myNew.GetCount());

            Console.ReadKey();
        }
    }
}
