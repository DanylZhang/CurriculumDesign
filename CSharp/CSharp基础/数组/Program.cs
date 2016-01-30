using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数组
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 30, 50, 100 };
            //int[] arr = new int[5] { 5, 3, 8 };//个数和声明数必须一致
            Console.WriteLine(array.Length);
            Console.WriteLine(array[0]);
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(array[i]);
            }

            string[] name={""};//静态的创建固定长度的数组，数组长度为1
            name[0] = "a";
            //name[1] = "b";//在C#中数组长度是固定的，无法动态增加
            string[] str = new string[5];//动态的创建固定长度的数组，数组长度为5
            str[0] = "a";
            str[1] = "b";
            str[2] = "c";
            str[3] = "d";
            str[4] = "e";
            //str[5] = "f";//Out Of Range

            string[] str1 = { "梅西", "卡卡", "郑大世" };
            for (int i = 0; i < str1.Length; ++i)
            {
                Console.Write(str1[i]);
                if (i == (str1.Length - 1))
                {
                    Console.Write("\n");
                    continue;
                }
                Console.Write("|");
            }

            foreach (string n in str1)
            {
                Console.WriteLine(n);
            }
        }
    }
}