using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Ugly Numbers
Difficulty Level : Medium
 Last Updated : 09 Feb, 2021
Ugly numbers are numbers whose only prime factors are 2, 3 or 5. The sequence 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, … shows the first 11 ugly numbers. By convention, 1 is included. 
Given a number n, the task is to find n’th Ugly number.

Examples:  

Input  : n = 7
Output : 8

Input  : n = 10
Output : 12

Input  : n = 15
Output : 24

Input  : n = 150
Output : 5832
    */
    class UglyNumberExample
    {
        /*
         Method 1 (Simple) 
Loop for all positive integers until ugly number count is smaller than n, if an integer is ugly than increment ugly number count.
To check if a number is ugly, divide the number by greatest divisible powers of 2, 3 and 5, if the number becomes 1 then it is an ugly number otherwise not. 

For example, let us see how to check for 300 is ugly or not. Greatest divisible power of 2 is 4, after dividing 300 by 4 we get 75. Greatest divisible power of 3 is 3, after dividing 75 by 3 we get 25. Greatest divisible power of 5 is 25, after dividing 25 by 25 we get 1. Since we get 1 finally, 300 is ugly number.

Below is the implementation of the above approach:
        
         */

        /*This function divides a by
        greatest divisible power of b*/
        static int maxDivide(int a, int b)
        {
            while (a % b == 0)
                a = a / b;
            return a;
        }

        /* Function to check if a number
        is ugly or not */
        static int isUgly(int no)
        {
            no = maxDivide(no, 2);
            no = maxDivide(no, 3);
            no = maxDivide(no, 5);

            return (no == 1) ? 1 : 0;
        }

        /* Function to get the nth ugly
        number*/
        static int getNthUglyNo(int n)
        {
            int i = 1;

            // ugly number count
            int count = 1;

            // Check for all integers
            // until count becomes n
            while (n > count)
            {
                i++;
                if (isUgly(i) == 1)
                    count++;
            }
            return i;
        }
        /*
         Output
150th ugly no. is 5832 
This method is not time efficient as it checks for all integers until ugly number count becomes n, but space complexity of this method is O(1) 
 
Method 2 (Use Dynamic Programming) 
Here is a time efficient solution with O(n) extra space. The ugly-number sequence is 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, … 
     because every number can only be divided by 2, 3, 5, one way to look at the sequence is to split the sequence to three groups as below: 
     (1) 1×2, 2×2, 3×2, 4×2, 5×2, … 
     (2) 1×3, 2×3, 3×3, 4×3, 5×3, … 
     (3) 1×5, 2×5, 3×5, 4×5, 5×5, …
     We can find that every subsequence is the ugly-sequence itself (1, 2, 3, 4, 5, …) multiply 2, 3, 5. Then we use similar merge method as merge sort, to get every ugly number from the three subsequence. Every step we choose the smallest one, and move one step after.

1 Declare an array for ugly numbers:  ugly[n]
2 Initialize first ugly no:  ugly[0] = 1
3 Initialize three array index variables i2, i3, i5 to point to 
   1st element of the ugly array: 
        i2 = i3 = i5 =0; 
4 Initialize 3 choices for the next ugly no:
         next_mulitple_of_2 = ugly[i2]*2;
         next_mulitple_of_3 = ugly[i3]*3
         next_mulitple_of_5 = ugly[i5]*5;
5 Now go in a loop to fill all ugly numbers till 150:
For (i = 1; i < 150; i++ ) 
{
     These small steps are not optimized for good 
      readability. Will optimize them in C program 
        next_ugly_no  = Min(next_mulitple_of_2,
                            next_mulitple_of_3,
                            next_mulitple_of_5);

        ugly[i] =  next_ugly_no       

    if (next_ugly_no  == next_mulitple_of_2) 
    {             
        i2 = i2 + 1;        
        next_mulitple_of_2 = ugly[i2]*2;
    } 
    if (next_ugly_no  == next_mulitple_of_3) 
    {             
        i3 = i3 + 1;        
        next_mulitple_of_3 = ugly[i3]*3;
     }
if (next_ugly_no == next_mulitple_of_5)
{
    i5 = i5 + 1;
    next_mulitple_of_5 = ugly[i5] * 5;
} 
     
}/* end of for loop */
        /*
         * 6.return next_ugly_no
        Example:
        Let us see how it works 

        initialize
           ugly[] =  | 1 |
           i2 = i3 = i5 = 0;

        First iteration
           ugly[1] = Min(ugly[i2] * 2, ugly[i3] * 3, ugly[i5] * 5)
                    = Min(2, 3, 5)
                    = 2
           ugly[] =  | 1 | 2 |
           i2 = 1,  i3 = i5 = 0(i2 got incremented)

        Second iteration
            ugly[2] = Min(ugly[i2] * 2, ugly[i3] * 3, ugly[i5] * 5)
                     = Min(4, 3, 5)
                     = 3
            ugly[] =  | 1 | 2 | 3 |
            i2 = 1,  i3 = 1, i5 = 0(i3 got incremented)

        Third iteration
            ugly[3] = Min(ugly[i2] * 2, ugly[i3] * 3, ugly[i5] * 5)
                     = Min(4, 6, 5)
                     = 4
            ugly[] =  | 1 | 2 | 3 | 4 |
            i2 = 2,  i3 = 1, i5 = 0(i2 got incremented)

        Fourth iteration
            ugly[4] = Min(ugly[i2] * 2, ugly[i3] * 3, ugly[i5] * 5)
                      = Min(6, 6, 5)
                      = 5
            ugly[] =  | 1 | 2 | 3 | 4 | 5 |
            i2 = 2,  i3 = 1, i5 = 1(i5 got incremented)

        Fifth iteration
            ugly[4] = Min(ugly[i2] * 2, ugly[i3] * 3, ugly[i5] * 5)
                      = Min(6, 6, 10)
                      = 6
            ugly[] =  | 1 | 2 | 3 | 4 | 5 | 6 |
            i2 = 3,  i3 = 2, i5 = 1(i2 and i3 got incremented)

        Will continue same way till I < 150
            */

        /*
         Output
5832
Time Complexity: O(n) 
Auxiliary Space: O(n)
        */
        static int getNthUglyNo_dp(int n)
        {

            // To store ugly numbers
            int[] ugly = new int[n];
            int i2 = 0, i3 = 0, i5 = 0;
            int next_multiple_of_2 = 2;
            int next_multiple_of_3 = 3;
            int next_multiple_of_5 = 5;
            int next_ugly_no = 1;

            ugly[0] = 1;

            for (int i = 1; i < n; i++)
            {
                next_ugly_no
                    = Math.Min(next_multiple_of_2,
                               Math.Min(next_multiple_of_3,
                                        next_multiple_of_5));

                ugly[i] = next_ugly_no;

                if (next_ugly_no == next_multiple_of_2)
                {
                    i2 = i2 + 1;
                    next_multiple_of_2 = ugly[i2] * 2;
                }

                if (next_ugly_no == next_multiple_of_3)
                {
                    i3 = i3 + 1;
                    next_multiple_of_3 = ugly[i3] * 3;
                }
                if (next_ugly_no == next_multiple_of_5)
                {
                    i5 = i5 + 1;
                    next_multiple_of_5 = ugly[i5] * 5;
                }
            }

            return next_ugly_no;
        }

        public static void Main()
        {
            int no = getNthUglyNo_dp(150);

            // Function call
            Console.WriteLine("150th ugly"
                              + " no. is " + no);
        }
    }
}
