using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BubbleSortExample
    {
        /*
         https://www.geeksforgeeks.org/bubble-sort/
        Bubble Sort
Difficulty Level : Easy
Last Updated : 10 Aug, 2021
 
Bubble Sort is the simplest sorting algorithm that works by repeatedly swapping the adjacent elements if they are in wrong order.
Example: 
First Pass: 
( 5 1 4 2 8 ) –> ( 1 5 4 2 8 ), Here, algorithm compares the first two elements, and swaps since 5 > 1. 
( 1 5 4 2 8 ) –>  ( 1 4 5 2 8 ), Swap since 5 > 4 
( 1 4 5 2 8 ) –>  ( 1 4 2 5 8 ), Swap since 5 > 2 
( 1 4 2 5 8 ) –> ( 1 4 2 5 8 ), Now, since these elements are already in order (8 > 5), algorithm does not swap them.
Second Pass: 
( 1 4 2 5 8 ) –> ( 1 4 2 5 8 ) 
( 1 4 2 5 8 ) –> ( 1 2 4 5 8 ), Swap since 4 > 2 
( 1 2 4 5 8 ) –> ( 1 2 4 5 8 ) 
( 1 2 4 5 8 ) –>  ( 1 2 4 5 8 ) 
Now, the array is already sorted, but our algorithm does not know if it is completed. The algorithm needs one whole pass without any swap to know it is sorted.
Third Pass: 
( 1 2 4 5 8 ) –> ( 1 2 4 5 8 ) 
( 1 2 4 5 8 ) –> ( 1 2 4 5 8 ) 
( 1 2 4 5 8 ) –> ( 1 2 4 5 8 ) 
( 1 2 4 5 8 ) –> ( 1 2 4 5 8 ) 
         */


        // An optimized version of Bubble Sort 
        static void bubbleSort(int[] arr, int n)
        {
            int i, j, temp;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap arr[j] and arr[j+1] 
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                // IF no two elements were  
                // swapped by inner loop, then break 
                if (swapped == false)
                    break;
            }
        }

        // Function to print an array  
        static void printArray(int[] arr, int size)
        {
            int i;
            for (i = 0; i < size; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver method  
        public static void Main()
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            int n = arr.Length;
            bubbleSort(arr, n);
            Console.WriteLine("Sorted array");
            printArray(arr, n);
            /*
             Output: 

Sorted array:
11 12 22 25 34 64 90
 

Worst and Average Case Time Complexity: O(n*n). Worst case occurs when array is reverse sorted.
Best Case Time Complexity: O(n). Best case occurs when array is already sorted.
Auxiliary Space: O(1)
Boundary Cases: Bubble sort takes minimum time (Order of n) when elements are already sorted.
Sorting In Place: Yes
Stable: Yes
            */
        }

    }
}

