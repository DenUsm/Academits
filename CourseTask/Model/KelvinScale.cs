using System;

namespace Model
{
    public class KelvinScale : IScale
    {
        private const string name = "Kelvin, K";

        public string Name { get => name; }

        public double? ConvertCelsiusToOtherScale(double? value)
        {
            return value + 273.15;
        }

        public double? ConvertTemperatureToCelsius(double? value)
        {
            if (value != null)
            {
                return Convert.ToDouble(value) - 273.15;
            }
            return value;
        }
    }
}
