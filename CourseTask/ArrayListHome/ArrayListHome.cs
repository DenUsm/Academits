using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            // 1. Прочитать в список все строки из файла
            List<string> list = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(@".\File\TextFile.txt"))
                {
                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        list.Add(currentLine);
                    }
                }
            }
            catch()
            {

            }

            foreach (string str in list)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();

            // 2. Есть список из целых чисел. Удалить из него все четные числа
            List<int> listIntegerValue = new List<int> { 1, 2, 2, 4, 5, 6, 6, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            for (int i = 0; i < listIntegerValue.Count; i++)
            {
                if (listIntegerValue[i] % 2 == 0)
                {
                    listIntegerValue.RemoveAt(i);
                    i--;
                }
            }

            foreach (int value in listIntegerValue)
            {
                Console.Write("{0} ", value);
            }

            Console.WriteLine();

            // 3. Надо создать новый список, в котором будут элементы первого списка в таком же порядке, но без повторений
            List<int> listRepeat = new List<int> { 1, 1, 1, 2, 2, 3, 4, 4, 4, 5, 6, 6, 7, 4, 4, 9, 2, 2, 2 };
            List<int> listWithoutRepeat = new List<int>();

            for (int i = 0; i < listRepeat.Count; i++)
            {
                if (!listWithoutRepeat.Contains(listRepeat[i]))
                {
                    listWithoutRepeat.Add(listRepeat[i]);
                }
            }

            Console.WriteLine();

            foreach (int value in listRepeat)
            {
                Console.Write("{0} ", value);
            }

            Console.WriteLine();

            foreach (int value in listWithoutRepeat)
            {
                Console.Write("{0} ", value);
            }

            Console.ReadKey();
        }
    }
}
