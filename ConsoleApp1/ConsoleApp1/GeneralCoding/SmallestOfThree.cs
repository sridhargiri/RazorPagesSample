using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/smallest-of-three-integers-without-comparison-operators/
Smallest of three integers without comparison operators
Difficulty Level : Medium
Last Updated : 22 Mar, 2021
Write a program to find the smallest of three integers, without using any of the comparison operators. 
Let 3 input numbers be x, y and z.
Method 1 (Repeated Subtraction) 
Take a counter variable c and initialize it with 0. In a loop, repeatedly subtract x, y and z by 1 and increment c. The number which becomes 0 first is the smallest. After the loop terminates, c will hold the minimum of 3.
    */
    public class SmallestOfThree
    {
        static int smallest(int x, int y, int z)
        {
            int c = 0;

            while (x != 0 && y != 0 && z != 0)
            {
                x--;
                y--;
                z--;
                c++;
            }

            return c;
        }

        // Driver Code
        public static void Main()
        {
            int x = 12, y = 15, z = 5;

            Console.Write("Minimum of 3"
                          + " numbers is " + smallest(x, y, z));
            //Output: 

            //Minimum of 3 numbers is 5
        }
    }
    /*
     Method 2 (Use Bit Operations) 
Use method 2 of this post to find minimum of two numbers (We can’t use Method 1 as Method 1 uses comparison operator). 
    Once we have functionality to find minimum of 2 numbers, we can use this to find minimum of 3 numbers. 
    */
    public class SmallestOfThreeBit
    {

        static int CHAR_BIT = 8;

        /*Function to find minimum of x and y*/
        static int min(int x, int y)
        {
            return y + ((x - y) & ((x - y) >> (sizeof(int) * CHAR_BIT - 1)));
        }

        /* Function to find minimum of 3 numbers x, y and z*/
        static int smallest(int x, int y, int z)
        {
            return Math.Min(x, Math.Min(y, z));
        }

        // Driver code
        static void Main()
        {
            int x = 12, y = 15, z = 5;
            Console.WriteLine("Minimum of 3 numbers is " + smallest(x, y, z));//op 5
        }
    }
    /*
     Method 3 (Use Division operator) 
We can also use division operator to find minimum of two numbers. If value of (a/b) is zero, then b is greater than a, else a is greater. Thanks to gopinath and Vignesh for suggesting this method.
    */
    public class SmallestOfThreeDivision
    {

        // Using division operator to
        // find minimum of three numbers
        static int smallest(int x, int y, int z)
        {
            if ((y / x) != 1) // Same as "if (y < x)"
                return ((y / z) != 1) ? y : z;
            return ((x / z) != 1) ? x : z;
        }

        // Driver code
        public static void Main()
        {
            int x = 78, y = 88, z = 68;
            Console.Write("Minimum of 3 numbers"
                              + " is {0}",
                          smallest(x, y, z));//output Minimum of 3 numbers is 68
        }
    }
}
