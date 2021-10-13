using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/value-to-be-subtracted-from-array-elements-to-make-sum-of-all-elements-equals-k/
    Value to be subtracted from array elements to make sum of all elements equals K
Difficulty Level : Medium
Last Updated : 19 Jul, 2021
Given an integer K and an array, height[] where height[i] denotes the height of the ith tree in a forest. 
    The task is to make a cut of height X from the ground such that exactly K unit wood is collected. If it is not possible, then print -1 else print X.

Examples: 
Input: height[] = {1, 2, 1, 2}, K = 2 
Output: 1 
Make a cut at height 1, the updated array will be {1, 1, 1, 1} and 
the collected wood will be {0, 1, 0, 1} i.e. 0 + 1 + 0 + 1 = 2.

Input: height = {1, 1, 2, 2}, K = 1 
Output: -1  

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: This problem can be solved using binary search.  

Sort the heights of the trees.
The lowest height to make the cut is 0 and the highest is the maximum height among all the trees. So, set low = 0 and high = max(height[i]).
Repeat the steps below while low ≤ high: 
Set mid = low + ((high – low) / 2).
Count the amount of wood that can be collected if the cut is made at height mid and store it in a variable collected.
If collected = K then mid is the answer.
If collected > K then update low = mid + 1 as the cut needs to be made at a height higher than the current height.
Else update high = mid – 1 as cuts need to be made at a lower height.
Print -1 if no such value of mid is found.
Below is the implementation of the above approach:

     */
    class WoodCollect
    {
        static int[] height = { 1, 2, 1, 2 };

        // Function to return the amount of wood
        // collected if the cut is made at height m
        public static int woodCollected(int n, int m)
        {
            int sum = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (height[i] - m <= 0)
                    break;
                sum += (height[i] - m);
            }
            return sum;
        }

        // Function that returns Height at
        // which cut should be made
        public static int collectKWood(int n, int k)
        {
            // Sort the heights of the trees
            Array.Sort(height);

            // The minimum and the maximum
            // cut that can be made
            int low = 0, high = height[n - 1];

            // Binary search to find the answer
            while (low <= high)
            {
                int mid = low + ((high - low) / 2);

                // The amount of wood collected
                // when cut is made at the mid
                int collected = woodCollected(n, mid);

                // If the current collected wood is
                // equal to the required amount
                if (collected == k)
                    return mid;

                // If it is more than the required amount
                // then the cut needs to be made at a
                // height higher than the current height
                if (collected > k)
                    low = mid + 1;

                // Else made the cut at a lower height
                else
                    high = mid - 1;
            }
            return -1;
        }

        // Driver code
        public static void Main()
        {
            int k = 2;
            int n = height.Length;
            Console.WriteLine(collectKWood(n, k));
            /*
             output 1
            Time Complexity: O(nlogn)

            Auxiliary Space: O(1)
            */
        }
    }
}
