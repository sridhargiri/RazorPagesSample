using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class TripletSumClosest
    {
        /*
         https://www.geeksforgeeks.org/find-a-triplet-in-an-array-whose-sum-is-closest-to-a-given-number/
        Find a triplet in an array whose sum is closest to a given number
Difficulty Level : Medium
Last Updated : 18 Feb, 2021
Given an array arr[] of N integers and an integer X, the task is to find three integers in arr[] such that the sum is closest to X.
Examples:

Input: arr[] = {-1, 2, 1, -4}, X = 1
Output: 2
Explanation:
Sums of triplets:
(-1) + 2 + 1 = 2
(-1) + 2 + (-4) = -3
2 + 1 + (-4) = -1
2 is closest to 1.

Input: arr[] = {1, 2, 3, 4, -5}, X = 10
Output: 9
Explanation:
Sums of triplets:
1 + 2 + 3 = 6
2 + 3 + 4 = 9
1 + 3 + 4 = 7
...
9 is closest to 10.
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Simple Approach: The naive approach is to explore all the subsets of size 3 and keep a track of the difference between X and the sum of this subset. Then return the subset whose difference between its sum and X is minimum.

Algorithm:

Create three nested loops with counter i, j and k respectively.
The first loop will start from start to end, the second loop will run from i+1 to end, the third loop will run from j+1 to end.
Check if the difference of the sum of ith, jth and kth element with the given sum is less than the current minimum or not. Update the current minimum
Print the closest sum.
Implementation:
        */
        static int solution(ArrayList arr, int x)
        {

            // To store the closets sum
            int closestSum = int.MaxValue;

            // Run three nested loops each loop
            // for each element of triplet
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    for (int k = j + 1; k < arr.Count; k++)
                    {
                        if (Math.Abs(x - closestSum) >
                            Math.Abs(x - ((int)arr[i] +
                           (int)arr[j] + (int)arr[k])))
                        {
                            closestSum = ((int)arr[i] +
                                          (int)arr[j] +
                                          (int)arr[k]);
                        }
                    }
                }
            }

            // Return the closest sum found
            return closestSum;
        }

        // Driver code
        public static void Main(string[] args)
        {
            ArrayList arr = new ArrayList() { -1, 2, 1, -4 };
            int x = 1;
            Console.Write(solution(arr, x));
            /*
             Output: 

2
Complexity Analysis:

Time complexity: O(N3). 
Three nested loops are traversing in the array, so time complexity is O(n^3).
Space Complexity: O(1). 
As no extra space is required.
            */
        }
    }
    /*
     Efficient approach: By Sorting the array the efficiency of the algorithm can be improved. This efficient approach uses the two-pointer technique. Traverse the array and fix the first element of the triplet. Now use the Two Pointers algorithm to find the closest number to x – array[i]. Update the closest sum. Two pointers algorithm take linear time so it is better than a nested loop.

Algorithm: 

Sort the given array.
Loop over the array and fix the first element of the possible triplet, arr[i].
Then fix two pointers, one at I + 1 and the other at n – 1. And look at the sum, 
If the sum is smaller than the sum we need to get to, we increase the first pointer.
Else, If the sum is bigger, Decrease the end pointer to reduce the sum.
Update the closest sum found so far.
    */
    public class TripletSumClosestEff
    {

        // Function to return the sum of a
        // triplet which is closest to x
        static int solution(List<int> arr, int x)
        {

            // Sort the array
            arr.Sort();

            // To store the closets sum
            int closestSum = int.MaxValue;

            // Fix the smallest number among
            // the three integers
            for (int i = 0; i < arr.Count - 2; i++)
            {

                // Two pointers initially pointing at
                // the last and the element
                // next to the fixed element
                int ptr1 = i + 1, ptr2 = arr.Count - 1;

                // While there could be more pairs to check
                while (ptr1 < ptr2)
                {

                    // Calculate the sum of the current triplet
                    int sum = arr[i] + arr[ptr1] + arr[ptr2];

                    // If the sum is more closer than
                    // the current closest sum
                    if (Math.Abs(x - sum) <
                        Math.Abs(x - closestSum))
                    {
                        closestSum = sum;
                    }

                    // If sum is greater then x then decrement
                    // the second pointer to get a smaller sum
                    if (sum > x)
                    {
                        ptr2--;
                    }

                    // Else increment the first pointer
                    // to get a larger sum
                    else
                    {
                        ptr1++;
                    }
                }
            }

            // Return the closest sum found
            return closestSum;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] ar = { -1, 2, 1, -4 };
            List<int> arr = new List<int>(ar);
            int x = 1;
            Console.WriteLine(solution(arr, x));
            /*
             Output: 
2
Complexity Analysis:

Time complexity: O(N2). 
There are only two nested loops traversing the array, so time complexity is O(n^2). Two pointer algorithm take O(n) time and the first element can be fixed using another nested traversal.
Space Complexity: O(1). 
As no extra space is required.
            */
        }
    }
}
