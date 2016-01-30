using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//委托可以实现为方法传递一个方法过来并执行该方法
namespace 委托的组合
{
    class Program
    {
        static void Main(string[] args)
        {
            //Delegate是个类，有个无参的构造函数，但是为private类型，所以new必须传参
            SomeDelegate s = new SomeDelegate(Hello) + new SomeDelegate(Wow) + new SomeDelegate(Haha);
            s("Tom");

            Console.WriteLine("===========");
            s -= Hello;
            s("Jerry");
        }

        static void Hello(string name)
        {
            Console.WriteLine("Hello {0}", name);
        }

        static void Wow(string name)
        {
            Console.WriteLine("Wow {0}", name);
        }

        static void Haha(string name)
        {
            Console.WriteLine("Haha {0}", name);
        }
    }

    public delegate void SomeDelegate(string name);
}