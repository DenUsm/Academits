using System.ComponentModel;

namespace Model
{
    public class TemperatureModel
    {
        public enum ScaleMesurment
        {
            [Description("Kelvin, K")]
            Kelvin = 1,
            [Description("Fahrenheit, °F")]
            Fahrenheit = 2,
            [Description("Celsius, °C")]
            Celsius = 3
        }

        public const double coeffKelvin = 273.15;

        public const double coeffMultiFahrenheit = 1.8;

        public const double coeffSumFahrenheit = 32;

        public ScaleMesurment Scale { get; set; }

        public double Value { get; set; }
    }
}
