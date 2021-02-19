using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if an integer is rotation of another given integer
Last Updated : 12 Feb, 2021
Given two integers A and B, the task is to check if the integer A is rotation of the digits of the integer B or not. If found to be true, then print “Yes”. Otherwise print “No”.

Examples:

Input: A= 976, B= 679
Output: Yes

Input: A= 974, B= 2345
Output: No

Approach: Follow the steps below to solve the problem:
    If A == B, then print “Yes”.
Calculate the count of digits of integer present in the integer A and B in variables, say dig1 and dig2.
If dig1 != dig2 is found ot be true, then print “No”.
Initialize a variable, say temp. Assign temp = A.
Now, iterate and perform the following operations:
Find the position of the first digit value of A and store it in a variable, say X = A / 10(dig1 – 1).
Rotate the digits of the integer A by performing A = (A – X*10(dig1 – 1))*10 + X.
Print “Yes” if A is equal to B and break.
Check if (A== temp) i.e A becomes equal to original integer temp. If found to be true, then print “No” and break.
Below is the implementation of the above approach:
    */
    class NumberRotation
    {
        static bool check(double A, double B)
        {

            if (A == B)
            {
                return true;
            }

            // Stores the count of digits in A 
            double dig1 = Math.Floor(Math.Log10(A) + 1);

            // Stores the count of digits in B 
            double dig2 = Math.Floor(Math.Log10(B) + 1);

            // If dig1 not equal to dig2 
            if (dig1 != dig2)
            {
                return false;
            }

            double temp = A;

            while (true)
            {

                // Stores position of first digit 
                double power = Math.Pow(10, dig1 - 1);

                // Stores the first digit 
                double firstdigit = A / power;

                // Rotate the digits of the integer 
                A = A - firstdigit * power;
                A = A * 10 + firstdigit;

                // If A is equal to B 
                if (A == B)
                {
                    return true;
                }
                // If A is equal to the initial 
                // value of integer A 
                if (A == temp)
                {
                    return false;
                }
            }
        }
        public static void Main(string[] args)
        {
            double A = 967, B = 679;
            if (check(A, B))
                Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
