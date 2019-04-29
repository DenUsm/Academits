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

         
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.RowCount = 5;

            for(int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {    
                for (int j =0; j < tableLayoutPanel1.ColumnCount; j++)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Fill;
                   
                    tableLayoutPanel1.Controls.Add(btn);
                    
                }
            }

            //tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent;
            //tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Percent;
            //
            //tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent;
            //tableLayoutPanel1.RowStyles[1].SizeType = SizeType.Percent;
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
