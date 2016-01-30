using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 调用Win32API
{
    class Program
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);

        static void Main(string[] args)
        {
            Random rand = new Random();
            for (int i = 0; i < 300; ++i)
            {
                int fre = rand.Next(10000);
                Console.WriteLine(fre);
                Beep(fre, 100);
            }
        }
    }
}