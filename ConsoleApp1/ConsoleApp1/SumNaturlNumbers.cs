using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SumNaturlNumbers
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(AddNumbers(5));
        }
        public static int AddNumbers(int n) {
            if (n != 0)
                return n + AddNumbers(n - 1);
            else
                return 0;
        }
    }
}
