using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 委托实现事件
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter1 = new Counter();
            counter1.On10 += new EventDelegate(On10);//像Click事件一样
            while (true)
            {
                counter1.Next();
            }
        }

        static void On10(int i)
        {
            Console.WriteLine("10的倍数：{0}", i);
        }
    }

    class Counter
    {
        private int count = 0;
        public EventDelegate On10;

        //解耦，类开发者不必管使用者会执行什么样的委托事件，而类使用者则不必管何时肿么样 该类会调用委托的事件
        public void Next()
        {
            count++;
            if ((On10 != null) && (count % 10 == 0))
            {
                On10(count);
            }
        }
    }

    public delegate void EventDelegate(int i);
}