using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/minimize-the-maximum-element-in-constructed-array-with-sum-divisible-by-k/
    Minimize the maximum element in constructed Array with sum divisible by K
Last Updated : 20 Aug, 2021
Given two integers N and K, the task is to find the smallest value for maximum element of an array of size N consisting of positive integers whose sum of elements is divisible by K.

Examples:

Input: N = 4, K = 3
Output: 2
Explanation: 
Let the array be [2, 2, 1, 1]. Here, sum of elements of this array is divisible by K=3, and maximum element is 2.

Input: N = 3, K = 5
Output: 2

Approach:  To find the smallest maximum of an array of size N and having sum divisible by K, try to create an array with the minimum sum possible.



The minimum sum of N elements (each having a value greater than 0) that is divisible by K is:
sum = K * ceil(N/K)
Now, if the sum is divisible by N then the maximum element will be sum/N otherwise it is (sum/N + 1).
Below is the implementation of above approach.
     */
    public class MaximumSum
    {
        static int smallest_Maximum_divisible_by_K(int N, int K)
        {
            // Minimum possible sum possible
            // for an array of size N such that its
            // sum is divisible by K
            int sum = ((N + K - 1) / K) * K;

            // If sum is not divisible by N
            if (sum % N != 0)
                return (sum / N) + 1;

            // If sum is divisible by N
            else
                return sum / N;
        }
        public static void Main(string[] args)
        {
            int N = 4;
            int K = 3;
            Console.WriteLine(smallest_Maximum_divisible_by_K(N, K));
            /*
             * Output:2
Time Complexity: O(1)
Auxiliary Space: O(1)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/minimize-the-sum-of-pair-which-upon-removing-divides-the-array-into-3-subarrays/
    Minimize the sum of pair which upon removing divides the Array into 3 subarrays
Last Updated : 20 Aug, 2021
Given an array arr of size N, the task is to find pair of elements having minimum sum, which on removal breaks the array into 3 non-empty subarrays of the original array. Print the sum of the elements in this pair.

Input: arr[]: {4, 2, 1, 2, 4}
Output: 4
Explanation:
Minimum sum pairs are values (2, 1) and (1, 2) but selecting a pair with adjacent indices won’t break the array into 3 parts. Next minimum value pair is (2, 2), which divides the array into {4}, {1}, {4}. Hence the answer is 2 + 2 = 4.

Input: arr[] = {5, 2, 4, 6, 3, 7}
Output: 5
Explanation:
Among all the pairs which break the array into 3 subparts, pair with values (2, 3) gives minimum sum.

Naive approach: To divide the array into three subarrays. Both elements which needs to be removed should follow these conditions:

any of the endpoints (index 0 and N-1) can’t be selected.
adjacent indices can’t be selected.
So, find all combinations of possible pairs and select the one which follows the above conditions and has the lowest sum of all.



Time Complexity: O(N2)
Auxiliary space: O(N)

Efficient approach: Follow the below steps to solve this problem efficiently:

Create an array prefixMin, in which ith element represents the minimum element from 0th to ith index in array arr.
Create a variable ans, to store the final answer and initialise it with INT_MAX.
Now, run a loop for i=3 to i=N-1 (starting from 3 as 0th can’t be selected and this loop is to select the second element of the pair, which means it even can’t be started from 2 because then the only remaining options for the first element are 1 & 2, which both don’t follow the given conditions) and in each iteration change ans to the minimum value out of ans and arr[i]+prefixMin[i-2].
Print ans, after following the above steps.
Below is the implementation of the above approach:
     */
    public class MinimizeSum
    {
        static int minSumPair(int[] arr, int N)
        {

            if (N < 5)
            {
                return -1;
            }

            int[] prefixMin=new int[N];
            prefixMin[0] = arr[0];

            // prefixMin[i] contains minimum element till i
            for (int i = 1; i < N - 1; i++)
            {
                prefixMin[i] = Math.Min(arr[i], prefixMin[i - 1]);
            }

            int ans = int.MaxValue;

            for (int i = 3; i < N - 1; i++)
            {
                ans = Math.Min(ans, arr[i] + prefixMin[i - 2]);
            }

            return ans;
        }
        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 4, 6, 3, 7 };
            int m = minSumPair(arr, arr.Length); Console.WriteLine(m);
            /*
             Output 5
Time Complexity: O(n)
Space Complexity: O(n)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/count-of-n-size-maximum-sum-arrays-with-elements-in-range-0-2k-1-and-bitwise-and-equal-to-0/
    Count of N-size maximum sum Arrays with elements in range [0, 2^K – 1] and Bitwise AND equal to 0
    Given two positive integers N and K, the task is to find the number of arrays of size N such that each array element lies over the range [0, 2K – 1] with the maximum sum of array element having Bitwise AND of all array elements 0.

Examples:

Input: N = 2 K = 2
Output: 4
Explanation:
The possible arrays with maximum sum having the Bitwise AND of all array element as 0 {0, 3}, {3, 0}, {1, 2}, {2, 1}. The count of such array is 4.

Input: N = 5 K = 6 
Output: 15625 

    Approach: The given problem can be solved by observing the fact that as the Bitwise AND of the generated array should be 0, then for each i in the range [0, K – 1] there should be at least 1 element with an ith bit equal to 0 in its binary representation. Therefore, to maximize the sum of the array, it is optimal to have exactly 1 element with the ith bit unset.

Hence, for each of the K bits, there are NC1 ways to make it unset in 1 array element. Therefore, the resultant count of an array having the maximum sum is given by NK.

Below is the implementation of the approach

     */
    public class MaximumSumArrayBitwise
    {

        // Function to find the value of X to
        // the power Y
        static int BitwisePower(int x, int y)
        {

            // Stores the value of X^Y
            int res = 1;

            while (y > 0)
            {

                // If y is odd, multiply x
                // with result
                if (y % 2 != 0)
                    res = res * x;

                // Update the value of y and x
                y = y >> 1;
                x = x * x;
            }

            // Return the result
            return res;
        }

        // Function to count number of arrays
        // having element over the range
        // [0, 2^K - 1] with Bitwise AND value
        // 0 having maximum possible sum
        static void countArrays(int N, int K)
        {

            // Print the value of N^K
            Console.WriteLine((int)(BitwisePower(N, K)));
        }

        // Driver Code
        public static void Main()
        {
            int N = 4, K = 3;

            countArrays(N, K);
            /*
Output: 15625

Time Complexity: O(log K)
Auxiliary Space: O(1)
            */
        }
    }
}
