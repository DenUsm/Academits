﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            using (StreamReader reader = new StreamReader(@"Example.csv", Encoding.Default))
            {
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
            TransformationCellsValue(list);
            WriteHtmlFile(list);
            Console.ReadKey();
        }

        public static void WriteHtmlFile(List<string> list)
        {
            using (StreamWriter writer = new StreamWriter(@"index.html"))
            {
                writer.WriteLine("<html>");
                writer.WriteLine("<body>");
                writer.WriteLine("<table border = \"1\" cellspacing = \"0\">");
                writer.WriteLine("<tr>");
                for (int i = 0; i < list.Count; i++)
                {
                    writer.WriteLine(list[i]);
                }
                writer.WriteLine("</table>");
                writer.WriteLine("</body>");
                writer.WriteLine("</html>");
            }
            Console.WriteLine("Get Html file success");
        }

        public static string[] GetCellsFromCsv(string input)
        {
            List<string> list = new List<string>();
            int count = 0;

            int indexEndCell = 0;
            string result = "";

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
                        result = input.Substring(count, indexEndCell - count + 1);
                        count += indexEndCell - count + 1;
                        list.Add(result);
                    }
                    else
                    {
                        if ((input[count + 2].ToString().Equals("\"")) && (input[count + 3].ToString().Equals(",")))
                        {
                            indexEndCell += 3;
                        }

                        result = input.Substring(count, indexEndCell - count + 1);
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
                        result = input.Substring(count, indexEndCell - count + 1);
                        count += input.Length - count;
                    }
                    else
                    {
                        result = input.Substring(count, indexEndCell - count + 2);
                        count += indexEndCell - count + 2;
                    }

                    list.Add(result);
                }
            }
            //Если запятая последний символ то есть пустая строка
            if (input[count - 1].ToString().Equals(","))
            {
                list.Add(" ");
            }

            return list.ToArray();
        }

        public static void TransformationCellsValue(List<string> list)
        {
            string beginSymbol;
            string lastSymbol;
            string attribute = "\"";

            for (int i = 0; i < list.Count; i++)
            {
                string str = list[i];
                beginSymbol = str[0].ToString();
                lastSymbol = str[str.Length - 1].ToString();

                if (!beginSymbol.Equals(attribute) && (lastSymbol.Equals(",")))
                {
                    list[i] = "<td>" + ReplaceSymbol(str.Substring(0, str.Length - 1)) + "</td>";
                }
                if (beginSymbol.Equals(attribute) && !(lastSymbol.Equals(",")))
                {
                    if (lastSymbol.Equals(attribute))
                    {
                        list[i] = "<td>" + ReplaceSymbol(str.Substring(1, str.Length - 3)) + "</td></tr>";
                    }
                    else
                    {
                        list[i] = "<td>" + ReplaceSymbol(str.Substring(1, str.Length - 1)) + "<br/>";

                        str = list[i + 1];
                        beginSymbol = str[0].ToString();
                        lastSymbol = str[str.Length - 1].ToString();

                        if (lastSymbol.Equals(","))
                        {
                            list[i] += ReplaceSymbol(str.Substring(0, str.Length - 2)) + "</td>";
                        }
                        else
                        {
                            list[i] += ReplaceSymbol(str.Substring(0, str.Length - 2)) + "</td></tr><tr>";
                        }

                        list.RemoveAt(i + 1);
                    }
                }
                if (!beginSymbol.Equals(attribute) && !(lastSymbol.Equals(",")))
                {
                    list[i] = "<td>" + ReplaceSymbol(str.Substring(0, str.Length - 1)) + "</td></tr><tr>";
                }
                if (beginSymbol.Equals(attribute) && (lastSymbol.Equals(",")))
                {
                    list[i] = "<td>" + ReplaceSymbol(str.Substring(1, str.Length - 3)) + "</td>";
                }
            }
        }

        public static string ReplaceSymbol(string input)
        {
            string[] symbol = new string[] { "\"\"", "<", ">", "&" };
            string[] symbolReplace = new string[] { "\"", "&lt", "&gt", "&amp" };

            for (int i = 0; i < symbol.Length; i++)
            {
                input = input.Replace(symbol[i], symbolReplace[i]);
            }
            return input;
        }
    }
}
