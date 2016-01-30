using System;
using System.Windows.Forms;

namespace 双击控件
{
    public partial class DBClickControl : UserControl
    {
        public DBClickControl()
        {
            InitializeComponent();
        }
        private int count = 0;
        private DateTime lastClickTime;
        public event DBClickDelegate OnDBClick;
        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            TimeSpan ts = DateTime.Now - lastClickTime;
            if (ts.TotalMilliseconds <= 500)
            {
                if (count == 2)
                {
                    if (OnDBClick != null)
                    {
                        OnDBClick();
                    }
                }
                count = 0;
            }
            else
            {
                count = 1;
            }
            lastClickTime = DateTime.Now;
        }
    }

    public delegate void DBClickDelegate();
}