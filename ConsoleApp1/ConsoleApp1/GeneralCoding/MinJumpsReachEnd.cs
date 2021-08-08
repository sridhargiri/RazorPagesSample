/*
 Minimum number of jumps to reach end | Set 2 (O(n) solution)
Last Updated: 20-06-2020
https://www.geeksforgeeks.org/minimum-number-jumps-reach-endset-2on-solution/
Given an array of integers where each element represents the max number of steps that can be made forward from that element. Write a function to return the minimum number of jumps to reach the end of the array (starting from the first element). If an element is 0, then we cannot move through that element.

Examples:

Input:  arr[] = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9}
Output: 3 (1-> 3 -> 8 -> 9)
Explanation: Jump from 1st element to 
2nd element as there is only 1 step, 
now there are three options 5, 8 or 9. 
If 8 or 9 is chosen then the end node 9 
can be reached. So 3 jumps are made.

Input:  arr[] = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
Output: 10
Explanation: In every step a jump is 
needed so the count of jumps is 10.
In this post, its O(n) solution will be discussed.


Implementation:
Variables to be used:

maxReach 
The variable maxReach stores at all time the maximal reachable index in the array.
step 
The variable step stores the number of steps we can still take(and is initialized with value at index 0, i.e. initial number of steps)
jump 
jump stores the amount of jumps necessary to reach that maximal reachable position.
Given array arr = 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9

maxReach = arr[0]; // arr[0] = 1, so the maximum index we can reach at the moment is 1.
step = arr[0]; // arr[0] = 1, the amount of steps we can still take is also 1.
jump = 1; // we will always need to take at least one jump.
Now, starting iteration from index 1, the above values are updated as follows:
First we test whether we have reached the end of the array, in that case we just need to return the jump variable.
if (i == arr.length - 1)
    return jump;
Next we update the maxReach. This is equal to the maximum of maxReach and i+arr[i](the number of steps we can take from the current position).
maxReach = Math.max(maxReach, i+arr[i]);
We used up a step to get to the current index, so steps has to be decreased.
step--;
If no more steps are remaining (i.e. steps=0, then we must have used a jump. Therefore increase jump. 
Since we know that it is possible somehow to reach maxReach, we again initialize the steps to the number of steps to reach maxReach from position i. 
But before re-initializing step, we also check whether a step is becoming zero or negative. 
In this case, It is not possible to reach further.
if (step == 0) {
    jump++;
    if(i>=maxReach)
       return -1;
    step = maxReach - i;
}
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MinJumps
    {
        static int minJumps(int[] arr)
        {
            if (arr.Length <= 1)
                return 0;

            // Return -1 if not 
            // possible to jump 
            if (arr[0] == 0)
                return -1;

            // initialization 
            int maxReach = arr[0];
            int step = arr[0];
            int jump = 1;

            // Start traversing array 
            for (int i = 1; i < arr.Length; i++)
            {
                // Check if we have reached 
                // the end of the array 
                if (i == arr.Length - 1)
                    return jump;

                // updating maxReach 
                maxReach = Math.Max(maxReach, i + arr[i]);

                // we use a step to get 
                // to the current index 
                step--;

                // If no further steps left 
                if (step == 0)
                {
                    // we must have used a jump 
                    jump++;

                    // Check if the current index/position 
                    // or lesser index is the maximum reach 
                    // point from the previous indexes 
                    if (i >= maxReach)
                        return -1;

                    // re-initialize the steps to 
                    // the amount of steps to reach 
                    // maxReach from position i. 
                    step = maxReach - i;
                }
            }

            return -1;
        }

        // Driver Code 
        public static void Main()
        {
            int[] arr = new int[] { 1, 3, 5, 8, 9, 2,
                                6, 7, 6, 8, 9 };

            // calling minJumps method 
            Console.Write(minJumps(arr));
        }
    }

    // This code is contributed 
    // by nitin mittal 
    //Complexity Analysis:

    //    Time complexity: O(n).
    //Only one traversal of the array is needed.
    //Auxiliary Space: O(1).
    //There is no space required.
    /*
     Naive Recursive Approach. 
Approach: A naive approach is to start from the first element and recursively call for all the elements reachable from first element. The minimum number of jumps to reach end from first can be calculated using minimum number of jumps needed to reach end from the elements reachable from first. 

minJumps(start, end) = Min ( minJumps(k, end) ) for all k reachable from start 
https://www.geeksforgeeks.org/minimum-number-of-jumps-to-reach-end-of-a-given-array/?ref=leftbar-rightbar

     */
    public class MinJumps1
    {
        // Returns minimum number of
        // jumps to reach arr[h] from arr[l]
        static int minJumps(int[] arr, int l, int h)
        {
            // Base case: when source
            // and destination are same
            if (h == l)
                return 0;

            // When nothing is reachable
            // from the given source
            if (arr[l] == 0)
                return int.MaxValue;

            // Traverse through all the points
            // reachable from arr[l]. Recursively
            // get the minimum number of jumps
            // needed to reach arr[h] from these
            // reachable points.
            int min = int.MaxValue;
            for (int i = l + 1; i <= h && i <= l + arr[l]; i++)
            {
                int jumps = minJumps(arr, i, h);
                if (jumps != int.MaxValue && jumps + 1 < min)
                    min = jumps + 1;
            }
            return min;
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 1, 3, 6, 3, 2, 3, 6, 8, 9, 5 };
            int n = arr.Length;
            Console.Write("Minimum number of jumps to reach end is "
                          + minJumps(arr, 0, n - 1));
            /*
             Output: 

Minimum number of jumps to reach end is 4
Complexity Analysis: 

Time complexity: O(n^n). 
There are maximum n possible ways to move from a element. So maximum number of steps can be N^N so the upperbound of time complexity is O(n^n)
Auxiliary Space: O(1). 
There is no space required (if recursive stack space is ignored).
Note: If the execution is traced for this method, it can be seen that there will be overlapping subproblems.
            */
        }
    }
    /*
     Method 2: Dynamic Programming. 
Approach: 

In this way, make a jumps[] array from left to right such that jumps[i] indicate the minimum number of jumps needed to reach arr[i] from arr[0].
To fill the jumps array run a nested loop inner loop counter is j and outer loop count is i.
Outer loop from 1 to n-1 and inner loop from 0 to n-1.
if i is less than j + arr[j] then set jumps[i] to minimum of jumps[i] and jumps[j] + 1. initially set jump[i] to INT MAX
Finally, return jumps[n-1].
    */
    public class MinJumps2
    {
        static int minJumps(int[] arr, int n)
        {
            // jumps[n-1] will hold the
            // result
            int[] jumps = new int[n];

            // if first element is 0,
            if (n == 0 || arr[0] == 0)

                // end cannot be reached
                return int.MaxValue;

            jumps[0] = 0;

            // Find the minimum number of
            // jumps to reach arr[i]
            // from arr[0], and assign
            // this value to jumps[i]
            for (int i = 1; i < n; i++)
            {
                jumps[i] = int.MaxValue;
                for (int j = 0; j < i; j++)
                {
                    if (i <= j + arr[j] && jumps[j] != int.MaxValue)
                    {
                        jumps[i] = Math.Min(jumps[i], jumps[j] + 1);
                        break;
                    }
                }
            }
            return jumps[n - 1];
        }

        // Driver program
        public static void Main()
        {
            int[] arr = { 1, 3, 6, 1, 0, 9 };
            Console.Write("Minimum number of jumps to reach end is : " + minJumps(arr, arr.Length));
            /*
             Output: 

Minimum number of jumps to reach end is 3
Thanks to paras for suggesting this method. 
Time Complexity: O(n^2) 
            */
        }
    }
    /*
     Method 3: Dynamic Programming. 
In this method, we build jumps[] array from right to left such that jumps[i] indicates the minimum number of jumps needed to reach arr[n-1] from arr[i]. Finally, we return jumps[0].
    */
    public class MinJumps3
    {
        // Returns Minimum number
        // of jumps to reach end
        public static int minJumps(int[] arr, int n)
        {
            // jumps[0] will
            // hold the result
            int[] jumps = new int[n];
            int min;

            // Minimum number of jumps needed to
            // reach last element from last elements
            // itself is always 0
            jumps[n - 1] = 0;

            // Start from the second element, move
            // from right to left and construct the
            // jumps[] array where jumps[i] represents
            // minimum number of jumps needed to reach
            // arr[m-1] from arr[i]
            for (int i = n - 2; i >= 0; i--)
            {
                // If arr[i] is 0 then arr[n-1]
                // can't be reached from here
                if (arr[i] == 0)
                {
                    jumps[i] = int.MaxValue;
                }

                // If we can directly reach to the end
                // point from here then jumps[i] is 1
                else if (arr[i] >= n - i - 1)
                {
                    jumps[i] = 1;
                }

                // Otherwise, to find out the minimum
                // number of jumps needed to reach
                // arr[n-1], check all the points
                // reachable from here and jumps[] value
                // for those points
                else
                {
                    // initialize min value
                    min = int.MaxValue;

                    // following loop checks with all
                    // reachable points and takes the minimum
                    for (int j = i + 1; j < n && j <= arr[i] + i; j++)
                    {
                        if (min > jumps[j])
                        {
                            min = jumps[j];
                        }
                    }

                    // Handle overflow
                    if (min != int.MaxValue)
                    {
                        jumps[i] = min + 1;
                    }
                    else
                    {
                        jumps[i] = min; // or Integer.MAX_VALUE
                    }
                }
            }

            return jumps[0];
        }

        // Driver Code
        public static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 3, 6, 1, 0, 9 };
            int size = arr.Length;
            Console.WriteLine("Minimum number of"
                              + " jumps to reach end is " + minJumps(arr, size));
            /*
             Output: 

Minimum number of jumps to reach end is 3
Complexity Analysis: 

Time complexity:O(n^2). 
Nested traversal of the array is needed.
Auxiliary Space:O(n). 
To store the DP array linear space is needed.
            */
        }
    }
}
