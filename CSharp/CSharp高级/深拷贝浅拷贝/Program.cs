using System;

namespace 深拷贝浅拷贝
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Id = 123;
            Dog jingba = new Dog();
            jingba.Name = "北京八爷";
            p1.Dog = jingba;
            Person p2 = (Person)p1.Clone();
        }
    }
    class Person :ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dog Dog { get; set; }
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
        public object Clone()
        {
            Person p = new Person();
            p.Id = this.Id;
            p.Name = this.Name;
            //两个Person对象指向同一个Dog
            //这就是浅层拷贝,只拷贝类的第一层成员
            //要想实现深层拷贝就去实现Dog类的ICloneable接口
            p.Dog = this.Dog;
            //return p;

            //.NET实现的浅层拷贝快捷方法，仅拷贝成员级别的
            //MemberwiseClone()是protected方法，仅在类内部调用
            return this.MemberwiseClone();
        }
    }
    class Dog
    {
        public string Name { get; set; }
    }
}