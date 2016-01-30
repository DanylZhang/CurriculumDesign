using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary测试
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("芙蓉",25);
            dic.Add("凤姐",26);
            dic.Add("安妮",22);
            //dic.Add("安妮", 20);//再添加相同键的值就会报错，就像数据库一样，主键是唯一的
            dic["安妮"] = 20;//通过索引的方式，可以更改已有主键对应的value，如果没有就会新插入该键值对
            foreach(string key in dic.Keys)
            {
                Console.WriteLine("{0}={1}",key,dic[key]);
            }
            SortedDictionary<string, int> sdic = new SortedDictionary<string, int>(dic);
            foreach (string key in sdic.Keys)
            {
                Console.WriteLine("{0}={1}", key, sdic[key]);
            }
        }
    }
}