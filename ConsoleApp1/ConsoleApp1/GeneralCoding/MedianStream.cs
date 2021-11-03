using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/median-of-stream-of-running-integers-using-stl/
    Median of Stream of Running Integers using STL
Difficulty Level : Hard
Last Updated : 07 Jul, 2021
Given that integers are being read from a data stream. Find the median of all the elements read so far starting from the first integer till the last integer. This is also called the Median of Running Integers. The data stream can be any source of data, for example, a file, an array of integers, input stream etc.
 

What is Median?
Median can be defined as the element in the data set which separates the higher half of the data sample from the lower half. In other words, we can get the median element as, when the input size is odd, we take the middle element of sorted data. If the input size is even, we pick an average of middle two elements in the sorted stream.
Examples: 
 



Input: 5 10 15 
Output: 5, 7.5, 10 
Explanation: Given the input stream as an array of integers [5,10,15]. Read integers one by one and print the median correspondingly. So, after reading first element 5,median is 5. After reading 10,median is 7.5 After reading 15 ,median is 10.
Input: 1, 2, 3, 4 
Output: 1, 1.5, 2, 2.5 
Explanation: Given the input stream as an array of integers [1, 2, 3, 4]. Read integers one by one and print the median correspondingly. So, after reading first element 1,median is 1. After reading 2,median is 1.5 After reading 3 ,median is 2.After reading 4 ,median is 2.5. 
 

 

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution.
Approach: The idea is to use max heap and min heap to store the elements of higher half and lower half. Max heap and min heap can be implemented using priority_queue in C++ STL. Below is the step by step algorithm to solve this problem.
Algorithm: 
 

Create two heaps. One max heap to maintain elements of lower half and one min heap to maintain elements of higher half at any point of time..
Take initial value of median as 0.
For every newly read element, insert it into either max heap or min-heap and calculate the median based on the following conditions: 
If the size of max heap is greater than the size of min-heap and the element is less than the previous median then pop the top element from max heap and insert into min-heap and insert the new element to max heap else insert the new element to min-heap. Calculate the new median as the average of top of elements of both max and min heap.
If the size of max heap is less than the size of min-heap and the element is greater than the previous median then pop the top element from min-heap and insert into the max heap and insert the new element to min heap else insert the new element to the max heap. Calculate the new median as the average of top of elements of both max and min heap.
If the size of both heaps is the same. Then check if the current is less than the previous median or not. If the current element is less than the previous median then insert it to the max heap and a new median will be equal to the top element of max heap. If the current element is greater than the previous median then insert it to min-heap and new median will be equal to the top element of min heap.
Below is the implementation of above approach. 
     */
    class MedianStream
    {

        // method to calculate med of stream
        public static void MedianOfStreamOfInteger(int[] a)
        {
            double med = a[0];

            // max heap to store the smaller half elements
            List<int> smaller = new List<int>();

            // min-heap to store the greater half elements
            List<int> greater = new List<int>();
            smaller.Add(a[0]);
            Console.WriteLine(med);

            // reading elements of stream one by one
            /* At any time we try to make heaps balanced and
                    their sizes differ by at-most 1. If heaps are
                    balanced,then we declare median as average of
                    min_heap_right.top() and max_heap_left.top()
                    If heaps are unbalanced,then median is defined
                    as the top element of heap of larger size */
            for (int i = 1; i < a.Length; i++)
            {

                int x = a[i];

                // case1(left side heap has more elements)
                if (smaller.Count > greater.Count)
                {
                    if (x < med)
                    {
                        smaller.Sort();
                        smaller.Reverse();
                        greater.Add(smaller[0]);
                        smaller.RemoveAt(0);
                        smaller.Add(x);
                    }
                    else
                        greater.Add(x);
                    smaller.Sort();
                    smaller.Reverse();
                    greater.Sort();
                    med = (double)(smaller[0] + greater[0]) / 2;
                }

                // case2(both heaps are balanced)
                else if (smaller.Count == greater.Count)
                {
                    if (x < med)
                    {
                        smaller.Add(x);
                        smaller.Sort();
                        smaller.Reverse();
                        med = (double)smaller[0];
                    }
                    else
                    {
                        greater.Add(x);
                        greater.Sort();
                        med = (double)greater[0];
                    }
                }

                // case3(right side heap has more elements)
                else
                {
                    if (x > med)
                    {
                        greater.Sort();
                        smaller.Add(greater[0]);
                        greater.RemoveAt(0);
                        greater.Add(x);
                    }
                    else
                        smaller.Add(x);
                    smaller.Sort();
                    smaller.Reverse();
                    med = (double)(smaller[0] + greater[0]) / 2;

                }
                Console.WriteLine(med);
            }
        }

        // Driver code
        public static void Main(String[] args)
        {

            // stream of integers
            int[] arr = new int[] { 5, 15, 10, 20, 3 };
            MedianOfStreamOfInteger(arr);
            /*
             Output: 
5
10
10
12.5
10
 

Complexity Analysis: 
 

Time Complexity: O(n Log n). 
Time Complexity to insert element in min heap is log n. So to insert n element is O( n log n).
Auxiliary Space : O(n). 
The Space required to store the elements in Heap is O(n).
            */
        }
    }

}
