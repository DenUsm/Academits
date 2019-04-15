using System.ComponentModel;

namespace TemperatureConverter
{
    public class ModelTemperatureConverter
    {
        public enum ScaleMesurment
        {
            [Description("K")]
            Kelvin = 1,
            [Description("°F")]
            Fahrenheit = 2,
            [Description("°C")]
            Celsius = 3
        }

        private ScaleMesurment scaleMesurment;

        public ModelTemperatureConverter()
        {
            
        }




    }
}
