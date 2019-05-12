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

            //Начльный уровень сложности
            int width = 9;
            int height = 9;
            int countMine = 10;

            Console.CursorVisible = false;
            while (true)
            {
                int selectedMenuItem = view.GetMenu();
                //Выбор пункта меню новая игра
                if (selectedMenuItem == (int)MainMenu.NewGame)
                {
                    //создли новую игру
                    model.SetGameParameter(width, height, countMine);
                    view.SetPaameterGui(width, height);
                    bool isExit = true;
                    while (isExit)
                    {
                        int seletedGameManagment = view.DrawGameBoard(model);
                        switch (seletedGameManagment)
                        {
                            //возврат назад
                            case (int)GameManagment.Back:
                                model.StopTimer();
                                isExit = false;
                                break;
                            //открыти ячейки
                            case (int)GameManagment.Open:
                                model.OpenCell(view.X, view.Y);
                                break;
                            //отмтить/убрать флаг
                            case (int)GameManagment.Flag:
                                model.SetFlagCoordinate(view.X, view.Y);
                                break;
                        }

                        //проверка статуса игры посл хода
                        if (model.GetStatusGame() == GameStatus.GameOver)
                        {
                            view.DrawGameOver();
                            seletedGameManagment = view.DrawGameBoard(model);
                            isExit = false;
                        }
                        if (model.GetStatusGame() == GameStatus.Win)
                        {
                            view.DrawWin();
                            seletedGameManagment = view.DrawGameBoard(model);
                            isExit = false;
                        }
                    }
                }
                //Выбор пункта меню сложность
                else if (selectedMenuItem == (int)MainMenu.Lavel)
                {
                    Console.Clear();
                    view.SetIndex(0);
                    bool isExit = true;
                    while (isExit)
                    {
                        int selectedSubMenuItem = view.GetSubMenu();
                        switch (selectedSubMenuItem)
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
                                    Console.Clear();
                                    Console.WriteLine("Вы выбрали режим игры новичок");
                                    Console.WriteLine("Чтобы начать игру нажмите любую клавишу и выберите в меню пункт \"Новая игра\"");
                                    Console.ReadKey();
                                    Console.Clear();
                                    isExit = true;
                                    break;
                                }
                            //любитель
                            case (int)SubMenuLevel.Medium:
                                {
                                    width = 16;
                                    height = 16;
                                    countMine = 40;
                                    Console.Clear();
                                    Console.WriteLine("Вы выбрали режим игры любитель");
                                    Console.WriteLine("Чтобы начать игру нажмите любую клавишу и выберите в меню пункт \"Новая игра\"");
                                    Console.ReadKey();
                                    Console.Clear();
                                    isExit = true;
                                    break;
                                }
                            //профессионал
                            case (int)SubMenuLevel.Professional:
                                {
                                    width = 30;
                                    height = 16;
                                    countMine = 99;
                                    Console.Clear();
                                    Console.WriteLine("Вы выбрали режим игры професионал");
                                    Console.WriteLine("Чтобы начать игру нажмите любую клавишу и выберите в меню пункт \"Новая игра\"");
                                    Console.ReadKey();
                                    Console.Clear();
                                    isExit = true;
                                    break;
                                }
                            //Особые
                            case (int)SubMenuLevel.Special:
                                {
                                    try
                                    {
                                        Console.Write("Пожалуйста введите ширину поля: ");
                                        width = Convert.ToInt32(Console.ReadLine());

                                        Console.Write("Пожалуйста введите высоту поля: ");
                                        height = Convert.ToInt32(Console.ReadLine());

                                        Console.Write("Пожалуйста введите количество мин: ");
                                        countMine = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Пожалуйста введите данные в корректном формате");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                    isExit = true;
                                    Console.Clear();
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
                //Выбор пункта меню новая правила игры
                else if (selectedMenuItem == (int)MainMenu.Rule)
                {
                    view.DrawAboutProgramAndRule(ModelMineSweeper.Rule);
                    Console.ReadKey();
                    Console.Clear();
                }
                //Выбор пункта меню рекорды
                else if (selectedMenuItem == (int)MainMenu.HighScores)
                {
                    view.DrawHightScoresTable(ModelMineSweeper.HightSores);
                    Console.ReadKey();
                    Console.Clear();
                }
                //Выбор пункта меню выход
                else if (selectedMenuItem == (int)MainMenu.Exit)
                {
                    Environment.Exit(0);
                }
                //Выбор пункта о программе
                else if (selectedMenuItem == (int)MainMenu.About)
                {
                    view.DrawAboutProgramAndRule(ModelMineSweeper.About);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}

