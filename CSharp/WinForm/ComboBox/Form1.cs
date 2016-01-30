using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string city = comboBox1.SelectedItem.ToString();
            if (city == "山东")
            {
                comboBox2.Items.Add("青岛");
                comboBox2.Items.Add("菏泽");
            }
            else if (city == "河南")
            {
                comboBox2.Items.Add("郑州");
                comboBox2.Items.Add("开封");
            }
            else
            {
                comboBox2.Items.Add("深圳");
                comboBox2.Items.Add("广州");
            }
        }
    }
}