using System;
using System.Windows.Forms;

namespace TemperatureConverter
{
    public partial class MainForm : Form, IViewMainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ControllerMainForm controller;

        public ControllerMainForm Controller
        {
            get
            {
                return controller;
            }
            set
            {
                if (controller == value) return;
            }
        }

    }
}
