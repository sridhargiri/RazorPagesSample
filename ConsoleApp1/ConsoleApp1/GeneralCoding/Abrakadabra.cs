/*
Abra_ka_dabra series looks like following.(1+2+3), (2+3+4), (3+4+5), (4+5+6)
So, your method should return 6, 54, 648, 9720 for inputs 1,2,3,4, and so on.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Abrakadabra
    {
        public static void Main(string[] args)
        {
            int res = Abra(4);
            Console.WriteLine(res);
        }
        public static int Abra(int n)
        {
            int product = 1, sum = 0, i = 1, j = 1, k = 0;
            while (n>0)
            {
                while (k<3)
                {
                    sum += i++;k++;
                }
                product = product * sum;
                k = 0; i=++j;sum = 0;
                n--;
            }
            return product;
        }
    }
}
