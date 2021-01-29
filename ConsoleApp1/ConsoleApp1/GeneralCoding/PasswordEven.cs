using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
	 Length of the longest substring with every character appearing even number of times
Difficulty Level : Medium
 Last Updated : 11 Nov, 2020
Given a numerical string S of length N, the task is to find the length of the longest substring of S where each element occurs even number of times.

Examples:

Input: S = “324425”
Output: 4
Explanation: Two substrings consisting of even frequent elements only are “44” and “2442”. Since “2442” is the longer of the two, print 4 as the required answer.

Input: S = “223015150”
Output: 6
Explanation: Three substrings consisting of even frequent elements only are “22”, “1515” and “015150”. Since “015150” is the longest among the three, print 4 as the required answer.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Naive Approach: The simplest approach is to generate all possible substrings of even length from the given string and for each substring, check if it contains characters with even frequencies only or not. Print the length of the longest of all such substrings.
Time Complexity: O(N3)
Auxiliary Space: O(N)

Efficient Approach: To optimize the above approach the idea is to use Bit Masking. Follow the steps below to solve the problem:
	
Traverse the string from left to right.
While traversing, use a bitmask variable, say mask, to keep track of the occurrence of each element from index 0 to the current index, whether it is even or odd. The ith (0 ≤ i ≤ 9) bit in the mask is 0 if the digit i has occurred even number of times up to the current index, and 1 if it has occurred an odd number of times.
Use a variable val to store the value of digit present at the current index.
To update the occurrence of val, take Bitwise XOR of mask with 1 << val.
Use a Hash table ind to keep track of the index of each bitmask.
After updating the value of mask at the current index, check if it is present in ind or not:
If the value of the mask is already present in ind, it means that each element from index ind[mask] + 1 to current index occurs even number of times. Therefore, update the answer if the length of this segment from index ind[mask] + 1 to the current index is greater than the answer.
Otherwise, assign the value of the current index to ind[mask].
Finally, print the length of the required substring after completing the above steps.
Below is the implementation of the above approach:
	 */
    class PasswordEven
    {

        // Function to find length of the
        // longest subString with each element
        // occurring even number of times
        static int lenOflongestReqSubstr(String s,
                                        int N)
        {
            // Initialize unordered_map
            Dictionary<int,
                        int> ind =
                        new Dictionary<int,
                                        int>();

            int mask = 0;
            ind.Add(0, -1);

            // Stores the length of the
            // longest required subString
            int ans = 0;

            // Traverse the String
            for (int i = 0; i < N; i++)
            {
                // Stores the value of the
                // digit present at current 
                // index
                int val = s[i] - '0';

                // Bitwise XOR of the mask 
                // with 1 left-shifted by val
                mask ^= (1 << val);

                // Check if the value of mask is
                // already present in ind or not
                if (ind.ContainsKey(mask))
                {
                    // Update the readonly answer
                    ans = Math.Max(ans, i - ind[mask]);
                }

                // Otherwise
                else
                    ind.Add(mask, i);
            }

            // Return the answer
            return ans;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            // Given String
            String s = "223015150";

            // Length of the given String
            int N = s.Length;

            // Function Call
            Console.Write(
            lenOflongestReqSubstr(s, N));
        }
    }

    // This code is contributed by 29AjayKumar

}
