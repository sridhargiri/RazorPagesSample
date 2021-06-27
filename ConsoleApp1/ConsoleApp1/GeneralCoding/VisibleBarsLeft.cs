using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class VisibleBarsLeft
    {
        /*
https://www.geeksforgeeks.org/number-of-ways-such-that-only-k-bars-are-visible-from-the-left/ 
         Efficient Approach: The efficient approach would be to use recursion. Follow the steps below to solve the problem:

Create a recursive function KvisibleFromLeft() that takes N and K as input parameters and does the following:
Base cases:
If N is equal to K, there is one way to arrange the bars, which is in ascending order. So, return 1.
If K==1, there are (N-1)! ways to arrange the bars, as the longest bar is placed in the first position and the remaining N-1 bars can be placed anywhere on the remaining N-1 positions. So, return (N-1)!.
For the recursion, there are two cases:
The smallest bar can be placed at the first position, then, among the remaining N-1 bars, only K-1 bars need to be visible. Thus, the answer would be the same as the number of ways to arrange N-1 bars such that K-1 bars are visible. This case, thus, recursively calls KvisibleFromLeft(N-1, K-1).
The smallest bar can be placed at any of the N-1 positions, other than the first. This would hide the smallest bar, and thus, the answer would be the same as the number of ways to arrange N-1 bars such that K bars are visible. Thus, this case recursively calls (N-1)*KvisibleFromLeft(N-1,K).
Below is the implementation of the above approach:
        */
        static int[,] dp = new int[1005, 1005];
        static int KvisibleFromLeft(int N, int K)
        {
            // If subproblem has already
            // been calculated, return
            if (dp[N, K] != 0)
                return dp[N, K];

            // Only ascending order is possible
            if (N == K)
                return dp[N, K] = 1;

            // N is placed at the first position
            // The nest N-1 are arranged in (N-1)! ways
            if (K == 1)
            {
                int ans = 1;
                for (int i = 1; i < N; i++)
                    ans *= i;
                return dp[N, K] = ans;
            }

            // Recursing
            return dp[N, K] = KvisibleFromLeft(N - 1, K - 1) + (N - 1) * KvisibleFromLeft(N - 1, K);
        }
        static void Main(string[] args)
        {
            // Input
            int N = 5, K = 2;
            Console.WriteLine(KvisibleFromLeft(N, K));
        }
        /*
         Output
50
Time Complexity: O(NK)
Auxiliary Space: O(NK)
        */
    }
}
