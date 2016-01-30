using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDI通讯录
{
    abstract class Employee
    {
        public string Name
        {
            set;
            get;
        }
        public string PhoneNumber
        {
            set;
            get;
        }
        public string Email
        {
            set;
            get;
        }
        public abstract void Print(Graphics g, int x, int y);
    }
}