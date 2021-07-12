using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/median-of-two-sorted-arrays-of-different-sizes/
     Median of two sorted arrays of different sizes
Difficulty Level : Expert
Last Updated : 01 Jul, 2021
Given two sorted arrays, a[] and b[], the task is to find the median of these sorted arrays, in O(log n + log m) time complexity, when n is the number of elements in the first array, and m is the number of elements in the second array.
This is an extension of median of two sorted arrays of equal size problem. Here we handle arrays of unequal size also. 
Example: 

Input: ar1[] = {-5, 3, 6, 12, 15}
        ar2[] = {-12, -10, -6, -3, 4, 10}
Output : The median is 3.
Explanation : The merged array is :
        ar3[] = {-12, -10, -6, -5 , -3,
                 3, 4, 6, 10, 12, 15},
       So the median of the merged array is 3

Input: ar1[] = {2, 3, 5, 8}
        ar2[] = {10, 12, 14, 16, 18, 20}
Output : The median is 11.
Explanation : The merged array is :
        ar3[] = {2, 3, 5, 8, 10, 12, 14, 16, 18, 20}
        if the number of the elements are even, 
        so there are two middle elements,
        take the average between the two :
        (10 + 12) / 2 = 11.
Method 1: This method uses a linear and simpler approach. 

Approach: The given arrays are sorted, so merge the sorted arrays in an efficient way and keep the count of elements inserted in the output array or printed form. So when the elements in the output array are half the original size of the given array print the element as a median element. There are two cases: 

Case 1: m+n is odd, the median is at (m+n)/2 th index in the array obtained after merging both the arrays.
Case 2: m+n is even, the median will be average of elements at index ((m+n)/2 – 1) and (m+n)/2 in the array obtained after merging both the arrays
Algorithm: 

