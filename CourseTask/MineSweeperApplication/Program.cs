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
        /// 
        public static TextUiMineSweeper view = new TextUiMineSweeper();
        public static MineSweeperModel model = new MineSweeperModel();

        [STAThread]
        static void Main()
        {
            Console.CursorVisible = false;
            while (true)
            {
                int selectedMenuItem = view.GetMenu();

                //Выбор пункта меню новая игра
                if (selectedMenuItem == (int)MainMenu.NewGame)
                {
                    Console.Clear();
                    view.SetIndex(0);
                    bool isExit = true;
                    while (isExit)
                    {
                        int selectedSubMenuItem = view.GetSubMenu();
                        switch (selectedSubMenuItem)
                        {
                            //начальный уровень
                            case (int)Level.Beginner:
                                {
                                    model.SetGameParameter(Level.Beginner);
                                    view.SetPaameterGui(model.cellBoard.Width, model.cellBoard.Height);
                                    ProcessGame();
                                    isExit = false;
                                    break;
                                }
                            //любитель
                            case (int)Level.Medium:
                                {
                                    model.SetGameParameter(Level.Medium);
                                    view.SetPaameterGui(model.cellBoard.Width, model.cellBoard.Height);
                                    ProcessGame();
                                    isExit = false;
                                    break;
                                }
                            //профессионал
                            case (int)Level.Professional:
                                {
                                    model.SetGameParameter(Level.Professional);
                                    view.SetPaameterGui(model.cellBoard.Width, model.cellBoard.Height);
                                    ProcessGame();
                                    isExit = false;
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
                    view.DrawAboutProgramAndRule(MineSweeperModel.Rule);
                }
                //Выбор пункта меню рекорды
                else if (selectedMenuItem == (int)MainMenu.HighScores)
                {
                    view.DrawHightScoresTable(MineSweeperModel.HightSores);
                }
                //Выбор пункта меню выход
                else if (selectedMenuItem == (int)MainMenu.Exit)
                {
                    Environment.Exit(0);
                }
                //Выбор пункта о программе
                else if (selectedMenuItem == (int)MainMenu.About)
                {
                    view.DrawAboutProgramAndRule(MineSweeperModel.About);
                }
            }
        }

        private static void ProcessGame()
        {
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
                    string name = view.SetNameHightScore(model.CheckResult());
                    model.SaveResultHightScore(name);
                    seletedGameManagment = view.DrawGameBoard(model);
                    isExit = false;
                }
            }
        }
    }
}

