using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Reverse number
    Examples :

Input : num = 12345
Output : 54321

Input : num = 876
Output : 678
     */
    class ReverseNumber
    {
        // Iterative function to  
        // reverse digits of num 
        static int reversDigits(int num)
        {
            int rev_num = 0;
            while (num > 0)
            {
                rev_num = rev_num * 10 + num % 10;
                num = num / 10;
            }
            return rev_num;
        }

        // Driver code 
        public static void Main()
        {
            int num = 4562;
            Console.Write("Reverse of no. is "
                            + reversDigits(num));
        }
    }
}
