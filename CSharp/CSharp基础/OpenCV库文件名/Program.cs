using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenCV库文件名
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> files = Directory.GetFiles(@"D:\Program Files\opencv\build\x86\vc12\lib").ToList();
            foreach (string str in files)
            {
                if (str.EndsWith("0.lib"))
                {
                    Console.WriteLine("-l" + str.Substring(0, str.Length - 4) + " \\");
                }
            }
        }
    }
}