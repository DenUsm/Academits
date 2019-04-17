using Model;

namespace Controller
{
    public interface ITemperatureView
    {
        void SetController(TemperatureController controller);
        void ConvertTemperature();
    }
}
