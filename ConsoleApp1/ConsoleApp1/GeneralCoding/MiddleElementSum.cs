using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/sum-of-middle-elements-of-two-sorted-arrays/
    Sum of middle elements of two sorted Arrays

    Given 2 sorted arrays Ar1 and Ar2 of size N each. Merge the given arrays and find the sum of the two middle elements of the merged array.

Examples:

Input: N = 5
Ar1[] = {1, 2, 4, 6, 10}
Ar2[] = {4, 5, 6, 9, 12}
Output: 11
Explanation: The merged array looks like {1, 2, 4, 4, 5, 6, 6, 9, 10, 12}. Sum of middle elements is 11 (5 + 6).

Input: N = 5
Ar1[] = {1, 12, 15, 26, 38}
Ar2[] = {2, 13, 17, 30, 45}
Output: 32
Explanation: The merged array looks like {1, 2, 12, 13, 15, 17, 26, 30, 38, 45} sum of middle elements is 32 (15 + 17).


Naive Approach: To solve the problem by Simply Merging the arrays follow the below steps:

Create an array merged[] of size 2*n (as both the arrays have the same size n).
Simultaneously traverse arr1[] and arr2[]. 
Pick a smaller of current elements in arr1[] and arr2[], copy this smaller element to the next position in merged[], and move ahead in merged[] and the array whose element is picked.
If there are remaining elements in arr1[] or arr2[], copy them also in merged[].
Return the sum of the middle two elements.
Below is the implementation for the above approach:

     */
    public class MiddleElementSum
    {
        static int findMidSum(int[] ar1, int[] ar2, int n)
        {
            if (n == 1)
                return ar1[0] + ar2[0];
            if (n == 2)
                return Math.Max(ar1[0], ar2[0]) + Math.Min(ar1[1], ar2[1]);

            int i = 0, j = 0;
            int k = 0;
            int[] merged = new int[2 * n];

            while (i < n && j < n)
            {
                if (ar1[i] <= ar2[j])
                {
                    merged[k] = ar1[i];
                    i++;
                    k++;
                }
                else
                {
                    merged[k] = ar2[j];
                    j++;
                    k++;
                }
            }
            while (i < n)
            {
                merged[k] = ar1[i];
                i++;
                k++;
            }
            while (j < n)
            {
                merged[k] = ar2[j];
                j++;
                k++;
            }

            return merged[n] + merged[n - 1];
        }
        /*
        Optimized Approach: To optimize our previous approach we will use a counter to decrease the auxiliary space used 
        Follow the steps to solve the problem:

Simultaneously traverse arr1[] and arr2[]. 
Use count to keep track of the nth element and (n+1)th element ( for an array of 2*n size, nth and (n+1)th elements are the middle elements).
Pick the smaller of the current elements in arr1[] and arr2[], update the m1 with m2 and m2 with the smaller element, and move the pointer of the array whose element is picked. 
At the end of the loop, m1 will have the nth element, and m2 will have the n+1th element. Return m1+m2.
Below is the implementation for the above approach:
        */
        static int findMidSumOptimised(int[] ar1, int[] ar2, int n)
        {
            if (n == 1)
                return ar1[0] + ar2[0];
            if (n == 2)
                return Math.Max(ar1[0], ar2[0]) + Math.Min(ar1[1], ar2[1]);

            // Current index of i/p array ar1[]
            int i = 0;

            // Current index of i/p array ar2[]
            int j = 0;
            int count;
            int m1 = -1, m2 = -1;

            // Since there are 2n elements, median
            // will be average of elements at
            // index n-1 and n in the array
            // obtained after merging ar1 and ar2
            for (count = 0; count <= n; count++)
            {

                // Below is to handle case where
                // all elements of ar1[] are
                // smaller than smallest(or first)
                // element of ar2[]
                if (i == n)
                {
                    m1 = m2;
                    m2 = ar2[0];
                    break;
                }

                // Below is to handle case where
                // all elements of ar2[] are
                // smaller than smallest(or first)
                // element of ar1[]
                else if (j == n)
                {
                    m1 = m2;
                    m2 = ar1[0];
                    break;
                }

                // equals sign because if two
                // arrays have some common elements
                if (ar1[i] <= ar2[j])
                {

                    // Store the prev median
                    m1 = m2;
                    m2 = ar1[i];
                    i++;
                }
                else
                {

                    // Store the prev median
                    m1 = m2;
                    m2 = ar2[j];
                    j++;
                }
            }

            return (m1 + m2);
            /*
             Output: 11
Time Complexity: O(n)
Auxiliary Space: O(1), Since we have used count, m1 and m2 to keep track of the middle elements
            */
        }
        /*
         fficient Approach: To solve the problem in the most efficient way we will use Binary search:

Initialize low = 0 and high = n, where n is the size of the first array.
Find the point to partition the ar1 into 2 parts using Binary Search.
First halve should have the elements smaller or equal to the first middle element and second halve should have the element greater or equal to the second middle element. And each half will have n elements.
Using the partition point of ar1, find the partition point for ar2. 
Check whether all the elements in first half is smaller than second half.
l1 = largest element of the first half from ar1
l2 = largest element of the first half from ar2
r1 = smallest element of the second half from ar1
r2 = smallest element of the second half from ar2
Since l1 is already less than r1 and l2 is already less than r2,
if(l1 > r2) 
high = cut1 – 1
if(l2 > r1)
low = cut1+1
else 
return max(l1, l2) + min(r1, r2)
Since max of the largest elements of first halves from ar1 and ar2  will be the maximum in first half and min of the smallest elements from second halves from ar1 and ar2 will be the smallest in the second half, return the sum of the max(l1, l2) and min(r1, r2).
Below is the implementation for the above approach:
        */
        static int findMidSumBinarySearch(int[] ar1, int[] ar2, int n)
        {
            if (n == 1)
            {
                return ar1[0] + ar2[0];
            }
            if (n == 2)
            {
                return Math.Max(ar1[0], ar2[0]) + Math.Min(ar1[1], ar2[1]);
            }
            // code here
            int low = 0, high = n - 1;
            int ans = -1;
            while (low <= high)
            {
                int cut1 = low + (high - low) / 2;
                int cut2 = n - cut1;

                int l1 = (cut1 == 0 ? int.MinValue : ar1[cut1 - 1]);
                int l2 = (cut2 == 0 ? int.MinValue : ar2[cut2 - 1]);
                int r1 = (cut1 == n ? int.MaxValue : ar1[cut1]);
                int r2 = (cut2 == n ? int.MaxValue : ar2[cut2]);

                if (l1 > r2)
                {
                    high = cut1 - 1;
                }
                else if (l2 > r1)
                {
                    low = cut1 + 1;
                }
                else
                {
                    ans = Math.Max(l1, l2) + Math.Min(r1, r2);
                    break;
                }
            }
            return ans;
            /*
op 11
Time Complexity: O(logn)
Auxiliary Space: O(1)
            */
        }
        // Drivers code
        public static void Main(string[] args)
        {

            int[] ar1 = { 1, 2, 4, 6, 10 };
            int[] ar2 = { 4, 5, 6, 9, 12 };
            Console.WriteLine(findMidSum(ar1, ar2, ar1.Length));
            /*
            Output 11
Time Complexity: O(n), Since we are traversing both arrays, the time complexity is O(2*n)
Auxiliary Space: O(n), As we are using one extra array to store the merged array elements

Optimized Approach: To optimize our previous approach we will use a counter to decrease the auxiliary space used.
            */

        }
    }
}
