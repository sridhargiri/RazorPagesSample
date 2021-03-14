using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     * https://www.geeksforgeeks.org/count-minimum-number-of-fountains-to-be-activated-to-cover-the-entire-garden/
     * https://leetcode.com/problems/minimum-number-of-taps-to-open-to-water-a-garden/
     Count minimum number of fountains to be activated to cover the entire garden
Difficulty Level : Hard
 Last Updated : 01 Feb, 2021
There is a one-dimensional garden of length N. In each position of the N length garden, a fountain has been installed. Given an array a[]such that a[i] describes the coverage limit of ith fountain. A fountain can cover the range from the position max(i – a[i], 1) to min(i + a[i], N). In beginning, all the fountains are switched off. The task is to find the minimum number of fountains needed to be activated such that the whole N-length garden can be covered by water.

Examples:

Input: a[] = {1, 2, 1}
Output: 1
Explanation:
For position 1: a[1] = 1, range = 1 to 2
For position 2: a[2] = 2, range = 1 to 3
For position 3: a[3] = 1, range = 2 to 3
Therefore, the fountain at position a[2] covers the whole garden.
Therefore, the required output is 1.

Input: a[] = {2, 1, 1, 2, 1} 
Output: 2 

 
Approach: The problem can be solved using Dynamic Programming. Follow the steps below to solve the problem: 




traverse the array and for every array index, i.e. ith fountain, find the leftmost fountain up to which the current fountain covers.
Then, find the rightmost fountain that the leftmost fountain obtained in the above step covers up to and update it in the dp[] array.
Initialize a variable cntFount to store the minimum number of fountains that need to be activated.
Now, traverse the dp[] array and keep activating the fountains from the left that covers maximum fountains currently on the right and increment cntFount by 1. Finally, print cntFount as the required answer.
Below is the implementation of the above approach.
    */
    class GardenWater
    {

        // Function to find minimum
        // number of fountains to be
        // activated
        static int minCntFoun(int[] a, int N)
        {
            // dp[i]: Stores the position of
            // rightmost fountain that can
            // be covered by water of leftmost
            // fountain of the i-th fountain
            int[] dp = new int[N];
            for (int i = 0; i < N; i++)
            {
                dp[i] = -1;
            }

            // Stores index of leftmost
            // fountain in the range of
            // i-th fountain
            int idxLeft;

            // Stores index of rightmost
            // fountain in the range of
            // i-th fountain
            int idxRight;

            // Traverse the array
            for (int i = 0; i < N; i++)
            {
                idxLeft = Math.Max(i - a[i], 0);
                idxRight = Math.Min(i + (a[i] + 1), N);
                dp[idxLeft] = Math.Max(dp[idxLeft], idxRight);
            }

            // Stores count of fountains
            // needed to be activated
            int cntfount = 1;

            // Stores index of next
            // fountain that needed
            // to be activated
            int idxNext = 0;
            idxRight = dp[0];

            // Traverse []dp array
            for (int i = 0; i < N; i++)
            {
                idxNext = Math.Max(idxNext, dp[i]);

                // If left most fountain
                // cover all its range
                if (i == idxRight)
                {
                    cntfount++;
                    idxRight = idxNext;
                }
            }
            return cntfount;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            int[] a = { 1, 2, 1 };
            int N = a.Length;

            Console.Write(minCntFoun(a, N));
        }
        /*
         Output
            1
Time Complexity: O(N)
Auxiliary Space: O(N)
        */
    }
}
