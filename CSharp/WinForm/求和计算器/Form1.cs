using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 求和计算器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double d1, d2, sum;
            if (double.TryParse(textBox1.Text, out d1) && double.TryParse(textBox2.Text, out d2))
            {
                sum = d1 + d2;
                textBox3.Text = string.Format("{0}", sum);
            }
            else
            {
                MessageBox.Show("格式错误！", "警告！", MessageBoxButtons.OKCancel);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}