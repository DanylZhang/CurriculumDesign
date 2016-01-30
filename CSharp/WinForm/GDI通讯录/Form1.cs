using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI通讯录
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         private Employee[] employee = new Employee[4];
        private void Form1_Load(object sender, EventArgs e)
        {
            employee[0] = new Teacher("张三", "13900000000", "zs@qq.com");
            employee[1] = new Seller("李四", "13911111111", "ls@qq.com");
            employee[2] = new TeacherManager("杨中科", "13800000000", "yzk@itcats.com");
            employee[3] = new SellerManager("王五", "13811111111", "ww@itcats.com");
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            Pen pen = new Pen(Color.Green, 4);
            for (int i = 0; i < employee.Length; ++i)
            {
                employee[i].Print(g, 60, 50 + i * 120);
                g.DrawLine(pen, 60, 130 + i * 120, 500, 130 + i * 120);
            }
            pen.Dispose();
            g.Dispose();
        }
    }
}