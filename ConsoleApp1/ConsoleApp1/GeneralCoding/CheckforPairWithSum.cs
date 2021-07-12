using System;
using System.Collections.Generic;
using System.Text;

/*
 * https://www.geeksforgeeks.org/hashedin-interview-experience-for-software-engineer-1-off-campus/
 * https://www.geeksforgeeks.org/given-an-array-a-and-a-number-x-check-for-pair-in-a-with-sum-as-x/
 Given an array A[] and a number x, check for pair in A[] with sum as x
Last Updated: 28-10-2020
Write a program that, given an array A[] of n numbers and another number x, determines whether or not there exist two elements in S whose sum is exactly x. 
Examples: 

Input: arr[] = {0, -1, 2, -3, 1}
        sum = -2
Output: -3, 1
If we calculate the sum of the output,
1 + (-3) = -2

Input: arr[] = {1, -2, 1, 0, 5}
       sum = 0
Output: -1
No valid pair exists.

Sorting and Two-Pointers technique.
Approach: A tricky approach to solve this problem can be to use the two-pointer technique. But for using two pointer technique, the array must be sorted. Once the array is sorted the two pointers can be taken which mark the beginning and end of the array respectively. If the sum is greater than the sum of those two elements, shift the left pointer to increase the value of required sum and if the sum is lesser than the required value, shift the right pointer to decrease the value. Let’s understand this using an example.

Let an array be {1, 4, 45, 6, 10, -8} and sum to find be 16
After sorting the array 
A = {-8, 1, 4, 6, 10, 45}
Now, increment ‘l’ when the sum of the pair is less than the required sum and decrement ‘r’ when the sum of the pair is more than the required sum. 
This is because when the sum is less than the required sum then to get the number which could increase the sum of pair, start moving from left to right(also sort the array) thus “l++” and vice versa.
Initialize l = 0, r = 5 
A[l] + A[r] ( -8 + 45) > 16 => decrement r. Now r = 4 
A[l] + A[r] ( -8 + 10) increment l. Now l = 1 
A[l] + A[r] ( 1 + 10) increment l. Now l = 2 
A[l] + A[r] ( 4 + 10) increment l. Now l = 3 
A[l] + A[r] ( 6 + 10) == 16 => Found candidates (return 1)

Note: If there is more than one pair having the given sum then this algorithm reports only one. Can be easily extended for this though. 
Algorithm: 

hasArrayTwoCandidates (A[], ar_size, sum)
Sort the array in non-decreasing order.
Initialize two index variables to find the candidate 
elements in the sorted array. 
Initialize first to the leftmost index: l = 0
Initialize second the rightmost index: r = ar_size-1
Loop while l < r. 
If (A[l] + A[r] == sum) then return 1
Else if( A[l] + A[r] < sum ) then l++
Else r–
No candidates in the whole array – return 0
filter_none
 */
namespace ConsoleApp1
{
    public class CheckforPairWithSum
    {
        static bool hasArrayTwoCandidates(int[] A,
                           int arr_size, int sum)
        {
            int l, r;

            /* Sort the elements */
            sort(A, 0, arr_size - 1);

            /* Now look for the two candidates 
            in the sorted array*/
            l = 0;
            r = arr_size - 1;
            while (l < r)
            {
                if (A[l] + A[r] == sum)
                    return true;
                else if (A[l] + A[r] < sum)
                    l++;
                else // A[i] + A[j] > sum
                    r--;
            }
            return false;
        }

        /* Below functions are only to sort the 
        array using QuickSort */

        /* This function takes last element as pivot,
        places the pivot element at its correct
        position in sorted array, and places all
        smaller (smaller than pivot) to left of
        pivot and all greater elements to right
        of pivot */
        static int partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            // index of smaller element
            int i = (low - 1);
            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller
                // than or equal to pivot
                if (arr[j] <= pivot)
                {
                    i++;

                    // swap arr[i] and arr[j]
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot)
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }
        //https://www.geeksforgeeks.org/quick-sort/
        /* The main function that 
        implements QuickSort()
        arr[] --> Array to be sorted,
        low --> Starting index,
        high --> Ending index */
        static void sort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, arr[pi] 
                is now at right place */
                int pi = partition(arr, low, high);

