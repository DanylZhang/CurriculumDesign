using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 枚举
{
    enum Gender {Male,Famale,Unkown};//C#中枚举和类同级
    class Program
    {
        static void Main(string[] args)
        {
            Gender g = Gender.Male;//枚举的意义就在于限定变量的取值范围
            Console.WriteLine(g);
        }
    }
}