using System.Windows.Forms;
using Model;
using Controller;
using System;
using System.Reflection;
using System.ComponentModel;

namespace View
{
    public partial class TemperatureView : Form, ITemperatureView
    {
        private TemperatureController controller;

        public TemperatureView()
        {
            InitializeComponent();
            InitialValueScaleInCmb();
        }

        private string GetDescription(Enum enumElement)
        {
            Type type = enumElement.GetType();

            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumElement.ToString();
        }

        private void InitialValueScaleInCmb()
        {
            foreach (TemperatureModel.ScaleMesurment scale in Enum.GetValues(typeof(TemperatureModel.ScaleMesurment)))
            {
                string value = GetDescription(scale);
                cmbInputScale.Items.Add(value);
                cmbOutputScale.Items.Add(value);
            }
            cmbInputScale.SelectedIndex = 0;
            cmbOutputScale.SelectedIndex = 1;
        }

        public void SetController(TemperatureController controller)
        {
            this.controller = controller;
        }

        public void ConvertTemperature()
        {
            throw new NotImplementedException();
        }
    }
}
