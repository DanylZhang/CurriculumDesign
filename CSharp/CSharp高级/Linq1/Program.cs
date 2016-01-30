using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 2, 5, 1, -8, -3, 50, 35, 4, -45, 89, 678, 321 };

            var e = a.Where(i => i > 0).OrderBy(i => i).Select(i => "[" + i + "]");
            foreach (var i in e)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("==========进化到Linq==========");
            var e1 = from i in a//对集合a中的每一个元素命名为i，并对i进行如下处理
                     where i > 0
                     orderby i descending
                     select "[" + i + "]";//返回值类型取决于select
                    //基于类型推断的考虑，select在最后，from在最前
            foreach(var i in e1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("==========进化到select匿名类型==========");
            var e2 = from i in a
                     where i > 0
                     orderby i
                     select new { Name = "老" + i, Age = i };
            foreach(var p in e2)
            {
                Console.WriteLine("{0}:{1}", p.Name, p.Age);
            }
            Console.WriteLine("==========进化到let==========");
            string[] strs = { "1", "2", "34", "67" };
            var e3 = from str in strs
                     let i = Convert.ToInt32(str)//let相当于声明一个变量
                     select i;
            //Linq语句经由lambda表达式最终转换为委托，故Linq中可用C#函数
            foreach(var i in e3)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("==========进化到复杂集合==========");
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Tom", 19);
            dict.Add("Jerry", 18);
            dict.Add("Tim", 16);
            dict.Add("Doclars", 21);
            dict.Add("Amy", 22);
            var e4 = from name in dict.Keys
                     where dict[name] > 20
                     select name;
            Console.WriteLine(string.Join(",", e4.ToArray()));
        }
    }
}