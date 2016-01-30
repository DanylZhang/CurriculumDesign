using System;

namespace CSharp时间相关
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt1=Convert.ToDateTime("下午 18:00");

            //Console.WriteLine(dt1.ToBinary());
            //Console.WriteLine(dt1.ToFileTime());
            //Console.WriteLine(dt1.ToFileTimeUtc());
            //Console.WriteLine(dt1.ToLocalTime());
            //Console.WriteLine(dt1.ToLongDateString());
            //Console.WriteLine(dt1.ToLongTimeString());
            //Console.WriteLine(dt1.ToOADate());
            //Console.WriteLine(dt1.ToShortDateString());
            Console.WriteLine(dt1.ToShortTimeString());
            //Console.WriteLine(dt1.ToString());
            //Console.WriteLine(dt1.ToUniversalTime());

            Console.WriteLine(DateTime.Parse("18:00"));
            Console.WriteLine(DateTime.Today);
            Console.WriteLine(DateTime.Now.Date);
            Console.WriteLine(DateTime.Now.Day+"号");
            Console.WriteLine(DateTime.Now.DayOfWeek);//返回星期几
            Console.WriteLine(DateTime.Now.DayOfYear);//一年当中的第几天
            Console.WriteLine(DateTime.Now.Minute);

            Console.WriteLine(dt1.Hour);
        }
    }
}