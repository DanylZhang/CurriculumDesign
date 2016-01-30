using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 匿名方法
{
    class Program
    {
        static void Main(string[] args)
        {
            //匿名函数
            AnonymousDelegate f = delegate (string s)
              {
                  Console.WriteLine("匿名 {0}", s);
              };
            f("Hello");

            //Lambda表达式，如果函数体只有一句话，可以不写大括号
            f = (s1) => Console.WriteLine("lambda {0}", s1);
            f("Wow");

            int[] array = { -1, 2, 3, 1, 5, -8, 8, 6, -9 };
            foreach (int i in array.Select(j => j * 2))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("======偶数======");
            foreach (int i in array.Where(j => j % 2 == 0))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("======排序======");
            foreach (int i in array.OrderBy(j => j))
            {
                Console.WriteLine(i);
            }
        }
    }

    public delegate void AnonymousDelegate(string s);
}