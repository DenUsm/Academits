using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            using (StreamReader reader = new StreamReader(@".\File\TextFile.txt"))
            {
                string currentLine;
                while((currentLine = reader.ReadLine()) != null)
                {
                    list.Add(currentLine);
                }
            }

            foreach (string str in list)
            {
                Console.WriteLine(str);
            }

            Console.ReadKey();
        }
    }
}
