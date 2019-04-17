using Model;

namespace Controller
{
    public class TemperatureController
    {
        private TemperatureModel temperature;

        private ITemperatureView view;

        public TemperatureController(ITemperatureView view)
        {
            this.view = view;
            view.SetController(this);
        }
    }
}
