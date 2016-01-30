using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 100;
            switch (i)
            {
                case 2://相当于if (i == 2)
                    Console.WriteLine("你真2！");
                    Console.WriteLine("你才2！");
                    break;
                case 4://相当于if (i == 4)
                    Console.WriteLine("死死死！");
                    break;
                case 10://不同的情况执行一样的操作是唯一一个 case 后不用 break 的情况
                case 20:
                case 50:
                case 100://相当于if (i == 10 || i == 20 || i == 50 || i == 100)
                    Console.WriteLine("这是整钱！");
                    Console.WriteLine("您真有钱！");
                    break;
                default://相当于 if 语句的 else
                    Console.WriteLine("您输入的{0}没有意义！", i);
                    break;
            }
        }
    }
}