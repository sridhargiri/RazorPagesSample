using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.GeneralCoding
{
    /*
     Union and Intersection of two sorted arrays
    Given two sorted arrays, find their union and intersection.
Example:

Input : arr1[] = {1, 3, 4, 5, 7}
        arr2[] = {2, 3, 5, 6} 
Output : Union : {1, 2, 3, 4, 5, 6, 7} 
         Intersection : {3, 5}

Input : arr1[] = {2, 5, 6}
        arr2[] = {4, 6, 8, 10} 
Output : Union : {2, 4, 5, 6, 8, 10} 
         Intersection : {6}
    To find union of two sorted arrays, follow the following merge procedure : 
 

1) Use two index variables i and j, initial values i = 0, j = 0 
2) If arr1[i] is smaller than arr2[j] then print arr1[i] and increment i. 
3) If arr1[i] is greater than arr2[j] then print arr2[j] and increment j. 
4) If both are same then print any of them and increment both i and j. 
5) Print remaining elements of the larger array.
    
     */
    class UnionIntersection
    {
        /* Function prints union of arr1[] and arr2[] 
        m is the number of elements in arr1[] 
        n is the number of elements in arr2[] */
        static int printUnion(int[] arr1,
                              int[] arr2, int m, int n)
        {
            int i = 0, j = 0;

            while (i < m && j < n)
            {
                if (arr1[i] < arr2[j])
                    Console.Write(arr1[i++] + " ");
                else if (arr2[j] < arr1[i])
                    Console.Write(arr2[j++] + " ");
                else
                {
                    Console.Write(arr2[j++] + " ");
                    i++;
                }
            }

            /* Print remaining elements of  
            the larger array */
            while (i < m)
                Console.Write(arr1[i++] + " ");
            while (j < n)
                Console.Write(arr2[j++] + " ");

            return 0;
        }
        //below approach will handle duplicates
        static void UnionArray(int[] arr1,
                               int[] arr2)
        {

            // Taking max element present 
            // in either array 
            int m = arr1[arr1.Length - 1];
            int n = arr2[arr2.Length - 1];

            int ans = 0;

            if (m > n)
                ans = m;
            else
                ans = n;

            // Finding elements from 1st array 
            // (non duplicates only). Using 
            // another array for storing union 
            // elements of both arrays 
            // Assuming max element present 
            // in array is not more than 10^7 
            int[] newtable = new int[ans + 1];

            // First element is always 
            // present in final answer 
            Console.Write(arr1[0] + " ");

            // Incrementing the First element's 
            // count in it's corresponding 
            // index in newtable 
            ++newtable[arr1[0]];

            // Starting traversing the first 
            // array from 1st index till last 
            for (int i = 1; i < arr1.Length; i++)
            {
                // Checking whether current 
                // element is not equal to 
                // it's previous element 
                if (arr1[i] != arr1[i - 1])
                {
                    Console.Write(arr1[i] + " ");
                    ++newtable[arr1[i]];
                }
            }

            // Finding only non common 
            // elements from 2nd array 
            for (int j = 0; j < arr2.Length; j++)
            {
                // By checking whether it's already 
                // present in newtable or not 
                if (newtable[arr2[j]] == 0)
                {
                    Console.Write(arr2[j] + " ");
                    ++newtable[arr2[j]];
                }
            }
        }

        /* Function prints Intersection of arr1[] 
        and arr2[] m is the number of elements in arr1[] 
        n is the number of elements in arr2[] */
        static void printIntersection(int[] arr1,
                                      int[] arr2, int m, int n)
        {
            int i = 0, j = 0;

            while (i < m && j < n)
            {
                if (arr1[i] < arr2[j])
                    i++;
                else if (arr2[j] < arr1[i])
                    j++;
                else
                {
                    Console.Write(arr2[j++] + " ");
                    i++;
                }
            }
        }
        public static void Main()
        {
            int[] arr1 = { 1, 2, 4, 5, 6 };
            int[] arr2 = { 2, 3, 5, 7 };
            int m = arr1.Length;
            int n = arr2.Length;
            //output 1 2 3 4 5 6 7 
            printUnion(arr1, arr2, m, n);

            int[] arr3 = { 1, 2, 2, 2, 3 };
            int[] arr4 = { 2, 3, 4, 5 };

            UnionArray(arr3, arr4);
        }
    }
}
