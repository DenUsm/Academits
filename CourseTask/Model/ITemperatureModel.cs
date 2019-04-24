namespace Model
{
    public interface ITemperatureModel
    {
        //Описание шкалы перевода
        string DescriptionScale { get; }
        //Приведение шкалы к градусам цельсия
        double? DegreeToCelsius { get; set; }
        //приведение градусов цельсия к шкале измерения
        double? CelsiusToDegree { get; set; }
    }
}
