using Model;
using System;
using Interface;

namespace Presenter
{
    public class TemperaturePresenter
    {
        //private TemperatureModel model = new TemperatureModel();
        private ITemperatureView view;
        private ITemperatureModel [] model;

        public TemperaturePresenter(ITemperatureView view, ITemperatureModel [] model)
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

            ITemperatureModel input = model[indexInput];
            ITemperatureModel output = model[indexOutput];

            input.DegreeToCelsius = view.InputDegree;
            output.CelsiusToDegree = input.DegreeToCelsius;

            view.OutputDegree = output.CelsiusToDegree;           
        }     
    }
}
