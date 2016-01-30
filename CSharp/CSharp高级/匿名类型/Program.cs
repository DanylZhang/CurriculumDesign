using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//可以说 var、匿名类型都是为了 Linq而存在的，还有扩展方法
namespace 匿名类型
{
    class Program
    {
        static void Main(string[] args)
        {
            object a = 5;
            a = "666";//原因是 object类型是所有C#类型的基类，其引用可以指向任意类型

            var i = 5;
            //i = "aaa";//可以看出 var只能算是 自动类型推导

            //var主要就是为了匿名类型而存在，如果没有var就无法声明匿名类型的对象
            var p = new { Name = "Tom", Age = 6 };
            Console.WriteLine(p.Name);
            var P1 = new { Name = "Jerry", Age = 6 };//编译器只生成一个匿名类型，因为 p1和p22成员相同

            object p2 = new { Father = "1", Mother = "2" };
            //p2. //object点不出成员
        }
    }
}