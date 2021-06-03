
/* Count Possible Decodings of a given Digit Sequence in O(N) time and Constant Auxiliary space
Last Updated: 14 - 09 - 2020
Given a digit sequence S, the task is to find the number of possible decodings of the given digit sequence where 1 represents ‘A’, 2 represents ‘B’ … and so on up to 26, where 26 represents ‘Z’.
Examples:

Input: S = “121” 
Output: 3
The possible decodings are “ABA”, “AU”, “LA”
Input: S = “1234” 
Output: 3
The possible decodings are “ABCD”, “LCD”, “AWD”


Approach: In order to solve this problem in O(N) time complexity, Dynamic Programming is used.
And in order to reduce the auxiliary space complexity to O(1), we use the space optimized version of recurrence relation discussed in the Fibonacci Number Post.
Similar to the Fibonacci Numbers, the key observations of any current ith index can be calculated using its previous two indices. 
So the Recurrence Relation to calculate the ith index can be denoted as

// Condition to check last
// digit can be included or not
if (digit[i - 1] is not '0')
    count[i] += count[i - 1]

// Condition to check the last
// two digits contribution
if (digit[i - 2] is 1 or
   (digit[i - 2] is 2 and
    digit[i - 1] is less than 7))
    count[i] += count[i - 2]


Below is the implementation of the above approach:*
 */
using System;
using System.Text;

namespace ConsoleApp1
{
    class DecodeWays
    {

        // A Dynamic programming based function
        // to count decodings in digit sequence
        static int countDecodingDP(String digits, int n)
        {

            // For base condition "01123"
            // should return 0
            if (digits[0] == '0')
            {
                return 0;
            }

            int count0 = 1, count1 = 1, count2;

            // Using last two calculated values,
            // calculate for ith index
            for (int i = 2; i <= n; i++)
            {
                int dig1 = 0, dig2, dig3 = 0;

                // Change bool to int
                if (digits[i - 1] != '0')
                {
                    dig1 = 1;
                }
                if (digits[i - 2] == '1')
                {
                    dig2 = 1;
                }
                else
                    dig2 = 0;

                if (digits[i - 2] == '2' &&
                   digits[i - 1] < '7')
                {
                    dig3 = 1;
                }
                count2 = dig1 * count1 +
                         dig2 + dig3 * count0;

                count0 = count1;
                count1 = count2;
            }

            // Return the required answer
            return count1;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            String digits = "1234";
            int n = digits.Length;

            // Function call
            Console.Write(countDecodingDP(digits, n));
            //Output: 3             The possible decodings are “ABCD”, “LCD”, “AWD”
        }
    }
    public class WaysToReachStation
    {
        //https://www.geeksforgeeks.org/count-ways-to-reach-the-nth-station/
        //C++
    }
}
// This code is contributed by Amit Katiyar
