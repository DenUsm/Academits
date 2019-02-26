using System;
using System.IO;
using System.Text;

namespace CSVTask
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"Example.csv", Encoding.Default))
            {
                string firstAttributeEndCellWithQuotes = ",\"";
                string secondAttributeEndCellWithQuotes = "\",";
                string attributeEndCellWithoutQuotes = ",";
                string attributeCommaOrBreakLine = "\"";

                string str;

                while ((str = reader.ReadLine()) != null)
                {
                    int indexInitial = 0;

                    while (true)
                    {
                        //Проверка начинается ли ячейка с кавычек
                        if (!str[indexInitial].ToString().Equals(attributeCommaOrBreakLine))
                        {                     
                            int indexEndCell = str.IndexOf(attributeEndCellWithoutQuotes, indexInitial);

                            if (indexEndCell == -1)
                            {
                                break;
                            }

                            int lengthAttribute = attributeEndCellWithoutQuotes.Length;
                            string result = "<td>" + str.Substring(indexInitial, indexEndCell) + "</td>";
                            indexInitial = indexEndCell + lengthAttribute;
                        }
                        else
                        {
                            //Находим индексы возможных вариантов окончания ячейки
                            int firstIndexEndCell = str.IndexOf(firstAttributeEndCellWithQuotes, indexInitial);
                            int secondIndexEndCell = str.IndexOf(secondAttributeEndCellWithQuotes, indexInitial);

                            //вариант окончания ячейки ,\" и следом ,
                            if ((firstIndexEndCell != -1) && (str[firstIndexEndCell + firstAttributeEndCellWithQuotes.Length].ToString() == ","))
                            {
                                int lengthAttribute = firstAttributeEndCellWithQuotes.Length;
                                string result = str.Substring(firstIndexEndCell, str.Length - firstIndexEndCell - lengthAttribute);
                                indexInitial = firstIndexEndCell + lengthAttribute;
                            }
                            //вариант окончания ячейки \", и следом нет ,
                            else if ((secondIndexEndCell != -1) && (str[secondIndexEndCell + secondAttributeEndCellWithQuotes.Length].ToString() != ","))
                            {
                                int lengthAttribute = secondAttributeEndCellWithQuotes.Length;
                                string result = str.Substring(secondIndexEndCell, str.Length - secondIndexEndCell - lengthAttribute);
                                indexInitial = secondIndexEndCell + lengthAttribute;
                            }
                            //нет окончания значит перенос строки
                            else
                            {
                                int indexEndCell = str.IndexOf(attributeCommaOrBreakLine, indexInitial);
                                int lengthAttribute = attributeCommaOrBreakLine.Length;
                                string result = "<td>" + str.Substring(indexInitial + lengthAttribute, str.Length - indexInitial - lengthAttribute) + "<br/>";
                                indexInitial += lengthAttribute;
                            }
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
