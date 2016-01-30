using System;
using System.Threading;
using System.Windows.Forms;

namespace 摇奖机
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setText = new SetText((msg) => lblRandom.Text = msg);
        }
        private SetText setText = null;
        private Thread thread = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "开始")
            {
                btnStart.Text = "停止";
                lblResult.Text = "";
                thread = new Thread(new ThreadStart(() =>
                {
                    Random rand = new Random();
                    while (true)
                    {
                        this.Invoke(setText,rand.Next(0,10).ToString());
                        Thread.Sleep(50);
                    }
                }));
                thread.Start();
            }
            else
            {
                thread.Abort();
                btnStart.Text = "开始";
                lblResult.Text = "中奖者：" + lblRandom.Text;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnStart.Text == "停止")
            {
                e.Cancel = true;
                MessageBox.Show("请先停止摇奖");
            }
        }
    }
    public delegate void SetText(string msg);
}