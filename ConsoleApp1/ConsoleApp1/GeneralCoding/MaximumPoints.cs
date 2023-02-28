using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     Find maximum points which can be obtained by deleting elements from array
    https://www.geeksforgeeks.org/find-maximum-points-which-can-be-obtained-by-deleting-elements-from-array/?ref=gcse
    Given an array A having N elements and two integers L and R where,<>
    You can choose any element of the array (let’s say ax) and delete it, and also delete all elements equal to ax+1, ax+2 … ax+R and ax-1, ax-2 … ax-L from the array. This step will cost ax points. 
    The task is to maximize the total cost after deleting all the elements from the array.
    Examples: 

Input : 2 1 2 3 2 2 1
        L = 1, R = 1
Output : 8
We select 2 to delete, then (2-1)=1 and (2+1)=3 will need to be deleted, 
for given L and R range respectively.
Repeat this until 2 is completely removed. So, total cost = 2*4 = 8.

Input : 2 4 2 9 5
        L = 1, R = 2
Output : 18
We select 2 to delete, then 5 and then 9.
So total cost = 2*2 + 5 + 9 = 18.
    Approach: We will find the count of all the elements. Now let’s say an element X is selected then, all elements in the range [X-L, X+R] will be deleted. 
    Now we select the minimum range from L and R and finds up to which elements are to be deleted when element X is selected. Our results will be the maximum of previously deleted elements and when element X is deleted. 
    We will use dynamic programming to store the result of previously deleted elements and use it further
Implementation

     */
    public class MaximumPoints
    {

        // function to return maximum
        // cost obtained
        static int maxCost(int[] a, int n,
                           int l, int r)
        {
            int mx = 0, k;

            // find maximum element
            // of the array.
            for (int i = 0; i < n; ++i)
                mx = Math.Max(mx, a[i]);

            // initialize count of all
            // elements to zero.
            int[] count = new int[mx + 1];
            for (int i = 0; i < count.Length; i++)
                count[i] = 0;

            // calculate frequency of all
            // elements of array.
            for (int i = 0; i < n; i++)
                count[a[i]]++;

            // stores cost of deleted elements.
            int[] res = new int[mx + 1];
            res[0] = 0;

            // selecting minimum range
            // from L and R.
            l = Math.Min(l, r);

            for (int num = 1; num <= mx; num++)
            {

                // finds upto which elements
                // are to be deleted when
                // element num is selected.
                k = Math.Max(num - l - 1, 0);

                // get maximum when selecting
                // element num or not.
                res[num] = Math.Max(res[num - 1], num *
                                  count[num] + res[k]);
            }

            return res[mx];
        }

        // Driver Code
        public static void Main()
        {
            int[] a = { 2, 1, 2, 3, 2, 2, 1 };
            int l = 1, r = 1;

            // size of array
            int n = a.Length;

            // function call to find maximum cost
            Console.WriteLine(maxCost(a, n, l, r));
            /*
Output  8
Time Complexity: O(max(A))
Auxiliary Space: O(max(A))
            */
        }
    }
}
