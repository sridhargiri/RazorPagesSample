using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Segregate 0s and 1s in an array
Difficulty Level : Easy
 Last Updated : 23 Jul, 2019
You are given an array of 0s and 1s in random order. Segregate 0s on left side and 1s on right side of the array. Traverse array only once.
Input array   =  [0, 1, 0, 1, 0, 0, 1, 1, 1, 0] 
Output array =  [0, 0, 0, 0, 0, 1, 1, 1, 1, 1]
    Method 1 (Count 0s or 1s)
Thanks to Naveen for suggesting this method.
1) Count the number of 0s. Let count be C.
2) Once we have count, we can put C 0s at the beginning and 1s at the remaining n – C positions in array.

Time Complexity : O(n)
     */
    class ZeroOneArray
    {
        static void segregate0and1(int[] arr, int n)
        {
            // counts the no of zeros in arr 
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] == 0)
                    count++;
            }

            // loop fills the arr with 0 until count 
            for (int i = 0; i < count; i++)
                arr[i] = 0;

            // loop fills remaining arr space with 1 
            for (int i = count; i < n; i++)
                arr[i] = 1;
        }

        // function to print segregated array 
        static void print(int[] arr, int n)
        {
            Console.WriteLine("Array after segregation is ");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }

        // The method 1 traverses the array two times. Method 2 does the same in a single pass
        //        Method 2 (Use two indexes to traverse)
        //Maintain two indexes.Initialize first index left as 0 and second index right as n-1.

        //Do following while left<right
        //a) Keep incrementing index left while there are 0s at it
        //b) Keep decrementing index right while there are 1s at it
        //c) If left<right then exchange arr[left] and arr[right]

        //Implementation:
        /*Function to put all 0s on 
      left and all 1s on right*/
        static void segregate0and1_1(int[] arr, int size)
        {
            /* Initialize left and right indexes */
            int left = 0, right = size - 1;

            while (left < right)
            {
                /* Increment left index while 
                   we see 0 at left */
                while (arr[left] == 0 && left < right)
                    left++;

                /* Decrement right index while  
                   we see 1 at right */
                while (arr[right] == 1 && left < right)
                    right--;

                /* If left is smaller than right then 
                   there is a 1 at left and a 0 at right.  
                   Exchange arr[left] and arr[right]*/
                if (left < right)
                {
                    arr[left] = 0;
                    arr[right] = 1;
                    left++;
                    right--;
                }
            }
        }
        /*
         Another approach :
1. Take two pointer type0(for element 0) starting from beginning (index = 0) and type1(for element 1) starting from end (index = array.length-1).
Initialize type0 = 0 and type1 = array.length-1
2. It is intended to Put 1 to the right side of the array. Once it is done, then 0 will definitely towards left side of array.
        */
        static void segregate0and1_2(int[] arr)
        {
            int type0 = 0;
            int type1 = arr.Length - 1;

            while (type0 < type1)
            {
                if (arr[type0] == 1)
                {
                    // swap  
                    arr[type1] = arr[type1] + arr[type0];
                    arr[type0] = arr[type1] - arr[type0];
                    arr[type1] = arr[type1] - arr[type0];
                    type1--;
                }

                else
                {
                    type0++;
                }
            }

        }
        public static void Main()
        {
            int[] arr = new int[] { 0, 1, 0, 1, 1, 1 };
            int n = arr.Length;

            segregate0and1(arr, n);
            print(arr, n);
            arr = new int[] { 0, 1, 0, 1, 1, 1 };
            int i, arr_size = arr.Length;
            segregate0and1_1(arr, arr_size);
            Console.WriteLine("Array after segregation is ");
            for (i = 0; i < 6; i++)
                Console.Write(arr[i] + " ");
            //output 
            //Array after segregation is 0 0 1 1 1 1 Time Complexity: O(n)
            int[] array = new int[] { 0, 1, 0, 1, 1, 1 };
            segregate0and1_2(array);

            Console.Write("Array after segregation is ");
            foreach (int a in array)
            {
                Console.Write(a + " ");
            }
        }
    }

    class ZeroOneTwoArray
    {
        /*
         Sort an array of 0s, 1s and 2s
Difficulty Level : Medium
 Last Updated : 01 Dec, 2020
Given an array A[] consisting 0s, 1s and 2s. The task is to write a function that sorts the given array. The functions should put all 0s first, then all 1s and all 2s in last.
        Examples:

Input: {0, 1, 2, 0, 1, 2}
Output: {0, 0, 1, 1, 2, 2}

Input: {0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1}
Output: {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2}
        A simple solution is discussed in this(Sort an array of 0s, 1s and 2s (Simple Counting)) post.

Method 1

Approach:The problem is similar to our old post Segregate 0s and 1s in an array, and both of these problems are variation of famous Dutch national flag problem.
The problem was posed with three colours, here `0′, `1′ and `2′. The array is divided into four sections:

a[1..Lo-1] zeroes (red)
a[Lo..Mid-1] ones (white)
a[Mid..Hi] unknown
a[Hi+1..N] twos (blue)
Dutch National Flag Algorithm OR 3-way Partitioning:
At first, the full array is unknown. There are three indices – low, mid and high. Initially, the value of low = mid = 1 and high = N.       

  
If the ith element is 0 then swap the element to the low range, thus shrinking the unknown range.
Similarly, if the element is 1 then keep it as it is but shrink the unknown range.
If the element is 2 then swap it with an element in high range.
Algorithm:
Keep three indices low = 1, mid = 1 and high = N and there are four ranges, 1 to low (the range containing 0), low to mid (the range containing 1), mid to high (the range containing unknown elements) and high to N (the range containing 2).
Traverse the array from start to end and mid is less than high. (Loop counter is i)
If the element is 0 then swap the element with the element at index low and update low = low + 1 and mid = mid + 1
If the element is 1 then update mid = mid + 1
If the element is 2 then swap the element with the element at index high and update high = high – 1 and update i = i – 1. As the swapped element is not processed
Print the output array.
Dry Run:
Part way through the process, some red, white and blue elements are known and are in the “right” place. The section of unknown elements, a[Mid..Hi], is shrunk by examining a[Mid]:       
 https://www.geeksforgeeks.org/sort-an-array-of-0s-1s-and-2s/           
         
         */

        // Sort the input array, the array is assumed to 
        // have values in {0, 1, 2} 
        static void sort012(int[] a, int arr_size)
        {
            int lo = 0;
            int hi = arr_size - 1;
            int mid = 0, temp = 0;

            while (mid <= hi)
            {
                switch (a[mid])
                {
                    case 0:
                        {
                            temp = a[lo];
                            a[lo] = a[mid];
                            a[mid] = temp;
                            lo++;
                            mid++;
                            break;
                        }
                    case 1:
                        mid++;
                        break;
                    case 2:
                        {
                            temp = a[mid];
                            a[mid] = a[hi];
                            a[hi] = temp;
                            hi--;
                            break;
                        }
                }
            }
        }

        /* Utility function to print array arr[] */
        static void printArray(int[] arr, int arr_size)
        {
            int i;

            for (i = 0; i < arr_size; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("");
        }

        /*Driver function to check for above functions*/
        public static void Main()
        {
            int[] arr = { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            int arr_size = arr.Length;
            sort012(arr, arr_size);

            Console.Write("Array after seggregation ");

            printArray(arr, arr_size);
            //meth 2
            arr = new int[12] { 0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            int n = arr.Length;

            sortArr(arr, n);

            Console.WriteLine(maxConsecutiveOnes(14));
            Console.Write(maxConsecutiveOnes(222));
        }
        /*
         Output:
array after segregation
 0 0 0 0 0 1 1 1 1 1 2 2 
Complexity Analysis:
Time Complexity: O(n).
Only one traversal of the array is needed.
Space Complexity: O(1).
No extra space is required.
The above code performs unnecessary swaps for some inputs which are not really required. It can be modified to reduce some swaps.

Thanks to Ankur Roy for suggesting this optimization.
        
         Method 2

Approach: Count the number of 0s, 1s and 2s in the given array. Then store all the 0s in the beginning followed by all the 1s then all the 2s.
Algorithm:
Keep three counter c0 to count 0s, c1 to count 1s and c2 to count 2s
Traverse through the array and increase the count of c0 is the element is 0,increase the count of c1 is the element is 1 and increase the count of c2 is the element is 2
Now again traverse the array and replace first c0 elements with 0, next c1 elements with 1 and next c2 elements with 2.
        */

        // Utility function to print the contents of an array 
        static void printArr(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }

        // Function to sort the array of 0s, 1s and 2s 
        static void sortArr(int[] arr, int n)
        {
            int i, cnt0 = 0, cnt1 = 0, cnt2 = 0;

            // Count the number of 0s, 1s and 2s in the array 
            for (i = 0; i < n; i++)
            {
                switch (arr[i])
                {
                    case 0:
                        cnt0++;
                        break;
                    case 1:
                        cnt1++;
                        break;
                    case 2:
                        cnt2++;
                        break;
                }
            }

            // Update the array 
            i = 0;

            // Store all the 0s in the beginning 
            while (cnt0 > 0)
            {
                arr[i++] = 0;
                cnt0--;
            }

            // Then all the 1s 
            while (cnt1 > 0)
            {
                arr[i++] = 1;
                cnt1--;
            }

            // Finally all the 2s 
            while (cnt2 > 0)
            {
                arr[i++] = 2;
                cnt2--;
            }

            // Print the sorted array 
            printArr(arr, n);
        }
        /*
         Output:
0 0 0 0 0 1 1 1 1 1 2 2
Complexity Analysis:
Time Complexity: O(n).
Only two traversals of the array is needed.
Space Complexity: O(1).
As no extra space is required.
        
-->Method 3 simple counting
Sort an array of 0s, 1s and 2s (Simple Counting)
Difficulty Level : Basic
 Last Updated : 08 Sep, 2020
Given an array A[] consisting 0s, 1s and 2s, write a function that sorts A[]. The functions should put all 0s first, then all 1s and all 2s in last.
Examples: 
 

Input :  {0, 1, 2, 0, 1, 2}
Output : {0, 0, 1, 1, 2, 2}

Input :  {0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1}
Output : {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2}


 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Count the number of 0’s, 1’s and 2’s. After Counting, put all 0’s first, then 1’s and lastly 2’s in the array. We traverse the array two times. Time complexity will be O(n).
         */


        public static void sort012_Simplecount(int[] arr, int n)
        {
            // Variables to maintain
            // the count of 0's, 
            // 1's and 2's in the array
            int count0 = 0, count1 = 0;
            int count2 = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == 0)
                    count0++;
                if (arr[i] == 1)
                    count1++;
                if (arr[i] == 2)
                    count2++;
            }

            // Putting the 0's in the
            // array in starting.
            for (int i = 0; i < count0; i++)
                arr[i] = 0;

            // Putting the 1's in the
            // array after the 0's.
            for (int i = count0; i <
                (count0 + count1); i++)
                arr[i] = 1;

            // Putting the 2's in the
            // array after the 1's
            for (int i = (count0 + count1);
                i < n; i++)
                arr[i] = 2;

            printArray(arr, n);
        }
        /*
         Length of the Longest Consecutive 1s in Binary Representation
Difficulty Level : Medium
 Last Updated : 09 Nov, 2020
Given a number n, find length of the longest consecutive 1s in its binary representation.

Examples :

Input : n = 14
Output : 3
The binary representation of 14 is 1110.

Input : n = 222
Output : 4
The binary representation of 222 is 11011110.
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
Naive Approach: One simple way would be to simply loop over the bits, and keep track of the number of consecutive set bits, and the maximum that this value has reached. In this approach, we need to convert it to binary (base-2) representation and then find and print the result.

Using Bit Magic: The idea is based on the concept that if we AND a bit sequence with a shifted version of itself, we’re effectively removing the trailing 1 from every sequence of consecutive 1s.

      11101111   (x)
    & 11011110   (x << 1)
    ----------
      11001110   (x & (x << 1)) 
        ^    ^
        |    |
   trailing 1 removed
So the operation x = (x & (x << 1)) reduces length of every sequence of 1s by one in binary representation of x. If we keep doing this operation in a loop, we end up with x = 0. The number of iterations required to reach 0 is actually length of the longest consecutive sequence of 1s.
        */
        // Function to find length of the  
        // longest consecutive 1s in binary 
        // reprsentation of a number hashedin  
        private static int maxConsecutiveOnes(int x)
        {

            // Initialize result 
            int count = 0;

            // Count the number of iterations 
            // to reach x = 0. 
            while (x != 0)
            {

                // This operation reduces length 
                // of every sequence of 1s by one. 
                x = (x & (x << 1));

                count++;
            }

            return count;
        }
    }
}
