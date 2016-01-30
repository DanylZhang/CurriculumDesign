using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 静态类
{
    class Program
    {
        static void Main(string[] args)
        {
            //A a = new A();//静态类不能new即不能创建实例
            Console.WriteLine(Math.PI);//都是静态类
        }
        static class A
        {

        }
    }
}