using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class LongestOne
    {
        /*
         https://www.geeksforgeeks.org/find-longest-sequence-1s-binary-representation-one-flip/
        Find longest sequence of 1’s in binary representation with one flip
Difficulty Level : Hard
Last Updated : 30 Sep, 2019
Give an integer n. We can flip exactly one bit. Write code to find the length of the longest sequence of 1 s you could create.

Examples:

Input : 1775         
Output : 8 
Binary representation of 1775 is 11011101111.
After flipping the highlighted bit, we get 
consecutive 8 bits. 11011111111.

Input : 12         
Output : 3 

Input : 15
Output : 5

Input : 71
Output: 4

Binary representation of 71 is 1000111.
After flipping the highlighted bit, we get 
consecutive 4 bits. 1001111.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
A simple solution is to store binary representation of given number in a binary array. Once we have elements in binary array, we can apply methods discussed here.

An efficient solution is to walk through the bits in binary representation of given number. We keep track of current 1’s sequence length and the previous 1’s sequence length. When we see a zero, update previous Length:



If the next bit is a 1, previous Length should be set to current Length.
If the next bit is a 0, then we can’t merge these sequences together. So, set previous Length to 0.
We update max length by comparing following two:

Current value of max-length
Current-Length + Previous-Length .
result = return max-length+1 (// add 1 for flip bit count )
.

Below is the implementation of above idea :
         */
        static int flipBit(int a)
        {
            /* If all bits are l, binary representation
            of 'a' has all 1s */
            if (~a == 0)
            {
                return 8 * sizeof(int);
            }

            int currLen = 0, prevLen = 0, maxLen = 0;
            while (a != 0)
            {
                // If Current bit is a 1 
                // then increment currLen++
                if ((a & 1) == 1)
                {
                    currLen++;
                }

                // If Current bit is a 0 then 
                // check next bit of a
                else if ((a & 1) == 0)
                {
                    /* Update prevLen to 0 (if next bit is 0)
                    or currLen (if next bit is 1). */
                    prevLen = (a & 2) == 0 ? 0 : currLen;

                    // If two consecutively bits are 0
                    // then currLen also will be 0.
                    currLen = 0;
                }

                // Update maxLen if required
                maxLen = Math.Max(prevLen + currLen, maxLen);

                // Remove last bit (Right shift)
                a >>= 1;
            }

            // We can always have a sequence of
            // at least one 1, this is fliped bit
            return maxLen + 1;
        }

        // Driver code
        public static void Main(String[] args)
        {
            // input 1
            Console.WriteLine(flipBit(13));

            // input 2
            Console.WriteLine(flipBit(1775));

            // input 3
            Console.WriteLine(flipBit(15));
        }
        /*
         Output :
4
8
5
        */
    }
}
