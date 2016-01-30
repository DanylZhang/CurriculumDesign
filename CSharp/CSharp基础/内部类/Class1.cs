using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 内部类
{
    class Class1
    {
        public class Class3
        {
            public Class3()
            {
                Console.WriteLine("使用内部类必须在前面添加外部类名！");
            }
        }
    }
    public class Class2
    {

    }
}