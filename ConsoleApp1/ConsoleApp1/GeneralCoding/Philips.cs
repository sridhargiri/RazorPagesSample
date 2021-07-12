using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
        This is similar to philips hackerrank
    https://www.geeksforgeeks.org/count-of-subarrays-having-sum-equal-to-its-length/
    Count of subarrays having sum equal to its length
Difficulty Level : Hard
Last Updated : 18 May, 2021
Given an array arr[] of size N, the task is to find the number of subarrays having the sum of its elements equal to the number of elements in it.

Examples:

Input: N = 3, arr[] = {1, 0, 2}
Output: 3
Explanation:
Total number of subarrays are 6 i.e., {1}, {0}, {2}, {1, 0}, {0, 2}, {1, 0, 2}.
Out of 6 only three subarrays have the number of elements equals to sum of its elements i.e., 
1) {1}, sum = 1, length = 1.
2) {0, 2}, sum = 2, length = 2.
3) {1, 0, 2}, sum = 3, length = 3.

Input: N = 3, arr[] = {1, 1, 0}
Output: 3
Explanation:
Total number of subarrays are 6 i.e. {1}, {1}, {0}, {1, 1}, {1, 0}, {1, 1, 0}.
Out of 6 only three subarrays have the number of elements equals to sum of its elements i.e., 
1) {1}, sum = 1, length = 1.
2) {1}, sum = 1, length = 1.
3) {1, 1}, sum = 2, length = 2.

 
Naive Approach: The idea is to generate all the subarrays of the array and if the sum of elements of the subarray is equal to the number of elements in it then count this subarray. Print the count after checking all the subarrays.



Time Complexity: O(N2)
Auxiliary Space: O(N)

Efficient Approach: This problem can be converted into a simpler problem by using observation. If all the elements of the array are decremented by 1, then all the subarrays of array arr[] with a sum equal to its number of elements are same as finding the number of subarrays with sum 0 in the new array(formed by decrementing all the elements of arr[ ] by 1). Below are the steps:

Decrement all the array elements by 1.
Initialize a prefix array with prefix[0] = arr[0].
Traverse the given array arr[] from left to right, starting from index 1 and update a prefix sum array as pref[i] = pref[i-1] + arr[i].
Initialize the answer to 0.
Iterate the prefix array pref[] from left to right and increment the answer by the value of the current element in the map.
Increment the value of the current element in the map.
Print the value of answer after the above steps.
Below is the implementation of the above approach:
    */
    class Philips
    {

        // Function that counts the subarrays
        // with sum of its elements as its length
        static int countOfSubarray(int[] arr, int N)
        {
            // Decrementing all the elements
            // of the array by 1
            for (int i = 0; i < N; i++)
                arr[i]--;

            // Making prefix sum array
            int[] pref = new int[N];
            pref[0] = arr[0];

            for (int i = 1; i < N; i++)
                pref[i] = pref[i - 1] + arr[i];

            // Declare map to store count of
            // elements upto current element
            Dictionary<int,
                       int> mp = new Dictionary<int,
                                                int>();
            int answer = 0;

            // To count all the subarrays
            // whose prefix sum is 0
            mp.Add(0, 1);

            // Iterate the array
            for (int i = 0; i < N; i++)
            {

                // Increment answer by count of
                // current element of prefix array

                if (mp.ContainsKey(pref[i]))
                {
                    answer += mp[pref[i]];
                    mp[pref[i]] = mp[pref[i]] + 1;
                }
                else
                {
                    mp.Add(pref[i], 1);
                }
            }

            // Return the answer
            return answer;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            // Given array []arr
            int[] arr = { 1, 1, 0 };
            int N = arr.Length;

            // Function call
            Console.Write(countOfSubarray(arr, N));
            /*
             Output: 
3
 

Time Complexity: O(N * Log(N))
Auxiliary Space: O(N)
            */
        }
    }
}
