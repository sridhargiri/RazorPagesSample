using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     
     https://www.geeksforgeeks.org/minimum-number-of-replacement-done-of-substring-01-with-110-to-remove-it-completely/
    Minimum number of replacement done of substring “01” with “110” to remove it completely
Last Updated : 28 Jun, 2021
Given a binary string S, the task is to find the minimum number of repetitive replacements of substring “01” to string “110” such that there doesn’t exist any substring “01” in the given string S.

Examples:

Input: S = “01”
Output: 1
Explanation:
Below are the operations performed:
Operation 1: Choosing substring (0, 1) in the string “01” and replacing it with “110” modifies the given string to “110”.
After the above operations, the string S(= “110”) doesn’t contain any substring as “01”. Therefore, the total number of operation required is 1.

Input: S = “001”
Output:3
Explanation:
Below are the operations performed:
Operation 1: Choosing substring (1, 2) in the string “001” and replacing it with “110” modifies the given string to “0110”.
Operation 2: Choosing substring (0, 1) in the string “0110” and replacing it with “110” modifies the given string to “11010”.
Operation 3: Choosing substring (2, 3) in the string “11010” and replacing it with “110” modifies the given string to “111100”.
After the above operations, the string S(= “111100”) doesn’t contain any substring as “01”. Therefore, the total number of operation required is 3.

Approach: The given problem can be solved using the Greedy Approach. The operation is whenever a substring “01” is found it is replaced with “110” and now the number of ‘1’ is present on the right side of this ‘0’ forms substring “01” which takes part in changing the string to “110”. Therefore, the idea is to traverse the string from the end and whenever ‘0’ occurs, perform the given operation until the number of 1s present on the right side. Follow the steps below to solve the problem:



Initialize two variables, say ans and cntOne both as 0 to store the minimum number of operations performed and count of consecutive 1s from the end during traversal.
Traverse the given string S from the end and perform the following steps: 
If the current character is 0, then increment the ans by the number of consecutive 1s obtained till now and twice the value of the count of consecutive 1s.
Otherwise, increment the value of cntOne by 1.
After completing the above steps, print the value of ans as the minimum number of operations.
Below is the implementation of the above approach:
     */
    class ReplaceSubstring
    {
        static void minimumOperations(string S, int N)
        {
            // Stores the number of operations
            // performed
            int ans = 0;

            // Stores the resultant count
            // of substrings
            int cntOne = 0;

            // Traverse the string S from end
            for (int i = N - 1; i >= 0; i--)
            {

                // If the current character
                // is 0
                if (S[i] == '0')
                {
                    ans += cntOne;
                    cntOne *= 2;
                }

                // If the current character
                // is 1
                else
                    cntOne++;
            }

            Console.WriteLine(ans);
        }
        static void Main(string[] args)
        {
            string S = "001";
            minimumOperations(S, S.Length);
            /*
             Output:
3
Time Complexity: O(N)

Auxiliary Space: O(1)
            */
        }
    }
}
