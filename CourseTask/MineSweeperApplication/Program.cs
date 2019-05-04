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

            ModelMineSweeper model = new ModelMineSweeper();
            model.SetParameterGame(9, 9, 10);

            Console.Write("Введите координату x:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите координату y:");
            int y = Convert.ToInt32(Console.ReadLine());

            model.GetFirstCoordinateFromUser(x, y);

            while (true)
            {
                Console.WriteLine("55 - Посмотреть открытое поле");
                Console.WriteLine("22 - Сделать ход");

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
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите координату y:");
                    y = Convert.ToInt32(Console.ReadLine());

                    if (cmd == 33)
                    {
                        model.GetCoordinateFromUser(x, y);
                    }
                    else if (cmd == 44)
                    {
                        model.SetFlagCoordinate(x, y);
                    }
                }           
            }
        }
    }
}
