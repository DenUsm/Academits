namespace Model
{
    public interface IScale
    {
        //Описание шкалы перевода
        string Name { get; }
        //Приведение шкалы к градусам цельсия
        double? ConvertTemperatureToCelsius(double? value);
        //приведение градусов цельсия к шкале измерения
        double? ConvertCelsiusToOtherScale(double? value);
    }
}
