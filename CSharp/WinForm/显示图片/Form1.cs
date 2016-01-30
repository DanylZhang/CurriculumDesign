using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 显示图片
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int year;
            if (textBox1.Text.Length < 18 || !int.TryParse(textBox1.Text.Substring(6, 4), out year))
            {
                pictureBox1.Visible = false;
                MessageBox.Show("身份证号格式错误！");
                return;
            }

            int age=DateTime.Now.Year-year;
            if (age < 0)
            {
                pictureBox1.Visible = false;
                MessageBox.Show("身份证号格式错误！");
                return;
            }
            else if (age >= 0 && age < 18)
            {
                pictureBox1.Visible = false;
                MessageBox.Show("年龄太小！","警告！");
                return;
            }
            else
            {
                pictureBox1.Visible = true;
            }
        }
    }
}