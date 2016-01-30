using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 委托应用之数据过滤
{
    enum A { A1, A2 };

    class Program
    {
        static void Main(string[] args)
        {
            A a = A.A1;
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);
            list1.Add(8);
            list1.Add(-9);
            list1.Add(300);

            //此处的委托用法很像 C++中的 一元函数对象
            List<int> list2 = Filter(list1, PositiveNumberFilter);
            foreach(int i in list2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("======偶数======");
            //此处很像Click += new EventHandler(Button1_Click);
            List<int> list3 = Filter(list1, new FilterDelegate(EvenNumberFilter));
            foreach(int i in list3)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// 过滤正数，必须与委托的参数类型一致
        /// </summary>
        /// <param name="i"></param>
        /// <returns>参数是否是正数</returns>
        static bool PositiveNumberFilter(int i)
        {
            return i > 0;
        }

        static bool EvenNumberFilter(int i)
        {
            return i % 2 == 0;
        }

        static List<int> Filter(List<int> list,FilterDelegate f)
        {
            List<int> list1 = new List<int>();
            foreach (int i in list)
            {
                if (f(i))
                {
                    list1.Add(i);
                }
            }
            return list1;
        }
    }
    
    //委托是一种类型，声明委托就像是在声明一个函数并在前面加上delegate
    public delegate bool FilterDelegate(int i);
    //委托不支持重载
    //public delegate bool FilterDelegate(double i);
}