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

            ITemperatureModel[] model = new ITemperatureModel[] {
                new Celsius("Celsius, °C"),
                new Kelvin("Kelvin, K"),
                new Fahrenheit("Fahrenheit, °F")             
            };

            TemperatureView view = new TemperatureView();
            TemperaturePresenter presenter = new TemperaturePresenter(view, model);
            view.InitialValueScaleInCmb(model);
            view.ShowDialog();
        }
    }
}
