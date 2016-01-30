using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 内部类
{
    class Program
    {
        static void Main(string[] args)
        {
            Class2 cls2 = new Class2();//正常书写，没有问题
            内部类.Class1.Class3 cls3 = new Class1.Class3();//使用内部类必须在前面添加外部类名
        }
    }
}