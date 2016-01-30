//永远不要把字段设为public，一般某字段对应的属性要设置为public
//字段标示符要小写，对应的属性开头要大写
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 属性
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Name = "Tom";
            p.Age = 20;
            Console.WriteLine("{0}:{1}", p.Name, p.Age);
        }
    }
    class Person
    {
        private int age;
        public string Name { get; set; }
        public int Age
        {
            set
            {
                if (value < 0)
                {
                    return;
                }
                this.age = value;
            }
            get
            {
                return this.age;
            }
        }
    }
}