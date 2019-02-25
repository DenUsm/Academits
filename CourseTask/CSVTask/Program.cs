using System;
using System.IO;
using System.Text;

namespace CSVTask
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"D:\example.txt", Encoding.Default))
            {


                string strAllLine = "";
                string str;

                while ((str = reader.ReadLine()) != null)
                {
                    strAllLine += str + "<br/>";
                }
                TransferHtml(strAllLine);
            }

            Console.ReadKey();
        }



        public static void TransferHtml(string str)
        {
            string firstAttributeEndCellWithQuotes = ",\"";
            string secondAttributeEndCellWithQuotes = "\",";
            string attributeEndCellWithoutQuotes = ",";
            string attributeCommaOrBreakLine = "\"";
            string attributeTag = "<br/>";

            int indexInitial = 0;
            bool breakLine = false;

            while (true)
            {
                //Проверка начинается ли ячейка с кавычек
                if (!str[indexInitial].ToString().Equals(attributeCommaOrBreakLine))
                {
                    if (!breakLine)
                    {
                        int indexEndCell = str.IndexOf(attributeEndCellWithoutQuotes, indexInitial);
                        string result = "<td>" + str.Substring(indexInitial, indexEndCell - indexInitial) + "</td>";
                        indexInitial = indexEndCell + attributeEndCellWithoutQuotes.Length;
                    }
                    else
                    {
                        int indexEndCell = str.IndexOf(attributeTag, indexInitial);
                        string result = "<td>" + str.Substring(indexInitial + 1, indexEndCell - indexInitial - 1) + "</td>";
                        indexInitial = indexEndCell + attributeEndCellWithoutQuotes.Length;
                        breakLine = false;
                    }
                }
                else
                {
                    //Находим индексы возможных вариантов окончания ячейки
                    int firstIndexEndCell = str.IndexOf(firstAttributeEndCellWithQuotes, indexInitial);
                    int secondIndexEndCell = str.IndexOf(secondAttributeEndCellWithQuotes, indexInitial);

                    //вариант окончания ячейки ,\" и следом ,
                    if ((firstIndexEndCell != -1) && (str[firstIndexEndCell + firstAttributeEndCellWithQuotes.Length].ToString().Equals(",")))
                    {
                        int lengthAttribute = firstAttributeEndCellWithQuotes.Length;
                        string result = str.Substring(indexInitial + 1, firstIndexEndCell - indexInitial);
                        indexInitial = firstIndexEndCell + 1;
                        breakLine = true;
                    }
                    //вариант окончания ячейки \", и следом нет ,
                    else if ((secondIndexEndCell != -1) && (!str[secondIndexEndCell + secondAttributeEndCellWithQuotes.Length].ToString().Equals(",")))
                    {
                        int lengthAttribute = secondAttributeEndCellWithQuotes.Length;
                        string result = str.Substring(indexInitial + 1, secondIndexEndCell - indexInitial - 1);
                        indexInitial = secondIndexEndCell + 1;
                        breakLine = true;
                    }
                }
            }
        }
    }
}
