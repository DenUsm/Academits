using System;
using View;
using Presenter;

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
            TemperaturePresenter presenter = new TemperaturePresenter(view);
            view.ShowDialog();
        }
    }
}
