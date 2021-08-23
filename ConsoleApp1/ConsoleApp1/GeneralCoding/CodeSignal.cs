using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     codesignal
    */
    public class CodeSignal
    {
    }
    /*
     https://www.geeksforgeeks.org/sum-of-array-elements-after-reversing-each-element/
    Sum of array elements after reversing each element
Difficulty Level : Easy
Last Updated : 09 Apr, 2021
Given an array arr[] consisting of N positive integers, the task is to find the sum of all array elements after reversing digits of every array element.

Examples:

Input: arr[] = {7, 234, 58100}
Output: 18939
Explanation:
Modified array after reversing each array elements = {7, 432, 18500}.
Therefore, the sum of the modified array = 7 + 432 + 18500 = 18939.

Input: arr[] = {0, 100, 220}
Output: 320
Explanation:
Modified array after reversing each array elements = {0, 100, 220}.
Therefore, the sum of the modified array = 0 + 100 + 220 = 320.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The idea is to reverse each number of the given array as per the given conditions and find sum of all array elements formed after reversing. Below steps to solve the problem:



Initialize a variable, say sum, to store the required sum.
Initialize variable count as 0 and f as false to store count of ending 0s of arr[i] and flag to avoid all non-ending 0.
Initialize rev as 0 to store reversal of each array element.
Traverse the given array and for each array element do the following operation:
Increment count and divide arr[i] by 10 until all the zeros at the end are traversed.
Reset f with true that means all ending 0 digits have been considered.
Now, reverse arr[i] by updating rev = rev*10 + arr[i] % 10 and  arr[i] = arr[i]/10.
After traversing each digit of arr[i], update rev = rev * Math.pow(10, count) to add all ending 0’s to the end of reversed number.
For each reverse number in the above step, add that value to the resultant sum.
Below is the implementation of the above approach:
     */
    public class ReverseSum
    {

        // Function to find the sum of elements
        // after reversing each element in arr[]
        static void totalSum(int[] arr)
        {

            // Stores the final sum
            int sum = 0;

            // Traverse the given array
            for (int i = 0; i < arr.Length; i++)
            {

                // Stores count of ending 0s
                int count = 0;

                int rev = 0, num = arr[i];

                // Flag to avoid count of 0s
                // that doesn't ends with 0s
                bool f = false;

                while (num > 0)
                {

                    // Count of ending 0s
                    while (num > 0 && !f &&
                           num % 10 == 0)
                    {
                        count++;
                        num = num / 10;
                    }

                    // Update flag with true
                    f = true;

                    // Reversing the num
                    if (num > 0)
                    {
                        rev = rev * 10 +
                              num % 10;

                        num = num / 10;
                    }
                }

                // Add all ending 0s to
                // end of rev
                if (count > 0)
                    rev = rev * (int)Math.Pow(10, count);

                // Update sum
                sum = sum + rev;
            }

            // Print total sum
            Console.Write(sum);
        }

        // Driver Code
        static public void Main()
        {

            // Given arr[]
            int[] arr = { 7, 234, 58100 };

            // Function call
            totalSum(arr);
            /*
             Output: 18939

Time Complexity: O(N*log10M), where N denotes the length of the array and M denotes maximum array element. 
Auxiliary Space: O(1)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/find-the-sum-of-digits-of-a-number-at-even-and-odd-places/
    Find the sum of digits of a number at even and odd places
Difficulty Level : Easy
Last Updated : 22 Jun, 2021
Given a number N, the task is to find the sum of digits of a number at even and odd places.

Examples: 

Input: N = 54873 
Output: 
Sum odd = 16 
Sum even = 11

Input: N = 457892 
Output: 
Sum odd = 20 
Sum even = 15  

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach:  



First, calculate the reverse of the given number.
To the reverse number we apply modulus operator and extract its last digit which is actually the first digit of a number so it is odd positioned digit.
The next digit will be even positioned digit, and we can take the sum in alternating turns.
Below is the implementation of the above approach:
     */
    public class OddEvenSum
    {

        // Function to return the reverse of a number
        static int reverse(int n)
        {
            int rev = 0;
            while (n != 0)
            {
                rev = (rev * 10) + (n % 10);
                n /= 10;
            }
            return rev;
        }

        // Function to find the sum of the odd
        // and even positioned digits in a number
        static void getSum(int n)
        {
            n = reverse(n);
            int sumOdd = 0, sumEven = 0, c = 1;

            while (n != 0)
            {

                // If c is even number then it means
                // digit extracted is at even place
                if (c % 2 == 0)
                    sumEven += n % 10;
                else
                    sumOdd += n % 10;
                n /= 10;
                c++;
            }

            Console.WriteLine("Sum odd = " + sumOdd);
            Console.WriteLine("Sum even = " + sumEven);
        }

        // Driver code
        public static void Main()
        {
            int n = 457892;
            getSum(n);
            /*
             Output: 
Sum odd = 20
Sum even = 15
            */
        }
    }

    /*
     https://www.geeksforgeeks.org/sorting-boundary-elements-of-a-matrix/
    Sorting boundary elements of a matrix
Difficulty Level : Expert
Last Updated : 10 Jun, 2021
Given a matrix mat[][] of size M*N, the task is to sort only the border elements of the matrix in the clockwise direction and print the matrix after sorting again.

Examples: 
 

Input: M = 4, N = 5, Below is the given matrix: 

1 2 3 4 0 
1 1 1 1 2  
1 2 2 2 4 
1 9 3 1 7
Output: 
0 1 1 1 1 
9 1 1 1 1 
7 2 2 2 2 
4 4 3 3 2 
Explanation: 
For given matrix, border elements are: 
(1, 2, 3, 4, 0, 2, 4, 7, 1, 3, 9, 1, 1, 1) 
After sorting in clockwise order: 
(0, 1, 1, 1, 1, 1, 2, 2, 3, 3, 4, 4, 7, 9)

Input: M = 3, N = 4 



4 2 8 0 
2 6 9 8 
0 3 1 7
Output: 
0 0 1 2 
8 6 9 2 
8 7 4 3 
Explanation: 
For given matrix, border elements are: 
(4, 2, 8, 0, 8, 7, 1, 3, 0, 2) 
After sorting in clockwise order: 
(0, 0, 1, 2, 2, 3, 4, 7, 8, 8) 
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The idea is to store all border elements of the given matrix in an array and sort this array then simply print the new matrix using this sorted array as the border elements.

Detailed steps are as follows:  

Traverse the given matrix and push all the boundary elements to an array A[].
Sort array A[] in ascending order.
Print first row using first N elements of array A[].
From second row to second-last row, first print a single element from end of A[], then print N-2 middle elements from original matrix and finally a single element from the front of A[].
For last row, print middle elements from A[] which are still not printed, in reverse order.
Below is the implementation of the above approach: 
     */
    public class SortBoundary
    { }

}
