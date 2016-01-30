using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("int最大值{0}，int最小值{1}", int.MaxValue, int.MinValue);
            Console.WriteLine("byte最大值{0}，byte最小值{1}", byte.MaxValue, byte.MinValue);
            byte b = 3;
            int i1 = b;//类型转换隐式完成
            Console.WriteLine("i1={0}", i1);
            i1 = 9299;
            b = (byte)i1;//类型转换需要显示完成
            Console.WriteLine("b={0},i1={1}", b, i1);
            string s = "123";
            //int i = (int)s;对于这种转换只能借助Convert.To..()方法完成
            int i = Convert.ToInt32(s);
            Console.WriteLine("i={0}", i);
        }
    }
}