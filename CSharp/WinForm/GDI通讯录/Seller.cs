using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDI通讯录
{
    class Seller:Employee
    {
        public Seller(string name, string phoneNo, string email)
        {
            // TODO: Complete member initialization
            this.Name = name;
            this.PhoneNumber = phoneNo;
            this.Email = email;
        }
        public override void Print(Graphics g, int x, int y)
        {
            Font font = new Font("楷体", 15, FontStyle.Bold);
            string s = string.Format("姓名：{0}\n电话：{1}\nEmail：{2}", this.Name, this.PhoneNumber, this.Email);
            s = s + "（我是一名销售员工）";
            g.DrawString(s, font, Brushes.Blue, x, y);
            font.Dispose();
        }
        public virtual void Publicize()
        {
            //销售人员在做市场宣传
        }
    }
}