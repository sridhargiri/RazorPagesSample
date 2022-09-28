using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    https://www.geeksforgeeks.org/k-largestor-smallest-elements-in-an-array/ 
    Method 6 (Use Min Heap) 
This method is mainly an optimization of method 2. Instead of using temp[] array, use Min Heap.
1) Build a Min Heap MH of the first k elements (arr[0] to arr[k-1]) of the given array. O(k*log(k))
2) For each element, after the kth element (arr[k] to arr[n-1]), compare it with root of MH. 
……a) If the element is greater than the root then make it root and call heapify for MH 
……b) Else ignore it. 
// The step 2 is O((n-k)*log(k))
3) Finally, MH has k largest elements, and the root of the MH is the kth largest element.
Time Complexity: O(k*log(k) + (n-k)*log(k)) without sorted output. If sorted output is needed then O(k*log(k) + (n-k)*log(k) + k*log(k)) so overall it is O(k*log(k) + (n-k)*log(k))
    
     */
    public class LargestKElements
    {

        public static void FirstKelements_minHeap(int[] arr,
                                          int size,
                                          int k)
        {

            // Creating Min Heap for given
            // array with only k elements
            // Create min heap with priority queue
            List<int> minHeap = new List<int>();
            for (int i = 0; i < k; i++)
            {
                minHeap.Add(arr[i]);
            }

            // Loop For each element in array
            // after the kth element
            for (int i = k; i < size; i++)
            {
                minHeap.Sort();

                // If current element is smaller
                // than minimum ((top element of
                // the minHeap) element, do nothing
                // and continue to next element
                if (minHeap[0] > arr[i])
                    continue;

                // Otherwise Change minimum element
                // (top element of the minHeap) to
                // current element by polling out
                // the top element of the minHeap
                else
                {
                    minHeap.RemoveAt(0);
                    minHeap.Add(arr[i]);
                }
            }

            // Now min heap contains k maximum
            // elements, Iterate and print  
            foreach (int i in minHeap)
            {
                Console.Write(i + " ");
            }
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] arr = { 11, 3, 2, 1, 15, 5, 4, 45, 88, 96, 50, 45 };
            int size = arr.Length;

            // Size of Min Heap
            int k = 3;
            FirstKelements_minHeap(arr, size, k);
        }
    }
    /*
     Method 7(Using Quick Sort partitioning algorithm):

Choose a pivot number.
if K is lesser than the pivot_Index then repeat the step.
if K == pivot_Index : Print the array (low to pivot to get K-smallest elements and (n-pivot_Index) to n for K-largest elements)
if  K > pivot_Index : Repeat the steps for right part.
We can improve on the standard quicksort algorithm by using the random() function. Instead of using the pivot element as the last element, we can randomly choose the pivot element. The worst-case time complexity of this version is O(n2) and the average time complexity is O(n).

Following is the implementation of the above algorithm
    
     */
    public class LargestKElements_Pivot
    {

        // picks up last element between start and end
        static int findPivot(int[] a, int start, int end)
        {

            // Selecting the pivot element
            int pivot = a[end];

            // Initially partition-index will be
            // at starting
            int pIndex = start;

            for (int i = start; i < end; i++)
            {

                // If an element is lesser than pivot, swap it.
                if (a[i] <= pivot)
                {
                    int temp6 = a[i];
                    a[i] = a[pIndex];
                    a[pIndex] = temp6;

                    // Incrementing pIndex for further
                    // swapping.
                    pIndex++;
                }
            }

            // Lastly swapping or the
            // correct position of pivot
            int temp = a[pIndex];
            a[pIndex] = a[end];
            a[end] = temp;
            return pIndex;
        }

        // THIS PART OF CODE IS CONTRIBUTED BY - rjrachit
        // Picks up random pivot element between start and end
        static int findRandomPivot(int[] arr, int start, int end)
        {
            int n = end - start + 1;

            // Selecting the random pivot index
            Random _random = new Random();
            var randomNumber = _random.Next(0, n);
            int pivotInd = randomNumber;
            int temp = arr[end];
            arr[end] = arr[start + pivotInd];
            arr[start + pivotInd] = temp;
            int pivot = arr[end];

            // initialising pivoting point to start index
            pivotInd = start;
            for (int i = start; i < end; i++)
            {

                // If an element is lesser than pivot, swap it.
                if (arr[i] <= pivot)
                {
                    int temp1 = arr[i];
                    arr[i] = arr[pivotInd];
                    arr[pivotInd] = temp1;

                    // Incrementing pivotIndex for further
                    // swapping.
                    pivotInd++;
                }
            }

            // Lastly swapping or the
            // correct position of pivot
            int tep = arr[pivotInd];
            arr[pivotInd] = arr[end];
            arr[end] = tep;
            return pivotInd;
        }

        static void SmallestLargest(int[] a, int low, int high, int k, int n)
        {
            if (low == high)
                return;
            else
            {
                int pivotIndex = findRandomPivot(a, low, high);

                if (k == pivotIndex)
                {
                    Console.Write(k + " smallest elements are : ");
                    for (int i = 0; i < pivotIndex; i++)
                        Console.Write(a[i] + "  ");

                    Console.WriteLine();

                    Console.Write(k + " largest elements are : ");
                    for (int i = (n - pivotIndex); i < n; i++)
                        Console.Write(a[i] + "  ");
                }

                else if (k < pivotIndex)
                    SmallestLargest(a, low, pivotIndex - 1, k, n);

                else if (k > pivotIndex)
                    SmallestLargest(a, pivotIndex + 1, high, k, n);
            }
        }

        // Driver Code
        public static void Main(String[] args)
        {
            int[] a = { 11, 3, 2, 1, 15, 5, 4, 45, 88, 96, 50, 45 };
            int n = a.Length;

            int low = 0;
            int high = n - 1;

            // Lets assume k is 3
            int k = 3;

            // Function Call
            SmallestLargest(a, low, high, k, n);
            /*
Output
3 smallest elements are : 3  2  1  
3 largest elements are : 96  50  88  
Time Complexity: O(nlogn)
Auxiliary Space: O(1)
            */
        }
    }
}
