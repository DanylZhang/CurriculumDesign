using System;
using System.Collections.Generic;
using System.Linq;

namespace HashSetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(3);
            list.Add(5);
            list.Add(3);
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("***********");
            HashSet<int> hash = new HashSet<int>();
            hash.Add(5);
            hash.Add(3);
            hash.Add(5);
            hash.Add(3);
            foreach (int i in hash)
            {
                Console.WriteLine(i);
            }
        }
    }
}