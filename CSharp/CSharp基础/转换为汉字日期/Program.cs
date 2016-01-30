using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 转换为汉字日期
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "2014年8月10日";
            Console.WriteLine(CHDate(s));

        }
        static string CHDate(string str)
        {
            char[] strs = str.ToCharArray();
            for (int i = 0; i < strs.Length; ++i)
            {
                switch (strs[i])
                {
                    case '1':
                        strs[i] = '一';break;
                    case '2':
                        strs[i] = '二';break;
                    case '3':
                        strs[i] = '三';break;
                    case '4':
                        strs[i] = '四';break;
                    case '5':
                        strs[i] = '五';break;
                    case '6':
                        strs[i] = '六';break;
                    case '7':
                        strs[i] = '七';break;
                    case '8':
                        strs[i] = '八';break;
                    case '9':
                        strs[i] = '九';break;
                    case '0':
                        strs[i] = '零';break;
                    default:
                        break;
                }
            }
                return new string(strs);
        }
    }
}