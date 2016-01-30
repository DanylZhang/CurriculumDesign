using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 构造函数
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            Console.WriteLine("{0}:{1}", p1.Name, p1.Age);
            Person p2 = new Person("Tom");
            Console.WriteLine("{0}:{1}", p2.Name, p2.Age);
            Person p3 = new Person("Tom",20);
            Console.WriteLine("{0}:{1}", p3.Name, p3.Age);
        }
    }
    class Person
    {
        #region 姓名
        /// <summary>
        /// 姓名
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion
        #region 年龄
        /// <summary>
        /// 年龄
        /// </summary>
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        #endregion
        public Person()
        {
            this.Name = "未命名";
            this.Age = 0;
        }
        public Person(string name)
        {
            this.Name = name;
            this.Age = 0;
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}