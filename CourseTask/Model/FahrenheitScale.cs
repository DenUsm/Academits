namespace Model
{
    public class FahrenheitScale : IScale
    {
        public string Name => "Fahrenheit, °F";

        public double? ConvertCelsiusToOtherScale(double? value)
        {
            if (value != null)
            {
                return value * 1.8 + 32;
            }
            return value;
        }

        public double? ConvertTemperatureToCelsius(double? value)
        {
            if (value != null)
            {
                return (value - 32) * 5 / 9;
            }
            return value;
        }
    }
}
