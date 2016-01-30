using System;
using System.Collections;
using System.Linq;

namespace ArrayList测试
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList可以存放任何类型的对象，因为CSharp里面所有的的类都继承自object
            ArrayList list1 = new ArrayList();
            list1.Add(1);
            list1.Add("2");
            list1.Add(true);
            for (int i = 0; i < list1.Count; ++i)
            {
                object obj = list1[i];
                Console.WriteLine(obj);
            }
            int[] a = { 3, 8, 9, 22, 33 };
            ArrayList list2 = new ArrayList();
            list2.AddRange(a);
            foreach (object obj in list2)
            {
                Console.WriteLine(obj);
            }
        }
    }
}