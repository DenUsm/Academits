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
            string inputCsvPath = args[0];
            string outputHtmlPath = args[1];

            List<string> list = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(inputCsvPath, Encoding.Default))
                {
                    using (StreamWriter writer = new StreamWriter(outputHtmlPath))
                    {
                        string str;
                        bool lineBreak = false;

                        writer.Write("<!DOCTYPE html>");
                        writer.Write("<html>");
                        writer.Write("<head>");
                        writer.Write("<meta charset=\"UTF-8\">");
                        writer.Write("<meta name=\"description\" content=\"CSV to HTML\">");
                        writer.Write("<meta name=\"author\" content=\"Denis Usmanov\">");
                        writer.Write("</head>");
                        writer.Write("<body>");
                        writer.Write("<table border=\"1\" cellspacing=\"0\">");
                        writer.Write("<tr>");
                        writer.Write("<td>");

                        while ((str = reader.ReadLine()) != null)
                        {
                            //string res = "";
                            int length = str.Length - 1;

                            for (int i = 0; i <= length; i++)
                            {
                                //If cells initial by "\""
                                if (!str[i].ToString().Equals("\""))
                                {
                                    for (int j = i; j <= length; j++)
                                    {
                                        if (!str[j].ToString().Equals(","))
                                        {
                                            //Check and replace exception symbol
                                            switch (str[j].ToString())
                                            {
                                                case "\"":
                                                    if (lineBreak)
                                                    {
                                                        writer.Write("</td><td>");
                                                        j++;
                                                        lineBreak = false;
                                                        continue;
                                                    }
                                                    else if ((str[j].ToString() + str[j + 1].ToString()) == "\"")
                                                    {
                                                        writer.Write("\"");
                                                        j++;
                                                    }
                                                    break;
                                                case "<":
                                                    writer.Write("&lt;");
                                                    break;
                                                case ">":
                                                    writer.Write("&gt;");
                                                    break;
                                                case "&":
                                                    writer.Write("&amp;");
                                                    break;
                                                default:
                                                    writer.Write(str[j].ToString());
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            writer.Write("</td><td>");
                                            i = j;
                                            break;
                                        }
                                        if (j == length)
                                        {
                                            writer.Write("</td></tr><tr><td>");
                                            i = j;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int j = i + 1; j <= length; j++)
                                    {
                                        string test1 = str[j - 1].ToString();
                                        string test2 = str[j].ToString();

                                        //Check and replace exception symbol
                                        switch (str[j].ToString())
                                        {
                                            case "\"":
                                                if (j == length)
                                                {
                                                    writer.Write("</td>");
                                                    i = j;
                                                    break;
                                                }
                                                if (str[j + 1].ToString().Equals("\""))
                                                {
                                                    writer.Write(str[j].ToString());
                                                    j++;
                                                    break;
                                                }
                                                else if (str[j + 1].ToString().Equals(","))
                                                {
                                                    if (j + 1 == length)
                                                    {
                                                        writer.Write("</td><td><tr>");
                                                    }
                                                    writer.Write("</td><td>");
                                                    j += 2;
                                                    i = j;
                                                    break;
                                                }
                                                break;
                                            case "<":
                                                writer.Write("&lt;");
                                                break;
                                            case ">":
                                                writer.Write("&gt;");
                                                break;
                                            case "&":
                                                writer.Write("&amp;");
                                                break;
                                            default:
                                                if (j == length)
                                                {
                                                    writer.Write(str[j].ToString() + "<br/>");
                                                    lineBreak = true;
                                                    i = j;
                                                }
                                                else
                                                {
                                                    writer.Write(str[j].ToString());
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }

                        writer.Write("</tr>");
                        writer.Write("</table>");
                        writer.Write("</body>");
                        writer.Write("</html>");
                    }
                }
                Console.WriteLine("Html file create. Press any key");
                Console.ReadKey();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found, please check string path");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found, please check string path");
            }
        }
    }
}
