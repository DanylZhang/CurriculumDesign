using System;

namespace 对象的引用
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            int j = i;
            i++;
            Console.WriteLine(j);

            //int、datetime、bool、char等类型都属于值类型(ValueType)，赋值的时候是传递拷贝。
            //普通对象则是引用类型(ReferenceType)，赋值的时候是传递引用。

            Person p1 = new Person();
            p1.Age = 10;
            Person p2 = p1;
            p1.Age++;
            Console.WriteLine(p2.Age);

            IncAge(p2);
            Console.WriteLine(p2.Age);//12,传递给函数也是引用传递
        }
        static void IncAge(Person p)
        {
            p.Age++;
        }
    }
    class Person
    {
        public int Age { get; set; }
    }
}