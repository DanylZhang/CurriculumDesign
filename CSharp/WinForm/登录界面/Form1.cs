using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 登录界面
{
    public partial class Form1 : Form
    {
        private int ErrorTimes = 0;//错误次数
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" && txtPassWord.Text == "888888")
            {
                MessageBox.Show("登录成功！", "登录");
                Application.Exit();
            }
            else
            {
                ErrorTimes++;
                MessageBox.Show("用户名或密码错误！","登录");
            }
            if (ErrorTimes >= 3)
            {
                MessageBox.Show("三次登录失败，程序即将退出！","警告");
                Application.Exit();
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.Size = new System.Drawing.Size(80, 28);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.Size = new System.Drawing.Size(75, 23);
        }
    }
}