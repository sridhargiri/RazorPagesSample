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


        // The existing function always runs O(N2) time even if the array is sorted.
        // It can be optimized by stopping the algorithm if the inner loop didn’t cause any swap.
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
    /*
     https://www.geeksforgeeks.org/selection-sort/
    Selection Sort Algorithm
Lets consider the following array as an example: arr[] = {64, 25, 12, 22, 11}

First pass:

For the first pbosition in the sorted array, the whole array is traversed from index 0 to 4 sequentially. The first position where 64 is stored presently, after traversing whole array it is clear that 11 is the lowest value.
   64   	   25   	   12   	   22   	   11   
Thus, replace 64 with 11. After one iteration 11, which happens to be the least value in the array, tends to appear in the first position of the sorted list.
   11   	   25   	   12   	   22   	   64   
Second Pass:

For the second position, where 25 is present, again traverse the rest of the array in a sequential manner.
   11   	   25   	   12   	   22   	   64   
After traversing, we found that 12 is the second lowest value in the array and it should appear at the second place in the array, thus swap these values.
   11   	   12   	   25   	   22   	   64   
Third Pass:

Now, for third place, where 25 is present again traverse the rest of the array and find the third least value present in the array.
   11   	   12   	   25   	   22   	   64   
While traversing, 22 came out to be the third least value and it should appear at the third place in the array, thus swap 22 with element present at third position.
   11   	   12   	   22   	   25   	   64   
Fourth pass:

Similarly, for fourth position traverse the rest of the array and find the fourth least element in the array 
As 25 is the 4th lowest value hence, it will place at the fourth position.
   11   	   12   	   22   	   25   	   64   
Fifth Pass:

At last the largest value present in the array automatically get placed at the last position in the array
The resulted array is the sorted array.
   11   	   12   	   22   	   25   	   64   

Selection sort is a simple and efficient sorting algorithm that works by repeatedly selecting the smallest (or largest) element from the unsorted portion of the list and moving it to the sorted portion of the list. The algorithm repeatedly selects the smallest (or largest) element from the unsorted portion of the list and swaps it with the first element of the unsorted portion. This process is repeated for the remaining unsorted portion of the list until the entire list is sorted. One variation of selection sort is called “Bidirectional selection sort” that goes through the list of elements by alternating between the smallest and largest element, this way the algorithm can be faster in some cases.

The algorithm maintains two subarrays in a given array.

The subarray which already sorted. 
The remaining subarray was unsorted.
In every iteration of the selection sort, the minimum element (considering ascending order) from the unsorted subarray is picked and moved to the beginning of unsorted subarray. 

After every iteration sorted subarray size increase by one and unsorted subarray size decrease by one.
     */
    public class SelectionSortExample
    {
        static void sort(int[] arr)
        {
            int n = arr.Length;

            // One by one move boundary of unsorted subarray
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first
                // element
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }

        // Prints the array
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 64, 25, 12, 22, 11 };
            sort(arr);
            Console.WriteLine("Sorted array");
            printArray(arr);
            /*
Output
Sorted array: 
11 12 22 25 64 
            Complexity Analysis of Selection Sort:
Time Complexity: The time complexity of Selection Sort is O(N2) as there are two nested loops:

One loop to select an element of Array one by one = O(N)
Another loop to compare that element with every other Array element = O(N)
Therefore overall complexity = O(N) * O(N) = O(N*N) = O(N2)

Auxiliary Space: O(1) as the only extra memory used is for temporary variables while swapping two values in Array. The selection sort never makes more than O(N) swaps and can be useful when memory write is a costly operation. 

Sort an array of strings using Selection Sort
Is Selection Sort Algorithm stable?
Stability: The default implementation is not stable. However, it can be made stable. Please see stable selection sort for details.

Is Selection Sort Algorithm in place?
Yes, it does not require extra space.

Snapshots: Quiz on Selection Sort
Other Sorting Algorithms on GeeksforGeeks/GeeksQuiz: Coding practice for sorting

Advantages of Selection Sort Algorithm:
Simple and easy to understand.
Preserves the relative order of items with equal keys which means it is stable.
Works well with small datasets.
It is adaptable to various types of data types.
Selection sort is an in-place sorting algorithm, which means it does not require any additional memory to sort the list.
Disadvantages of Selection Sort Algorithm:
Selection sort has a time complexity of O(n^2) in the worst and average case.
Does not works well on large datasets.
Selection sort algorithm needs to iterate over the list multiple times, thus it can lead to an unbalanced branch.
Selection sort has poor cache performance and hence it is not cache friendly. 
Not adaptive, meaning it doesn’t take advantage of the fact that the list may already be sorted or partially sorted
Not a good choice for large data sets with slow random access memory (RAM)
It’s not a comparison sort and doesn’t have any performance guarantees like merge sort or quick sort.
It has poor cache performance
It can cause poor branch prediction due to its high branch misprediction rate
It has a high number of write operations, leading to poor performance on systems with slow storage.
It is not a parallelizable algorithm, meaning that it cannot be easily split up to be run on multiple processors or cores.
It does not handle data with many duplicates well, as it makes many unnecessary swaps.
It can be outperformed by other algorithms such as quicksort and heapsort in most cases. 

Summary:
Selection sort is a simple and easy-to-understand sorting algorithm that works by repeatedly selecting the smallest (or largest) element from the unsorted portion of the list and moving it to the sorted portion of the list. 
This process is repeated for the remaining unsorted portion of the list until the entire list is sorted.
It has a time complexity of O(n^2) in the worst and average case which makes it less efficient for large data sets.
Selection sort is a stable sorting algorithm.
It can be used to sort different types of data.
It has specific applications where it is useful such as small data sets and memory-constrained systems.
            */
        }

    }
    /*
https://www.geeksforgeeks.org/insertion-sort/
    Insertion sort is a simple sorting algorithm that works similar to the way you sort playing cards in your hands. The array is virtually split into a sorted and an unsorted part. Values from the unsorted part are picked and placed at the correct position in the sorted part.

Characteristics of Insertion Sort:
This algorithm is one of the simplest algorithm with simple implementation
Basically, Insertion sort is efficient for small data values
Insertion sort is adaptive in nature, i.e. it is appropriate for data sets which are already partially sorted.
Working of Insertion Sort algorithm:
Consider an example: arr[]: {12, 11, 13, 5, 6}

   12   	   11   	   13   	   5   	   6   
First Pass:

Initially, the first two elements of the array are compared in insertion sort.
   12   	   11   	   13   	   5   	   6   
Here, 12 is greater than 11 hence they are not in the ascending order and 12 is not at its correct position. Thus, swap 11 and 12.
So, for now 11 is stored in a sorted sub-array.
   11   	   12   	   13   	   5   	   6   
Second Pass:


 Now, move to the next two elements and compare them
   11   	   12   	   13   	   5   	   6   
Here, 13 is greater than 12, thus both elements seems to be in ascending order, hence, no swapping will occur. 12 also stored in a sorted sub-array along with 11
Third Pass:

Now, two elements are present in the sorted sub-array which are 11 and 12
Moving forward to the next two elements which are 13 and 5
   11   	   12   	   13   	   5   	   6   
Both 5 and 13 are not present at their correct place so swap them
   11   	   12   	   5   	   13   	   6   
After swapping, elements 12 and 5 are not sorted, thus swap again
   11   	   5   	   12   	   13   	   6   
Here, again 11 and 5 are not sorted, hence swap again
   5   	   11   	   12   	   13   	   6   
Here, 5 is at its correct position
Fourth Pass:

Now, the elements which are present in the sorted sub-array are 5, 11 and 12
Moving to the next two elements 13 and 6
   5   	   11   	   12   	   13   	   6   
Clearly, they are not sorted, thus perform swap between both
   5   	   11   	   12   	   6   	   13   
Now, 6 is smaller than 12, hence, swap again
   5   	   11   	   6   	   12   	   13   
Here, also swapping makes 11 and 6 unsorted hence, swap again
   5   	   6   	   11   	   12   	   13   
Finally, the array is completely sorted.
Illustrations:
 

Pseudo Code
procedure insertionSort(A: list of sortable items)
   n = length(A)
   for i = 1 to n - 1 do
       j = i
       while j > 0 and A[j-1] > A[j] do
           swap(A[j], A[j-1])
           j = j - 1
       end while
   end for
end procedure
This algorithm sorts an array of items by repeatedly taking an element from the unsorted portion of the array and inserting it into its correct position in the sorted portion of the array.

The procedure takes a single argument, ‘A’, which is a list of sortable items.
The variable ‘n’ is assigned the length of the array A.
The outer for loop starts at index ‘1’ and runs for ‘n-1’ iterations, where ‘n’ is the length of the array.
The inner while loop starts at the current index i of the outer for loop and compares each element to its left neighbor. If an element is smaller than its left neighbor, the elements are swapped.
The inner while loop continues to move an element to the left as long as it is smaller than the element to its left.
Once the inner while loop is finished, the element at the current index is in its correct position in the sorted portion of the array.
The outer for loop continues iterating through the array until all elements are in their correct positions and the array is fully sorted.
Insertion Sort Algorithm 
To sort an array of size N in ascending order: 

Iterate from arr[1] to arr[N] over the array. 
Compare the current element (key) to its predecessor. 
If the key element is smaller than its predecessor, compare it to the elements before. Move the greater elements one position up to make space for the swapped element.
    */
    public class InsertionSortExample
    {

        // Function to sort array
        // using insertion sort
        void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        // A utility function to print
        // array of size n
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.Write("\n");
        }

        // Driver Code
        public static void Main()
        {
            int[] arr = { 12, 11, 13, 5, 6 };
            InsertionSortExample ob = new InsertionSortExample();
            ob.InsertionSort(arr);
            printArray(arr);
            // output 5 6 11 12 13
        }
    }
    /*
     https://www.geeksforgeeks.org/merge-sort/
    Merge sort is a sorting algorithm that works by dividing an array into smaller subarrays, sorting each subarray, and then merging the sorted subarrays back together to form the final sorted array.

In simple terms, we can say that the process of merge sort is to divide the array into two halves, sort each half, and then merge the sorted halves back together. This process is repeated until the entire array is sorted.

One thing that you might wonder is what is the specialty of this algorithm. We already have a number of sorting algorithms then why do we need this algorithm? One of the main advantages of merge sort is that it has a time complexity of O(n log n), which means it can sort large arrays relatively quickly. It is also a stable sort, which means that the order of elements with equal values is preserved during the sort.

Merge sort is a popular choice for sorting large datasets because it is relatively efficient and easy to implement. It is often used in conjunction with other algorithms, such as quicksort, to improve the overall performance of a sorting routine.


Merge Sort Working Process:
Think of it as a recursive algorithm continuously splits the array in half until it cannot be further divided. This means that if the array becomes empty or has only one element left, the dividing will stop, i.e. it is the base case to stop the recursion. If the array has multiple elements, split the array into halves and recursively invoke the merge sort on each of the halves. Finally, when both halves are sorted, the merge operation is applied. Merge operation is the process of taking two smaller sorted arrays and combining them to eventually make a larger one.

Illustration:
To know the functioning of merge sort, lets consider an array arr[] = {38, 27, 43, 3, 9, 82, 10}

At first, check if the left index of array is less than the right index, if yes then calculate its mid point

 

Now, as we already know that merge sort first divides the whole array iteratively into equal halves, unless the atomic values are achieved. 
Here, we see that an array of 7 items is divided into two arrays of size 4 and 3 respectively.

 

Now, again find that is left index is less than the right index for both arrays, if found yes, then again calculate mid points for both the arrays.

 

Now, further divide these two arrays into further halves, until the atomic units of the array is reached and further division is not possible.

 

After dividing the array into smallest units, start merging the elements again based on comparison of size of elements
Firstly, compare the element for each list and then combine them into another list in a sorted manner.

 

After the final merging, the list looks like this:
    The following diagram shows the complete merge sort process for an example array {38, 27, 43, 3, 9, 82, 10}. 

If we take a closer look at the diagram, we can see that the array is recursively divided into two halves till the size becomes 1. 
    Once the size becomes 1, the merge processes come into action and start merging arrays back till the complete array is merged.
    Algorithm:
step 1: start

step 2: declare array and left, right, mid variable

step 3: perform merge function.
    if left > right
        return
    mid= (left+right)/2
    mergesort(array, left, mid)
    mergesort(array, mid+1, right)
    merge(array, left, mid, right)

step 4: Stop

Follow the steps below to solve the problem:

MergeSort(arr[], l,  r)
If r > l

Find the middle point to divide the array into two halves: 
middle m = l + (r – l)/2
Call mergeSort for first half:   
Call mergeSort(arr, l, m)
Call mergeSort for second half:
Call mergeSort(arr, m + 1, r)
Merge the two halves sorted in steps 2 and 3:
Call merge(arr, l, m, r)
Below is the implementation of the above approach:
     */
    public class MergeSortExample
    {

        // Merges two subarrays of []arr.
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        void merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                // point
                int m = l + (r - l) / 2;

                // Sort first and
                // second halves
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }

        // A utility function to
        // print array of size n */
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine("Given Array");
            printArray(arr);
            MergeSortExample ob = new MergeSortExample();
            ob.sort(arr, 0, arr.Length - 1);
            Console.WriteLine("\nSorted array");
            printArray(arr);
            /*
             Output
Given array is 
12 11 13 5 6 7 
Sorted array is 
5 6 7 11 12 13 
Time Complexity: O(N log(N)),  Sorting arrays on different machines. Merge Sort is a recursive algorithm and time complexity can be expressed as following recurrence relation. 

T(n) = 2T(n/2) + θ(n)

The above recurrence can be solved either using the Recurrence Tree method or the Master method. It falls in case II of the Master Method and the solution of the recurrence is θ(Nlog(N)). The time complexity of Merge Sort isθ(Nlog(N)) in all 3 cases (worst, average, and best) as merge sort always divides the array into two halves and takes linear time to merge two halves.

Auxiliary Space: O(n), In merge sort all elements are copied into an auxiliary array. So N auxiliary space is required for merge sort.


             */
        }
    }
    /*
     https://www.geeksforgeeks.org/quick-sort/
    Like Merge Sort, QuickSort is a Divide and Conquer algorithm. It picks an element as a pivot and partitions the given array around the picked pivot. There are many different versions of quickSort that pick pivot in different ways. 

Always pick the first element as a pivot.
Always pick the last element as a pivot (implemented below)
Pick a random element as a pivot.
Pick median as the pivot.
The key process in quickSort is a partition(). 
    The target of partitions is, given an array and an element x of an array as the pivot, put x at its correct position in a sorted array and put all smaller elements (smaller than x) before x, and put all greater elements (greater than x) after x. 
    All this should be done in linear time.
    There can be many ways to do partition, following pseudo-code adopts the method given in the CLRS book. The logic is simple, we start from the leftmost element and keep track of the index of smaller (or equal to) elements as i. While traversing, if we find a smaller element, we swap the current element with arr[i]. Otherwise, we ignore the current element. 

Pseudo Code for recursive QuickSort function:




    quickSort(arr[], low, high)
    {

        if (low < high)
        {

             pi is partitioning index, arr[pi] is now at right place 

            pi = partition(arr, low, high);

            quickSort(arr, low, pi – 1);  // Before pi

            quickSort(arr, pi + 1, high); // After pi

        }

    }

    Pseudo code for partition()

This function takes last element as pivot, places the pivot element at its correct position in sorted array, and places all smaller (smaller than pivot) to left of pivot and all greater elements to right of pivot 

partition(arr[], low, high)
    {
        // pivot (Element to be placed at right position)
        pivot = arr[high];

        i = (low – 1)  // Index of smaller element and indicates the 
    // right position of pivot found so far

    for (j = low; j <= high - 1; j++)
        {

            // If current element is smaller than the pivot
            if (arr[j] < pivot)
            {
                i++;    // increment index of smaller element
                swap arr[i] and arr[j]
            }
        }
        swap arr[i + 1] and arr[high])
    return (i + 1)
}

    Illustration of partition() :

Consider: arr[] = {10, 80, 30, 90, 40, 50, 70}

Indexes: 0   1   2   3   4   5   6
low = 0, high = 6, pivot = arr[h] = 70
Initialize index of smaller element, i = -1

     */
    public class QuickSortExample
    {

        // A utility function to swap two elements
        static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        /* This function takes last element as pivot, places
             the pivot element at its correct position in sorted
             array, and places all smaller (smaller than pivot)
             to left of pivot and all greater elements to right
             of pivot */
        static int partition(int[] arr, int low, int high)
        {

            // pivot
            int pivot = arr[high];

            // Index of smaller element and
            // indicates the right position
            // of pivot found so far
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {

                // If current element is smaller
                // than the pivot
                if (arr[j] < pivot)
                {

                    // Increment index of
                    // smaller element
                    i++;
                    swap(arr, i, j);
                }
            }
            swap(arr, i + 1, high);
            return (i + 1);
        }

        /* The main function that implements QuickSort
                    arr[] --> Array to be sorted,
                    low --> Starting index,
                    high --> Ending index
           */
        static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = partition(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }

        // Function to print an array
        static void printArray(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }

        // Driver Code
        public static void Main()
        {
            int[] arr = { 10, 7, 8, 9, 1, 5 };
            int n = arr.Length;

            quickSort(arr, 0, n - 1);
            Console.Write("Sorted array: ");
            printArray(arr, n);
            /*
Output
Sorted array: 
1 5 7 8 9 10 
            */
        }
    }
}

