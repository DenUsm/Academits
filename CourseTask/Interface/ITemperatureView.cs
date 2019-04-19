using System;

namespace Interface
{
    public interface ITemperatureView
    {
        //ввод значения градусов
        double InputDegree { get; }

        //вывод значения градусов
        double OutputDegree { set; }

        //индекс выбора входной шкалы измерения
        int IndexInputScale { get; }

        //индекс выбора выходной шкалы измерения
        int IndexOutputScale { get; }

        //Событие нажатия кнопки для перевода температуры
        event EventHandler<EventArgs> ConvertTemperature;
    }
}
