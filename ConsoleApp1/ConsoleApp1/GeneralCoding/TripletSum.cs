using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-a-triplet-that-sum-to-a-given-value/?ref=lbp
     Given an array and a value, find if there is a triplet in array whose sum is equal to the given value. 
    If there is such a triplet present in array, then print the triplet and return true. Else return false
    Input: array = {12, 3, 4, 1, 6, 9}, sum = 24; 
Output: 12, 3, 9 
Explanation: There is a triplet (12, 3 and 9) present 
in the array whose sum is 24. 
Input: array = {1, 2, 3, 4, 5}, sum = 9 
Output: 5, 3, 1 
Explanation: There is a triplet (5, 3 and 1) present 
in the array whose sum is 9
     */
    /*
     Method 1: This is the naive approach towards solving the above problem.  

 

Approach: A simple method is to generate all possible triplets and compare the sum of every triplet with the given value. The following code implements this simple method using three nested loops.
Algorithm: 
Given an array of length n and a sum s
Create three nested loop first loop runs from start to end (loop counter i), second loop runs from i+1 to end (loop counter j) and third loop runs from j+1 to end (loop counter k)
The counter of these loops represents the index of 3 elements of the triplets.
Find the sum of ith, jth and kth element. If the sum is equal to given sum. Print the triplet and break.
If there is no triplet, then print that no triplet exist
    */
    public class TripletSum
    {
        // returns true if there is
        // triplet with sum equal
        // to 'sum' present in A[].
        // Also, prints the triplet
        static bool find3Numbers(int[] A,
                                 int arr_size,
                                 int sum)
        {
            // Fix the first
            // element as A[i]
            for (int i = 0;
                 i < arr_size - 2; i++)
            {

                // Fix the second
                // element as A[j]
                for (int j = i + 1;
                     j < arr_size - 1; j++)
                {

                    // Now look for
                    // the third number
                    for (int k = j + 1;
                         k < arr_size; k++)
                    {
                        if (A[i] + A[j] + A[k] == sum)
                        {
                            Console.WriteLine("Triplet is " + A[i] + ", " + A[j] + ", " + A[k]);
                            return true;
                        }
                    }
                }
            }

            // If we reach here,
            // then no triplet was found
            return false;
        }

        // Driver Code
        static public void Main()
        {
            int[] A = { 1, 4, 45, 6, 10, 8 };
            int sum = 22;
            int arr_size = A.Length;

            find3Numbers(A, arr_size, sum);
            /*
             Output
Triplet is 4, 10, 8
 

Complexity Analysis: 
Time Complexity: O(n3). 
There are three nested loops traversing the array, so the time complexity is O(n^3)
Space Complexity: O(1). 
As no extra space is required.
            */
        }
    }
    /*
     Method 2: This method uses sorting to increase the efficiency of the code. 

Approach: By Sorting the array the efficiency of the algorithm can be improved. This efficient approach uses the two-pointer technique. Traverse the array and fix the first element of the triplet. Now use the Two Pointers algorithm to find if there is a pair whose sum is equal to x – array[i]. Two pointers algorithm take linear time so it is better than a nested loop.
Algorithm : 
Sort the given array.
Loop over the array and fix the first element of the possible triplet, arr[i].
Then fix two pointers, one at i + 1 and the other at n – 1. And look at the sum, 
If the sum is smaller than the required sum, increment the first pointer.
Else, If the sum is bigger, Decrease the end pointer to reduce the sum.
Else, if the sum of elements at two-pointer is equal to given sum then print the triplet and break.
Implementation:
    */
    public class CheckTripletSum
    {

        // returns true if there is triplet
        // with sum equal to 'sum' present
        // in A[]. Also, prints the triplet
        bool find3Numbers(int[] A, int arr_size,
                          int sum)
        {
            int l, r;

            /* Sort the elements */
            quickSort(A, 0, arr_size - 1);

            /* Now fix the first element 
        one by one and find the
        other two elements */
            for (int i = 0; i < arr_size - 2; i++)
            {

                // To find the other two elements,
                // start two index variables from
                // two corners of the array and
                // move them toward each other
                l = i + 1; // index of the first element
                           // in the remaining elements
                r = arr_size - 1; // index of the last element
                while (l < r)
                {
                    if (A[i] + A[l] + A[r] == sum)
                    {
                        Console.Write("Triplet is {0}, {1}, {2} that add upto {3}", A[i], A[l], A[r], sum);
                        return true;
                    }
                    else if (A[i] + A[l] + A[r] < sum)
                        l++;

                    else // A[i] + A[l] + A[r] > sum
                        r--;
                }
            }

            // If we reach here, then
            // no triplet was found
            return false;
        }

        int partition(int[] A, int si, int ei)
        {
            int x = A[ei];
            int i = (si - 1);
            int j;

            for (j = si; j <= ei - 1; j++)
            {
                if (A[j] <= x)
                {
                    i++;
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }
            }
            int temp1 = A[i + 1];
            A[i + 1] = A[ei];
            A[ei] = temp1;
            return (i + 1);
        }

        /* Implementation of Quick Sort
    A[] --> Array to be sorted
    si --> Starting index
    ei --> Ending index
    */
        void quickSort(int[] A, int si, int ei)
        {
            int pi;

            /* Partitioning index */
            if (si < ei)
            {
                pi = partition(A, si, ei);
                quickSort(A, si, pi - 1);
                quickSort(A, pi + 1, ei);
            }
        }

        // Driver Code
        static void Main()
        {
            CheckTripletSum triplet = new CheckTripletSum();
            int[] A = new int[] { 1, 4, 45, 6, 10, 8 };
            int sum = 22;
            int arr_size = A.Length;
            triplet.find3Numbers(A, arr_size, sum);
            /*
             Output
Triplet is 4, 8, 10
Complexity Analysis: 
Time complexity: O(N^2). 
There are only two nested loops traversing the array, so time complexity is O(n^2). Two pointers algorithm takes O(n) time and the first element can be fixed using another nested traversal.
Space Complexity: O(1). 
As no extra space is required
            */

        }
    }
    /*
     Method 3: This is a Hashing-based solution. 

Approach: This approach uses extra space but is simpler than the two-pointers approach. Run two loops outer loop from start to end and inner loop from i+1 to end. Create a hashmap or set to store the elements in between i+1 to j-1. So if the given sum is x, check if there is a number in the set which is equal to x – arr[i] – arr[j]. If yes print the triplet. 
 
Algorithm: 
Traverse the array from start to end. (loop counter i)
Create a HashMap or set to store unique pairs.
Run another loop from i+1 to end of the array. (loop counter j)
If there is an element in the set which is equal to x- arr[i] – arr[j], then print the triplet (arr[i], arr[j], x-arr[i]-arr[j]) and break
Insert the jth element in the set.
Implementation:
    */
    public class TripletSumHashing
    {

        // returns true if there is triplet
        // with sum equal to 'sum' present
        // in A[]. Also, prints the triplet
        static bool find3Numbers(int[] A, int arr_size, int sum)
        {
            // Fix the first element as A[i]
            for (int i = 0; i < arr_size - 2; i++)
            {
                // Find pair in subarray A[i+1..n-1]
                // with sum equal to sum - A[i]
                HashSet<int> s = new HashSet<int>();
                int curr_sum = sum - A[i];
                for (int j = i + 1; j < arr_size; j++)
                {
                    if (s.Contains(curr_sum - A[j]))
                    {
                        Console.Write("Triplet is {0}, {1}, {2} that add upto {3}", A[i], A[j], curr_sum - A[j], sum);
                        return true;
                    }
                    s.Add(A[j]);
                }
            }

            // If we reach here, then no triplet was found
            return false;
        }
        /*
         dry run of hashing approach, input array = 1, 4, 45, 6, 10, 8 and sum = 22, 
outer for run from 0 to 4 (=array_size=2 i.e. 6-2)

note: hashset initialised every loop

i=0; curr_sum = target-a[i] = 22-1=21, 
	j=1; 21-4=17,	hashset not contains, so add 4
	j=2; 21-45=-24,	hashset not contains, so add 45
	j=3; 21-6=15,	hashset not contains, so add 6
	j=4; 21-10=11,	hashset not contains, so add 10
	j=5; 21-8=13,	hashset not contains, so add 8

i=1; curr_sum = target-a[i] = 22-4=18,
	j=2; 18-45=-27,	hashset not contains, so add 45
	j=3; 18-6=12,	hashset not contains, so add 6
	j=4; 18-10=8,	hashset not contains, so add 10
	j=5; 18-8=10,	hashset contains, so return true by printing below to console, 
	--->print A[i] as A[1]=4, A[j] as A[5]=8, print current difference which is 22-4 as 10
        */
        /* Driver code */
        public static void Main()
        {
            int[] A = { 1, 4, 45, 6, 10, 8 };
            int sum = 22;
            int arr_size = A.Length;

            find3Numbers(A, arr_size, sum);
            /*
             Output:

Triplet is 4, 8, 10
Time complexity: O(N^2) 
Auxiliary Space: O(N)

You can watch the explanation of the problem on YouTube discussed By Geeks For Geeks Team.
            https://www.youtube.com/watch?v=X5UhF3xS5Dk
            */
        }
    }
}