                // Recursively sort elements before
                // partition and after partition
                sort(arr, low, pi - 1);
                sort(arr, pi + 1, high);
            }
        }

        // Driver code
        public static void Main()
        {
            int[] A = { 1, 4, 45, 6, 10, -8 };
            int n = 16;
            int arr_size = 6;

            if (hasArrayTwoCandidates(A, arr_size, n))
                Console.Write("Array has two elements"
                              + " with given sum");
            else
                Console.Write("Array doesn't have "
                              + "two elements with given sum");
        }
    }
    /*
     
Method 2 : Hashing.
Approach: This problem can be solved efficiently by using the technique of hashing. Use a hash_map to check for the current array value x(let), if there exists a value target_sum-x which on adding to the former gives target_sum. This can be done in constant time. Let’s look at the following example. 

arr[] = {0, -1, 2, -3, 1} 
sum = -2 
Now start traversing: 
Step 1: For ‘0’ there is no valid number ‘-2’ so store ‘0’ in hash_map. 
Step 2: For ‘-1’ there is no valid number ‘-1’ so store ‘-1’ in hash_map. 
Step 3: For ‘2’ there is no valid number ‘-4’ so store ‘2’ in hash_map. 
Step 4: For ‘-3’ there is no valid number ‘1’ so store ‘-3’ in hash_map. 
Step 5: For ‘1’ there is a valid number ‘-3’ so answer is 1, -3 

Algorithm:  

Initialize an empty hash table s.
Do following for each element A[i] in A[] 
If s[x – A[i]] is set then print the pair (A[i], x – A[i])
Insert A[i] into s.
Pseudo Code :  

unordered_set s
for(i=0 to end)
  if(s.find(target_sum - arr[i]) == s.end)
    insert(arr[i] into s)
  else 
    print arr[i], target-arr[i]
     */
    class CheckforpairWithSum
    {
        static void printpairs(int[] arr,
                               int sum)
        {
            HashSet<int> s = new HashSet<int>();
            for (int i = 0; i < arr.Length; ++i)
            {
                int temp = sum - arr[i];

                // checking for condition
                if (s.Contains(temp))
                {
                    Console.Write("Pair with given sum " + sum + " is (" + arr[i] + ", " + temp + ")");
                }
                s.Add(arr[i]);
            }
        }

        // Driver Code
        static void Main()
        {
            int[] A = new int[] { 1, 4, 45,
                              6, 10, 8 };
            int n = 16;
            printpairs(A, n);
            /*
             Method 2 output using hashing
            Output: 
            Pair with given sum 16 is (10, 6)
Complexity Analysis:  

Time Complexity: O(n). 
As the whole array is needed to be traversed only once.
Auxiliary Space: O(n). 
A hash map has been used to store array elements.
Note: If the range of numbers includes negative numbers then also it will work fine.
            */
        }
    }

    // This code is contributed by
    // Manish Shaw(manishshaw1)

    /*
 https://www.geeksforgeeks.org/count-pairs-difference-equal-k/
    Count all distinct pairs with difference equal to k
Difficulty Level : Medium
Last Updated : 18 Jun, 2021
Geek-O-Lympics
Given an integer array and a positive integer k, count all distinct pairs with differences equal to k. 

Examples: 

Input: arr[] = {1, 5, 3, 4, 2}, k = 3
Output: 2
There are 2 pairs with difference 3, the pairs are {1, 4} and {5, 2} 

Input: arr[] = {8, 12, 16, 4, 0, 20}, k = 4
Output: 5
There are 5 pairs with difference 4, the pairs are {0, 4}, {4, 8}, 
{8, 12}, {12, 16} and {16, 20} 
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
Method 1 (Simple) 
A simple solution is to consider all pairs one by one and check difference between every pair. Following program implements the simple solution. We run two loops: the outer loop picks the first element of pair, the inner loop looks for the other element. This solution doesn’t work if there are duplicates in array as the requirement is to count only distinct pairs.
    */
    public class CheckforPairWithDifference
    {

        static int countPairsWithDiffK(int[] arr,
                                    int n, int k)
        {
            int count = 0;

            // Pick all elements one by one
            for (int i = 0; i < n; i++)
            {

                // See if there is a pair
                // of this picked element
                for (int j = i + 1; j < n; j++)
                    if (arr[i] - arr[j] == k ||
                          arr[j] - arr[i] == k)
                        count++;
            }

            return count;
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 1, 5, 3, 4, 2 };
            int n = arr.Length;
            int k = 3;

            Console.WriteLine("Count of pairs with "
                                 + " given diff is "
                   + countPairsWithDiffK(arr, n, k));
            /*
             Output: 

Count of pairs with given diff is 2
Time Complexity of O(n2)
            */
        }
    }
    //check this also
    //https://www.geeksforgeeks.org/find-number-pairs-xy-yx/
}
