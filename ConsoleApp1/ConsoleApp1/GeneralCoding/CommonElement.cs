using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-common-elements-three-sorted-arrays/
    Find common elements in three sorted arrays
Difficulty Level : Easy
Last Updated : 16 Aug, 2021
Given three arrays sorted in non-decreasing order, print all common elements in these arrays.

Examples: 
Input: 
ar1[] = {1, 5, 10, 20, 40, 80} 
ar2[] = {6, 7, 20, 80, 100} 
ar3[] = {3, 4, 15, 20, 30, 70, 80, 120} 
Output: 20, 80



Input: 
ar1[] = {1, 5, 5} 
ar2[] = {3, 4, 5, 5, 10} 
ar3[] = {5, 5, 10, 20} 
Output: 5, 5


     */
    public class CommonElement
    {
        /*
         * Method 1
         A simple solution is to first find intersection of two arrays and store the intersection in a temporary array, then find the intersection of third array and temporary array. 
        Time complexity of this solution is O(n1 + n2 + n3) where n1, n2 and n3 are sizes of ar1[], ar2[] and ar3[] respectively.
        The above solution requires extra space and two loops, we can find the common elements using a single loop and without extra space. 
        The idea is similar to intersection of two arrays. Like two arrays loop, we run a loop and traverse three arrays. 
        Let the current element traversed in ar1[] be x, in ar2[] be y and in ar3[] be z. We can have following cases inside the loop. 

        If x, y and z are same, we can simply print any of them as common element and move ahead in all three arrays.
        Else If x < y, we can move ahead in ar1[] as x cannot be a common element.
        Else If x > z and y > z), we can simply move ahead in ar3[] as z cannot be a common element.
        Below image is a dry run of the above approach: 
        */


        // This function prints common element
        // s in ar1
        static void findCommonElements1(int[] ar1, int[] ar2, int[] ar3)
        {

            // Initialize starting indexes for
            // ar1[], ar2[] and ar3[]
            int i = 0, j = 0, k = 0;

            // Iterate through three arrays while
            // all arrays have elements
            while (i < ar1.Length && j < ar2.Length && k < ar3.Length)
            {

                // If x = y and y = z, print any of
                // them and move ahead in all arrays
                if (ar1[i] == ar2[j] && ar2[j] == ar3[k])
                {
                    Console.Write(ar1[i] + " ");
                    i++;
                    j++;
                    k++;
                }

                // x < y
                else if (ar1[i] < ar2[j])
                    i++;

                // y < z
                else if (ar2[j] < ar3[k])
                    j++;

                // We reach here when x > y and
                // z < y, i.e., z is smallest
                else
                    k++;
            }
        }
        /*
         Output
Common Elements are 20 80 
Time complexity of the above solution is O(n1 + n2 + n3). 
        In the worst case, the largest sized array may have all small elements and middle-sized array has all middle elements.
        */

        /*
         Method 2:



The approach used above works well if the arrays does not contain duplicate values however it can fail in cases where the array elements are repeated. This can lead to a single common element to get printed multiple times.

These duplicate entries can be handled without using any additional data structure by keeping the track of the previous element. Since the elements inside the array are arranged in sorted manner there is no possibility for the repeated elements to occur at random positions. 

Let’s consider the current element traversed in ar1[] be x, in ar2[] be y and in ar3[] be z and let the variables prev1, prev2, prev3 for keeping the track of last encountered element in each array and initialize them with INT_MIN. Hence for every element we visit across each array, we check for the following.

If x = prev1, move ahead in ar1[] and repeat the procedure until x != prev1. Similarly, apply the same for the ar2[] and ar3[].
If x, y, and z are same, we can simply print any of them as common element, update prev1, prev2, and prev3 and move ahead in all three arrays.
Else If (x < y), we update prev1 and move ahead in ar1[] as x cannot be a common element.
Else If (y < z), we update prev2 and move ahead in ar2[] as y cannot be a common element.
Else If (x > z and y > z), we update prev3 and we move ahead in ar3[] as z cannot be a common element.
Below is the implementation of the above approach:
        */
        void findCommonElements2(int[] ar1, int[] ar2, int[] ar3)
        {

            int n1 = ar1.Length, n2 = ar2.Length, n3 = ar3.Length;
            int i = 0, j = 0, k = 0;

            // Declare three variables prev1,
            // prev2, prev3 to track
            // previous element
            int prev1, prev2, prev3;

            // Initialize prev1, prev2,
            // prev3 with INT_MIN
            prev1 = prev2 = prev3 = int.MinValue;

            // Iterate through three arrays
            // while all arrays have
            // elements
            while (i < n1 && j < n2 && k < n3)
            {

                // If ar1[i] = prev1 and i < n1,
                // keep incrementing i
                while (ar1[i] == prev1 && i < n1)
                    i++;

                // If ar2[j] = prev2 and j < n2,
                // keep incrementing j
                while (ar2[j] == prev2 && j < n2)
                    j++;

                // If ar3[k] = prev3 and k < n3,
                // keep incrementing k
                while (ar3[k] == prev3 && k < n3)
                    k++;

                // If x = y and y = z, print
                // any of them, update
                // prev1 prev2, prev3 and move
                //ahead in each array
                if (ar1[i] == ar2[j] && ar2[j] == ar3[k])
                {
                    Console.WriteLine(ar1[i]);
                    prev1 = ar1[i];
                    prev2 = ar2[j];
                    prev3 = ar3[k];
                    i++;
                    j++;
                    k++;
                }

                // If x < y, update prev1
                // and increment i
                else if (ar1[i] < ar2[j])
                {
                    prev1 = ar1[i];
                    i++;
                }

                // If y < z, update prev2
                // and increment j
                else if (ar2[j] < ar3[k])
                {
                    prev2 = ar2[j];
                    j++;
                }

                // We reach here when x > y
                // and z < y, i.e., z is
                // smallest update prev3
                // and imcrement k
                else
                {
                    prev3 = ar3[k];
                    k++;
                }
            }
        }
        /*
         Time Complexity for the above approach still remains O(n1 + n2 + n3) and space complexity also remains O(1) and no extra space and data structure is required to handle the duplicate array entries.
        */
        /*
         Method 3:

In this approach, we will first delete the duplicate from each array, and after this, we will find the frequency of each element and the element whose frequency equals 3 will be printed. 
        For finding the frequency we can use a map but in this, we will use an array instead of a map. 
        But the problem with using an array is, we cannot find the frequency of negative numbers so in the code given below we will consider each and every element of array to be positive.
        */
        public static void findCommonElements3(int[] arr1,
                                      int[] arr2,
                                      int[] arr3)
        {
            int n1 = arr1.Length, n2 = arr2.Length, n3 = arr3.Length;

            // creating a max variable
            // for storing the maximum
            // value present in the all
            // the three array
            // this will be the size of
            // array for calculating the
            // frequency of each element
            // present in all the array
            int max = int.MinValue;

            // deleting duplicates in linear time
            // for arr1
            int res1 = 1;
            for (int i = 1; i < n1; i++)
            {
                max = Math.Max(arr1[i], max);
                if (arr1[i] != arr1[res1 - 1])
                {
                    arr1[res1] = arr1[i];
                    res1++;
                }
            }

            // deleting duplicates in linear time
            // for arr2
            int res2 = 1;
            for (int i = 1; i < n2; i++)
            {
                max = Math.Max(arr2[i], max);
                if (arr2[i] != arr2[res2 - 1])
                {
                    arr2[res2] = arr2[i];
                    res2++;
                }
            }

            // deleting duplicates in linear time
            // for arr3
            int res3 = 1;
            for (int i = 1; i < n3; i++)
            {
                max = Math.Max(arr3[i], max);
                if (arr3[i] != arr3[res3 - 1])
                {
                    arr3[res3] = arr3[i];
                    res3++;
                }
            }

            // creating an array for finding frequency
            int[] freq = new int[max + 1];

            // calculating the frequency of
            // all the elements present in
            // all the array
            for (int i = 0; i < res1; i++)
                freq[arr1[i]]++;
            for (int i = 0; i < res2; i++)
                freq[arr2[i]]++;
            for (int i = 0; i < res3; i++)
                freq[arr3[i]]++;

            // iterating till max and
            // whenever the frequency of element
            // will be three we print that element
            for (int i = 0; i <= max; i++)
                if (freq[i] == 3)
                    Console.WriteLine(i + " ");
        }
        public static void Main(string[] args)
        {

            int[] arr1 = { 1, 5, 10, 20, 40, 80 };
            int[] arr2 = { 6, 7, 20, 80, 100 };
            int[] arr3 = { 3, 4, 15, 20, 30, 70, 80, 120 };

            findCommonElements3(arr1, arr2, arr3);
            //Output-20 80
        }
    }
}
