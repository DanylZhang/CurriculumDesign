using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 运算符重载
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Id = 123;
            p1.Name = "王富贵";
            Person p2 = new Person();
            p2.Id = 123;
            p2.Name = "王飘云";
            Console.WriteLine(p1 == p2);
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Id == p2.Id;
        }
        public static bool operator !=(Person p1, Person p2)
        {
            return p1.Id != p2.Id;
        }
        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is Person)
            {
                flag = this.Equals((Person)obj);
            }
            return flag;
        }
    }
}