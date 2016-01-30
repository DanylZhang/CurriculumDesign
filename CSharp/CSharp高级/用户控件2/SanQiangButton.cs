using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 用户控件2
{
    public partial class SanQiangButton : UserControl
    {
        public SanQiangButton()
        {
            InitializeComponent();
        }
        private int count = 0;

        //事件的标准写法
        //event 委托类型 事件名{add remove}
        //private SanQiangDelegate onSanQiang;
        public event SanQiangDelegate OnSanQiang;//就像属性一样简写

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            if (count == 3)
            {
                if (OnSanQiang != null)
                {
                    OnSanQiang();
                }
                count = 0;
            }
        }
    }
    public delegate void SanQiangDelegate();
}