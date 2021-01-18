using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    //Check if frequency of each digit is less than the digit
    //    Given an integer n, the task is to check if frequency of each digit of the number is less than or equal to digit itself.

    //Examples:

    //Input : 51241
    //Output : False

    //Input : 1425243
    //Output : True
    class DigitFrequency
    {
        //Naive Approach: 
        //Start from 0 and count the frequency for every digit upto 9, if at any place frequency is more than the digit value then return false, else return true.

        static bool validate(long n)
        {
            for (int i = 0; i < 10; i++)
            {
                long temp = n;
                int count = 0;
                while (temp > 0)
                {
                    // If current digit of  
                    // temp is same as i 
                    if (temp % 10 == i)
                        count++;

                    // if frequency is greater than  
                    // digit value, return false 
                    if (count > i)
                        return false;

                    temp /= 10;
                }
            }
            return true;
        }
        //Efficient Approach: is to store the frequency of each digit and if at any place frequency is more than the digit value then return false, else return true.

        static bool validate1(long n)
        {
            int[] count = new int[10];
            while (n > 0)
            {
                // calculate frequency  
                // of each digit  
                int r = (int)n % 10;

                // If count is already r, then   
                // incrementing it would invalidate,  
                // hence we return false.  
                if (count[r] == r)
                    return false;

                count[r]++;
                n /= 10;
            }

            return true;
        }
        static public void Main(String[] args)
        {
            long n = 1552793;
            if (validate(n))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            if (validate1(n))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }
    }
}
