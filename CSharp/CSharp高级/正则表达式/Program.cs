using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace 正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient myWebClient = new WebClient();
            Stream myStream = myWebClient.OpenRead(new Uri("http://www.baidu.com"));
            StreamReader sr = new StreamReader(myStream, Encoding.UTF8);
            string strHTML = sr.ReadToEnd();

            //MatchCollection匹配分组
            MatchCollection matches = Regex.Matches(strHTML, "<a(.+?)href=\"(.+?)\"(.*?)>(.+?)</a>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            foreach (var match in matches.Cast<Match>())
            {
                Console.WriteLine(match.Groups[2].Value);
            }

            //分组替换
            string s = "age=18 name=tom height=180";
            s = Regex.Replace(s, @"(\w+?)=(\w+?)", "$1是$2", RegexOptions.IgnoreCase);
            Console.WriteLine(s);
        }
    }
}