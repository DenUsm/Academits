using System;
using View;
using Controller;

namespace TemperatureConverterApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TemperatureView view = new TemperatureView();
            TemperatureController controller = new TemperatureController(view);
            view.ShowDialog();
        }
    }
}
