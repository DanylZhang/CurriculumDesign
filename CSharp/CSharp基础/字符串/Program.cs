using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字符串
{
    class Program
    {
        static void Main(string[] args)
        {
            //char采用UTF-16编码，可存储汉字
            char chars = '张';
            int aaa = chars;
            Console.WriteLine(chars);
            Console.WriteLine(aaa);

            //ToLower(),ToUpper()大小写转换
            string s = "Hello";
            Console.WriteLine(s);
            s = s.ToLower();//内部操作是s重新指向了一块新的内存区域
            Console.WriteLine(s);
            Console.WriteLine(s.ToUpper());

            //Trim()去掉字符串两端的空字符
            string s1 = " ab ";
            Console.WriteLine("|{0}|", s1);
            Console.WriteLine("|{0}|", s1.Trim());

            //Equals()判断相等，可以不区分大小写
            bool b = ("abc" == "ABC");//==区分大小写，False
            bool b1 = ("abc".Equals("ABC", StringComparison.OrdinalIgnoreCase));//含有不区分大小写的选项，True
            Console.WriteLine("b={0},b1={1}", b, b1);

            //CompareTo()返回值为1、-1、0
            int i = "abc".CompareTo("aba");
            Console.WriteLine(i);

            //Split()拆分字符串成字符串数组
            string s2 = "aaa,bbb,ccc,adgas.asdf3.783|234|34234,243";
            string[] s3 = s2.Split(',', '.', '|');
            foreach (string item in s3)
            {
                Console.WriteLine(item);
            }

            //Split()
            string s4 = "aaa,bbb,ccc,,123,34,,,442..56";
            //string[] s5 = s4.Split(',');
            string[] s5 = s4.Split(new char[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries);//移除空的字符串
            foreach (string item in s5)
            {
                Console.WriteLine(item);
            }

            //Join()添加分隔符
            string[] values = { "aa", "bb", "cc" };
            Console.WriteLine(string.Join("|", values));

            //读文件
            string[] lines = System.IO.File.ReadAllLines(@"d:\Documents\Visual Studio 2013\Projects\学生信息管理系统\学生信息管理系统\score.txt", Encoding.Default);
            foreach (string item in lines)
            {
                Console.WriteLine(item);
            }

            //Replace(string OldValue,string NewValue)
            string s6 = "李时珍同志是一个好同志，是一个好医生，向李时珍同志学习";
            s6 = s6.Replace("李时珍", "李素丽");
            Console.WriteLine(s6);

            //Substring(int StartIndex)
            string s7 = "http://www.baidu.com";
            string domain = s7.Substring(7);
            Console.WriteLine(domain);

            //Substring(int StartIndex,int length)
            domain = s7.Substring(7, 9);
            Console.WriteLine(domain);
            //domain = s7.Substring(7, 100);//如果length超过了长度，就会报错

            //Contains(string Value)
            string s8 = "社会主义真和谐啊！";
            if (s8.Contains("和谐"))
            {
                Console.WriteLine("请文明用语，共建河蟹社会！");
            }

            //StartsWith()
            string s9 = "http://www.baidu.com";
            if (s9.StartsWith("http://") || s9.StartsWith("https://"))
            {
                Console.WriteLine("是网址");
            }
            else
            {
                Console.WriteLine("不是网址");
            }

            //EndsWith()
            if (s9.EndsWith(".com"))
            {
                Console.WriteLine("这是一个商业网址");
            }

            //IndexOf()
            string s10 = "你好，我是王某某";
            int i1 = s10.IndexOf("我是");//如果不含有该字符串则返回-1
            Console.WriteLine(i1);
        }
    }
}