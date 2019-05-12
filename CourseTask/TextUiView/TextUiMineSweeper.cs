using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using ModelGame;

namespace TextUiView
{
    public class TextUiMineSweeper
    {
        public int X { get; set; }
        public int Y { get; set; }
        private int width;
        private int height;

        //Список главного меню
        private List<string> mainMenu = new List<string>();

        //Список подменю Сложность
        private List<string> subMenuLavel = new List<string>();

        private int menuIndex = 0;

        public TextUiMineSweeper()
        {
            Initialize();
            X = 0;
            Y = 0;
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

        //задание парамтров ширины и высоты для поля
        public void SetPaameterGui(int width, int height)
        {
            this.width = width;
            this.height = height;
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("//                                                                      //");
            Console.WriteLine("//                    Вас приветсвует игра сапер!!!                     //");
            Console.WriteLine("//                        Автор: Усманов Денис                          //");
            Console.WriteLine("//                                                                      //");
            Console.WriteLine("//                               v1.0                                   //");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();
        }

        //Функция вывода мню и подмню
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

        //Заполнение списков с парамтрами меню
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

        //Вывод информации времени об игре
        private void ShowTimeInterval(ModelMineSweeper model)
        {
            Console.WriteLine("{0}", "Время игры: " + model.Time.ToString());
        }

        //Вывод игрового поля
        public int DrawGameBoard(ModelMineSweeper model)
        {
            ShowTimeInterval(model);

            int interval = 2;

            Console.Write("".PadLeft(interval, ' '));
            for (int i = 1; i <= model.cellBoard.Width; i++)
            {
                Console.Write("{0}", i.ToString().PadLeft(interval + 1, ' '));
            }

            Console.Write(Environment.NewLine);

            Console.Write("".PadLeft(interval, ' '));
            for (int i = 0; i < (interval + 1) * model.cellBoard.Width + 1; i++)
            {
                Console.Write("-");
            }

            Console.Write(Environment.NewLine);

            for (int i = 1; i <= model.cellBoard.Height; i++)
            {
                Console.Write("{0}|", i.ToString().PadLeft(interval, ' '));
                for (int j = 1; j <= model.cellBoard.Width; j++)
                {
                    int x = j - 1;
                    int y = i - 1;

                    if (Y == y && X == x)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    //стиль ячек при рзпечатывании
                    if (model.cellBoard.Cells[x, y].IsOpened)
                    {
                        int res = (int)model.cellBoard.Cells[x, y].Type;
                        Console.Write("[");
                        if (res == (int)ModelGame.Type.Mine)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("*");
                        }
                        else
                        {
                            Console.ForegroundColor = (ConsoleColor)res;
                            Console.Write(res.ToString());
                        }
                        Console.ResetColor();
                        Console.Write("]");
                    }
                    else if (model.cellBoard.Cells[x, y].IsFlagged)
                    {
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0}", "@");
                        Console.Write("]");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("[{0}]", "-");
                        Console.ResetColor();
                    }
                }
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine(Environment.NewLine);
            foreach (var value in Enum.GetValues(typeof(GameManagment)))
            {
                Console.WriteLine(GetDescription((GameManagment)value));
            }

            ConsoleKeyInfo ckey = Console.ReadKey();

            //Упарвление движением по полю вниз
            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (Y == width - 1)
                {
                    Y = 0;
                }
                else { Y++; }
            }
            //Упарвление движением по полю вверх
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (Y <= 0)
                {
                    Y = width - 1;
                }
                else { Y--; }
            }
            //Упарвление движением по полю вправо
            if (ckey.Key == ConsoleKey.RightArrow)
            {
                if (X == height - 1)
                {
                    X = 0;
                }
                else { X++; }
            }
            //Упарвление движением по полю влево
            else if (ckey.Key == ConsoleKey.LeftArrow)
            {
                if (X <= 0)
                {
                    X = height - 1;
                }
                else { X--; }
            }
            //Выйти в меню
            else if (ckey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return (int)GameManagment.Back;
            }
            //Флаг
            else if (ckey.Key == ConsoleKey.Z)
            {
                Console.Clear();
                return (int)GameManagment.Flag;
            }
            //Открыть
            else if (ckey.Key == ConsoleKey.X)
            {
                Console.Clear();
                return (int)GameManagment.Open;
            }

            Console.Clear();
            return -1;
        }

        //Вывод сообщения об окончании игры
        public void DrawGameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("//                                                                      //");
            Console.WriteLine("//                           Вы проиграли!!!                            //");
            Console.WriteLine("//                                                                      //");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();
        }

        //Вывод сообщния о победе в игре
        public void DrawWin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("//                                                                      //");
            Console.WriteLine("//                           Вы победили!!!                             //");
            Console.WriteLine("//                                                                      //");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
            Console.ResetColor();
        }
    }
}
