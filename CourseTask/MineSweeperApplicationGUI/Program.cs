using System;
using GuiView;
using PresenterGame;

namespace MineSweeperApplicationGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GuiViewMineSweeper view = new GuiViewMineSweeper();
            PresenterMineSweeper presenter = new PresenterMineSweeper(view);
            view.ShowDialog();
        }
    }
}
