using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace 扩展方法
{
    //扩展方法第一步，须是静态类
    static class StringHepler
    {
        //扩展方法第二步，静态类中须是静态方法
        //扩展方法第三步，扩展类的对象为第一个参数，且在前面加 this
        public static bool IsEmail(this string s)
        {
            if (s.Contains("@"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string ToChinese(this bool b)
        {
            return b ? "真" : "假";
        }
    }
}