using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GC回收
{
    class Program
    {
        static void Main(string[] args)
        {
            //GC.Collect();手动垃圾回收，非极端情况不要手动GC，否则影响性能
            Person p1 = new Person();
            WeakReference wr = new WeakReference(p1);
            p1 = null;
            //wr.IsAlive;//判断此弱引用的对象是否还活着
            Console.WriteLine(wr.IsAlive);
            GC.Collect();
            Console.WriteLine(wr.IsAlive);
        }
    }

    class Person
    {
        public string Name
        {
            get;set;
        }
        public int Age
        {
            get;set;
        }
    }
}