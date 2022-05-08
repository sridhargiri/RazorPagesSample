using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/minimize-cost-to-reduce-array-if-for-choosing-every-2-elements-3rd-one-is-chosen-for-free/
    Minimize cost to reduce Array if for choosing every 2 elements, 3rd one is chosen for free
    Last Updated : 26 Jan, 2022
Given an array arr[]. The task is to minimize the cost of reducing the array with a given operation. In one operation choose two elements add their value to the total cost and remove them and remove any other element with a value almost the two chosen elements. 

Examples:

Input: arr[] = {1, 2, 3}
Output: 5
Explanation: Choose 2 and 3, cost = 5. 1 is reduced from array for free.

Input: arr[] = {6, 5, 7, 9, 2, 2}
Output: 23
Approach: This problem can be solved by using the Greedy Approach. Follow the steps below to solve the given problem.

Sort the given array.
Traverse the sorted array from the end.
Add 2 elements to the final cost and skip the 3rd one.
Return the final cost.
Below is the implementation of the above approach
     */
    class TakeTwoGetThirdFree
    {
        // Function to find minimum cost
        // to get the desired array
        static int minCost(List<int> arr)
        {
            // Sorting the array
            arr.Sort();
            int ans = 0;
            for (int i = arr.Count - 1, k = 1;
                 i >= 0;
                 i--, k++)
                if (k == 3)
                    k = 0;
                else
                    ans += arr[i];
            return ans;
        }
        public static void Main(string[] args)
        {
            List<int> arr = new List<int> { 6, 5, 7, 9, 2, 2 };
            Console.WriteLine(minCost(arr));
            /*
             Output
23
Time Complexity: O(N*log N)
Auxiliary Space: O(1)
            */
        }
    }
}
