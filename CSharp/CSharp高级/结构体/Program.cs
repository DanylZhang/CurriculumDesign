using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 结构体
{
    class Program
    {
        static void Main(string[] args)
        {
            //这段代码可验证类class对象是引用类型，即指向内存中同一个对象
            Person p1 = new Person();
            p1.Age = 20;
            Person p2 = p1;
            p2.SayHello();
            p1.Age++;
            p2.SayHello();
            Console.WriteLine(object.ReferenceEquals(p1, p2));

            Console.WriteLine("========struct========");
            //这段代码验证结构体struct对象是值类型(System.ValueType)，赋值“=”即创建新对象
            MyPoint point1 = new MyPoint();
            point1.X = 5;
            MyPoint point2 = point1;
            point2.SayHello();
            point1.X++;
            point2.SayHello();
            Console.WriteLine(object.ReferenceEquals(point1, point2));
        }
    }

    //enum delegate class struct

    struct MyPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void SayHello() { Console.WriteLine(X); }
    }
    class Person
    {
        public int Age { get; set; }
        public void SayHello() { Console.WriteLine(Age); }
    }
}