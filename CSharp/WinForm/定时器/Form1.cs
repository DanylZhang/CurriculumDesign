using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 定时器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1_Tick(null, null);//尽量不要调用事件处理函数
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
    }
}