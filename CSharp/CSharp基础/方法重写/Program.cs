using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 方法重写
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] per = new Person[4];
            Chinese cn1 = new Chinese();
            Chinese cn2 = new Chinese();
            Japanese jp1 = new Japanese();
            Japanese jp2 = new Japanese();
            per[0] = cn1;
            per[1] = cn2;
            per[2] = jp1;
            per[3] = jp2;
            for (int i = 0; i < per.Length; ++i)
            {
                //if (per[i] is Chinese)
                //{
                //    Chinese c = per[i] as Chinese;
                //    c.ShowNationality();
                //}
                //else if (per[i] is Japanese)
                //{
                //    Japanese j = (Japanese)per[i];
                //    j.ShowNationality();
                //}
                per[i].ShowNationality();
            }
            per[1].Go();
        }
    }
    abstract class Person
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        abstract public void ShowNationality();
        virtual public void Go()
        {
            Console.WriteLine("go somewhere");
        }
    }
    class Chinese : Person
    {
        public string HuKou
        {
            get;
            set;
        }
        override public void ShowNationality()
        {
            //base.ShowNationality();//这种解决方案在任何时候都将调用父类的方法，使用new关键字
            Console.WriteLine("中国人");
        }
        public override void Go()
        {
            Console.WriteLine("go China");
        }
    }
    class Japanese : Person
    {
        public void PoFu()
        {
            Console.WriteLine(":-)");
        }
        override public void ShowNationality()
        {
            Console.WriteLine("日本");
        }
        public new void Go()//new是向父类隐藏子类的实现，即声明该成员是子类自己的不是重写的父类的
        {
            Console.WriteLine("go Japan");
        }
    }
}