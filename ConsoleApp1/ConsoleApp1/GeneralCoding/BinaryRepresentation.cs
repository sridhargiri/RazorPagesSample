using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BinaryRepresentation
    {
        /*
         Method 1: Iterative 
For any number, we can check whether its ‘i’th bit is 0(OFF) or 1(ON) by bitwise ANDing it with “2^i” (2 raise to i). 

1) Let us take number 'NUM' and we want to check whether it's 0th bit is ON or OFF    
    bit = 2 ^ 0 (0th bit)
    if  NUM & bit == 1 means 0th bit is ON else 0th bit is OFF

2) Similarly if we want to check whether 5th bit is ON or OFF    
    bit = 2 ^ 5 (5th bit)
    if NUM & bit == 1 means its 5th bit is ON else 5th bit is OFF.
Let us take unsigned integer (32 bit), which consist of 0-31 bits. To print binary representation of unsigned integer, start from 31th bit, check whether 31th bit is ON or OFF, if it is ON print “1” else print “0”. Now check whether 30th bit is ON or OFF, if it is ON print “1” else print “0”, do this for all bits from 31 to 0, finally we will get binary representation of number.


void bin(unsigned n)
{
    unsigned i;
    for (i = 1 << 31; i > 0; i = i / 2)
        (n & i) ? printf("1") : printf("0");
}
         */

        //Method 2: Recursive
        //Following is recursive method to print binary representation of ‘NUM’. 

        //step 1) if NUM > 1
        //    a) push NUM on stack
        //    b) recursively call function with 'NUM / 2'
        //step 2)
        //    a) pop NUM from stack, divide it by 2 and print it's remainder.

        static void bin(int n)
        {

            // step 1
            if (n > 1)
                bin(n / 2);

            // step 2
            Console.Write(n % 2);
        }
        /*
         Method 3: Recursive using bitwise operator 
Steps to convert decimal number to its binary representation are given below: 

step 1: Check n > 0
step 2: Right shift the number by 1 bit and recursive function call
step 3: Print the bits of number
        */


        // Function to convert decimal
        // to binary number
        static void bin1(int n)
        {
            if (n > 1)
                bin1(n >> 1);

            Console.Write(n & 1);
        }
        /*
         Count N-length Binary Strings consisting of “11” as substring
Last Updated : 19 Feb, 2021
Given a positive integer N, the task is to find the number of binary strings of length N which contains “11” as a substring.

Examples:

Input: N = 2
Output: 1
Explanation: The only string of length 2 that has “11” as a substring is “11”.

Input: N = 12
Output: 3719

Approach: The idea is to derive the number of possibilities of having “11” as a substring for binary representations starting with 0 or 1 based on the following observations:




If the first bit is 0, then the starting bit does not contribute to the string having “11” as a substring. Therefore, the remaining (N – 1) bits have to form a string having “11” as a substring.
If the first bit is 1 and the following bit is also 1, then there exists 2(N – 2) strings having “11” as a substring.
If the first bit is 1 but the following bit is 0, then a string having “11” as a substring can be formed with remaining (N – 2) bits.
Therefore, the recurrence relation to generate all the binary strings of length N is:
dp[i] = dp[i – 1] + dp[i – 2] + 2(N – 2)
where,
dp[i] is the string of length i having “11” as a substring.
and dp[0] = dp[1] = 0.

Follow the steps below to solve the problem:

Initialize an array, say dp[], of size (N + 1) and assign dp[0] as 0 and dp[1] as 0.
Precompute the first N powers of 2 and store it in an array, say power[].
Iterate over the range [2, N] and update dp[i] as (dp[i – 1] + dp[i – 2] + power[i – 2]).
After completing the above steps, print the value of dp[N] as the result.
Below is the implementation of the above approach:
         */
        static void binaryStrings(int N)
        {
            // Initialize dp[] of size N + 1 
            int[] dp = new int[N + 1];

            // Base Cases 
            dp[0] = 0;
            dp[1] = 0;

            // Stores the first N powers of 2 
            int[] power = new int[N + 1];
            power[0] = 1;

            // Generate  
            for (int i = 1; i <= N; i++)
            {
                power[i] = 2 * power[i - 1];
            }

            // Iterate over the range [2, N] 
            for (int i = 2; i <= N; i++)
            {
                dp[i] = dp[i - 1]
                        + dp[i - 2]
                        + power[i - 2];
            }

            // Print total count of substrings 
            Console.WriteLine(dp[N]);
        }
        // Driver code
        static public void Main()
        {
            int N = 12;
            binaryStrings(N);

            bin(7);
            Console.WriteLine();
            bin(4);
            bin1(131);
            Console.WriteLine();
            bin1(3);
        }
    }
    /*
https://www.geeksforgeeks.org/smallest-string-obtained-by-removing-all-occurrences-of-01-and-11-from-binary-string-set-2/
Smallest string obtained by removing all occurrences of 01 and 11 from Binary String | Set 2
Last Updated : 10 Jun, 2021
Given a binary string S of length N, the task is to find the smallest string possible by removing all occurrences of substrings “01” and “11”. After removal of any substring, concatenate the remaining parts of the string.

Examples:

Input: S = “1010”
Output: 2
Explanation: Removal of substring “01” modifies string S to “10”.

Input: S = “111”
Output: 1 

 
Stack-based Approach: Refer to the previous article to find the length of the smallest string possible by given operations.
Time Complexity: O(N)
Auxiliary Space: O(N)

Spac-Optimized Approach: The above approach can be space-optimized by only storing the length of the characters not removed. Follow the steps below to solve the problem:



Initialize a variable, say st as 0, to store the length of the smallest string possible.
Iterate over the characters of the string S and perform the following steps:
If st is greater than 0 and S[i] is equal to ‘1‘, then pop the last element by decrementing st by 1.
Otherwise, increment st by 1.
Finally, after completing the above steps, print the answer obtained in st.
Below is the implementation of the above approach:
    */
    public class BinaryStringRemoveZeroOne
    {

        // Function to find the length of
        // the smallest string possible by
        // removing substrings "01" and "11"
        static int shortestString(string S, int N)
        {

            // Stores the length of
            // the smallest string
            int st = 0;

            // Traverse the string S
            for (int i = 0; i < N; i++)
            {

                // If st is greater
                // than 0 and S[i] is '1'
                if (st > 0 && S[i] == '1')
                {

                    // Delete the last
                    // character and
                    // decrement st by 1
                    st--;
                }

                // Otherwise
                else
                {

                    // Increment st by 1
                    st++;
                }
            }

            // Return the answer in st
            return st;
        }

        // Driver code
        public static void Main(string[] args)
        {
            // Input
            string S = "1010";
            int N = S.Length;

            // Function call
            Console.WriteLine(shortestString(S, N));
            /*
             Output: 
2

Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
