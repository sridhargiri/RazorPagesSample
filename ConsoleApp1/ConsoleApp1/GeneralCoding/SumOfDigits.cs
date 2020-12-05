using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class pro
    {
        public int _sum(int num)
        {
            int sum = 0;
            int r = 0;
            while (num > 0)
            {
                r = num % 10;
                sum = sum + r;
                num = num / 10;
            }
            return sum;
        }
        public int sum(int num)
        {
            if (num != 0)
            {
                return (num % 10 + sum(num / 10));
            }
            else
            {
                return 0;
            }
        }
    }
    public class SumOfDigits
    {
        public static void Main(string[] args)
        {
            int num, result;
            pro pg = new pro();
            Console.WriteLine("Enter the Number : ");
            num = int.Parse(Console.ReadLine());
            result = pg._sum(num);
            Console.WriteLine("Sum of Digits in {0} is {1}", num, result);
            Console.ReadLine();
        }
    }
}
