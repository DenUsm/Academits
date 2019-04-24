using System;

namespace Model
{
    public class Celsius : ITemperatureModel
    {
        public Celsius(string scale)
        {
            DescriptionScale = scale;
        }

        public string DescriptionScale { get; }

        public double? DegreeToCelsius { get; set; }

        public double? CelsiusToDegree { get => DegreeToCelsius; set => DegreeToCelsius = value; }
    }
}
