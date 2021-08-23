using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-the-number-which-when-added-to-the-given-ratio-a-b-the-ratio-changes-to-c-d/
    Find the number which when added to the given ratio a : b, the ratio changes to c : d
Last Updated : 22 Mar, 2021
Given four integers a, b, c and d. The task is to find the number X which when added to the numbers a and b the ratio changes from a : b to c : d.
Examples: 
 

Input: a = 3, b = 6, c = 3, d = 4 
Output: 6 
When 6 is added to a and b 
a = 3 + 6 = 9 
b = 6 + 6 = 12 
And, the new ratio will be 9 : 12 = 3 : 4
Input: a = 2, b = 3, c = 4, d = 5 
Output: 2 
 

 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: Old ratio is a : b and new ratio is c : d. Let the required number be X, 
So, (a + X) / (b + X) = c / d 
or, ad + dx = bc + cx 
or, x(d – c) = bc – ad 
So, x = (bc – ad) / (d – c) 
Below is the implementation of the above approach: 
     */
    class RatioNum
    {

        // Function to return the
        // required number X
        static int getX(int a, int b, int c, int d)
        {
            int X = (b * c - a * d) / (d - c);
            return X;
        }

        // Driver code
        static public void Main()
        {
            int a = 2, b = 3, c = 4, d = 5;
            Console.Write(getX(a, b, c, d));
        }
    }
    //output 2
    /*
     https://www.geeksforgeeks.org/program-to-find-the-common-ratio-of-three-numbers/
    Program to find the common ratio of three numbers
Last Updated : 01 Apr, 2021
Given a:b and b:c. The task is to write a program to find ratio a:b:c
Examples: 
 

Input: a:b = 2:3, b:c = 3:4
Output: 2:3:4

Input:  a:b = 3:4, b:c = 8:9
Output: 6:8:9
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The trick is to make the common term ‘b’ equal in both ratios. Therefore, multiply the first ratio by b2 (b term of second ratio) and the second ratio by b1.
 

Given: a:b1 and b2:c 
Solution: a:b:c = (a*b2):(b1*b2):(c*b1)
For example: 
If a : b = 5 : 9 and b : c = 7 : 4, then find a : b : c.
Solution: 
Here, Make the common term ‘b’ equal in both ratios. 
Therefore, multiply the first ratio by 7 and the second ratio by 9. 
So, a : b = 35 : 63 and b : c = 63 : 36 
Thus, a : b : c = 35 : 63 : 36

Below is the implementation of the above approach
     */
    public class RatioThree
    {
        static int __gcd(int a, int b)
        {
            return b == 0 ? a : __gcd(b, a % b);
        }

        // Function to print a:b:c
        static void solveProportion(int a, int b1,
                                    int b2, int c)
        {
            int A = a * b2;
            int B = b1 * b2;
            int C = b1 * c;

            // To print the given proportion
            // in simplest form.
            int gcd = __gcd(__gcd(A, B), C);

            Console.Write(A / gcd + ":" +
                           B / gcd + ":" +
                           C / gcd);
        }

        // Driver code
        public static void Main()
        {

            // Get the ratios
            int a, b1, b2, c;

            // Get ratio a:b1
            a = 3;
            b1 = 4;

            // Get ratio b2:c
            b2 = 8;
            c = 9;

            // Find the ratio a:b:c
            solveProportion(a, b1, b2, c);
            //Output: 
            //6:8:9
        }
    }
}
