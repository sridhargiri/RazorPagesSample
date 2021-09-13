using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if K ‘0’s can be flipped such that Binary String contains no pair of adjacent ‘1’s
Last Updated : 01 Mar, 2021
Given a binary string S of length N and an integer K, the task is to check if it is possible to flip K 0s such that the resulting string does not contain any pair of adjacent 1s. If it is possible to do so, then print “Yes”. Otherwise, print “No”.

Input: S = “01001001000”, K = 1
Output: Yes
Explanation:
Modifying S = “01001001000” to “01001001001” or modifying S = “01001001000″ to “01001001010″ satisfies the given condition.

Input: S = “000001000”, K = 4 
Output: No

Approach: The idea to traverse the string and replace those ‘0′s with ‘1′s whose both adjacent characters are ‘0′ and flip one of the ‘0′s to count all the possible positions of flips such that it doesn’t affect the original string. Follow the steps below to solve the problem:

Initialize s variable, say cnt as 0, to store the count of positions that can be flipped.
Traverse the string using a variable i and perform the following steps:
If the current character is ‘1′, then increment i by 2.
Otherwise:
If i = 0, and s[i + 1] = ‘0’: Increment cnt by 1 and i by 2. Otherwise, increment i by 1.
If i = (N – 1), and s[i – 1] = ‘0’: Increment cnt by 1 and i by 2. Otherwise, increment i by 1.
Otherwise, if s[i + 1] = ‘0’ and s[i – 1] = ‘0’: Increment cnt by 1 and i by 2. Otherwise, increment i by 1.
After completing the above steps, if the value of cnt is at least K, then print “Yes”, Otherwise, print “No”.
Below is the implementation of the above approach:
    */
    class BinaryStringFlip
    {

        // Function to check if k '0's can
        // be flipped such that the string
        // does not contain any pair of adjacent '1's
        static void canPlace(string s, int n, int k)
        {

            // Store the count of flips
            int cnt = 0;

            // Variable to iterate the string
            int i = 0;

            // Iterate over characters
            // of the string
            while (i < n)
            {

                // If the current character
                // is '1', increment i by 2
                if (s[i] == '1')
                {
                    i += 2;
                }

                // Otherwise, 3 cases arises
                else
                {

                    // If the current index
                    // is the starting index
                    if (i == 0)
                    {

                        // If next character is '0'
                        if (s[i + 1] == '0')
                        {
                            cnt++;
                            i += 2;
                        }

                        // Increment i by 1
                        else
                            i++;
                    }

                    // If the current index
                    // is the last index
                    else if (i == n - 1)
                    {

                        // If previous character is '0'
                        if (s[i - 1] == '0')
                        {

                            cnt++;
                            i += 2;
                        }
                        else
                            i++;
                    }

                    // For remaining characters
                    else
                    {

                        // If both the adjacent
                        // characters are '0'
                        if (s[i + 1] == '0' && s[i - 1] == '0')
                        {

                            cnt++;
                            i += 2;
                        }
                        else
                            i++;
                    }
                }
            }

            // If cnt is at least K, print "Yes"
            if (cnt >= k)
            {
                Console.WriteLine("Yes");
            }

            // Otherwise, print "No"
            else
            {
                Console.WriteLine("No");
            }
        }

        // Driver Code
        public static void Main(String[] args)
        {
            string S = "10001";
            int K = 1;
            int N = S.Length;

            canPlace(S, N, K);//op yes
                              //            Time Complexity: O(n)
                              //Auxiliary Space: O(1)
        }
    }
    /*
     https://www.geeksforgeeks.org/minimize-flips-to-make-binary-string-as-all-1s-by-flipping-characters-in-substring-of-size-k-repeatedly/
    Minimize flips to make binary string as all 1s by flipping characters in substring of size K repeatedly
Last Updated : 10 Sep, 2021
Given a binary string S of size N and an integer K, the task is to find the minimum number of operations required to make all characters as 1s in the binary string by flipping characters in the substring of size K. If it is not possible to do so, then print “-1”.

Examples:

Input: S = “00010110 “, K = 3
Output: 3
Explanation:
Below are the operations performed:

Consider the substring S[0, 2] which is of size K(= 3) and flipping those characters modifies the string to “11110110”.
Consider the substring S[4, 6] which is of size K(= 3) and flipping those characters modifies the string to “11111000”.
Consider the substring S[5, 7] which is of size K(= 3) and flipping those characters modifies the string to “11111111”.
After the above operations, all the 0s are converted to 1s, and the minimum number of operations required is 3.

Input: S = “01010”, K = 4
Output: -1



Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The given problem can be solved using the Greedy Approach. Follow the below steps to solve the problem:

Initialize a variable, say minOperations as 0 that stores the count of the minimum number of operations required.
Traverse the string S using the variable i and if the characters S[i] is ‘0’ and the value of (i + K) is at most K, then flip all the characters of the substring S[i, i + K] and increment the value of minOperations by 1.
After the above operations, traverse the string S and if there exists any character ‘0’ then print “-1” and break out of the loop.
If all the characters of the string S are 1s, then print the minOperations as the resultant minimum number of operations.
Below is the implementation of the above approach:
     */
    public class MinFlips
    {
        static void minFlipsToMakeAllZeroToOne(string S, int K, int N)
        {

            // Stores the minimum number of
            // operations required
            int min = 0;
            var _s = S.ToCharArray();
            int i;

            // Traverse the string S
            for (i = 0; i < N; i++)
            {

                // If the character is 0
                if (_s[i] == '0' && i + K <= N)
                {

                    // Flip the substrings of
                    // size K starting from i
                    for (int j = i; j < i + K; j++)
                    {
                        if (_s[j] == '1')
                            _s[j] = '0';
                        else
                            _s[j] = '1';
                    }

                    // Increment the minimum count
                    // of operations required
                    min++;
                }
            }

            // After performing the operations
            // check if string S contains any 0s
            for (i = 0; i < N; i++)
            {
                if (_s[i] == '0')
                    break;
            }

            // If S contains only 1's
            if (i == N)
                Console.WriteLine(min);
            else
                Console.WriteLine(-1);
        }
        static void Main(string[] args)
        {
            string S = "00010110";
            int K = 3;
            int N = S.Length;
            minFlipsToMakeAllZeroToOne(S, K, N);
            /*
             Output:3
Time Complexity: O(N*K)
Auxiliary Space: O(1)
            */
        }
    }
}
