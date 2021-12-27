using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/count-of-equal-value-pairs-from-given-two-arrays-such-that-ai-equals-bj/
    Count of equal value pairs from given two Arrays such that a[i] equals b[j]
    Given two arrays a[] and b[] of length N and M respectively, sorted in non-decreasing order. The task is to find the number of pairs (i, j) such that, a[i] equals b[j].
    input: a[] = {1, 1, 3, 3, 3, 5, 8, 8}, b[] = {1, 3, 3, 4, 5, 5, 5}
Output: 11
Explanation: Following are the 11 pairs with given condition The 11 pairs are {{1, 1}, {1, 1}, {3, 3}, {3, 3}, {3, 3}, {3, 3}, {3, 3}, {3, 3}, {5, 5}, {5, 5}, {5, 5}} . 
    Input: a[] = {1, 2, 3, 4}, b[] = {1, 1, 2}
Output: 3

Approach: This problem can be solved by using the Two Pointer approach. Let i point to the first element of array a[] and j point to the first element of array b[]. While traversing the arrays, there will be 3 cases.
    https://www.geeksforgeeks.org/two-pointers-technique/

Case 1: a[i] = b[j] Let target denote arr[i], cnt1 denote number of elements of array a that are equal to target and cnt2 denote the number of elements of array b that are equal to target. So the total number of pairs such that a[i] = b[j] is cnt1 * cnt2 . So our answer is incremented by cnt1 * cnt2 .
Case 2: a[i] < b[j] The only possibility of getting a[i] = b[j] in the future is by incrementing i, so we do i++.
Case 3: a[i] > b[j] The only possibility of getting a[i] = b[j] in the future is by incrementing j, so we do j++ .

Follow the steps below to solve the given problem.

Initialize the variables ans, i and j as 0.
Initialize answer, i, and j to 0 and start traversing both of the arrays (https://www.geeksforgeeks.org/c-c-while-loop-with-examples/) till i is less than N or j is less than M.
If a[i] equals b[j], calculate cnt1 and cnt2 and increment the answer by cnt1 * cnt2.
If a[i] is less than b[j], increment i.
If a[i] is greater than b[j], increment j.
After performing the above steps, print the values of ans as the answer.
Below is the implementation of the above approach:

     */
    public class ArrayEqualPair
    {
        static int findPairs(int[] a, int[] b, int n, int m)
        {

            // Initialize ans, i, j to 0 .
            int ans = 0, i = 0, j = 0;

            // Use the two pointer approach to
            // calculate the answer .
            while (i < n && j < m)
            {

                // Case - 1
                if (a[i] == b[j])
                {

                    // Target denotes a[i]
                    // or b[j] as a[i] = b[j].

                    // cnt1 denotes the number
                    // of elements in array
                    // a that are equal to target.

                    // cnt2 denotes the number
                    // of elements in array
                    // b that are equal to target
                    int target = a[i], cnt1 = 0, cnt2 = 0;

                    // Calculate cnt1
                    while (i < n && a[i] == target)
                    {
                        cnt1++;
                        i++;
                    }

                    // Calculate cnt2
                    while (j < m && b[j] == target)
                    {
                        cnt2++;
                        j++;
                    }

                    // Increment the answer by (cnt1 * cnt2)
                    ans += (cnt1 * cnt2);
                }

                // Case - 2
                else if (a[i] < b[j])
                    i++;

                // Case - 3
                else
                    j++;
            }

            // Return the answer
            return ans;
        }
        public static void Main(string[] args)
        {
            int N = 8, M = 7;
            int[] a = { 1, 1, 3, 3, 3, 5, 8, 8 };
            int[] b = { 1, 3, 3, 4, 5, 5, 5 };
            Console.WriteLine(findPairs(a, b, N, M));
            /*
             Output
11
Time Complexity: O(N + M)
Auxiliary Space: O(1)
            */
        }
    }
}
