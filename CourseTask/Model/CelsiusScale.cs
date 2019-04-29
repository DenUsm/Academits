using System;

namespace Model
{
    public class CelsiusScale : IScale
    {
        private const string name = "Celsius, °C";

        public string Name { get => name; }

        public double? ConvertCelsiusToOtherScale(double? value)
        {
            return value;
        }

        public double? ConvertTemperatureToCelsius(double? value)
        {
            return value;
        }
    }
}
