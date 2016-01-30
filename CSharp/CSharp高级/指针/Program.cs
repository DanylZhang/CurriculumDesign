using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//build属性里面选择Allow unsafe code
//方法前加上 unsafe标记
namespace 指针
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            int i = 5;
            int* p = &i;
            *p = 6;
            Console.WriteLine(i);
        }
    }
}