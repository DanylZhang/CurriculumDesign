using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 用户控件2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sanQiangButton1.OnSanQiang += OnSanQiang1;
        }
        void OnSanQiang1()
        {
            MessageBox.Show("兔子兔子!!!");
        }
    }
}
