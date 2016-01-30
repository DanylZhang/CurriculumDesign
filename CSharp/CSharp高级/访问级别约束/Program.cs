using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 访问级别约束
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Boss
    {
        //一个程序集外部能访问的方法不能返回一个internal类的对象
        //public Person CreatePerson()
        //{
        //    return new Person();
        //}
    }

    class Person
    {
        public void Hello()
        {
        }
    }
    //子类不能比父类的访问级别高
    //public > internal > private
    //internal(默认)表明该类仅能在程序集内部访问
    //public class Chinese : Person
    class Chinese : Person
    {
    }
}