using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SubarrayContigousEven
    {
        /*
         Length of the longest Subarray with only Even Elements
Difficulty Level : Easy
Last Updated : 24 Apr, 2020
Given an array arr[]. The task is to find the length of the longest subarray of arr[] such that it contains only even elements.

Examples:

Input : arr[] = { 5, 2, 4, 7 }
Output : Length = 2
subArr[] = {2, 4}

Input : arr[] = {9, 8, 5, 4, 4, 4, 2, 4, 1}
Output : Length 5
subArr[] = {4, 4, 4, 2, 4}
The idea is to observe that the largest subarray with only even elements is the maximum number of contiguous even elements in the array. Therefore, the task now reduces to find the maximum number of contiguous even elements in the array.

To do this, traverse the array using two variables, ans and current_count. The variable ans stores the final answer and current_count stores the length of subarray with only even numbers.

Now whenever an even element is found, keep incrementing the current_count and whenever an ODD element is found take the maximum of ans and current_count and reset current_count to zero.
At the end, ans will store the length of largest subarray with only even elements.
Below is the implementation of the above approach:
        */
        static int maxEvenSubarray(int[] array, int N)
        {
            int ans = 0;
            int count = 0;

            // Iterate the loop
            for (int i = 0; i < N; i++)
            {
                // Check whether the element is
                // even in continuous fashion
                if (array[i] % 2 == 0)
                {
                    count++;
                    ans = Math.Max(ans, count);
                }
                else
                {
                    // If element are not even in
                    // continuous fashion,
                    // Reinitialize the count
                    count = 0;
                }
            }

            // Check for the last 
            // element in the array
            ans = Math.Max(ans, count);
            return ans;
        }

        // Driver Code
        public static void Main()
        {
            int[] arr = { 9, 8, 5, 4, 4, 4, 2, 4, 1 };

            int N = arr.Length;

            Console.WriteLine(maxEvenSubarray(arr, N));
            /*
             Output:
5
Time Complexity: O(n)
            */
        }
    }
    /*
     Sum of all Subarrays | Set 1
https://www.geeksforgeeks.org/sum-of-all-subarrays/?ref=lbp
Given an integer array ‘arr[]’ of size n, find sum of all sub-arrays of given array. 
     Input   : arr[] = {1, 2, 3}
Output  : 20
Explanation : {1} + {2} + {3} + {2 + 3} + 
              {1 + 2} + {1 + 2 + 3} = 20

Input  : arr[] = {1, 2, 3, 4}
Output : 50
    */
    public class SumAllSubarray
    {
        /*
         
Method 1 (Simple Solution) 
A simple solution is to generate all sub-array and compute their sum. Time Complexity : O(n2) 
   https://www.geeksforgeeks.org/subarraysubstring-vs-subsequence-and-programs-to-generate-them/     
         */
        public static long SubArraySum(int[] arr,
                                      int n)
        {
            long result = 0, temp = 0;

            // Pick starting point
            for (int i = 0; i < n; i++)
            {
                // Pick ending point
                temp = 0;
                for (int j = i; j < n; j++)
                {

                    // sum subarray between current
                    // starting and ending points
                    temp += arr[j];
                    result += temp;
                }
            }
            return result;
        }
        /*
         Method 2 (efficient solution) 
If we take a close look then we observe a pattern. Let take an example  

arr[] = [1, 2, 3], n = 3
All subarrays :  [1], [1, 2], [1, 2, 3], 
                 [2], [2, 3], [3]
here first element 'arr[0]' appears 3 times    
     second element 'arr[1]' appears 4 times  
     third element 'arr[2]' appears 3 times

Every element arr[i] appears in two types of subsets:
i)  In subarrays beginning with arr[i]. There are 
    (n-i) such subsets. For example [2] appears
    in [2] and [2, 3].
ii) In (n-i)*i subarrays where this element is not
    first element. For example [2] appears in 
    [1, 2] and [1, 2, 3].

Total of above (i) and (ii) = (n-i) + (n-i)*i 
                            = (n-i)(i+1)
                                  
For arr[] = {1, 2, 3}, sum of subarrays is:
  arr[0] * ( 0 + 1 ) * ( 3 - 0 ) + 
  arr[1] * ( 1 + 1 ) * ( 3 - 1 ) +
  arr[2] * ( 2 + 1 ) * ( 3 - 2 ) 

= 1*3 + 2*4 + 3*3 
= 20
Below is the implementation of above idea. 
        */
        public static long SumSubarray(int[] arr,
                                       int n)
        {
            long result = 0;

            // computing sum of
            // subarray using formula
            for (int i = 0; i < n; i++)
                result += (arr[i] *
                          (i + 1) * (n - i));

            // return all subarray sum
            return result;
        }

        // Driver code
        static public void Main()
        {
            int[] arr = { 1, 2, 3 };
            int n = arr.Length;
            Console.WriteLine("Sum of SubArray: " + SubArraySum(arr, n));
            /*
             Output : 

Sum of SubArray : 20
Time complexity : O(n)
            refer https://www.quora.com/Can-we-find-the-sum-of-all-sub-arrays-of-an-integer-array-in-O-n-time
            */
        }
    }
}
