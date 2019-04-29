using System;
using View;
using Presenter;
using Model;

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

            IScale[] model = new IScale[] {
                new CelsiusScale(),
                new KelvinScale(),
                new FahrenheitScale()
            };

            TemperatureView view = new TemperatureView();
            TemperaturePresenter presenter = new TemperaturePresenter(view, model);
            view.InitialValueScaleInCmb(model);
            view.ShowDialog();
        }
    }
}
