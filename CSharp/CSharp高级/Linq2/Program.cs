using System;
using System.Linq;
//Linq只支持泛型的序列，IEnumerable<T>，对于非泛型的序列要用Cast<T>()或OfType转换
namespace Linq2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======按数字出现的次数排序=======");
            int[] a = { 1, 2, 3, 1, 4, 5, 5, 6, 4, 3, 3, 3, 3 };
            var e1 = from i in a
                     group i by i into g
                     orderby g.Count() descending
                     select new { 数字 = g.Key, 次数 = g.Count() };
            foreach(var item in e1)
            {
                Console.WriteLine("数字:{0},次数{1}", item.数字, item.次数);
            }
            Console.WriteLine("=======取交集==========");
            int[] b = { 21, 34, 1, 6, 234, 34, 2, 34, 1, 8 };
            var result = a.Intersect(b);
            foreach(var i in result)
            {
                Console.WriteLine(i);
            }

            int[] c = { 1 };
            //如果该数组不是只有一个元素，就会报错
            Console.WriteLine("第一个{0},最后一个{1},只有一个{2}", c.First(), c.Last(), c.Single());

            object[] values = { 12, 434, 23, 1, 3, 4,"aa"};
            //Cast<T>()是所有的都转换
            //int n = values.Cast<int>().Max();
            //OfType<T>()是只转换符合类型的
            int m = values.OfType<int>().Max();
        }
    }
}