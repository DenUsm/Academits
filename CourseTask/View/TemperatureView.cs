using System.Windows.Forms;
using Interface;
using Model;
using System;

namespace View
{
    public partial class TemperatureView : Form, ITemperatureView
    {
        public TemperatureView()
        {
            InitializeComponent();
            InitialValueScaleInCmb();
        }

        //ввод градусов в поле ввода
        public double? InputDegree
        {
            get
            {
                try
                {
                    return Convert.ToDouble(tbInputValue.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Ввведенные данные не корректны!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        //выбор шкалы входдных данных
        public int IndexInputScale { get; private set; }

        //выбор шкалы выходных данных
        public int IndexOutputScale { get; private set; }

        public double? OutputDegree
        {
            set
            {
                if (value != null)
                {
                    tbOutputValue.Text = Math.Round(Convert.ToDouble(value), 2).ToString();
                }
                else
                {
                    tbOutputValue.Clear();
                }
            }
        }

        //Событие перевода температуры
        public event EventHandler<EventArgs> ConvertTemperature;

        //заполнение начальными значениям cmb
        private void InitialValueScaleInCmb()
        {
            foreach (TemperatureModel.ScaleMesurment scale in Enum.GetValues(typeof(TemperatureModel.ScaleMesurment)))
            {
                string value = InitializeSomeControl.GetDescriptionScale(scale);
                cmbInputScale.Items.Add(value);
                cmbOutputScale.Items.Add(value);
            }
            cmbInputScale.SelectedIndex = 0;
            cmbOutputScale.SelectedIndex = 1;
        }

        //Обработка события нажатия кнопки конвертирования температуры
        private void btnConvert_Click(object sender, EventArgs e)
        {
            IndexInputScale = cmbInputScale.SelectedIndex;
            IndexOutputScale = cmbOutputScale.SelectedIndex;
            ConvertTemperature(this, EventArgs.Empty);
        }
    }
}
