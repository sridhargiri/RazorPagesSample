using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     * Technical scripter archive
     Given an array arr[] consisting of N integers, the task is to count the minimum number of times at most K equal elements are required to be removed to make the array empty.
    Examples:

Input: arr[] = {1, 3, 1, 1, 3}, K = 2
Output: 3
Explanation:
Step 1: Remove at most 2 1s from the array. The modified array is {1, 3, 3}.
Step 2: Remove at most 2 3s from the array. The modified array is {1}.
Step 3: Remove at most 2 1s from the array. The modified array is {}.
After 3 steps, the array becomes empty.
Therefore, the minimum number of steps required is 3.

Input: arr[] = {4, 4, 7, 3, 1, 1, 2, 1, 7, 3}, K = 5
Output: 5

    Naive Approach: 
    The simplest approach is to traverse the array and count the frequency of every array element and then, divide the frequency of every element by K and add it to count. Increment count if the frequency of the array element is not divisible by K. After completing the above steps, print the value of count as the result.
Time Complexity: O(N2)
Auxiliary Space: O(1)

Efficient Approach: The above approach can be optimized by Hashing to store the frequency of eacharray element and then count the minimum number of operations required. 
    Follow the steps below to solve the problem:

    Initialize a variable, say count, that stores the minimum number of steps required.
Initialize a Hashmap that stores the frequency of each element in the array.
Traverse the array arr[] and store the frequencies of each element in the Hashmap.
Traverse the Hashmap and add the value of frequency of each element, divided by K, to the variable count. If the frequency of the current array element is not divisible by K, then increment count by 1.
After completing the above steps, print count as the required minimum number of steps required to make the array empty.
Below is the implementation of the above approach:
     */
    class EmptyArray
    {
        public static void minSteps(
        int[] arr, int K)
        {
            int n = arr.Length;
            int count = 0;
            Dictionary<int, int> hashmap = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                if (hashmap.ContainsKey(arr[i]))
                    hashmap[arr[i]]++;
                else
                    hashmap[arr[i]] = 1;
            }
            foreach (var k in hashmap.Keys)
            {
                if (hashmap[k] % K == 0)
                    count += hashmap[k] / K;
                else
                    count += (hashmap[k] / K) + 1;
            }
            Console.WriteLine(count);
        }
        public static void Main(string[] args)
        {
            int[] arr = { 4, 4, 7, 3, 1, 1, 2, 1, 7, 3 };
            int K = 5;

            minSteps(arr, K);//output 5
        }
    }
}
