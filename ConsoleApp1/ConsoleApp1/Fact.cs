using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Fact
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fact(5));
        }
        public static long fact(int i)
        {
            if (i==0)
            {
                return 1;
            }
            return i*fact(i - 1);
        }
    }
}
