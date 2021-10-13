using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 https://www.geeksforgeeks.org/leftmost-and-rightmost-indices-of-the-maximum-and-the-minimum-element-of-an-array/
Leftmost and rightmost indices of the maximum and the minimum element of an array
Difficulty Level : Medium
Last Updated : 02 Jun, 2021
Given an array arr[], the task is to find the leftmost and the rightmost indices of the minimum and the maximum element from the array where arr[] consists of non-distinct elements.
Examples: 
 

Input: arr[] = {2, 1, 1, 2, 1, 5, 6, 5} 
Output: Minimum left : 1 
Minimum right : 4 
Maximum left : 6 
Maximum right : 6 
Minimum element is 1 which is present at indices 1, 2 and 4. 
Maximum element is 6 which is present only at index 6.
Input: arr[] = {0, 1, 0, 2, 7, 5, 6, 7} 
Output: Minimum left : 0 
Minimum right : 2 
Maximum left : 4 
Maximum right : 7 
 */
namespace ConsoleApp1
{
    /*
     Method 1: When the array is unsorted. 
 

Initialize the variable leftMin = rightMin = leftMax = rightMax = arr[0] and min = max = arr[0].
Start traversing the array from 1 to n – 1. 
If arr[i] < min then a new minimum is found. Update leftMin = rightMin = i.
Else arr[i] = min then another copy of the current minimum is found. Update the rightMin = i.
If arr[i] > max then a new maximum is found. Update leftMax = rightMax = i.
Else arr[i] = max then another copy of the current maximum is found. Update the rightMax = i.
Below is the implementation of the above approach:
    */
    public class LeftmostRightmostUnsorted
    {

