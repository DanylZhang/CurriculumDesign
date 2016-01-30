using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 扩展方法
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            //调用扩展方法时，.前面的是第一个参数
            Console.WriteLine(s.IsEmail().ToChinese());
        }
    }
}