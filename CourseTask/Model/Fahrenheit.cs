using System;

namespace Model
{
    public class Fahrenheit : ITemperatureModel
    {
        private double? degree;

        public Fahrenheit(string scale)
        {
            DescriptionScale = scale;
        }

        public string DescriptionScale { get; }

        public double? DegreeToCelsius
        {
            get => degree;
            set
            {
                if (value != null)
                {
                    degree = (Convert.ToDouble(value) - 32) * 5 / 9;
                }
                else
                {
                    degree = value;
                }
            }
        }

        public double? CelsiusToDegree { get => (degree * 1.8) + 32; set => degree = value; }
    }
}
