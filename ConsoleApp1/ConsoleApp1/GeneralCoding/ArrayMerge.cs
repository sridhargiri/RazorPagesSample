using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ArrayMerge
    {
        /*
         Merging two unsorted arrays in sorted order

    Write a SortedMerge() function that takes two lists, each of which is unsorted, and merges the two together into one new list which is in sorted (increasing) order. SortedMerge() should return the new list.

    Examples :

    Input : a[] = {10, 5, 15}
            b[] = {20, 3, 2}
    Output : Merge List :
            {2, 3, 5, 10, 15, 20}

    Input : a[] = {1, 10, 5, 15}
            b[] = {20, 0, 2}
    Output : Merge List :
            {0, 1, 2, 5, 10, 15, 20}
        There are many cases to deal with: either ‘a’ or ‘b’ may be empty, during processing either ‘a’ or ‘b’ may run out first, and finally there’s the problem of starting the result list empty, and building it up while going through ‘a’ and ‘b’.

    Method 1 (first Concatenate then Sort)



    In this case, we first append the two unsorted lists. Then we simply sort the concatenated list.
         */
        public static void sortedMerge(int[] a, int[] b,
                                   int[] res, int n,
                                   int m)
        {
            // Concatenate two arrays 
            int i = 0, j = 0, k = 0;
            while (i < n)
            {
                res[k] = a[i];
                i++;
                k++;
            }

            while (j < m)
            {
                res[k] = b[j];
                j++;
                k++;
            }

            // sorting the res array 
            Array.Sort(res);
            /*
             Output :
Sorted merged list : 2 3 5 10 12 15 20
Time Complexity : O ( (n + m) (log(n + m)) )
Auxiliary Space : O ( (n + m) )
            */
        }
        /*
         Method 2 (First Sort then Merge)

We first sort both the given arrays separately. Then we simply merge two sorted arrays.
        */

        static void sortedMerge1(int[] a, int[] b,
                         int[] res, int n, int m)
        {

            // Sorting a[] and b[] 
            Array.Sort(a);
            Array.Sort(b);

            // Merge two sorted arrays into res[] 
            int i = 0, j = 0, k = 0;

            while (i < n && j < m)
            {
                if (a[i] <= b[j])
                {
                    res[k] = a[i];
                    i += 1;
                    k += 1;
                }
                else
                {
                    res[k] = b[j];
                    j += 1;
                    k += 1;
                }
            }

            while (i < n)
            {

                // Merging remaining 
                // elements of a[] (if any) 
                res[k] = a[i];
                i += 1;
                k += 1;
            }
            while (j < m)
            {

                // Merging remaining 
                // elements of b[] (if any) 
                res[k] = b[j];
                j += 1;
                k += 1;
            }
        }
        public static void Main()
        {
            int[] a = { 10, 5, 15 };
            int[] b = { 20, 3, 2, 12 };
            int n = a.Length;
            int m = b.Length;

            // Final merge list 
            int[] res = new int[n + m];
            sortedMerge(a, b, res, n, m);

            Console.Write("Sorted merged list :");
            for (int i = 0; i < n + m; i++)
                Console.Write(" " + res[i]);
            sortedMerge1(a, b, res, n, m);

            Console.Write("Sorted merged list :");
            for (int i = 0; i < n + m; i++)
                Console.Write(" " + res[i]);
        }
    }
}
