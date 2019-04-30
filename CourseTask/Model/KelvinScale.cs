namespace Model
{
    public class KelvinScale : IScale
    {
        public string Name => "Kelvin, K";

        public double? ConvertCelsiusToOtherScale(double? value)
        {
            if (value != null)
            {
                return value + 273.15;
            }
            return value;
        }

        public double? ConvertTemperatureToCelsius(double? value)
        {
            if (value != null)
            {
                return value - 273.15;
            }
            return value;
        }
    }
}
