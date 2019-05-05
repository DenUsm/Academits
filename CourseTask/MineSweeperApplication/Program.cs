using System;
using ModelGame;
using GuiView;
using TextUiView;
using PresenterGame;
using System.Diagnostics;

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
            //Создание экземпляра обьекта для запуска приложения на WinForm
            //GuiViewMineSweeper view = new GuiViewMineSweeper();
            //PresenterMineSweeper presenter = new PresenterMineSweeper(view);
            //view.ShowDialog();    



            Console.WriteLine("*-----------------MineSweeperGame-----------------------*");
            Console.Write("Пожалуйста введите ширину поля: ");
            int width = Convert.ToInt32(Console.ReadLine());

            Console.Write("Пожалуйста введите высоту поля: ");
            int height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Пожалуйста введите количество мин: ");
            int countMine = Convert.ToInt32(Console.ReadLine());

            ModelMineSweeper model = new ModelMineSweeper();
            model.SetParameterGame(width, height, countMine);

            while (true)
            {
                //Console.Clear();
                Console.WriteLine("55 - Посмотреть открытое поле");
                Console.WriteLine("22 - Сделать ход");
                model.ShowBoard();

                int cmd = Convert.ToInt32(Console.ReadLine());
                if(cmd == 55)
                {
                    model.ShowSolved();
                }
                else if(cmd == 22)
                {
                    Console.WriteLine("33 - Открыть ячейку");
                    Console.WriteLine("44 - Отметить/Убрать ячейку как мину");

                    cmd = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Введите координату x:");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите координату y:");
                    int y = Convert.ToInt32(Console.ReadLine());

                    if (cmd == 33)
                    {
                        if(model.GetStatusGame() == GameStatus.InPogress)
                        {
                            model.OpenCell(x, y);
                        }
                    }
                    else if (cmd == 44)
                    {
                        model.SetFlagCoordinate(x, y);
                    }
                }

                if (model.GetStatusGame() == GameStatus.GameOver)
                {
                    Console.WriteLine("Game Over");
                    Console.ReadKey();
                    return;
                }
                else if(model.GetStatusGame() == GameStatus.Win)
                {
                    Console.WriteLine("You Win");
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}
