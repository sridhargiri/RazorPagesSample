using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    /*
     Check if an array is increasing or decreasing
https://www.geeksforgeeks.org/check-if-an-array-is-increasing-or-decreasing/?ref=gcse
Given an array arr[] of N elements where N ≥ 2, the task is to check the type of array whether it is:

Increasing.
Decreasing.
Increasing then decreasing.
Decreasing then increasing.
Note that the given array is definitely one of the given types.

Examples:

Input: arr[] = {1, 2, 3, 4, 5}
Output: Increasing

Input: arr[] = {1, 2, 4, 3}
Output: Increasing then decreasing




Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The following conditions must satitisfy for:

Increasing array: The first two and the last two elements must be in increasing order.
Decreasing array: The first two and the last two elements must be in decreasing order.
Increasing then decreasing array: The first two elements must be in increasing order and the last two elements must be in decreasing order.
Decreasing then increasing array: The first two elements must be in decreasing order and the last two elements must be in increasing order.
Below is the implementation of the above approach:
    */
    class IncDec
    {

        // Function to check the type of the array  
        public static void checkType(int[] arr, int n)
        {

            // If the first two and the last two elements  
            // of the array are in increasing order  
            if (arr[0] <= arr[1] &&
                arr[n - 2] <= arr[n - 1])
                Console.Write("Increasing");

            // If the first two and the last two elements  
            // of the array are in decreasing order  
            else if (arr[0] >= arr[1] &&
                     arr[n - 2] >= arr[n - 1])
                Console.Write("Decreasing");

            // If the first two elements of the array are in  
            // increasing order and the last two elements  
            // of the array are in decreasing order  
            else if (arr[0] <= arr[1] &&
                     arr[n - 2] >= arr[n - 1])
                Console.Write("Increasing then decreasing");

            // If the first two elements of the array are in  
            // decreasing order and the last two elements  
            // of the array are in increasing order  
            else
                Console.Write("Decreasing then increasing");
        }

        // Driver code  
        static public void Main()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };

            int n = arr.Length;

            checkType(arr, n);
            //output Increasing
        }
    }
    /*
     https://www.geeksforgeeks.org/check-if-array-forms-an-increasing-decreasing-sequence-or-vice-versa/
    Check if Array forms an increasing-decreasing sequence or vice versa
    Given an array arr[] of N integers, the task is to find if the array can be divided into 2 sub-array such that the first sub-array is strictly increasing and the second sub-array is strictly decreasing or vice versa. If the given array can be divided then print “Yes” else print “No”.

Examples: 

Input: arr[] = {3, 1, -2, -2, -1, 3} 
Output: Yes 
Explanation: 
First sub-array {3, 1, -2} which is strictly decreasing and second sub-array is {-2, 1, 3} is strictly increasing.

Input: arr[] = {1, 1, 2, 3, 4, 5} 
Output: No 
Explanation: 
The entire array is increasing. 
 

Naive Approach: The naive idea is to divide the array into two subarrays at every possible index and explicitly check if the first subarray is strictly increasing and the second subarray is strictly decreasing or vice-versa. If we can break any subarray then print “Yes” else print “No”. 
Time Complexity: O(N2) 
Auxiliary Space: O(1)

Efficient Approach: To optimize the above approach, traverse the array and check for the strictly increasing sequence and then check for strictly decreasing subsequence or vice-versa. Below are the steps: 

If arr[1] > arr[0], then check for strictly increasing then strictly decreasing as: 
Check for every consecutive pair until at any index i arr[i + 1] is less than arr[i].
Now from index i + 1 check for every consecutive pair check if arr[i + 1] is less than arr[i] till the end of the array or not. If at any index i, arr[i] is less than arr[i + 1] then break the loop.
If we reach the end in the above step then print “Yes” Else print “No”.
If arr[1] < arr[0], then check for strictly decreasing then strictly increasing as: 
Check for every consecutive pair until at any index i arr[i + 1] is greater than arr[i].
Now from index i + 1 check for every consecutive pair check if arr[i + 1] is greater than arr[i] till the end of the array or not. If at any index i, arr[i] is greater than arr[i + 1] then break the loop.
If we reach the end in the above step then print “Yes” Else print “No”.
Below is the implementation of above approach: 
     */
    public class IncDecViceversa
    {

        // Function to check if the given array
        // forms an increasing decreasing
        // sequence or vice versa
        static bool canMake(int n, int[] ar)
        {
            // Base Case
            if (n == 1)
                return true;
            else
            {

                // First subarray is
                // strictly increasing
                if (ar[0] < ar[1])
                {

                    int i = 1;

                    // Check for strictly
                    // increasing condition
                    // & find the break point
                    while (i < n && ar[i - 1] < ar[i])
                    {
                        i++;
                    }

                    // Check for strictly
                    // decreasing condition
                    // & find the break point
                    while (i + 1 < n && ar[i] > ar[i + 1])
                    {
                        i++;
                    }

                    // If i is equal to
                    // length of array
                    if (i >= n - 1)
                        return true;
                    else
                        return false;
                }

                // First subarray is
                // strictly Decreasing
                else if (ar[0] > ar[1])
                {
                    int i = 1;

                    // Check for strictly
                    // increasing condition
                    // & find the break point
                    while (i < n && ar[i - 1] > ar[i])
                    {
                        i++;
                    }

                    // Check for strictly
                    // increasing condition
                    // & find the break point
                    while (i + 1 < n && ar[i] < ar[i + 1])
                    {
                        i++;
                    }

                    // If i is equal to
                    // length of array - 1
                    if (i >= n - 1)
                        return true;
                    else
                        return false;
                }

                // Condition if ar[0] == ar[1]
                else
                {
                    for (int i = 2; i < n; i++)
                    {
                        if (ar[i - 1] <= ar[i])
                            return false;
                    }
                    return true;
                }
            }
        }

        // Driver Code
        public static void Main(String[] args)
        {
            // Given array []arr
            int[] arr = { 1, 2, 3, 4, 5 };
            int n = arr.Length;

            // Function Call
            if (!canMake(n, arr))
            {
                Console.Write("Yes");
            }
            else
            {
                Console.Write("No");
            }
            /*
Output: No
Time Complexity: O(N) 
Auxiliary Space: O(1)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/check-if-given-array-can-be-rearranged-as-increasing-decreasing-or-a-hill-sequence/?ref=rp
    Check if given Array can be rearranged as increasing, decreasing or a hill sequence
    Given an array arr[] of size N. The task is to find the number of sequences in which any one of the following conditions is met:

The given sequence can be re-arranged into strictly increasing order, or
The given sequence can be re-arranged into strictly decreasing order, or
The given sequence can be re-arranged into Hill sequence order.
The task is to check if the favourable Hill sequence is possible then print the possible sequence.

Examples:

Input: arr[] = {5, 7, 2, 1, 2}
Output: 1 2 5 7 2
Explanation: Here one such sequences is as follows
– s1 = {1, 2, 5, 7, 2}

Input: arr[] = {2, 4, 1, 2, 5, 6, 3}
Output: 1, 2, 3, 4, 5, 6, 2
Explanation: Here two such sequences are as follows
– s1 ={1, 2, 3, 4, 5, 6, 2} or, 
– s2 ={1, 2, 3, 6, 5, 4, 2}

Approach: The idea is to use hashing and sorting to solve the problem. Check if there are elements whose frequency is greater than 2 then it’s not possible. Follow the steps below to solve the problem:

Initialize the variable flag as 0.
Initialize the map<int, int> freq[].
Initialize the vector<int> a[].
Iterate over the range [0, n) using the variable i and perform the following tasks:
Push the value of arr[i] into the array a[].
Increase the count of freq[arr[i]] by 1.
Initialize the variable max as the maximum element in the array a[].
Initialize the variable freqsum as 0.
Traverse over the map freq[] using the variable x and perform the following tasks:
If x.second greater than equal to 3 then set flag as -1.
Traverse over the map freq[] using the variable x and perform the following tasks:
Count all the distinct elements in the variable freqsum.
If freq[max] equals 2 then set flag as -1 else set flag as 1.
If flag equals 1 then perform the following tasks:
Traverse over the map freq[] using the variable x and perform the following tasks:
If x.second equals 1 then push into the vector descending[] otherwise push it into the ascending[] also.
Sort the vector descending[] in ascending order and ascending[] in descending order.
After performing the above steps, print the result.
Below is the implementation of the above approach.
     */
    public class HillSequencePossible
    {
        public static void IsHillSequencePossible(int[] arr, int n)
        {

            // Flag will indicate whether
            // sequence is possible or not
            int flag = 0;

            Dictionary<int, int> freq = new Dictionary<int, int>();
            List<int> a = new List<int>();

            for (int i = 0; i < n; i++)
            {
                a.Add(arr[i]);
                if (freq.ContainsKey(arr[i]))
                {
                    freq[arr[i]] = freq[arr[i]] + 1;
                }
                else
                {
                    freq.Add(arr[i], 1);
                }
            }

            // Max element in <a>
            int max = a.Max();

            // Store only unique elements count
            int freqsum = 0;

            // If any element having freq more than 2
            foreach (KeyValuePair<int, int> i in freq)
            {

                // Hill sequence isn't possible
                if (i.Value >= 3)
                    flag = -1;
            }

            List<int> ascending
              = new List<int>();
            List<int> descending
              = new List<int>();

            // Counting all distinct elements only
            foreach (KeyValuePair<int, int> i in
                     freq)
            {

                // Having freq more than 1 should
                // be count only 1'nce
                if (i.Value > 1)
                    freqsum += 1;
                else
                    freqsum += i.Value;
            }

            // All elements are distinct
            // Hill sequence is possible
            if (a.Count == freqsum)
                flag = 1;
            else
            {

                // Max element appeared morethan 1nce
                // Hill sequence isn't possible
                if (freq[max] >= 2)
                    flag = -1;

                // Hill sequence is possible
                else
                    flag = 1;
            }

            // Print favourable sequence if flag==1
            // Hill sequence is possible
            if (flag == 1)
            {

                foreach (KeyValuePair<int, int> i in
                         freq)
                {

                    // If an element's freq==1
                    if (i.Value == 1)
                        descending.Add(i.Key);
                    else
                    {

                        // If an element's freq==2
                        descending.Add(i.Key);
                        ascending.Add(i.Key);
                    }
                }

                descending.Sort();
                ascending.Sort();
                ascending.Reverse();

                for (int i = 0; i < descending.Count; i++)
                    Console.Write(descending[i] + " ");

                for (int i = 0; i < ascending.Count; i++)
                    Console.Write(ascending[i] + " ");
            }
            else
            {
                Console.WriteLine("Not Possible!");
            }
        }

        // Driver Code
        public static void Main(String[] args)
        {
            int n = 5;
            int[] arr = new int[n];
            arr[0] = 5;
            arr[1] = 7;
            arr[2] = 2;
            arr[3] = 1;
            arr[4] = 2;

            IsHillSequencePossible(arr, n);
        }
    }
    /*
     https://www.geeksforgeeks.org/check-if-it-is-possible-to-make-array-increasing-or-decreasing-by-rotating-the-array/
    Check if it is possible to make array increasing or decreasing by rotating the array
    Given an array arr[] of N distinct elements, the task is to check if it is possible to make the array increasing or decreasing by rotating the array in any direction.
Examples: 
 

Input: arr[] = {4, 5, 6, 2, 3} 
Output: Yes 
Array can be rotated as {2, 3, 4, 5, 6}
Input: arr[] = {1, 2, 4, 3, 5} 
Output: No 
 

 
Approach: There are four possibilities: 
 

If the array is already increasing then the answer is Yes.
If the array is already decreasing then the answer is Yes.
If the array can be made increasing, this can be possible if the given array is first increasing up to the maximum element and then decreasing.
If the array can be made decreasing, this can be possible if the given array is first decreasing up to the minimum element and then increasing.
If it is not possible to make the array increasing or decreasing then print No.
Below is the implementation of the above approach: 
     */
    public class IsPossibleIncDecArray
    {

        // Function that returns true if the array
        // can be made increasing or decreasing
        // after rotating it in any direction
        static bool isPossibleToMakeArrayIncreasingDecreasing(int[] a, int n)
        {
            // If size of the array is less than 3
            if (n <= 2)
                return true;

            int flag = 0;

            // Check if the array is already decreasing
            for (int i = 0; i < n - 2; i++)
            {
                if (!(a[i] > a[i + 1] &&
                      a[i + 1] > a[i + 2]))
                {
                    flag = 1;
                    break;
                }
            }

            // If the array is already decreasing
            if (flag == 0)
                return true;

            flag = 0;

            // Check if the array is already increasing
            for (int i = 0; i < n - 2; i++)
            {
                if (!(a[i] < a[i + 1] &&
                      a[i + 1] < a[i + 2]))
                {
                    flag = 1;
                    break;
                }
            }

            // If the array is already increasing
            if (flag == 0)
                return true;

            // Find the indices of the minimum
            // && the maximum value
            int val1 = int.MaxValue, mini = -1,
                val2 = int.MinValue, maxi = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] < val1)
                {
                    mini = i;
                    val1 = a[i];
                }
                if (a[i] > val2)
                {
                    maxi = i;
                    val2 = a[i];
                }
            }

            flag = 1;

            // Check if we can make array increasing
            for (int i = 0; i < maxi; i++)
            {
                if (a[i] > a[i + 1])
                {
                    flag = 0;
                    break;
                }
            }

            // If the array is increasing upto max index
            // && minimum element is right to maximum
            if (flag == 1 && maxi + 1 == mini)
            {
                flag = 1;

                // Check if array increasing again or not
                for (int i = mini; i < n - 1; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                    return true;
            }

            flag = 1;

            // Check if we can make array decreasing
            for (int i = 0; i < mini; i++)
            {
                if (a[i] < a[i + 1])
                {
                    flag = 0;
                    break;
                }
            }

            // If the array is decreasing upto min index
            // && minimum element is left to maximum
            if (flag == 1 && maxi - 1 == mini)
            {
                flag = 1;

                // Check if array decreasing again or not
                for (int i = maxi; i < n - 1; i++)
                {
                    if (a[i] < a[i + 1])
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                    return true;
            }

            // If it is not possible to make the
            // array increasing or decreasing
            return false;
        }

        // Driver code
        public static void Main()
        {
            int[] a = { 4, 5, 6, 2, 3 };
            int n = a.Length;

            if (isPossibleToMakeArrayIncreasingDecreasing(a, n))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            /*
Output Yes
Time Complexity: O(N)

Auxiliary Space: O(1)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/find-whether-subarray-form-mountain-not/
    Find whether a subarray is in form of a mountain or not
Difficulty Level : Hard
Last Updated : 29 May, 2021
We are given an array of integers and a range, we need to find whether the subarray which falls in this range has values in the form of a mountain or not. All values of the subarray are said to be in the form of a mountain if either all values are increasing or decreasing or first increasing and then decreasing. 
More formally a subarray [a1, a2, a3 … aN] is said to be in form of a mountain if there exist an integer K, 1 <= K <= N such that, 
a1 <= a2 <= a3 .. <= aK >= a(K+1) >= a(K+2) …. >= aN 

Examples: 

Input : Arr[]  = [2 3 2 4 4 6 3 2], Range = [0, 2]
Output :  Yes

Explanation: The output is yes , subarray is [2 3 2], 
so subarray first increases and then decreases

Input:  Arr[] = [2 3 2 4 4 6 3 2], Range = [2, 7]
Output: Yes

Explanation: The output is yes , subarray is [2 4 4 6 3 2], 
so subarray first increases and then decreases


Input: Arr[]= [2 3 2 4 4 6 3 2], Range = [1, 3]
Output: no

Explanation: The output is no, subarray is [3 2 4], 
so subarray is not in the form above stated
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Solution: 

Approach: The problem has multiple queries so for each query the solution should be calculated with least possible time complexity. So create two extra spaces of the length of the original array. For every element find the last index on the left side which is increasing i.e. greater than its previous element and find the element on the right side will store the first index on the right side which is decreasing i.e. greater than its next element. If these value can be calculated for every index in constant time then for every given range the answer can be given in constant time.
Algorithm: 
Create two extra spaces of length n,left and right and a extra variable lastptr
Initialize left[0] = 0 and lastptr = 0
Traverse the original array from second index to the end
For every index check if it is greater than the pervious element, if yes then update the lastptr with the current index.
For every index store the lastptr in left[i]
initialize right[N-1] = N-1 and lastptr = N-1
Traverse the original array from second last index to the start
For every index check if it is greater than the next element, if yes then update the lastptr with the current index.
For every index store the lastptr in right[i]
Now process the queries
for every query l, r, if right[l] >= left[r] then print yes else no
Implementation:
     */
    public class MountainArray
    {

        // Utility method to construct
        // left and right array
        static void preprocess(int[] arr, int N, int[] left, int[] right)
        {
            // initialize first left
            // index as that index only
            left[0] = 0;
            int lastIncr = 0;

            for (int i = 1; i < N; i++)
            {
                // if current value is
                // greater than previous,
                // update last increasing
                if (arr[i] > arr[i - 1])
                    lastIncr = i;
                left[i] = lastIncr;
            }

            // initialize last right
            // index as that index only
            right[N - 1] = N - 1;
            int firstDecr = N - 1;

            for (int i = N - 2; i >= 0; i--)
            {
                // if current value is
                // greater than next,
                // update first decreasing
                if (arr[i] > arr[i + 1])
                    firstDecr = i;
                right[i] = firstDecr;
            }
        }

        // method returns true if
        // arr[L..R] is in mountain form
        static bool isSubarrayMountainForm(int[] arr, int[] left,
                                           int[] right, int L, int R)
        {
            // return true only if right at
            // starting range is greater
            // than left at ending range
            return (right[L] >= left[R]);
        }


        // Driver Code
        static public void Main()
        {
            int[] arr = {2, 3, 2, 4, 4, 6, 3, 2};
            int N = arr.Length;
            int[] left = new int[N];
            int[] right = new int[N];
            preprocess(arr, N, left, right);

            int L = 0;
            int R = 2;

            if (isSubarrayMountainForm(arr, left, right, L, R))
                Console.WriteLine("Subarray is in mountain form");
            else
                Console.WriteLine("Subarray is not in mountain form");

            L = 1;
            R = 3;

            if (isSubarrayMountainForm(arr, left, right, L, R))
                Console.WriteLine("Subarray is in mountain form");
            else
                Console.WriteLine("Subarray is not in mountain form");
            /*
             Output: 
Subarray is in mountain form
Subarray is not in mountain form
Complexity Analysis: 
Time Complexity:O(n). 
Only two traversals are needed so the time complexity is O(n).
Space Complexity:O(n). 
Two extra space of length n is required so the space complexity is O(n)
            */
        }
    }
}
