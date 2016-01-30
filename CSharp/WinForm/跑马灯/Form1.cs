using System;
using System.Windows.Forms;

namespace 跑马灯
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool leftFlag = true;
        private bool topFlag = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblMarquee.Right > panel1.Right)
            {
                leftFlag = false;
            }
            else if (lblMarquee.Left < panel1.Left)
            {
                leftFlag = true;
            }
            if (lblMarquee.Bottom > panel1.Bottom)
            {
                topFlag = false;
            }
            else if (lblMarquee.Top < panel1.Top)
            {
                topFlag = true;
            }
            if (leftFlag)
            {
                lblMarquee.Left++;
            }
            else
            {
                lblMarquee.Left--;
            }
            if (topFlag)
            {
                lblMarquee.Top++;
            }
            else
            {
                lblMarquee.Top--;
            }
        }
    }
}