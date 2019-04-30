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
            Console.WriteLine(model.ToString());

            Console.ReadKey();
        }
    }
}