        static void findIndices(int[] arr, int n)
        {
            int leftMin = 0, rightMin = 0;
            int leftMax = 0, rightMax = 0;

            int min = arr[0], max = arr[0];
            for (int i = 1; i < n; i++)
            {

                // If found new minimum
                if (arr[i] < min)
                {
                    leftMin = rightMin = i;
                    min = arr[i];
                }

                // If arr[i] = min then rightmost index
                // for min will change
                else if (arr[i] == min)
                    rightMin = i;

                // If found new maximum
                if (arr[i] > max)
                {
                    leftMax = rightMax = i;
                    max = arr[i];
                }

                // If arr[i] = max then rightmost index
                // for max will change
                else if (arr[i] == max)
                    rightMax = i;
            }

            Console.WriteLine("Minimum left : " + leftMin);
            Console.WriteLine("Minimum right : " + rightMin);
            Console.WriteLine("Maximum left : " + leftMax);
            Console.WriteLine("Maximum right : " + rightMax);
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 2, 1, 1, 2, 1, 5, 6, 5 };
            int n = arr.Length;
            findIndices(arr, n);
            /*
             Output: 
Minimum left : 1
Minimum right : 4
Maximum left : 6
Maximum right : 6
            */
        }
    }
    /*
     Method 2: When the array is sorted. 
 

When the array is sorted then leftMin = 0 and rightMax = n – 1.
In order to find the rightMin, apply a modified binary search: 
Set i = 1.
While arr[i] = min update rightMin = i and i = i * 2.
Finally do a linear search for the rest of the elements from rightMin + 1 to n – 1 while arr[i] = min.
Return rightMin in the end.
Similarly, for leftMax repeat the above steps but in reverse i.e. from n – 1 and update i = i / 2 after every iteration.
Below is the implementation of the above approach:
    */
    class LeftmostRightmostSorted
    {

        // Function to return the index of the rightmost
        // minimum element from the array
        public static int getRightMin(int[] arr, int n)
        {

            // First element is the minimum in a sorted array
            int min = arr[0];
            int rightMin = 0;
            int i = 1;
            while (i < n)
            {

                // While the elements are equal to the minimum
                // update rightMin
                if (arr[i] == min)
                    rightMin = i;

                i *= 2;
            }

            i = rightMin + 1;

            // Final check whether there are any elements
            // which are equal to the minimum
            while (i < n && arr[i] == min)
            {
                rightMin = i;
                i++;
            }

            return rightMin;
        }

        // Function to return the index of the leftmost
        // maximum element from the array
        public static int getLeftMax(int[] arr, int n)
        {

            // Last element is the maximum in a sorted array
            int max = arr[n - 1];
            int leftMax = n - 1;
            int i = n - 2;
            while (i > 0)
            {

                // While the elements are equal to the maximum
                // update leftMax
                if (arr[i] == max)
                    leftMax = i;

                i /= 2;
            }

            i = leftMax - 1;

            // Final check whether there are any elements
            // which are equal to the maximum
            while (i >= 0 && arr[i] == max)
            {
                leftMax = i;
                i--;
            }

            return leftMax;
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 0, 0, 1, 2, 5, 5, 6, 8, 8 };
            int n = arr.Length;

            // First element is the leftmost minimum in a sorted array
            Console.WriteLine("Minimum left : " + 0);
            Console.WriteLine("Minimum right : " + getRightMin(arr, n));
            Console.WriteLine("Maximum left : " + getLeftMax(arr, n));

            // Last element is the rightmost maximum in a sorted array
            Console.WriteLine("Maximum right : " + (n - 1));
            /*
             Output: 
Minimum left : 0
Minimum right : 1
Maximum left : 7
Maximum right : 8
            */
        }
    }
    /*
    https://www.geeksforgeeks.org/repeated-character-whose-first-appearance-is-leftmost/ 
Repeated Character Whose First Appearance is Leftmost
Difficulty Level : Easy
Last Updated : 03 Jun, 2021
Given a string, find the repeated character present first in the string.
Examples: 
Input  : geeksforgeeks
Output : g
(mind that it will be g, not e.)

Input  : abcdabcd
Output : a

Input  : abcd
Output : -1
No character repeats
Asked in: Goldman Sachs internship
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
We have discussed different approaches in Find repeated character present first in a string. 
How to solve this problem using one traversal of input string? 
Method 1 (Traversing from Left to Right) We traverse the string from left to right. We keep track of the leftmost index of every character. 
    If a character repeats, we compare its leftmsot index with current result and update the result if result is greater 
    */
    public class LeftMostAppearance
    {

        static int NO_OF_CHARS = 256;

        /* The function returns index of the first
        repeating character in a string. If
        all characters are repeating then
        returns -1 */
        static int firstRepeating(char[] str)
        {
            // Initialize leftmost index of every
            // character as -1.
            int[] firstIndex = new int[NO_OF_CHARS];
            for (int i = 0; i < NO_OF_CHARS; i++)
            {
                firstIndex[i] = -1;
            }

            // Traverse from left and update result
            // if we see a repeating character whose
            // first index is smaller than current
            // result.
            int res = int.MaxValue;
            for (int i = 0; i < str.Length; i++)
            {
                if (firstIndex[str[i]] == -1)
                {
                    firstIndex[str[i]] = i;
                }
                else
                {
                    res = Math.Min(res, firstIndex[str[i]]);
                }
            }

            return (res == int.MaxValue) ? -1 : res;
        }

        /* Method 2 (Traversing Right to Left) We traverse the string from right to left. We keep track of the visited characters. If a character repeats, we update the result. 
         The method 2 is better than method 1 as it does fewer comparisons.
        The function returns index of the first
        repeating character in a string. If
        all characters are repeating then
        returns -1 */
        static int firstRepeating(String str)
        {
            // Mark all characters as not visited
            Boolean[] visited = new Boolean[NO_OF_CHARS];
            for (int i = 0; i < NO_OF_CHARS; i++)
                visited[i] = false;

            // Traverse from right and update res as soon
            // as we see a visited character.
            int res = -1;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (visited[str[i]] == false)
                    visited[str[i]] = true;
                else
                    res = i;
            }

            return res;
        }

        /* Driver code */
        public static void Main(String[] args)
        {
            char[] str = "geeksforgeeks".ToCharArray();
            int index = firstRepeating(str);
            if (index == -1)
            {
                Console.Write("Either all characters are "
                        + "distinct or string is empty");
            }
            else
            {
                Console.Write("First Repeating character"
                        + " is {0}", str[index]);
            }
        }
    }
    /*
     https://www.geeksforgeeks.org/leftmost-column-with-atleast-one-1-in-a-row-wise-sorted-binary-matrix-set-2/
    Leftmost Column with atleast one 1 in a row-wise sorted binary matrix | Set 2
Difficulty Level : Expert
Last Updated : 15 Jun, 2021
Given a binary matrix mat[][] containing 0’s and 1’s. Each row of the matrix is sorted in the non-decreasing order, the task is to find the left-most column of the matrix with at least one 1 in it.
Note: If no such column exists return -1. 
Examples: 
 

Input: 
mat[][] = {{0, 0, 0, 1}
           {0, 1, 1, 1}
           {0, 0, 1, 1}}
Output: 2
Explanation:
The 2nd column of the
matrix contains atleast a 1.

Input: 
mat[][] = {{0, 0, 0}
           {0, 1, 1}  
           {1, 1, 1}}
Output: 1
Explanation:
The 1st column of the
matrix contains atleast a 1.

Input: 
mat[][] = {{0, 0}
           {0, 0}}
Output: -1
Explanation:
There is no such column which 
contains atleast one 1.
 


Here we start our traversal from the last element of the first row. This includes two steps. 
If the current iterating element is 1, we decrement the column index. As we find the leftmost column index with value 1, so we don’t have to check elements with greater column index. 
If the current iterating element is 0, we increment row index. As that element is 0, we don’t need to check previous elements of that row. 
We continue until one of the row or column index become invalid. 
 
Below is the implementation of the above approach. 
     */
    public class LeftmostOne
    {

        static readonly int N = 3;
        static readonly int M = 4;

        // Function return leftmost
        // column having at least a 1
        static int FindColumn(int[,] mat)
        {
            int row = 0, col = M - 1;
            int flag = 0;

            while (row < N && col >= 0)
            {

                // If current element is
                // 1 decrement column by 1
                if (mat[row, col] == 1)
                {
                    col--;
                    flag = 1;
                }

                // If current element is
                // 0 increment row by 1
                else
                {
                    row++;
                }
            }
            col++;

            if (flag != 0)
                return col + 1;
            else
                return -1;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[,] mat = { { 0, 0, 0, 1 },
                   { 0, 1, 1, 1 },
                   { 0, 0, 1, 1 } };

            Console.Write(FindColumn(mat));
            /*
             Output: 2

Time Complexity: O(N + M). where N is number of row and M is number of column. 
Space Complexity: O(1)
            */
        }
    }
}
