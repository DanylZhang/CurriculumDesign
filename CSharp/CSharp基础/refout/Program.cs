//ref、out不认为是对方法的有效重载
//ref一般用处类似于引用传递，而out一般用在函数有多个返回值的场所
//ref、out共同点：都可以对外部变量的值进行改变，并反映到函数外部
/*不同点：
 * ref类似于C++当中的引用传递，函数内部的改变对外部实参造成影响，但是传递的参数要先在函数外部初始化好
 * out则不需要参数在函数外部初始化好，因为传递过去后，一律认为变量还未初始化，但内部操作会影响外部变量值
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refout
{
    class Program
    {
        static void Main(string[] args)
        {
            //ref的实验
            int i1 = 10, i2 = 20;
            Console.WriteLine("i1={0},i2={1}", i1, i2);
            swap(ref i1, ref i2);
            Console.WriteLine("i1={0},i2={1}", i1, i2);

            //out的实验，TryParse()常用方法
            string str = Console.ReadLine();
            int i;
            if (int.TryParse(str, out i))//TryParse
            {
                Console.WriteLine("转换成功！{0}", i);
            }
            else
            {
                Console.WriteLine("输入错误！");
            }
        }
        static void swap(ref int i1, ref int i2)
        {
            int temp = i1;
            i1 = i2;
            i2 = temp;
        }
    }
}