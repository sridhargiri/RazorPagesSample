using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Max sum of M non-overlapping subarrays of size K
Difficulty Level : Hard
Last Updated : 09 May, 2020
Given an array and two numbers M and K. We need to find sum of max M subarrays of size K (non-overlapping) in the array. (Order of array remains unchanged). K is the size of subarrays and M is the count of subarray. It may be assumed that size of array is more than m*k. If total array size is not multiple of k, then we can take partial last array.

Examples :

Input: N = 7, M = 3, K = 1 
       arr[] = {2, 10, 7, 18, 5, 33, 0}; 
Output: 61 
Explanation: subsets are: 33, 18, 10 (3 subsets of size 1) 

Input: N = 4, M = 2, K = 2 
       arr[] = {3, 2, 100, 1}; 
Output:  106 
Explanation: subsets are: (3, 2), (100, 1) 2 subsets of size 2
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Here we can see that we need to find M subarrays each of size K so,
1. We create a presum array, which contains in each index sum of all elements from ‘index‘ to ‘index + K’ in the given array. And size of the sum array will be n+1-k.
2. Now if we include the subarray of size k, then we can not include any of the elements of that subarray again in any other subarray as it will create overlapping subarrays. So we make recursive call by excluding the k elements of included subarray.
3. if we exclude a subarray then we can use the next k-1 elements of that subarray in other subarrays so we will make recursive call by just excluding the first element of that subarray.
4. At last return the max(included sum, excluded sum).
    
     https://www.geeksforgeeks.org/max-sum-of-m-non-overlapping-subarrays-of-size-k/
    */
    class NonOverlapingSubarray
    {

        // calculating presum of array. 
        // presum[i] is going to store 
        // prefix sum of subarray of 
        // size k beginning with arr[i]
        static void calculatePresumArray(int[] presum,
                              int[] arr, int n, int k)
        {
            for (int i = 0; i < k; i++)
                presum[0] += arr[i];

            // store sum of array index i to i+k 
            // in presum array at index i of it.
            for (int i = 1; i <= n - k; i++)
                presum[i] += presum[i - 1] + arr[i + k - 1]
                                              - arr[i - 1];
        }

        // calculating maximum sum of
        // m non overlapping array
        static int maxSumMnonOverlappingSubarray(
                         int[] presum, int m, int size,
                                      int k, int start)
        {

            // if m is zero then no need 
            // any array of any size so
            // return 0.
            if (m == 0)
                return 0;

            // if start is greater then the 
            // size of presum array return 0.
            if (start > size - 1)
                return 0;

            //int mx = 0;

            // if including subarray of size k
            int includeMax = presum[start] +
                    maxSumMnonOverlappingSubarray(presum,
                              m - 1, size, k, start + k);

            // if excluding element and searching 
            // in all next possible subarrays
            int excludeMax =
                    maxSumMnonOverlappingSubarray(presum,
                                  m, size, k, start + 1);

            // return max
            return Math.Max(includeMax, excludeMax);
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 2, 10, 7, 18, 5, 33, 0 };
            int n = arr.Length;
            int m = 3, k = 1;
            int[] presum = new int[n + 1 - k];
            calculatePresumArray(presum, arr, n, k);

            // resulting presum array
            // will have a size = n+1-k
            Console.WriteLine(
                  maxSumMnonOverlappingSubarray(presum,
                                  m, n + 1 - k, k, 0));//op 61
        }
    }
    /*
         asked in JP Morga chase
Merge Overlapping Intervals
    https://www.geeksforgeeks.org/merging-intervals/
    Given a set of time intervals in any order, merge all overlapping intervals into one and output the result which should have only mutually exclusive intervals. Let the intervals be represented as pairs of integers for simplicity. 
For example, let the given set of intervals be {{1,3}, {2,4}, {5,7}, {6,8}}. The intervals {1,3} and {2,4} overlap with each other, so they should be merged and become {1, 4}. Similarly, {5, 7} and {6, 8} should be merged and become {5, 8}
 Write a function that produces the set of merged intervals for the given set of intervals. 
A simple approach is to start from the first interval and compare it with all other intervals for overlapping, if it overlaps with any other interval, then remove the other interval from the list and merge the other into the first interval. Repeat the same steps for remaining intervals after first. This approach cannot be implemented in better than O(n^2) time.
An efficient approach is to first sort the intervals according to the starting time. Once we have the sorted intervals, we can combine all intervals in a linear traversal. The idea is, in sorted array of intervals, if interval[i] doesn’t overlap with interval[i-1], then interval[i+1] cannot overlap with interval[i-1] because starting time of interval[i+1] must be greater than or equal to interval[i]. Following is the detailed step by step algorithm. 
    1. Sort the intervals based on increasing order of 
    starting time.
2. Push the first interval on to a stack.
3. For each interval do the following
   a. If the current interval does not overlap with the stack 
       top, push it.
   b. If the current interval overlaps with stack top and ending
       time of current interval is more than that of stack top, 
       update stack top with the ending  time of current interval.
4. At the end stack contains the merged intervals.
    Below is an implementation of the above approach.

     */
    public class MergeOverlappingIntervals
    {
        /*
          The Merged Intervals are: [1,9] 
Time complexity of the method is O(nLogn) which is for sorting. Once the array of intervals is sorted, merging takes linear time.
        */
        // sort the intervals in increasing order of start time
        class sortHelper : IComparer<Interval>
        {
            public int Compare(Interval a, Interval b)
            {
                Interval first = (Interval)a;
                Interval second = (Interval)b;
                if (first.start == second.start)
                {
                    return first.end - second.end;
                }
                return first.start - second.start;
            }
        }
        public static void mergeIntervals(Interval[] arr)
        {

            // Test if the given set has at least one interval
            if (arr.Length <= 0)
                return;
            Array.Sort(arr, new sortHelper());

            // Create an empty stack of intervals
            Stack<Interval> stack = new Stack<Interval>();

            // Push the first interval to stack
            stack.Push(arr[0]);

            // Start from the next interval and merge if necessary
            for (int i = 1; i < arr.Length; i++)
            {

                // get interval from stack top
                Interval top = (Interval)stack.Peek();

                // if current interval is not overlapping with stack top,
                // Push it to the stack
                if (top.end < arr[i].start)
                    stack.Push(arr[i]);

                // Otherwise update the ending time of top if ending of current
                // interval is more
                else if (top.end < arr[i].end)
                {
                    top.end = arr[i].end;
                    stack.Pop();
                    stack.Push(top);
                }
            }

            // Print contents of stack
            Console.Write("The Merged Intervals are: ");
            while (stack.Count != 0)
            {
                Interval t = (Interval)stack.Pop();
                Console.Write("[" + t.start + "," + t.end + "] ");
            }
        }
        static int mycomp(Interval a, Interval b)
        { return a.start < b.end ? 1 : 0; }

        /*
         A O(n Log n) and O(1) Extra Space Solution 
        The above solution requires O(n) extra space for the stack. We can avoid the use of extra space by doing merge operations in-place. Below are detailed steps. 

        1) Sort all intervals in increasing order of start time.
        2) Traverse sorted intervals starting from first interval, 
           do following for every interval.
              a) If current interval is not first interval and it 
                 overlaps with previous interval, then merge it with
                 previous interval. Keep doing it while the interval
                 overlaps with the previous one.         
              b) Else add current interval to output list of intervals.
        Note that if intervals are sorted by decreasing order of start times, we can quickly check if intervals overlap or not by comparing the start time of the previous interval with the end time of the current interval.
        Below is the implementation of the above algorithm. 
        */
        static void mergeIntervals(Interval[] arr, int n)
        {
            // Sort Intervals in increasing order of
            // start time
            Array.Sort(arr, mycomp);

            int index = 0; // Stores index of last element
                           // in output array (modified arr[])

            // Traverse all input Intervals
            for (int i = 1; i < n; i++)
            {
                // If this is not first Interval and overlaps
                // with the previous one
                if (arr[index].end >= arr[i].start)
                {
                    // Merge previous and current Intervals
                    arr[index].end = Math.Max(arr[index].end, arr[i].end);
                    arr[index].start = Math.Min(arr[index].start, arr[i].start);
                }
                else
                {
                    index++;
                    arr[index] = arr[i];
                }
            }

            // Now arr[0..index-1] stores the merged Intervals
            Console.WriteLine("The Merged Intervals are:");
            for (int i = 0; i <= index; i++)
                Console.WriteLine("[" + arr[i].start + ", " + arr[i].end + "] ");
        }
        // Driver code
        public static void Main()
        {

            Interval[] arr = new Interval[4];
            arr[0] = new Interval(6, 8);
            arr[1] = new Interval(1, 9);
            arr[2] = new Interval(2, 4);
            arr[3] = new Interval(4, 7);
            mergeIntervals(arr, arr.Length);//output = The Merged Intervals are: [1,9] 
        }
    }

    public class Interval
    {
        public int start, end;
        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
