using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//实现了IDisposable接口的对象一般是非托管资源，GC不负责回收。
//所以要注意对非托管资源（数据库连接、文件读写等）进行using，防止内存泄露
namespace IDisposable测试
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileStream fs = new FileStream("D:/Documents/blsys.ini", FileMode.Open, FileAccess.Read);
            //using (fs)
            //{
            //}
            //fs.ReadByte();//无法访问已关闭的文件

            TestPerson p1 = new TestPerson();
            using (p1)
            {
                p1.SayHello();
            }//这里会隐式调用实现的Dispose()方法
        }
    }
}