using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CSVTask
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"Example.csv", Encoding.Default))
            {
                string str;

                while ((str = reader.ReadLine()) != null)
                {
                    SplitCSV(str);
                }             
            }
            Console.ReadKey();
        }

        public static string[] SplitCSV(string input)
        {
            List<string> list = new List<string>();
            int index = 0;
            int count = 0;

            while (count != input.Length)
            {
                if (char.IsLetter(input[count]))
                {
                    int indexEndCell = input.IndexOf(",", index);
                    string result = input.Substring(index, indexEndCell - index);
                    count += indexEndCell + 1;
                    list.Add(result);

                    string test = input[count].ToString();
                }
            }

            return list.ToArray();
        }


        public static string [] MySeparatorString(string str)
        {
            string attributeCommaOrBreakLine = "\"";
            string attributeEndCellWithoutQuotes = ",";
            string attributeEndCellWithQuotes = "\",";
            string attribute = "<br/>";

            int indexInitial = 0;

            while (true)
            {
                //Проверяем начинается ли ячейка с ковычек
                if (str[indexInitial].ToString().Equals(attributeCommaOrBreakLine))
                {
                    int indexEndCell = str.IndexOf(attributeEndCellWithQuotes, indexInitial);
                    int index = indexEndCell + attributeEndCellWithQuotes.Length;

                    //проверяем на конец ячейки
                    if ((indexEndCell != -1) && (!str[index].ToString().Equals(",")))
                    {
                        //Проверяем вариант когда конец \",\",
                        if ((str[index].ToString().Equals(attributeCommaOrBreakLine)) && (str[index + 1].ToString().Equals(attributeEndCellWithoutQuotes)))
                        {
                            indexEndCell += 2;
                        }

                        int lengthAttribute = attributeEndCellWithQuotes.Length;
                        string result = "<td>" + str.Substring(indexInitial + 1, indexEndCell - indexInitial - 1) + "</td>";
                        indexInitial = indexEndCell + 1;
                        string test = str[indexInitial].ToString();
                    }
                }
                //Находим конец строки
                else if (str[indexInitial].ToString().Equals(attributeEndCellWithoutQuotes))
                {
                    int indexEndCell = str.IndexOf(attribute, indexInitial);
                    int lengthAttribute = attribute.Length;
                    string result = "<td>" + str.Substring(indexInitial + 1, indexEndCell - indexInitial - 1) + "</td></tr>";
                    indexInitial = indexEndCell + attribute.Length;
                    string test = str[indexInitial].ToString();
                }
                else
                {
                    //Ищем данные в ячейки заканчивающиеся запятой
                    int indexEndCell = str.IndexOf(attributeEndCellWithoutQuotes, indexInitial);
                    int lengthAttribute = attributeEndCellWithoutQuotes.Length;
                    string result = "<tr><td>" + str.Substring(indexInitial, indexEndCell - indexInitial) + "</td>";
                    indexInitial = indexEndCell + lengthAttribute;
                    string test = str[indexInitial].ToString();
                }
            }
        }
    }
}