Given two arrays are sorted. So they can be merged in O(m+n) time. Create a variable count to have a count of elements in the output array.
If the value of (m+n) is odd then there is only one median else the median is the average of elements at index (m+n)/2 and ((m+n)/2 – 1).
To merge the both arrays, keep two indices i and j initially assigned to 0. Compare the ith index of 1st array and jth index of second, increase the index of the smallest element and increase the count.
Check if the count reached (m+n) / 2 if (m+n) is odd and store the element, if even store the average of (m+n)/2 th and (m+n)/2 -1 th element and print it.
Implementation: 
    */
    class MedianTwoArray
    {

        // Function to calculate median
        static int getMedian(int[] ar1, int[] ar2,
                             int n, int m)
        {

            // Current index of input array ar1[]
            int i = 0;

            // Current index of input array ar2[]
            int j = 0;

            int count;
            int m1 = -1, m2 = -1;

            // Since there are (n+m) elements, 
            // There are following two cases 
            // if n+m is odd then the middle 
            //index is median i.e. (m+n)/2 
            if ((m + n) % 2 == 1)
            {
                for (count = 0;
                    count <= (n + m) / 2;
                    count++)
                {
                    if (i != n && j != m)
                    {
                        m1 = (ar1[i] > ar2[j]) ?
                              ar2[j++] : ar1[i++];
                    }
                    else if (i < n)
                    {
                        m1 = ar1[i++];
                    }

                    // for case when j<m,
                    else
                    {
                        m1 = ar2[j++];
                    }
                }
                return m1;
            }

            // median will be average of elements
            // at index ((m+n)/2 - 1) and (m+n)/2
            // in the array obtained after merging
            // ar1 and ar2
            else
            {
                for (count = 0;
                    count <= (n + m) / 2;
                    count++)
                {
                    m2 = m1;
                    if (i != n && j != m)
                    {
                        m1 = (ar1[i] > ar2[j]) ?
                              ar2[j++] : ar1[i++];
                    }
                    else if (i < n)
                    {
                        m1 = ar1[i++];
                    }

                    // for case when j<m,
                    else
                    {
                        m1 = ar2[j++];
                    }
                }
                return (m1 + m2) / 2;
            }
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] ar1 = { 900 };
            int[] ar2 = { 5, 8, 10, 20 };

            int n1 = ar1.Length;
            int n2 = ar2.Length;

            Console.WriteLine(getMedian(ar1, ar2, n1, n2));
            /*
             Output
10
Complexity Analysis: 

Time Complexity: O(m + n). 
To merge both the arrays O(m+n) time is needed.
Space Complexity: O(1). 
No extra space is required.
            */
        }
    }
    /*
     Efficient solution: 

    Approach:The idea is simple, calculate the median of both the arrays and discard one half of each array. 
    Now, there are some basic corner cases. For array size less than or equal to 2 

    Suppose there are two arrays and the size of both the arrays is greater than 2. 
    Find the middle element of the first array and middle element of the second array (the first array is smaller than the second) if the middle element of the smaller array is less than the second array, then it can be said that all elements of the first half of smaller array will be in the first half of the output (merged array). So, reduce the search space by ignoring the first half of the smaller array and the second half of the larger array. Else ignore the second half of the smaller array and first half of a larger array.

    In addition to that there are more basic corner cases: 

    If the size of smaller array is 0. Return the median of a larger array.
    if the size of smaller array is 1. 
    The size of the larger array is also 1. Return the median of two elements.
    If the size of the larger array is odd. Then after adding the element from 2nd array, it will be even so the median will be an average of two mid elements. So the element from the smaller array will affect the median if and only if it lies between (m/2 – 1)th and (m/2 + 1)th element of the larger array. So, find the median in between the four elements, the element of the smaller array and (m/2)th, (m/2 – 1)th and (m/2 + 1)th element of a larger array
    Similarly, if the size is even, then check for the median of three elements, the element of the smaller array and (m/2)th, (m/2 – 1)th element of a larger array
    If the size of smaller array is 2 
    If the larger array also has two elements, find the median of four elements.
    If the larger array has an odd number of elements, then the median will be one of the following 3 elements 
    Middle element of larger array
    Max of the first element of smaller array and element just before the middle, i.e M/2-1th element in a bigger array
    Min of the second element of smaller array and element 
    just after the middle in the bigger array, i.e M/2 + 1th element in the bigger array
    If the larger array has even number of elements, then the median will be one of the following 4 elements 
    The middle two elements of the larger array
    Max of the first element of smaller array and element just before the first middle element in the bigger array, i.e M/2 – 2nd element
    Min of the second element of smaller array and element just after the second middle in the bigger array, M/2 + 1th element
    How can one half of each array be discarded?

    Let’s take an example to understand this
    Input :arr[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
    brr[] = { 11, 12, 13, 14, 15, 16, 17, 18, 19 }
    Dry Run of the code:
    Recursive call 1:
    smaller array[] = 1 2 3 4 5 6 7 8 9 10, mid = 5
    larger array[] = 11 12 13 14 15 16 17 18 19 , mid = 15

    5 < 15
    Discard first half of the first array and second half of the second array

    Recursive call 2:
    smaller array[] = 11 12 13 14 15, mid = 13
    larger array[] = 5 6 7 8 9 10, mid = 7

    7 < 13
    Discard first half of the second array and second half of the first array

    Recursive call 3:
    smaller array[] = 11 12 13 , mid = 12
    larger array[] = 7 8 9 10 , mid = 8

    8 < 12
    Discard first half of the second array and second half of the first array

    Recursive call 4:
    smaller array[] = 11 12
    larger array[] = 8 9 10

    Size of the smaller array is 2 and the size of the larger array is odd
    so, the median will be the median of max( 11, 8), 9, min( 10, 12)
    that is 9, 10, 11, so the median is 10.

    Output:10.000000

    Algorithm: 

    Create a recursive function that takes two arrays and the sizes of both the arrays.
    Take care of the base cases for the size of arrays less than 2. (previously discussed in Approach).Note: The first array is always the smaller array.
    Find the middle elements of both the arrays. i.e element at (n – 1)/2 and (m – 1)/2 of first and second array respectively. Compare both the elements.
    If the middle element of the smaller array is less than the middle element of the larger array then the first half of the smaller array is bound to lie strictly in the first half of the merged array. It can also be stated that there is an element in the first half of the larger array and the second half of the smaller array which is the median. So, reduce the search space to the first half of the larger array and the second half of the smaller array.
    Similarly, If the middle element of the smaller array is greater than the middle element of the larger array then reduce the search space to the first half of the smaller array and second half of the larger array.
    Implementation: 

    
     */
    public class MedianSortedArray
    {

        // A utility function to find median of two integers
        static float MO2(int a, int b)
        {
            return (float)((a + b) / 2.0);
        }

        // A utility function to find median of three integers
        static float MO3(int a, int b, int c)
        {
            return a + b + c - Math.Max(a, Math.Max(b, c)) -
              Math.Min(a, Math.Min(b, c));
        }

        // A utility function to find a median of four integers
        static float MO4(int a, int b, int c, int d)
        {
            int Max = Math.Max(a, Math.Max(b, Math.Max(c, d)));
            int Min = Math.Min(a, Math.Min(b, Math.Min(c, d)));
            return (float)((a + b + c + d - Max - Min) / 2.0);
        }

        // Utility function to find median of single array
        static float medianSingle(int[] arr, int n)
        {
            if (n == 0)
                return -1;
            if (n % 2 == 0)
                return (float)((double)(arr[n / 2] +
                                          arr[n / 2 - 1]) / 2);
            return arr[n / 2];
        }

        static int[] copyOfRange(int[] src, int start, int end)
        {
            int len = end - start;
            int[] dest = new int[len];
            Array.Copy(src, start, dest, 0, len);
            return dest;
        }

        // This function assumes that N is smaller than or equal to M
        // This function returns -1 if both arrays are empty
        static float findMedianUtil(int[] A, int N,
                                    int[] B, int M)
        {

            // If smaller array is empty,
            // return median from second array
            if (N == 0)
                return medianSingle(B, M);

            // If the smaller array has only one element
            if (N == 1)
            {

                // Case 1: If the larger array also has one element,
                // simply call MO2()
                if (M == 1)
                    return MO2(A[0], B[0]);

                // Case 2: If the larger array has odd number of elements,
                // then consider the middle 3 elements of larger array and
                // the only element of smaller array. Take few examples
                // like following
                // A = {9}, B[] = {5, 8, 10, 20, 30} and
                // A[] = {1}, B[] = {5, 8, 10, 20, 30}
                if (M % 2 == 1)
                    return MO2(B[M / 2], (int)MO3(A[0],
                                B[M / 2 - 1], B[M / 2 + 1]));

                // Case 3: If the larger array has even number of element,
                // then median will be one of the following 3 elements
                // ... The middle two elements of larger array
                // ... The only element of smaller array
                return MO3(B[M / 2], B[M / 2 - 1], A[0]);
            }

            // If the smaller array has two elements
            else if (N == 2)
            {

                // Case 4: If the larger array also has two elements,
                // simply call MO4()
                if (M == 2)
                    return MO4(A[0], A[1], B[0], B[1]);

                // Case 5: If the larger array has odd number of elements,
                // then median will be one of the following 3 elements
                // 1. Middle element of larger array
                // 2. Max of first element of smaller array and element
                // just before the middle in bigger array
                // 3. Min of second element of smaller array and element
                // just after the middle in bigger array
                if (M % 2 == 1)
                    return MO3(B[M / 2], Math.Max(A[0], B[M / 2 - 1]),
                               Math.Min(A[1], B[M / 2 + 1]));

                // Case 6: If the larger array has even number of elements,
                // then median will be one of the following 4 elements
                // 1) & 2) The middle two elements of larger array
                // 3) Max of first element of smaller array and element
                // just before the first middle element in bigger array
                // 4. Min of second element of smaller array and element
                // just after the second middle in bigger array
                return MO4(B[M / 2], B[M / 2 - 1],
                           Math.Max(A[0], B[M / 2 - 2]),
                           Math.Min(A[1], B[M / 2 + 1]));
            }

            int idxA = (N - 1) / 2;
            int idxB = (M - 1) / 2;

            /*
             * if A[idxA] <= B[idxB], then median
             must exist in A[idxA....] and B[....idxB]
             */
            if (A[idxA] <= B[idxB])
                return findMedianUtil(copyOfRange(A, idxA, A.Length),
                                      N / 2 + 1, B, M - idxA);
            /*
             * if A[idxA] > B[idxB], then median
             must exist in A[...idxA] and B[idxB....]
             */
            return findMedianUtil(A, N / 2 + 1,
                                  copyOfRange(B, idxB, B.Length), M - idxA);
        }

        // A wrapper function around findMedianUtil(). This function
        // makes sure that smaller array is passed as first argument
        // to findMedianUtil
        static float findMedian(int[] A, int N, int[] B, int M)
        {
            if (N > M)
                return findMedianUtil(B, M, A, N);

            return findMedianUtil(A, N, B, M);
        }

        // Driver code
        static void Main()
        {
            int[] A = { 900 };
            int[] B = { 5, 8, 10, 20 };

            int N = A.Length;
            int M = B.Length;

            Console.WriteLine(findMedian(A, N, B, M));
            /*
             Output
10.000000
Complexity Analysis: 

Time Complexity: O(min(log m, log n)). 
In each step one half of each array is discarded. So the algorithm takes O(min(log m, log n)) time to reach the median value.
Space Complexity: O(1). 
No extra space is required.
            */
        }
    }
    public class MedianMath
    {
        static int Solution(int[] arr, int n)
        {

            // If length of array is even
            if (n % 2 == 0)
            {
                int z = n / 2;
                int e = arr[z];
                int q = arr[z - 1];
                int ans = (e + q) / 2;
                return ans;
            }

            // If length if array is odd
            else
            {
                int z = (int)Math.Round((decimal)n / 2);
                return arr[z];
            }
        }
        static void Main(string[] args)
        {
            int[] arr1 = { -5, 3, 6, 12, 15 };
            int[] arr2 = { -12, -10, -6, -3, 4, 10 };
            int[] arr3 = new int[arr1.Length + arr2.Length];
            int l = arr1.Length + arr2.Length;
            // Merge two array into one array
            for (int k = 0; k < arr1.Length; k++)
            {
                arr3[k] = arr1[k];
            }

            int a = 0;
            for (int k = arr1.Length; k < l; k++)
            {
                arr3[k] = arr2[a++];
            }

            // Sort the merged array
            Array.Sort(arr3);
            Console.WriteLine(Solution(arr3, l));
            /*
             Output
Median = 3
Complexity Analysis :

Time Complexity: O(n Log n)
Space Complexity: O(i+j). Since we are creating a new array of size i+j.
            */
        }
    }
}
