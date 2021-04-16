using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class PalindromeMinSwap
    {
        /*
         https://www.geeksforgeeks.org/count-minimum-swap-to-make-string-palindrome/
        Count minimum swap to make string palindrome
Difficulty Level : Medium
Last Updated : 19 Oct, 2020
Given a string s, the task is to find out the minimum no of adjacent swaps required to make string s palindrome. If it is not possible, then return -1.
Examples:

Input: aabcb 
Output: 3 
Explanation: 
After 1st swap: abacb 
After 2nd swap: abcab 
After 3rd swap: abcba
Input: adbcdbad 
Output: -1 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach
The following are detailed steps to solve this problem. 

Take two-pointer where the first pointer track from the left side of a string and second pointer keep track from the right side of a string.
Till the time we find the same character, keep moving the right pointer to one step left.
If the same character not found then return -1.
If the same character found then swap the right pointer’s character towards right until it is not placed at it’s correct position in a string.
Increase left pointer and repeat step 2.
Below is the implementation of the above approach: 
         */
        static int count_min_Swap_to_make_palindrome(String str)
        {

            // Length of string
            int n = str.Length;

            // it will convert string to
            // char array
            char[] s = str.ToCharArray();

            // Counter to count minimum
            // swap
            int count = 0;

            // A loop which run in half
            // string from starting
            for (int i = 0; i < n / 2;
                    i++)
            {

                // Left pointer
                int left = i;

                // Right pointer
                int right = n - left - 1;

                // A loop which run from
                // right pointer to left
                // pointer
                while (left < right)
                {

                    // if both char same
                    // then break the loop
                    // if not same then we
                    // have to move right
                    // pointer to one step
                    // left
                    if (s[left] == s[right])
                    {
                        break;
                    }
                    else
                    {
                        right--;
                    }
                }

                // it denotes both pointer at
                // same position and we don't
                // have sufficient char to make
                // palindrome string
                if (left == right)
                {
                    return -1;
                }
                else
                {
                    for (int j = right;
                        j < n - left - 1; j++)
                    {
                        char t = s[j];
                        s[j] = s[j + 1];
                        s[j + 1] = t;
                        count++;
                    }
                }
            }

            return count;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            String s = "geeksfgeeks";

            // Function calling
            int ans1 = count_min_Swap_to_make_palindrome(s);

            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            s = new string(charArray);

            int ans2 = count_min_Swap_to_make_palindrome(s);

            if (ans1 > ans2)
                Console.WriteLine(ans1);
            else
                Console.WriteLine(ans2);
            /*
             * output 9
             Complexity Analysis 
Time Complexity: Since we are running two nested loops on the length of string, the time complexity is O(n2) 
Auxiliary Space: Since we aren’t using any extra space, Therefore Auxiliary space used is O(1)
            */
        }
    }
}
