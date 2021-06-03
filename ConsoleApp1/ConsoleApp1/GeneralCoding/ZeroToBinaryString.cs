using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/minimum-number-of-operations-required-to-sum-to-binary-string-s/
Minimum number of operations required to sum to binary string S
Last Updated : 21 Jan, 2019
Given a binary string S. Find the minimum number of operations required to be performed on the number zero to convert it to the number represented by S.

It is allowed to perform operations of 2 types:

Add 2x
Subtract 2x
Note: Start performing operations on 0.

Examples:

Input : 100
Output : 1
Explanation: We just perform a single operation, i.e Add 4 (2^2)



Input : 111
Output : 2
Explanation: We perform the following two operations:
1) Add 8(2^3)
2) Subtract 1(2^0)

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
The idea is to use Dynamic Programming to solve this problem.

Note: In the below analysis, we considered that all binary strings are represented from LSB to MSB (from LHS to RHS) i.e 2(Binary form: “10”) is represented as “01”.

Let the given binary string be S.

Let dp[i][0] represents the minimum number of operations required to make a binary string R such that R[0…i] is same as S[0…i] and R[i+1…] = “00..0”

Similarly let dp[i][1] represents the minimum number of operations required to make a binary string R such that R[0…i] is same as S[0…i] and R[i+1…] = “11..1”

If Si is ‘0’, then dp[i][0] = dp[i – 1][0]. Since we do not require any additional operation. Now we consider the value of dp[i][1] which is a bit trickier. For dp[i][1] we can either make our transition from dp[i – 1][1] by just making the ith character of the string formed by dp[i-1][1], ‘0’. Since earlier this ith character was “1”. We just need to subtract 2i from the string represented by dp[i-1][0]. Thus we perform one operation other than the ones represented by dp[i-1][0].

The other transition can be from dp[i-1][0]. Let dp[i-1][1] represents the string R. Then we need to keep R[i] = 0 as it already is but R[i + 1…..] which is currently “000..0”, needs to be to be changed to “111…1”, this can be done by subtracting 2(i+1) from R. Thus we just need one operation other than the ones represented by dp[i-1][0].



Similar is the case when Si is ‘1’.

The final answer is the one represented by dp[l-1][0], where l is the length of the binary string S.

Below is the implementation of the above approach:
    */
    class ZeroToBinaryString
    {

        // Function to return the minimum 
        // operations required to sum 
        // to a number reprented by 
        // the binary string S
        static int findMinOperations(String S)
        {

            // Reverse the string to consider
            // it from LSB to MSB
            S = reverse(S);
            int n = S.Length;

            // initialise the dp table
            int[,] dp = new int[n + 1, 2];

            // If S[0] = '0', there is no need to
            // perform any operation
            if (S[0] == '0')
            {
                dp[0, 0] = 0;
            }
            else
            {
                // If S[0] = '1', just perform a single
                // operation(i.e Add 2^0)
                dp[0, 0] = 1;
            }

            // Irrespective of the LSB, dp[0,1] is always
            // 1 as there is always the need of making the
            // suffix of the binary string of the form "11....1"
            // as suggested by the definition of dp[i,1]
            dp[0, 1] = 1;

            for (int i = 1; i < n; i++)
            {
                if (S[i] == '0')
                {
                    // Transition from dp[i - 1,0]
                    dp[i, 0] = dp[i - 1, 0];

                    /* 1. Transition from dp[i - 1,1] by just doing
                    1 extra operation of subtracting 2^i
                    2. Transition from dp[i - 1,0] by just doing
                    1 extra operation of subtracting 2^(i+1) */
                    dp[i, 1] = 1 + Math.Min(dp[i - 1, 1], dp[i - 1, 0]);
                }
                else
                {

                    // Transition from dp[i - 1,1]
                    dp[i, 1] = dp[i - 1, 1];

                    /* 1. Transition from dp[i - 1,1] by just doing 
                    1 extra operation of adding 2^(i+1)
                    2. Transition from dp[i - 1,0] by just doing 
                    1 extra operation of adding 2^i */
                    dp[i, 0] = 1 + Math.Min(dp[i - 1, 0], dp[i - 1, 1]);
                }
            }
            return dp[n - 1, 0];
        }

        static String reverse(String input)
        {
            char[] temparray = input.ToCharArray();
            int left, right = 0;
            right = temparray.Length - 1;
            for (left = 0; left < right; left++, right--)
            {
                // Swap values of left and right 
                char temp = temparray[left];
                temparray[left] = temparray[right];
                temparray[right] = temp;
            }
            return String.Join("", temparray);
        }

        // Driver Code
        public static void Main()
        {
            String S = "100";
            Console.WriteLine(findMinOperations(S));
            S = "111";
            Console.WriteLine(findMinOperations(S));
            //output
            //1
            //2
        }
    }
}
