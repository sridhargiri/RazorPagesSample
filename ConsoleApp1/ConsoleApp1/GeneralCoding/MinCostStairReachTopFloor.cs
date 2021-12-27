using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MinCostStairReachTopFloor
    {
        /*
		 https://www.geeksforgeeks.org/minimum-cost-to-reach-the-top-of-the-floor-by-climbing-stairs/
		Minimum cost to reach the top of the floor by climbing stairs
Difficulty Level : Easy
Last Updated : 14 May, 2021
		Given N non-negative integers which signifies the cost of the moving from each stair. Paying the cost at i-th step, you can either climb one or two steps. Given that one can start from the 0-the step or 1-the step, the task is to find the minimum cost to reach the top of the floor(N+1) by climbing N stairs. 

Examples: Input: a[] = { 16, 19, 10, 12, 18 }
Output: 31
Start from 19 and then move to 12. 

Input: a[] = {2, 5, 3, 1, 7, 3, 4}
Output: 9 
2->3->1->3
		Approach: Let dp[i] be the cost to climb the i-th staircase to from 0-th or 1-th step. Hence dp[i] = cost[i] + min(dp[i-1], dp[i-2]). 
		Since dp[i-1] and dp[i-2] are needed to compute the cost of traveling from i-th step, a bottom-up approach can be used to solve the problem. 
		The answer will be the minimum cost of reaching n-1th stair and n-2th stair. Compute the dp[] array in a bottom-up manner. 
		Below is the implementation of the above approach.  
		 */
        static int minimumCost(int[] cost, int n)
        {
            // declare an array
            int[] dp = new int[n];

            // base case
            if (n == 1)
                return cost[0];

            // initially to
            // climb till 0-th
            // or 1th stair
            dp[0] = cost[0];
            dp[1] = cost[1];

            // iterate for finding the cost
            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Min(dp[i - 1],
                                dp[i - 2]) + cost[i];
            }

            // return the minimum
            return Math.Min(dp[n - 2],
                            dp[n - 1]);
        }
        /*
		 Space-optimized Approach: Instead of using dp[] array for memoizing the cost, use two-variable dp1 and dp2. Since the cost of reaching the last two stairs is required only, use two variables and update them by swapping when one stair is climbed. 

Below is the implementation of the above approach:  
		*/
        static int minimumCost_Opt(int[] cost,
                               int n)
        {
            int dp1 = 0, dp2 = 0;

            // traverse till N-th stair
            for (int i = 0; i < n; i++)
            {
                int dp0 = cost[i] +
                          Math.Min(dp1, dp2);

                // update the last
                // two stairs value
                dp2 = dp1;
                dp1 = dp0;
            }
            return Math.Min(dp1, dp2);
        }

        // Driver Code
        public static void Main()
        {
            int[] a = { 16, 19, 10, 12, 18 };
            int n = a.Length;
            Console.WriteLine(minimumCost(a, n));
            /*
			 Output: 31	
1st approach
Time Complexity: O(N) 
Auxiliary Space: O(N)

opt approach
			
Time Complexity: O(N) 
Auxiliary Space: O(1)
			 */
        }
    }

    // This code is contributed
    // by Subhadeep

}
