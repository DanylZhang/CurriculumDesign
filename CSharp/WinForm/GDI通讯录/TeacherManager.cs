using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDI通讯录
{
    class TeacherManager:Teacher
    {
        public TeacherManager(string name, string phoneNo, string email) : base(name, phoneNo, email) { }
        public override void Print(Graphics g, int x, int y)
        {
            Font font = new Font("楷体", 15, FontStyle.Bold);
            string s = string.Format("姓名：{0}\n电话：{1}\nEmail：{2}", this.Name, this.PhoneNumber, this.Email);
            s = s + "（我是一名讲师经理）";
            g.DrawString(s, font, Brushes.Blue, x, y);
            font.Dispose();
        }
        public override void Teach()
        {
            //讲师经理在讲公开课
        }
    }
}