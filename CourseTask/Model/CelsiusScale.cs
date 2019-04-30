namespace Model
{
    public class CelsiusScale : IScale
    {
        public string Name => "Celsius, °C";

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
