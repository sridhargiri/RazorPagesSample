using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     {12, 13, 1,  10, 34, 16}
    Output:
The third Largest element is 13
Complexity Analysis:
Time Complexity: O(n).
As the array is iterated thrice and is done in a constant time
Space complexity: O(1).
No extra space is needed as the indices can be stored in constant space.
Efficient Approach: The problem deals with finding the third largest element in the array in a single traversal. The problem can be cracked by taking help of a similar problem- finding the second maximum element. So the idea is to traverse the array from start to end and to keep track of the three largest elements up to that index (stored in variables). So after traversing the whole array, the variables would have stored the indices (or value) of the three largest elements of the array.

Algorithm:
Create three variables, first, second, third, to store indices of three largest elements of the array. (Initially all of them are initialized to a minimum value).
Move along the input array from start to the end.
For every index check if the element is larger than first or not. Update the value of first, if the element is larger, and assign the value of first to second and second to third. So the largest element gets updated and the elements previously stored as largest becomes second largest, and the second largest element becomes third largest.
Else if the element is larger than the second, then update the value of second,and the second largest element becomes third largest.
If the previous two conditions fail, but the element is larger than the third, then update the third.
Print the value of third after traversing the array from start to end
    */
    class ThirdLargest
    {

        static void thirdLargest(int[] arr, int arr_size)
        {
            /* There should be atleast three elements */
            if (arr_size < 3)
            {
                Console.Write(" Invalid Input ");
                return;

            }

            // Initialize first, second and third Largest element 
            int first = arr[0], second = int.MinValue,
                                    third = int.MinValue;

            // Traverse array elements to find the third Largest 
            for (int i = 1; i < arr_size; i++)
            {
                /* If current element is greater than first, 
				then update first, second and third */
                if (arr[i] > first)
                {
                    third = second;
                    second = first;
                    first = arr[i];
                }

                /* If arr[i] is in between first and second */
                else if (arr[i] > second)
                {
                    third = second;
                    second = arr[i];
                }
                /* If arr[i] is in between second and third */
                else if (arr[i] > third)
                {
                    third = arr[i];
                }
            }

            Console.Write("The third Largest element is " + third);
        }

        /* Driver program to test above function */
        public static void Main()
        {
            int[] arr = { 12, 13, 1, 10, 34, 16 };
            int n = arr.Length;
            thirdLargest(arr, n);
        }
    }

    // This code is contributed 
    // by Ita_c 

}
