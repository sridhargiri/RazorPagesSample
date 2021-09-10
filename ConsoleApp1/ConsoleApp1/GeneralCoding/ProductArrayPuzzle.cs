using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/a-product-array-puzzle/
    A Product Array Puzzle
Difficulty Level : Medium
Last Updated : 23 Apr, 2021
Given an array arr[] of n integers, construct a Product Array prod[] (of same size) such that prod[i] is equal to the product of all the elements of arr[] except arr[i]. Solve it without division operator in O(n) time.
Example : 

Input: arr[]  = {10, 3, 5, 6, 2}
Output: prod[]  = {180, 600, 360, 300, 900}
3 * 5 * 6 * 2 product of other array 
elements except 10 is 180
10 * 5 * 6 * 2 product of other array 
elements except 3 is 600
10 * 3 * 6 * 2 product of other array 
elements except 5 is 360
10 * 3 * 5 * 2 product of other array 
elements except 6 is 300
10 * 3 * 6 * 5 product of other array 
elements except 2 is 900


Input: arr[]  = {1, 2, 3, 4, 5}
Output: prod[]  = {120, 60, 40, 30, 24 }
2 * 3 * 4 * 5  product of other array 
elements except 1 is 120
1 * 3 * 4 * 5  product of other array 
elements except 2 is 60
1 * 2 * 4 * 5  product of other array 
elements except 3 is 40
1 * 2 * 3 * 5  product of other array 
elements except 4 is 30
1 * 2 * 3 * 4  product of other array 
elements except 5 is 24
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution.
Naive Solution:
Approach: Create two extra space, i.e. two extra arrays to store the product of all the array elements from start, up to that index and another array to store the product of all the array elements from the end of the array to that index. 
To get the product excluding that index, multiply the prefix product up to index i-1 with the suffix product up to index i+1.
Algorithm: 

