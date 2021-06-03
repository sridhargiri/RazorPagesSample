using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/program-for-armstrong-numbers/
     Program for Armstrong Numbers
Difficulty Level : Easy
Last Updated : 09 Nov, 2020
Given a number x, determine whether the given number is Armstrong number or not. A positive integer of n digits is called an Armstrong number of order n (order is number of digits) if.

abcd... = pow(a,n) + pow(b,n) + pow(c,n) + pow(d,n) + .... 
Example:

Input : 153
Output : Yes
153 is an Armstrong number.
1*1*1 + 5*5*5 + 3*3*3 = 153

Input : 120
Output : No
120 is not a Armstrong number.
1*1*1 + 2*2*2 + 0*0*0 = 9

Input : 1253
Output : No
1253 is not a Armstrong Number
1*1*1*1 + 2*2*2*2 + 5*5*5*5 + 3*3*3*3 = 723

Input : 1634
Output : Yes
1*1*1*1 + 6*6*6*6 + 3*3*3*3 + 4*4*4*4 = 1634
    The idea is to first count number digits (or find order). Let the number of digits be n. For every digit r in input number x, compute rn. If sum of all such values is equal to n, then return true, else false.
    */
    class ArmstrongNumber
    {

        // Function to calculate x raised
        // to the power y
        int power(int x, long y)
        {
            if (y == 0)
                return 1;
            if (y % 2 == 0)
                return power(x, y / 2) *
                       power(x, y / 2);

            return x * power(x, y / 2) *
                       power(x, y / 2);
        }

        // Function to calculate 
        // order of the number
        int order(int x)
        {
            int n = 0;
            while (x != 0)
            {
                n++;
                x = x / 10;
            }
            return n;
        }

        // Function to check whether the 
        // given number is Armstrong number
        // or not
        bool isArmstrong(int x)
        {

            // Calling order function
            int n = order(x);
            int temp = x, sum = 0;
            while (temp != 0)
            {
                int r = temp % 10;
                sum = sum + power(r, n);
                temp = temp / 10;
            }

            // If satisfies Armstrong condition
            return (sum == x);
        }
        /*
         Find nth Armstrong number

        Input  : 9
        Output : 9

        Input  : 10
        Output : 153
        */
        static int NthArmstrong(int n)
        {
            int count = 0;

            // upper limit from integer 
            for (int i = 1; i <= int.MaxValue; i++)
            {
                int num = i, rem, digit = 0, sum = 0;

                // Copy the value for num in num 
                num = i;

                // Find total digits in num 
                digit = (int)Math.Log10(num) + 1;

                // Calculate sum of power of digits 
                while (num > 0)
                {
                    rem = num % 10;
                    sum = sum + (int)Math.Pow(rem, digit);
                    num = num / 10;
                }

                // Check for Armstrong number 
                if (i == sum)
                    count++;
                if (count == n)
                    return i;
            }
            return n;
        }
        // Driver Code
        public static void Main()
        {
            ArmstrongNumber ob = new ArmstrongNumber();
            int x = 153;
            Console.WriteLine(ob.isArmstrong(x));
            x = 1253;
            Console.WriteLine(ob.isArmstrong(x));
            /*
             Output:
True
False
            */
            Console.WriteLine(NthArmstrong(12));
            //output 371
        }
    }
}
