using System.ComponentModel;

namespace Model
{
    public class TemperatureModel
    {
        private double celsius = 0;
        private double fahrenheit = 32;
        private double kelvin = 273.15;


        public double Fahrenheit
        {
            get => fahrenheit;
            set
            {
                fahrenheit = value;
                celsius = (fahrenheit - 32) * 5 / 9;
                kelvin = (fahrenheit - 32) * 5 / 9 + 273.15;
            }
        }

        public double Celsius
        {
            get => celsius;
            set
            {
                celsius = value;
                fahrenheit = (celsius * 1.8) + 32;
                kelvin = celsius + 273.15;
            }
        }

        public double Kelvin
        {
            get => kelvin;
            set
            {
                kelvin = value;
                fahrenheit = (kelvin - 273.15) * 1.8 + 32;
                celsius = kelvin - 273.15;
            }
        }

        public enum ScaleMesurment
        {
            [Description("Celsius, °C")]
            Celsius = 1,
            [Description("Fahrenheit, °F")]
            Fahrenheit = 2,
            [Description("Kelvin, K")]
            Kelvin = 3
        }
    }
}
