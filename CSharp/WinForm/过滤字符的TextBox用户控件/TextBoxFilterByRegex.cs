using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace 过滤字符的TextBox用户控件
{
    public partial class TextBoxFilterByRegex : UserControl
    {
        public TextBoxFilterByRegex()
        {
            InitializeComponent();
        }

        private string lastString = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("^\\d*$");

            if (reg.IsMatch(textBox1.Text))
            {
                lastString = textBox1.Text;
            }
            else
            {
                textBox1.Text = lastString;
                textBox1.Select(textBox1.Text.Length, 0);
                textBox1.ScrollToCaret();
            }
        }
    }
}