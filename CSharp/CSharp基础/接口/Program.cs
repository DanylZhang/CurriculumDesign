//抽象类使用来让子类继承实现的，接口只是定义了公共的能力簇，即相关能力写在一个接口内
//接口相当于给类打了一个标签，标志着这个类具有这个能力
//接口中能声明：方法，属性，索引器；但是不能声明：字段，因为没有用
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 接口
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird b1 = new Bird();
            b1.Fly();
            b1.Run();
            Flyable b2 = b1;
            b2.Fly();
            //b2.Run();//类似于抽象类继承实现多态

            object obj1 = new Bird();
            if (obj1 is Runable)
            {
                Console.WriteLine("可以跑");
                Runable r1 = (Runable)obj1;//如果转换失败报错
                Runable r2 = obj1 as Runable;//如果转换失败返回null
            }
            using (Bird b = new Bird())
            {

            }
        }
    }
    public interface Flyable//接口一般是***able
    {
        void Fly();//不能有访问修饰符，因为没有意义,且全部不能实现
        int Speed//因为属性的本质是方法，所以可以声明属性
        {
            get;
            set;
        }
        /*相当于声明了这样两个方法
        void set_Age(int value);
        int get_Age();*/
    }
    public interface Runable
    {
        void Run();
    }
    public class Bird : Flyable, Runable,IDisposable//“实现接口”，“继承父类”，可以实现多个接口，但只能继承自一个类
    {
        private int speed;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                this.speed = value;
            }
        }
        public void Fly()
        {
            Console.WriteLine("我在飞");
        }
        public void Run()
        {
            Console.WriteLine("蹦蹦哒");
        }

        public void Dispose()//该方法出了using会自动调用
        {
            Console.WriteLine("啊，我死了！！！");
        }
    }
}