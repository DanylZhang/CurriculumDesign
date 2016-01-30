using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 函数
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = { "111", "222", "333" };
            VFun(values);
            VFun("aaa", "bbb", "ccc");
            SayHello("Tom", "三儿", "铁蛋儿", "大虎");
            SayHello("Tom",30);
        }
        static void VFun(params string[] values)//函数可变参数params
        {
            foreach (string n in values)
            {
                Console.WriteLine(n);
            }
        }
        static void SayHello(string name, params string[] nicknames)
        {//函数可变参数混用，但必须是在参数列表的后面，类似于带默认值的形参应放在后面
            Console.WriteLine("我的名字是{0}", name);
            foreach (var nickname in nicknames)
            {
                Console.WriteLine("我的昵称：{0}", nickname);
            }
        }
        static void SayHello(string name, int age = 20)
        {//SayHello重载了，而且还带有默认形参，且默认形参放后面
            Console.WriteLine("我的名字是{0}", name);
            Console.WriteLine("我的年龄是{0}", age);
        }
    }
}