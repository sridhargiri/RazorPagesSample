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

}