Create two array prefix and suffix of length n, i.e length of the original array, initilize prefix[0] = 1 and suffix[n-1] = 1 and also another array to store the product.
Traverse the array from second index to end.
For every index i update prefix[i] as prefix[i] = prefix[i-1] * array[i-1], i.e store the product upto i-1 index from the start of array.
Traverse the array from second last index to start.
For every index i update suffix[i] as suffix[i] = suffix[i+1] * array[i+1], i.e store the product upto i+1 index from the end of array
Traverse the array from start to end.
For every index i the output will be prefix[i] * suffix[i], the product of the array element except that element.
    */
    class ProductArrayPuzzle
    {

        /* Function to print product array
        for a given array arr[] of size n */
        static void productArray(int[] arr, int n)
        {

            // Base case
            if (n == 1)
            {
                Console.Write(0);
                return;
            }
            // Initialize memory to all arrays
            int[] left = new int[n];
            int[] right = new int[n];
            int[] prod = new int[n];

            int i, j;

            /* Left most element of left array
            is always 1 */
            left[0] = 1;

            /* Rightmost most element of right
            array is always 1 */
            right[n - 1] = 1;

            /* Construct the left array */
            for (i = 1; i < n; i++)
                left[i] = arr[i - 1] * left[i - 1];

            /* Construct the right array */
            for (j = n - 2; j >= 0; j--)
                right[j] = arr[j + 1] * right[j + 1];

            /* Construct the product array using
            left[] and right[] */
            for (i = 0; i < n; i++)
                prod[i] = left[i] * right[i];

            /* print the constructed prod array */
            for (i = 0; i < n; i++)
                Console.Write(prod[i] + " ");

            return;
        }

        /* Driver program to test the above function */
        public static void Main()
        {
            int[] arr = { 10, 3, 5, 6, 2 };
            int n = arr.Length;
            Console.Write("The product array is :\n");

            productArray(arr, n);
            /*
             Output
The product array is: 

180 600 360 300 900 
            */
        }
    }
    /*
     Note: The above method can be optimized to work in space complexity O(1). Thanks to Dileep for suggesting the below solution.
Efficient solution:
Approach: In the previous solution, two extra arrays were created to store the prefix and suffix, in this solution store the prefix and suffix product in the output array (or product array) itself. Thus reducing the space required.
Algorithm: 



Create an array product and initialize its value to 1 and a variable temp = 1.
Traverse the array from start to end.
For every index i update product[i] as product[i] = temp and temp = temp * array[i], i.e store the product upto i-1 index from the start of array.
initialize temp = 1 and traverse the array from last index to start.
For every index i update product[i] as product[i] = product[i] * temp and temp = temp * array[i], i.e multiply with the product upto i+1 index from the end of array.
Print the product array.
    */
    public class ProductArrayPuzzle1
    {

        static void productArray(int[] arr, int n)
        {

            // Base case
            if (n == 1)
            {
                Console.Write(0);
                return;
            }
            int i, temp = 1;

            /* Allocate memory for the product
            array */
            int[] prod = new int[n];

            /* Initialize the product array as 1 */
            for (int j = 0; j < n; j++)
                prod[j] = 1;

            /* In this loop, temp variable contains
            product of elements on left side
            excluding arr[i] */
            for (i = 0; i < n; i++)
            {
                prod[i] = temp;
                temp *= arr[i];
            }

            /* Initialize temp to 1 for product on
            right side */
            temp = 1;

            /* In this loop, temp variable contains
            product of elements on right side
            excluding arr[i] */
            for (i = n - 1; i >= 0; i--)
            {
                prod[i] *= temp;
                temp *= arr[i];
            }

            /* print the constructed prod array */
            for (i = 0; i < n; i++)
                Console.Write(prod[i] + " ");

            return;
        }

        /* Driver program to test above functions */
        public static void Main()
        {
            int[] arr = { 10, 3, 5, 6, 2 };
            int n = arr.Length;
            Console.WriteLine("The product array is : ");

            productArray(arr, n);
            /*
             Output
The product array is: 
180 600 360 300 900 
Complexity Analysis: 

Time Complexity: O(n). 
The original array needs to be traversed only once, so the time complexity is constant.
Space Complexity: O(n). 
Even though the extra arrays are removed, the space complexity remains O(n), as the product array is still needed.
            */
        }
        /*
         Another Approach:

Store the product of all the elements is a variable and then iterate the array and add product/current_index_value in a new array. and then return this new array.

Below is the implementation of the above approach:
        */
        public class ProductArrayPuzzle2
        {
            static long[] productExceptSelf(int[] a, int n)
            {
                long prod = 1;
                long flag = 0;

                // product of all elements
                for (int i = 0; i < n; i++)
                {

                    // counting number of elements
                    // which have value
                    // 0
                    if (a[i] == 0)
                        flag++;
                    else
                        prod *= a[i];
                }

                // creating a new array of size n
                long[] arr = new long[n];

                for (int i = 0; i < n; i++)
                {

                    // if number of elements in
                    // array with value 0
                    // is more than 1 than each
                    // value in new array
                    // will be equal to 0
                    if (flag > 1)
                    {
                        arr[i] = 0;
                    }

                    // if no element having value
                    // 0 than we will
                    // insert product/a[i] in new array
                    else if (flag == 0)
                        arr[i] = (prod / a[i]);

                    // if 1 element of array having
                    // value 0 than all
                    // the elements except that index
                    // value , will be
                    // equal to 0
                    else if (flag == 1 && a[i] != 0)
                    {
                        arr[i] = 0;
                    }

                    // if(flag == 1 && a[i] == 0)
                    else
                        arr[i] = prod;
                }
                return arr;
            }
            public static void Main(string[] args)
            {
                int n = 5;
                int[] array = { 10, 3, 5, 6, 2 };
                var ans = productExceptSelf(array, n);
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(ans[i] + " ");
                }
                /*
                 Output
180 600 360 300 900 
Time Complexity : O(n)

The original array needs to be traversed only once, so the time complexity is constant.
                */
            }
        }
    }
    /*
     https://www.geeksforgeeks.org/product-of-middle-row-and-column-in-an-odd-square-matrix/
    Product of middle row and column in an odd square matrix
Last Updated : 25 May, 2021
Given an integer square matrix of odd dimensions (3 * 3, 5 * 5). The task is to find the product of the middle row & middle column elements.

Examples:  

Input: mat[][] = 
{{2, 1, 7},
 {3, 7, 2},
 {5, 4, 9}}
Output: Product of middle row = 42
        Product of middle column = 28
Explanation: Product of Middle row elements (3*7*2)
Product of Middle Column elements (1*7*4)

Input: mat[][] =
{ {1, 3, 5, 6, 7},
  {3, 5, 3, 2, 1},
  {1, 2, 3, 4, 5},
  {7, 9, 2, 1, 6},
  {9, 1, 5, 3, 2}}
Output: Product of middle row = 120
        Product of middle column = 450 
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: As the given matrix is of odd dimensions, so the middle row and column will be always at the n/2th. So, Run a loop from i = 0 to N and produce all the elements of the middle row i.e. row_prod *= mat[n / 2][i]. Similarly, the product of elements of the middle column will be col_prod *= mat[i][n / 2].

Below is the implementation of the above approach:  
     */
    public class ProductMiddle
    {
        //static int MAX = 100;

        static void middleProduct(int[,] mat, int n)
        {

            // loop for product of row and column
            int row_prod = 1, col_prod = 1;
            for (int i = 0; i < n; i++)
            {
                row_prod *= mat[n / 2, i];
                col_prod *= mat[i, n / 2];
            }

            // Print result
            Console.WriteLine("Product of middle row = "
                + row_prod);

            Console.WriteLine("Product of middle column = "
                + col_prod);
        }

        // Driver code
        public static void Main()
        {
            int[,] mat = { { 2, 1, 7 },
                    { 3, 7, 2 },
                    { 5, 4, 9 } };

            middleProduct(mat, 3);
            /*
             Output: 
Product of middle row = 42
Product of middle column = 28
 

Time Complexity: O(n)
 
             */
        }
    }
}
