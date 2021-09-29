using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/minimum-number-swaps-required-sort-array/
    Minimum number of swaps required to sort an array
    given an array of n distinct elements, find the minimum number of swaps required to sort the array.

Examples: 

Input : {4, 3, 2, 1}
Output : 2
Explanation : Swap index 0 with 3 and 1 with 2 to 
              form the sorted array {1, 2, 3, 4}.

Input : {1, 5, 4, 3, 2}
Output : 2

     */
    class MinswapsSortArray
    {

        /*
         Straight forward solution
While iterating over the array, check the current element, and if not in the correct place, replace that element with the index of the element which should have come in this place.
        */

        static int minSwaps(int[] arr, int N)
        {
            int ans = 0;
            int[] temp = new int[N];
            Array.Copy(arr, temp, N);
            Array.Sort(temp);
            for (int i = 0; i < N; i++)
            {

                // This is checking whether
                // the current element is
                // at the right place or not
                if (arr[i] != temp[i])
                {
                    ans++;

                    // Swap the current element
                    // with the right index
                    // so that arr[0] to arr[i] is sorted
                    swap(arr, i, indexOf(arr, temp[i]));
                }
            }
            return ans;
        }

        static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        static int indexOf(int[] arr, int ele)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ele)
                {
                    return i;
                }
            }
            return -1;
        }

        // Driver program to test
        // the above function
        static public void Main()
        {
            int[] a
                = { 101, 758, 315, 730, 472,
                         619, 460, 479 };
            int n = a.Length;
            // Output will be 5
            Console.WriteLine(minSwaps(a, n));
            /*
             Output:

5
Time Complexity: O(n*n) 
Auxiliary Space: O(n)
             */
        }
    }
    /*
     https://www.geeksforgeeks.org/minimum-adjacent-swaps-required-to-make-a-binary-string-alternating/
    Minimum adjacent swaps required to make a binary string alternating
Last Updated : 29 Sep, 2021
Given a binary string S of size N, the task is to find the number of minimum adjacent swaps required to make the string alternate. If it is not possible to do so, then print -1.

Examples: 

Input: S = “10011”
Output: 1
Explanation:
Swap index 2 and index 3 and the string becomes 10101 .

Input: S = “110100”
Output: 2
Explanation: 
First, swap index 1 and index 2 and the string becomes 101100 . 
Second, swap index 3 and index 4 and the string becomes 101010 . 
Approach: For making the string alternating either get “1” or “0” at the first position. When the length of the string is even, the string must be starting with “0” or “1”. When the length of the string is odd, there are two possible cases – if the no. of 1’s in the string is greater than no of 0’s in the string, the string must start with “1″. Otherwise if the no. of 0’s is greater than no of 1’s, the string must start with “0”. So, check for both the cases where the binary string starts with “1” at the first position and  “0” at the first position. Follow the steps below to solve the problem:

Initialize the variables ones and zeros as 0 to count the number of zeros and ones in the string.
Iterate over the range [0, N) using the variable i and count the number of 0’s and 1’s in the binary string.
Check for the base cases, i.e, if N is even then if zeros are equal to ones or not. And if N is odd, then the difference between them should be 1. If the base cases don’t satisfy, then return -1.
Initialize the variable ans_1 as 0 to store the answer when the string starts with 1 and j as 0.
Iterate over the range [0, N) using the variable i and if s[i] equals 1, then add the value of abs(j-i) to the variable ans_1 and increase the value of j by 2.
Similarly, initialize the variable ans_0 as 0 to store the answer when the string starts with 1 and k as 0.
Iterate over the range [0, N) using the variable i and if s[i] equals 0, then add the value of abs(k – i) to the variable ans_0 and increase the value of k by 2.
If N is even, then print the minimum of ans_1 or ans_0 as the result. Otherwise, if zeros is greater than ones, then print ans_0. Otherwise, print ans_1.
Below is the implementation of the above approach:
     */
    public class AlternatingBinaryString
    {
        static int minSwaps(string s)
        {
            // Count the no of zeros and ones
            int ones = 0, zeros = 0;
            int N = s.Length;

            for (int i = 0; i < N; i++)
            {
                if (s[i] == '1')
                    ones++;
                else
                    zeros++;
            }

            // Base Case
            if ((N % 2 == 0 && ones != zeros)
                || (N % 2 == 1
                    && Math.Abs(ones - zeros) != 1))
            {
                return -1;
            }

            // Store no of min swaps when
            // string starts with "1"
            int ans_1 = 0;

            // Keep track of the odd positions
            int j = 0;

            // Checking for when the string
            // starts with "1"
            for (int i = 0; i < N; i++)
            {
                if (s[i] == '1')
                {

                    // Adding the no of swaps to
                    // fix "1" at odd positions
                    ans_1 += Math.Abs(j - i);
                    j += 2;
                }
            }

            // Store no of min swaps when string
            // starts with "0"
            int ans_0 = 0;

            // Keep track of the odd positions
            int k = 0;

            // Checking for when the string
            // starts with "0"
            for (int i = 0; i < N; i++)
            {
                if (s[i] == '0')
                {

                    // Adding the no of swaps to
                    // fix "1" at odd positions
                    ans_0 += Math.Abs(k - i);
                    k += 2;
                }
            }

            // Returning the answer based on
            // the conditions when string
            // length is even
            if (N % 2 == 0)
                return Math.Min(ans_1, ans_0);

            // When string length is odd
            else
            {

                // When no of ones is greater
                // than no of zeros
                if (ones > zeros)
                    return ans_1;

                // When no of ones is greater
                // than no of zeros
                else
                    return ans_0;
            }
        }
        static void Main(string[] args)
        {
            string S = "110100"; minSwaps(S);
            /*
             Output: 2
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
