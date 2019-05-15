using System;
using System.Windows.Forms;

namespace GuiView
{
    public partial class RuleMineSweeper : Form
    {
        public RuleMineSweeper()
        {
            InitializeComponent();
        }

        //Вывод првил на форму
        public void EnterRuleOnForm(string rule)
        {
            rtbRule.AppendText(rule);
        }
    }
}
