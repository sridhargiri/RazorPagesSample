using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ArrayElemntsConsecutive
    {
        /* The function checks if the array elements 
    are consecutive If elements are consecutive, 
    then returns true, else returns    false */
        static bool areConsecutive(int[] arr, int n)
        {
            if (n < 1)
                return false;

            /* 1) Get the minimum element in array */
            int min = getMin(arr, n);

            /* 2) Get the maximum element in array */
            int max = getMax(arr, n);

            /* 3) max - min + 1 is equal to n, then  
            only check all elements */
            if (max - min + 1 == n)
            {

                /* Create a temp array to hold visited 
                flag of all elements. Note that, calloc 
                is used here so that all values are 
                initialized as false */
                bool[] visited = new bool[n];
                int i;

                for (i = 0; i < n; i++)
                {

                    /* If we see an element again, then 
                    return false */
                    if (visited[max-arr[i]] != false)
                        return false;

                    /* If visited first time, then mark  
                    the element as visited */
                    visited[max - arr[i]] = true;
                }

                /* If all elements occur once, then 
                return true */
                return true;
            }
            return false; // if (max - min + 1 != n) 
        }

        /* UTILITY FUNCTIONS */
        static int getMin(int[] arr, int n)
        {
            int min = arr[0];

            for (int i = 1; i < n; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }

            return min;
        }

        static int getMax(int[] arr, int n)
        {
            int max = arr[0];

            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            return max;
        }

        /* Driver program to test above functions */
        public static void Main()
        {
            int[] arr = { 5, 4, 2, 3, 1, 6 };
            int n = arr.Length;

            if (areConsecutive(arr, n) == true)
                Console.WriteLine("Array elements are"
                                  + " consecutive");
            else
                Console.WriteLine("Array elements are"
                             + " not consecutive");
        }
    }

    // This code is contributed by nitin mittal. 

}
