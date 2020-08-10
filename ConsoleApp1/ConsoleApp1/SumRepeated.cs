using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class SumRepeated
    {
        public static int SumAgain(int number)
        {
            int result = 0;
            int rem = 0;
            int n = number;
            while (n > 0)
            {
                rem = n % 10;
                result = result + rem;
                n = n / 10;
            }
            if (result > 9)
            {
                result = SumAgain(result);
            }
            return result;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(SumAgain(123456789));
        }
    }
}
