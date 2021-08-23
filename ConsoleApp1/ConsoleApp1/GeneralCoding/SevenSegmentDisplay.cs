using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/maximum-number-that-can-be-display-on-seven-segment-display-using-n-segments/
    Maximum number that can be display on Seven Segment Display using N segments
Difficulty Level : Medium
Last Updated : 04 May, 2021
Given a positive integer N. The task is to find the maximum number that can be displayed on seven segment display using N segments.
Seven Segment Display: A seven-segment display (SSD), or seven-segment indicator, is a form of an electronic display device for displaying decimal numerals that is an alternative to the more complex dot matrix displays
     The individual segments of a seven-segment display
Image Source: Wikipedia. 

 
Examples: 
Input : N = 5 
Output : 71
On 7-segment display, 71 will look like:
_
 | |
 | |

Input : N = 4
Output : 11
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Observe, the number having a greater number of digits than other numbers will be greater in value. So, we will try to make a number with maximum possible length (number of digits) using given ‘N’ segments. 
Also observe, to increase the length of the number we will try to use less segment on each digit as possible. So, number ‘1’ use only 2 segments to represent a digit. No other digit use less than 2 segments. 
So, in case N is even, the answer would be 1s N/2 number of time. 
In case N is odd, we cannot use all segments if we make 1s N/2 number of time. Also, if we use 3 segments to make a digit of 7 and (N-3)/2 number of 1s, then the number formed will be greater in value than the number formed by N/2 number of 1s. 
Below is the implementation of this approach:  
     */
    class SevenSegmentDisplay
    {

        // Function to print maximum number that
        // can be formed using N segments
        public static void printMaxNumber(int n)
        {
            // If n is odd
            if (n % 2 != 0)
            {
                // use 3 three segment to print 7
                Console.Write("7");

                // remaining to print 1
                for (int i = 0; i < (n - 3) / 2; i++)
                    Console.Write("1");
            }

            // If n is even
            else
            {

                // print n/2 1s.
                for (int i = 0; i < n / 2; i++)
                    Console.Write("1");
            }
        }

        // Driver Code
        public static void Main(String[] args)
        {
            int n = 5;
            printMaxNumber(n);
            /*
             Output: 71
Time Complexity: O(n)

Auxiliary Space: O(1)
            */
        }
    }
}
