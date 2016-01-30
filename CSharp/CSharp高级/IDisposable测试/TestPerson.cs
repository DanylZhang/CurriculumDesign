using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDisposable测试
{
    class TestPerson : IDisposable
    {
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
        public void Dispose()
        {
            Console.WriteLine("这表示着在Dispose掉Person");
        }
    }
}