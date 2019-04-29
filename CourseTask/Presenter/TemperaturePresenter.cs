using Model;
using System;
using Interface;

namespace Presenter
{
    public class TemperaturePresenter
    {
        //private TemperatureModel model = new TemperatureModel();
        private ITemperatureView view;
        private IScale [] model;

        public TemperaturePresenter(ITemperatureView view, IScale [] model)
        {
            this.view = view;
            this.model = model;
            view.ConvertTemperature += new EventHandler<EventArgs>(Convert);
        }

        //Обработка события выбора входной шкалы измерения
        private void Convert(object sender, EventArgs e)
        {
            int indexInput = view.IndexInputScale;
            int indexOutput = view.IndexOutputScale;

            IScale input = model[indexInput];
            IScale output = model[indexOutput];

            double? celsius = input.ConvertTemperatureToCelsius(view.InputDegree);
            view.OutputDegree = output.ConvertCelsiusToOtherScale(celsius);         
        }     
    }
}
