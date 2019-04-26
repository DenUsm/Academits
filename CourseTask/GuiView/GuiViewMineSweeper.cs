using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewInterface;

namespace GuiView
{
    public partial class GuiViewMineSweeper : Form, IMineSweeperView
    {
        public GuiViewMineSweeper()
        {
            InitializeComponent();
        }

        public int[,] GetCoordinate { get; private set; }

        public int SetValue { set => textBox1.Text = value.ToString(); }

        public event EventHandler<EventArgs> GetIndexCell;



        private void button1_Click(object sender, EventArgs e)
        {
            GetCoordinate = new int[1, 2] { {3, 1} };
            GetIndexCell(this, EventArgs.Empty);
        }
    }
}
