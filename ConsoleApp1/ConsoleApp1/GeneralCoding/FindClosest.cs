using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/closest-value-to-k-from-an-unsorted-array/
    Asked in Quinnox L1 2nd may 2023
    Closest value to K from an unsorted array
    Given an array arr[] consisting of N integers and an integer K, the task is to find the array element closest to K. If multiple closest values exist, then print the smallest one.

Examples:

Input: arr[]={4, 2, 8, 11, 7}, K = 6
Output: 7
Explanation:
The absolute difference between 4 and 6 is |4 – 6| = 2
The absolute difference between 2 and 6 is |2 – 6| = 4
The absolute difference between 8 and 6 is |8– 6| = 2
The absolute difference between 11 and 6 is |11 – 6| = 5
The absolute difference between 7 and 6 is |7 – 6| = 1
Here, the absolute difference between K(=6) and 7 is minimum. Therefore, the closest value of K(=6) is 7

Input: arr[]={100, 200, 400}, K = 300
Output: 200


    Approach: The idea is to traverse the given array and print an element of the array which gives the minimum absolute difference with the given integer K. Follow the steps below to solve the problem:

Initialize a variable, say res, to store the array element the closest value to K.
Traverse the array and compare the absolute value of abs(K – res) and the absolute value of abs(K – arr[i]).
If the value of abs(K – res) exceeds abs(K – arr[i]), then update res to arr[i].
Finally, print res.
Below is the implementation of the above approach:

     */
    public class FindClosestToTarget
    {

        static int closestValUnsorted(int[] arr, int N, int K)
        {

            // Stores the closest
            // value to K
            int res = arr[0];

            // Traverse the array
            for (int i = 1; i < N; i++)
            {

                // If absolute difference
                // of K and res exceeds
                // absolute difference of K
                // and current element
                if (Math.Abs(K - res) >
                    Math.Abs(K - arr[i]))
                {
                    res = arr[i];
                }
            }

            // Return the closest
            // array element
            return res;
        }
        /*
        https://www.geeksforgeeks.org/find-closest-number-array/
        Given an array of sorted integers. We need to find the closest value to the given number. Array may contain duplicate values and negative numbers. 

Examples:  

Input : arr[] = {1, 2, 4, 5, 6, 6, 8, 9}
             Target number = 11
Output : 9
9 is closest to 11 in given array

Input :arr[] = {2, 5, 6, 7, 8, 8, 9}; 
       Target number = 4
Output : 5
5 is closest to 4 in given array

Input :arr[] = {2, 5, 6, 7, 8, 8, 9, 15, 19, 22, 32}; 
       Target number = 34
Output : 32
32 is closest to 34 in given array
        */
        static int FindClosestSortedTwoPointers(int[] arr, int n, int target)
        {
            int left = 0, right = n - 1;
            while (left < right)
            {
                if (Math.Abs(arr[left] - target)
                    <= Math.Abs(arr[right] - target))
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return arr[left];
        }

        // Driver Code
        public static void Main()
        {
            int[] arr = { 100, 200, 400 };
            int K = 300;
            int N = arr.Length;

            Console.WriteLine(closestValUnsorted(arr, N, K));
            /*
Output: 200 

Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
    public static class FindClosest
    {
        /*
         find the element that is closest to zero
         */
        public static int ClosestTo(this IEnumerable<int> collection, int target)
        {
            // NB Method will return int.MaxValue for a sequence containing no elements.
            // Apply any defensive coding here as necessary.
            var closest = int.MaxValue;
            var minDifference = int.MaxValue;
            foreach (var element in collection)
            {
                var difference = Math.Abs((long)element - target);
                if (minDifference > difference)
                {
                    minDifference = (int)difference;
                    closest = element;
                }
            }

            return closest;
        }
    }
    class FindClosestCallingCode
    {
        static string B(string tcmid, string pid, string itemid)
        {
            return "tcm:" + pid + "-" + itemid + "-" + tcmid.Substring(12, 2);

        }
        static void Main(string[] args)
        {
            int[] array = new int[14] { 7, -10, 13, 8, 4, 9, -12, -3, 35, -9, 10, -1, -2, 7 };
            var closest = array.ToList().ClosestTo(0);
            Console.WriteLine(closest);
            Console.ReadLine();
            //Console.WriteLine(B("tcm:123-456-78", "321", "645"));
        }
    }
}
