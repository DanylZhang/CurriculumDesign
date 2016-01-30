using System;
using System.Drawing;

namespace 字符串拘留池
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "abc";
            string s2 = "123";
            Console.WriteLine(s1 == s2);

            bool b = object.ReferenceEquals(s1, s2);
            Console.WriteLine(b);

            string s3 = s2;
            b = object.ReferenceEquals(s2, s3);
            Console.WriteLine(b);

            Console.WriteLine("======Point=======");
            Point p1 = new Point(3, 5);
            Point p2 = new Point(3, 5);
            Console.WriteLine(p1 == p2);
            Console.WriteLine(object.ReferenceEquals(p1, p2));
            WeakReference wr = new WeakReference(p1);

            Console.WriteLine("======string=======");
            string s4 = "abc";
            string s5 = "abc";
            //因为有字符串拘留池的存在，所以仅有一个字符串的实例存在
            Console.WriteLine(object.ReferenceEquals(s4, s5));

            Console.WriteLine("======string=======");
            string s6 = "123";
            string s7 = new string("123".ToCharArray());//new相当于是说强制重新创建一个字符串
            Console.WriteLine(object.ReferenceEquals(s6, s7));
        }
    }
}