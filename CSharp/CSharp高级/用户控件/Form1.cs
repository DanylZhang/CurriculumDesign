using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 用户控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sanQiang1.AddSanQiangDelegate(OnSanQiang1);
            sanQiang1.AddSanQiangDelegate(OnSanQiang2);
        }

        void OnSanQiang1()
        {
            MessageBox.Show("兔子！！！");
        }
        void OnSanQiang2()
        {
            MessageBox.Show("我也三枪！");
        }

        private void btnShutdelegate_Click(object sender, EventArgs e)
        {
            //sanQiang1.OnSanQiang = null;
        }

        private void btnPretentDelegate_Click(object sender, EventArgs e)
        {
            //sanQiang1.OnSanQiang();
        }
    }
}