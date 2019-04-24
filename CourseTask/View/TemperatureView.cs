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
        public void InitialValueScaleInCmb(ITemperatureModel[] model)
        {
            foreach (var value in model)
            {
                cmbInputScale.Items.Add(value.DescriptionScale);
                cmbOutputScale.Items.Add(value.DescriptionScale);
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
