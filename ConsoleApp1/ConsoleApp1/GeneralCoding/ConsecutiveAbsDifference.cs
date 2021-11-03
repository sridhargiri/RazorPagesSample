using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/number-of-sub-sequence-such-that-it-has-one-consecutive-element-with-difference-less-than-or-equal-to-1/
    Number of sub-sequence such that it has one consecutive element with difference less than or equal to 1
    Given an array arr[] of N elements. The task is to find the number of sub-sequences which have at least two consecutive elements such that absolute difference between them is ≤ 1. 

Examples: 

Input: arr[] = {1, 6, 2, 1} 
Output: 6 
{1, 2}, {1, 2, 1}, {2, 1}, {6, 2, 1}, {1, 1} and {1, 6, 2, 1} 
are the sub-sequences that have at least one consecutive pair 
with difference less than or equal to 1.

Input: arr[] = {1, 6, 2, 1, 9} 
Output: 12 

Naive approach: The idea is to find all the possible sub-sequences and check if there exists a sub-sequence with any consecutive pair with difference ≤1 and increase the count.



Efficient approach: The idea is to iterate over the given array and for each ith-element, try to find the required sub-sequence ending with ith element as its last element. 
For every i, we want to use arr[i], arr[i] -1, arr[i] + 1, so we will define 2D array, dp[][], where dp[i][0] will contain the number of sub sequence that do not have any consecutive pair with difference less than 1 and dp[i][1] contain the number of sub sequence having any consecutive pair with difference ≤1. 
Also, we will maintain two variables required_subsequence and not_required_subsdequence to maintain the count of subsequences which have at least one consecutive element with difference ≤1 and count of sub-sequences which do not contain any consecutive element pair with difference ≤1.

Now, considering the sub-array arr[1] …. arr[i], we will perform the following steps:  

Compute the number of sub sequences which do not have any consecutive pair with difference less than 1 but will have by adding the ith element in the sub sequence. These are basically sum of dp[arr[i] + 1][0], dp[arr[i] – 1][0] and dp[arr[i]][0].
Total number of subsequences have at least one consecutive pair with difference at least 1 and ending at i is equal to total sub-sequences found till i (just append arr[i] at the last) + subsequences which turns into subsequence have at least consecutive pair with difference less than 1 on adding arr[i].
Total subsequence which do not have any consecutive pair with difference less than 1 and ending at i = total sub-sequence which do not have any consecutive pair with difference less than 1 before i + 1 (just the current element as a subsequence).
Update required_sub-sequence, not_required_subsequence and dp[arr[i][0]] and the final answer will be required_subsequence.
Below is the implementation of the above approach:

     */
    class ConsecutiveAbsDifference
    {

        static int N = 10000;

        // Function to return the number of subsequences
        // which have at least one consecutive pair
        // with difference less than or equal to 1
        static int count_required_sequence(int n, int[] arr)
        {
            int total_required_subsequence = 0;
            int total_n_required_subsequence = 0;
            int[,] dp = new int[N, 2];
            for (int i = 0; i < n; i++)
            {

                // Not required sub-sequences which
                // turn required on adding i
                int turn_required = 0;
                for (int j = -1; j <= 1; j++)
                    turn_required += dp[arr[i] + j, 0];

                // Required sub-sequence till now will be
                // required sequence plus sub-sequence
                // which turns required
                int required_end_i = (total_required_subsequence
                                    + turn_required);

                // Similarly for not required
                int n_required_end_i = (1 + total_n_required_subsequence
                                        - turn_required);

                // Also updating total required and
                // not required sub-sequences
                total_required_subsequence += required_end_i;
                total_n_required_subsequence += n_required_end_i;

                // Also, storing values in dp
                dp[arr[i], 1] += required_end_i;
                dp[arr[i], 0] += n_required_end_i;
            }

            return total_required_subsequence;
        }

        // Driver code
        static public void Main()
        {

            int[] arr = { 1, 6, 2, 1, 9 };
            int n = arr.Length;

            Console.WriteLine(count_required_sequence(n, arr));
            // op 12
        }
    }
}
