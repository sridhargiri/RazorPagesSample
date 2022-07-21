
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
            String digits = "12345";
            int n = digits.Length;

            // Function call
            Console.Write(countDecodingDP(digits, n));
            //Output: 3             The possible decodings are “ABCD”, “LCD”, “AWD”
        }
    }
    /*
https://www.geeksforgeeks.org/count-possible-decodings-given-digit-sequence/
     Count Possible Decodings of a given Digit Sequence
Difficulty Level : Medium
Last Updated : 31 Mar, 2021
Geek-O-Lympics
Let 1 represent ‘A’, 2 represents ‘B’, etc. Given a digit sequence, count the number of possible decodings of the given digit sequence. 

Examples: 

Input:  digits[] = "121"
Output: 3
// The possible decodings are "ABA", "AU", "LA"

Input: digits[] = "1234"
Output: 3
// The possible decodings are "ABCD", "LCD", "AWD"
An empty digit sequence is considered to have one decoding. It may be assumed that the input contains valid digits from 0 to 9 and there are no leading 0’s, no extra trailing 0’s, and no two or more consecutive 0’s.

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
This problem is recursive and can be broken into sub-problems. We start from the end of the given digit sequence. We initialize the total count of decodings as 0. We recur for two subproblems. 
1) If the last digit is non-zero, recur for the remaining (n-1) digits and add the result to the total count. 
2) If the last two digits form a valid character (or smaller than 27), recur for remaining (n-2) digits and add the result to the total count.

Following is the implementation of the above approach.  
    */
    public class PossibleWaysDecoding
    {

        // recuring function to find
        // ways in how many ways a
        // string can be decoded of length
        // greater than 0 and starting with
        // digit 1 and greater.
        static int Nagarro_count_Possible_Decoding_Ways(char[] digits, int n)
        {

            // base cases
            if (n == 0 || n == 1)
                return 1;

            // Initialize count
            int count = 0;

            // If the last digit is not 0, then
            // last digit must add to
            // the number of words
            if (digits[n - 1] > '0')
                count = Nagarro_count_Possible_Decoding_Ways(digits, n - 1);

            // If the last two digits form a number
            // smaller than or equal to 26, then
            // consider last two digits and recur
            if (digits[n - 2] == '1'
                || (digits[n - 2] == '2'
                    && digits[n - 1] < '7'))
                count += Nagarro_count_Possible_Decoding_Ways(digits, n - 2);

            return count;
        }

        // Given a digit sequence of length n,
        // returns count of possible decodings by
        // replacing 1 with A, 2 woth B, ... 26 with Z
        static int countWays(char[] digits, int n)
        {
            if (n == 0 || (n == 1 && digits[0] == '0'))
                return 0;
            return Nagarro_count_Possible_Decoding_Ways(digits, n);
        }

        // Driver code
        public static void Main()
        {
            char[] digits = { '1', '2', '3', '4' };
            int n = digits.Length;
            Console.Write("Count is ");
            Console.Write(countWays(digits, n));
            //Output:

            //Count is 3
        }
    }
    /*
     The time complexity of above the code is exponential. 
    If we take a closer look at the above program, we can observe that the recursive solution is similar to Fibonacci Numbers. 
    Therefore, we can optimize the above solution to work in O(n) time using Dynamic Programming. 
    */
    public class PossibleWaysDecodeNagarro
    {


        // A Dynamic Programming based
        // function to count decodings
        static int countDecodingDP(char[] digits,
                                   int n)
        {
            // A table to store results of subproblems
            int[] count = new int[n + 1];
            count[0] = 1;
            count[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                count[i] = 0;

                // If the last digit is not 0,
                // then last digit must add to
                // the number of words
                if (digits[i - 1] > '0')
                    count[i] = count[i - 1];

                // If second last digit is smaller
                // than 2 and last digit is smaller
                // than 7, then last two digits
                // form a valid character
                if (digits[i - 2] == '1' ||
                   (digits[i - 2] == '2' &&
                    digits[i - 1] < '7'))
                    count[i] += count[i - 2];
            }
            return count[n];
        }

        // Driver Code
        public static void Main()
        {
            char[] digits = { '1', '2', '3', '4' };
            int n = digits.Length;
            Console.WriteLine("Count is " +
                    countDecodingDP(digits, n));
            //output: Count is 3
        }

    }
    /*
     Method 3 : ( Top Down DP )

Approach :  

The above problem can be solved using Top down DP in the following way . 
    One of the basic intuition is that we need to find the total number of  ways to decode the given string such that each and every number in the string must lie in between the range of [ 1 , 26 ] both inclusive and without any leading 0’s . Let us consider an example string .

str = “123”

If we observe carefully we can observe a pattern over here i.e., the number of ways a particular substring can be decoded depends on the number of ways the remaining string is going to be decoded . 
   For example , we want the number of ways to decode the string with “1” as a prefix the result depends on the number of ways the remaining string, i.e., “23” can be decoded . 
    The number of ways the string “23” can be decoded are “2” , “3” and “23” there are 2 ways in both of these cases we can just append “1” to get the number of ways the given string can be decoded with “1” as a prefix i.e., “1” , “2” , “3” and “1” , “23” . 
    Now we have found the number of ways we can decode the given string with “1” as a prefix but “12” also lies in between the range of [ 1 , 26 ] both inclusive the number of ways to decode the given string with “12” as a prefix depends on the result on how the remaining string is decoded . 
    Here the remaining string is “3” it can be decoded in only 1 way so we can just append “12” in front of the string “3” to get it i.e., “12” , “3” . 
    So the total number of ways the given string can be decoded are 3 ways .

But we can see some of the overlapping of subproblems over here i.e., when we are computing the total number of ways to decode the string “23” we are computing the number of ways the string “3” can be decoded as well as when we are computing the number of ways the string “12” can be decoded we are again computing the number of ways the string “3” can be decoded . So we can avoid this by storing the result of every substring . Here we can identify each and every sub problem through the index of the string . So , if at any point of time if we have already computed the number of ways the substring can be decoded we can directly return the result and that leads to a lot of optimization .

Below is the C++ implementation
    */
    public class DecodeWaysDP_TopDownApproach
    {

        static int mod = 1000000007;

        // function which returns the number of ways to decode the message
        static int decodeMessage(int[] dp, int s, string str, int n)
        {

            // an empty string can also form 1 valid decoding
            if (s >= n)
                return 1;

            /*
                if we have already computed the number of
                ways to decode the substring return the
                answer directly
            */
            if (dp[s] != -1)
                return dp[s];

            int num, tc;
            num = tc = 0;
            for (int i = s; i < n; i++)
            {
                // generate the number
                num = num * 10 + ((int)str[i] - '0');

                // validate the number
                if (num >= 1 && num <= 26)
                {
                    /*
                            since the number of ways to decode any string
                            depends on the result of
                            how the remaining string is decoded so get the
                            number of ways how the rest of the string can
                            be decoded
                        */
                    int c = decodeMessage(dp, i + 1, str, n);

                    // add all the ways that the substring
                    // from the current index can be decoded
                    tc = (tc % mod + c % mod) % mod;
                }

                // leading 0’s or the number
                // generated so far is greater than 26
                // we can just stop the process
                // as it can never be a part of our solution
                else
                    break;
            }

            // store all the possible decodings and return the result
            return (dp[s] = tc);
        }
        static int CountWays(string str)
        {
            int n = str.Length;

            // empty string can form 1 valid decoding
            if (n == 0)
                return 1;

            // dp vector to store the number of ways
            // to decode each and every substring
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = -1;
            }

            // return the result
            return decodeMessage(dp, 0, str, n);
        }

        // Driver Code
        public static void Main()
        {
            string str = "1234";
            Console.Write(CountWays(str));
            /*
             Output : 
3
Time Complexity   :  O ( N ) where N is the length of the string . As we are solving each and every sub – problem only once .

Space Complexity :  O ( N ) as we are using vector to store the result of each and every substring
            */
        }
    }
    public class WaysToReachStation
    {
        //https://www.geeksforgeeks.org/count-ways-to-reach-the-nth-station/
        //C++
    }
}
// This code is contributed by Amit Katiyar
