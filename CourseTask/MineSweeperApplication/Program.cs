using System;
using ModelGame;

namespace MineSweeperApplication
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ModelMineSweeper model = new ModelMineSweeper(9, 10);
            model.FieldInitial();

            Console.ReadKey();
        }
    }
}
