using System;
using System.IO;
using System.Text;

namespace CSVTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string strAllFile;
            using (StreamReader reader = new StreamReader(@"Example.csv", Encoding.Default))
            {
                string currentLine;
                while((currentLine = reader.ReadLine()) != null)
                {
                    string[] str1 = currentLine.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    //CrateHTMLFile(str[0]);
                }
                

            //пока запятая не в конце чиатть по одной строке и накапливать
            }
           


            //foreach(string value in str)
            //{
            //    Console.WriteLine(value);
            //}

            Console.ReadKey();
        }

        //public static void CrateHTMLFile(string str)
        //{
        //    int indexInitial = 0;
        //    int entriesCount = 0;
        //
        //    while (true)
        //    {
        //        int findIndex = findString.IndexOf(compareString, indexInitial);
        //        if (findIndex == -1)
        //        {
        //            break;
        //        }
        //        indexInitial = findIndex + compareString.Length;
        //        entriesCount++;
        //    }
        //    return entriesCount;
        //
        //    int index = str.IndexOf(',');
        //    string row1 = str.Substring(0, index);
        //}
    }
}
