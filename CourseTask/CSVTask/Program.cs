using System;
using System.IO;
using System.Text;

namespace CSVTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = {";"};
            using (StreamReader reader = new StreamReader(@"Example.csv", Encoding.Default))
            {
                string currentLine;
                while((currentLine = reader.ReadLine()) != null)
                {
                    str = currentLine.Split(str, StringSplitOptions.RemoveEmptyEntries);
                }
            }


            foreach(string value in str)
            {
                Console.WriteLine(value);
            }

            Console.ReadKey();
        }

        //public static void CrateHTMLFile(string str)
        //{
        //
        //}
    }
}
