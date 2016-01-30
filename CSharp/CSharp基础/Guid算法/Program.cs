using System;
using System.Linq;

namespace Guid算法
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid id = Guid.NewGuid();
            Console.WriteLine(id);
        }
    }
}