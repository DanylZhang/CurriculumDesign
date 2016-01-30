using System;
using System.Windows.Forms;

namespace 用户控件
{
    public partial class SanQiang : UserControl
    {
        public SanQiang()
        {
            InitializeComponent();
        }

        //public SanQiangDelegate OnSanQiang;
        //将字段设为私有的就安全多了
        private SanQiangDelegate OnSanQiang;
        public void AddSanQiangDelegate(SanQiangDelegate d)
        {
            OnSanQiang += d;
        }
        private int count = 0;

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