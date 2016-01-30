using System;
using System.Threading;
using System.Windows.Forms;
//安全调用线程的步骤：
//1.声明方法
//2.声明委托类型
//3.创建委托对象
//4.启动线程
//5.在线程调用的方法里通过Control的Invoke方法执行委托

namespace MultiThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //线程访问控件（不安全的方式）
            //TextBox.CheckForIllegalCrossThreadCalls = false;
            setTex = new DelegateSetText(SetText);
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            Count();
        }
        private void Count()
        {
            DateTime beginTime = DateTime.Now;
            for (int i = 0; i < 999999999; ++i) { }
            Thread.Sleep(4000);
            DateTime endTime = DateTime.Now;
            TimeSpan ts = endTime.Subtract(beginTime);
            MessageBox.Show("数完了，总耗时：" + ts.TotalMilliseconds);
        }

        private void btnCountThread_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Count));
            //这一句并不是说线程开始了，而是将线程标记为可以开始了
            thread.Start();
        }

        private void btnShowCount_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowCount));
            thread.Start();
        }

        private void ShowCount()
        {
            for (int i = 0; i < 10000; ++i)
            {
                txtBoxCount.Text = i.ToString();
            }
        }

        private void btnShowCountSecurity_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(ShowCountSecurity);
            thread.Start();
        }
        private void ShowCountSecurity()
        {
            DateTime beginTime = DateTime.Now;
            for (int i = 0; i < 999999999; ++i)
            {
                //txtBoxCount.Text = i.ToString();
                this.Invoke(setTex, i.ToString());
            }
            Thread.Sleep(4000);
            DateTime endTime = DateTime.Now;
            TimeSpan ts = endTime.Subtract(beginTime);
            MessageBox.Show("数完了，总耗时：" + ts.TotalMilliseconds);
        }
        DelegateSetText setTex;
        private void SetText(string msg)
        {
            txtBoxCount.Text = msg;
        }
    }
    public delegate void DelegateSetText(string msg);
}