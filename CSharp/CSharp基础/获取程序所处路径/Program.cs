using System;

namespace 获取程序所处路径
{
    class Program
    {
        static void Main(string[] args)
        {
            string exeDir1 = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(exeDir1);//基本路径+'\'，不包含程序名

            string exeDir2 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            Console.WriteLine(exeDir2);//基本路径+'\'，不包含程序名

            string exeDir3 = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            Console.WriteLine(exeDir3);//仅有程序名，所以2、3配合使用

            string exeDir4 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            Console.WriteLine(exeDir4);//Full Path With Program Name.
        }
    }
}