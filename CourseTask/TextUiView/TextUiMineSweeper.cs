using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace TextUiView
{
    public class TextUiMineSweeper
    {
        private int width;
        private int height;
        private int[,] cell;

        //Список главного меню
        private List<string> mainMenu = new List<string>();

        //Список подменю Сложность
        private List<string> subMenuLavel = new List<string>();

        private int menuIndex = 0;

        public TextUiMineSweeper()
        {
            Initialize();
        }

        //задание размеров поле для построение gui
        public void SetGuiParameter(int width, int height)
        {
            this.width = width;
            this.height = height;
            cell = new int[width, height];
        }

        //задание значения индекса меню
        public void SetIndex(int index)
        {
            menuIndex = 0;
        }

        //Получение главного меню 
        public int GetMenu()
        {
            return DrawMenu(mainMenu);
        }

        //Получение подменю
        public int GetSubMenu()
        {
            return DrawMenu(subMenuLavel);
        }

        //Функция отрисовки меню
        private int DrawMenu(List<string> items)
        {
            ShowScreensaver();
            ShowGameMenu(items);

            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (menuIndex == items.Count - 1)
                {
                    menuIndex = 0;
                }
                else { menuIndex++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (menuIndex <= 0)
                {
                    menuIndex = items.Count - 1;
                }
                else { menuIndex--; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                return menuIndex;
            }

            Console.Clear();
            return -1;
        }

        //Получение описание перечисления
        private string GetDescription(Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description;
        }

        //Функция выывода начальной заствки для игры
        public void ShowScreensaver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("//                                                                      //");
            Console.WriteLine("//                    Вас приветсвует игра сапер!!!                     //");
            Console.WriteLine("//                        Автор: Усманов Денис                          //");
            Console.WriteLine("//                                                                      //");
            Console.WriteLine("//                               v1.0                                   //");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();
        }

        public void ShowGameMenu(List<string> items)
        {
            string formatFirst = "//                                                                      //";
            string formatSecond = "//                            ";

            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.WriteLine(formatFirst);

            //Вывод списка в консоль
            for (int i = 0; i < items.Count; i++)
            {
                if (i == menuIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("{0}//", (formatSecond + items[i]).PadRight(formatFirst.Length - 2, ' '));
                }
                else
                {
                    Console.WriteLine("{0}//", (formatSecond + items[i]).PadRight(formatFirst.Length - 2, ' '));
                }
                Console.ResetColor();
            }

            Console.WriteLine(formatFirst);
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
        }

        private void Initialize()
        {
            foreach (var value in Enum.GetValues(typeof(MainMenu)))
            {
                mainMenu.Add(GetDescription((MainMenu)value));
            }

            foreach (var value in Enum.GetValues(typeof(SubMenuLevel)))
            {
                subMenuLavel.Add(GetDescription((SubMenuLevel)value));
            }
        }
    }
}
