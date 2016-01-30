using System;
using System.Text.RegularExpressions;

namespace 正则表达式只能匹配中文
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "今天怎~么不开心。摩擦 摩擦，在这光滑的地板上。";
            Console.WriteLine(Regex.Replace(s, @"[^\u4e00-\u9fa5]", ""));
        }
    }
}