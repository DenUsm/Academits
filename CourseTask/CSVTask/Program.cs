using System;
using System.Collections.Generic;
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
                List<string> list = new List<string>();
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    string[] res = GetCellsFromCsv(str);
                    foreach (string value in res)
                    {
                        list.Add(value);
                    }
                }
            }
            Console.ReadKey();
        }

        public static string[] GetCellsFromCsv(string input)
        {
            List<string> list = new List<string>();
            int count = 0;

            int indexEndCell = 0;
            string result = "";
            string test = "";

            while (count != input.Length)
            {
                //Проверяем начинатся ли строка с буквы
                if (char.IsLetter(input[count]))
                {
                    indexEndCell = input.IndexOf(",", count);

                    if (indexEndCell == -1)
                    {
                        result = input.Substring(count, input.Length - count);
                        list.Add(result);
                        count += input.Length - count;
                        continue;
                    }

                    if (!input[indexEndCell - 1].ToString().Equals("\""))
                    {
                        result = input.Substring(count, indexEndCell - count);
                        count += indexEndCell - count + 1;
                        list.Add(result);
                    }
                    else
                    {
                        if ((input[count + 2].ToString().Equals("\"")) && (input[count + 3].ToString().Equals(",")))
                        {
                            indexEndCell += 3;
                        }

                        result = input.Substring(count, indexEndCell - count);
                        count += indexEndCell - count + 1;
                        list.Add(result);
                    }
                }
                else if (input[count].ToString().Equals("\""))
                {
                    indexEndCell = input.IndexOf("\",", count);

                    if (indexEndCell == -1)
                    {
                        result = input.Substring(count, input.Length - count);
                        count += input.Length - count;
                    }
                    else if ((input[indexEndCell + 2].ToString().Equals("\"")) && (input[indexEndCell + 3].ToString().Equals(",")))
                    {
                        indexEndCell += 3;
                        result = input.Substring(count, indexEndCell - count);
                        count += input.Length - count;
                    }
                    else
                    {
                        result = input.Substring(count, indexEndCell - count + 1);
                        count += indexEndCell - count + 2;
                    }

                    list.Add(result);
                }
            }
            //Если запятая последний символ то есть пустая строка
            if (input[count - 1].ToString().Equals(","))
            {
                list.Add("");
            }

            return list.ToArray();
        }

        public static void ReplaceSomeSymbol(string input, string [] symbol, string [] replaceSymbol)
        {
            string beginSymbol = input[0].ToString();
            string lastSymbol = input[input.Length - 1].ToString();
            string attribute = "\"";

            string result;
            if (!beginSymbol.Equals(attribute) && !lastSymbol.Equals(attribute))
            {
                result = input;
            }
            else if ()


            if(!beginSymbol.Equals(symbol[0]))
            //рассмотреть 4 случая получения строк, получить сами эти строки и потом 
            int index = input.IndexOf("\"");

            if (input[index].ToString().Equals(input[index + 1].ToString()))
            {
                input.Remove(index, 1);
            }
        }
    }
}
