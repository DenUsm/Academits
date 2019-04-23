using Model;
using System;
using Interface;

namespace Presenter
{
    public class TemperaturePresenter
    {
        private TemperatureModel model = new TemperatureModel();
        private ITemperatureView view;

        public TemperaturePresenter(ITemperatureView view)
        {
            this.view = view;
            view.ConvertTemperature += new EventHandler<EventArgs>(Convert);
        }

        //Обработка события выбора входной шкалы измерения
        private void Convert(object sender, EventArgs e)
        {
            int indexInput = view.IndexInputScale;
            int indexOutput = view.IndexOutputScale;

            if (indexInput == 0)
            {
                model.Celsius = view.InputDegree;
            }
            else if(indexInput == 1)
            {
                model.Fahrenheit = view.InputDegree;
            }
            else if(indexInput == 2)
            {
                model.Kelvin = view.InputDegree;
            }

            if (indexOutput == 0)
            {
                view.OutputDegree = model.Celsius;
            }
            else if (indexOutput == 1)
            {
                view.OutputDegree = model.Fahrenheit;
            }
            else if (indexOutput == 2)
            {
                view.OutputDegree = model.Kelvin;
            }
        }     
    }
}
