using System;

namespace TemperatureConverter
{
    public class ControllerMainForm
    {
        private ModelTemperatureConverter model;
        private IViewMainForm view;

        public ControllerMainForm()
        {
            model = new ModelTemperatureConverter();
            ModelTemperatureConverter. = 5;
        }

        //метод создания формы 
        public MainForm CreateFormView()
        {
            MainForm form = new MainForm();
            view = form;
            view.Controller = this;
            form.Show();
            return form;
        }

     
    }
}
