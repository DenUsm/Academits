using System;
using ModelGame;
using TextUiView;

namespace MineSweeperApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region
            //Создание экземпляра обьекта для запуска приложения на WinForm
            //GuiViewMineSweeper view = new GuiViewMineSweeper();
            //PresenterMineSweeper presenter = new PresenterMineSweeper(view);
            //view.ShowDialog();    

            //TextUiMineSweeper view = new TextUiMineSweeper();
            //view.ShowScreensaver();
            //view.ShowGameMenu(new string[] {"Новая игра", "Сложность", "Правила", "Результаты", "Выход" });
            //
            //
            //Console.ReadKey();
            #endregion

            TextUiMineSweeper view = new TextUiMineSweeper();
            ModelMineSweeper model = new ModelMineSweeper();

            //Уровень
            int width;
            int height;
            int countMine;

            Console.CursorVisible = false;
            while (true)
            {
                int selectedMenuItem = view.GetMenu();
                if (selectedMenuItem == (int)MainMenu.NewGame)
                {
                    Console.WriteLine("Action for NewGame");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (selectedMenuItem == (int)MainMenu.Lavel)
                {
                    Console.Clear();
                    view.SetIndex(0);
                    bool isExit = true;
                    while (isExit)
                    {
                        int selectedSubMenuItem = view.GetSubMenu();
                        switch(selectedSubMenuItem)
                        {
                            //возврат назад
                            case (int)SubMenuLevel.Back:
                                isExit = false;
                                break;
                            //начальный уровень
                            case (int)SubMenuLevel.Beginner:
                                {
                                    width = 9;
                                    height = 9;
                                    countMine = 10;
                                    isExit = true;
                                    break;
                                }
                            //любитель
                            case (int)SubMenuLevel.Medium:
                                {
                                    width = 20;
                                    height = 10;
                                    countMine = 40;
                                    isExit = true;
                                    break;
                                }
                            //профессионал
                            case (int)SubMenuLevel.Professional:
                                {
                                    width = 30;
                                    height = 20;
                                    countMine = 99;
                                    isExit = true;
                                    break;
                                }
                            //Особые
                            case (int)SubMenuLevel.Special:
                                {
                                    Console.Write("Пожалуйста введите ширину поля: ");
                                    width = Convert.ToInt32(Console.ReadLine());
                                    
                                    Console.Write("Пожалуйста введите высоту поля: ");
                                    height = Convert.ToInt32(Console.ReadLine());
                                    
                                    Console.Write("Пожалуйста введите количество мин: ");
                                    countMine = Convert.ToInt32(Console.ReadLine());
                                    isExit = true;
                                    Console.Clear();
                                    break;
                                }                                
                            default:
                                break;
                        }
                    }                           
                }
                else if(selectedMenuItem == (int)MainMenu.Rule)
                {
                    Console.WriteLine("Action for Rule");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (selectedMenuItem == (int)MainMenu.HighScores)
                {
                    Console.WriteLine("Action for HighScores");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (selectedMenuItem == (int)MainMenu.Exit)
                {
                    Environment.Exit(0);
                }
            }

            #region
            //Console.WriteLine("*-----------------MineSweeperGame-----------------------*");
            //Console.Write("Пожалуйста введите ширину поля: ");
            //int width = Convert.ToInt32(Console.ReadLine());
            //
            //Console.Write("Пожалуйста введите высоту поля: ");
            //int height = Convert.ToInt32(Console.ReadLine());
            //
            //Console.Write("Пожалуйста введите количество мин: ");
            //int countMine = Convert.ToInt32(Console.ReadLine());
            //
            //ModelMineSweeper model = new ModelMineSweeper();
            //model.SetGameParameter(width, height, countMine);
            //
            //while (true)
            //{
            //    //Console.Clear();
            //    Console.WriteLine("55 - Посмотреть открытое поле");
            //    Console.WriteLine("22 - Сделать ход");
            //    model.ShowBoard();
            //
            //    int cmd = Convert.ToInt32(Console.ReadLine());
            //    if(cmd == 55)
            //    {
            //        model.ShowSolved();
            //    }
            //    else if(cmd == 22)
            //    {
            //        Console.WriteLine("33 - Открыть ячейку");
            //        Console.WriteLine("44 - Отметить/Убрать ячейку как мину");
            //
            //        cmd = Convert.ToInt32(Console.ReadLine());
            //
            //        Console.Write("Введите координату x:");
            //        int x = Convert.ToInt32(Console.ReadLine());
            //        Console.Write("Введите координату y:");
            //        int y = Convert.ToInt32(Console.ReadLine());
            //
            //        if (cmd == 33)
            //        {
            //            if(model.GetStatusGame() == GameStatus.InPogress)
            //            {
            //                model.OpenCell(x, y);
            //            }
            //        }
            //        else if (cmd == 44)
            //        {
            //            model.SetFlagCoordinate(x, y);
            //        }
            //    }
            //
            //    if (model.GetStatusGame() == GameStatus.GameOver)
            //    {
            //        Console.WriteLine("Game Over");
            //        Console.ReadKey();
            //        return;
            //    }
            //    else if(model.GetStatusGame() == GameStatus.Win)
            //    {
            //        Console.WriteLine("You Win");
            //        Console.ReadKey();
            //        return;
            //    }
            //}
            #endregion
        }

       
    }
}

