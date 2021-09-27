using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/trapping-rain-water/   
     Leetcode https://www.programcreek.com/2014/06/leetcode-trapping-rain-water-java/
     */
    class RainwaterTrap
    {
       
        // Function to return the maximum
        // water that can be stored
        public static int maxWater(int[] arr, int n)
        {

            // To store the maximum water
            // that can be stored
            int res = 0;

            // For every element of the array
            // except first and last element
            for (int i = 1; i < n - 1; i++)
            {

                // Find maximum element on its left
                int left = arr[i];
                for (int j = 0; j < i; j++)
                {
                    left = Math.Max(left, arr[j]);
                }

                // Find maximum element on its right
                int right = arr[i];
                for (int j = i + 1; j < n; j++)
                {
                    right = Math.Max(right, arr[j]);
                }

                // Update maximum water value
                res += Math.Min(left, right) - arr[i];
            }
            return res;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] arr = { 0, 1, 0, 2, 1, 0,
                1, 3, 2, 1, 2, 1 };
            int n = arr.Length;

            Console.Write(maxWater(arr, n));
            /*
             Output
6
Complexity Analysis: 
Time Complexity: O(n2). 
There are two nested loops traversing the array, So time Complexity is O(n2).
Space Complexity: O(1). 
No extra space is required
            */
        }
    }
    /*
     Method 2: This is an efficient solution to the above problem.

Approach: In the previous solution, to find the highest bar on the left and right, array traversal is needed which reduces the efficiency of the solution. To make this efficient one must pre-compute the highest bar on the left and right of every bar in linear time. Then use these pre-computed values to find the amount of water in every array element.
Algorithm: 
Create two arrays left and right of size n. create a variable max_ = INT_MIN.
Run one loop from start to end. In each iteration update max_ as max_ = max(max_, arr[i]) and also assign left[i] = max_
Update max_ = INT_MIN.
Run another loop from end to start. In each iteration update max_ as max_ = max(max_, arr[i]) and also assign right[i] = max_
Traverse the array from start to end.
The amount of water that will be stored in this column is min(a,b) – array[i],(where a = left[i] and b = right[i]) add this value to total amount of water stored
Print the total amount of water stored.
    */
    class RainwaterTrapping
    {
        static int[] arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

        // Method for maximum amount of water
        static int findWater(int n)
        {
            // left[i] contains height of tallest bar to the
            // left of i'th bar including itself
            int[] left = new int[n];

            // Right [i] contains height of tallest bar to
            // the right of ith bar including itself
            int[] right = new int[n];

            // Initialize result
            int water = 0;

            // Fill left array
            left[0] = arr[0];
            for (int i = 1; i < n; i++)
                left[i] = Math.Max(left[i - 1], arr[i]);

            // Fill right array
            right[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
                right[i] = Math.Max(right[i + 1], arr[i]);

            // Calculate the accumulated water element by element
            // consider the amount of water on i'th bar, the
            // amount of water accumulated on this particular
            // bar will be equal to min(left[i], right[i]) - arr[i] .
            for (int i = 0; i < n; i++)
                water += Math.Min(left[i], right[i]) - arr[i];

            return water;
        }

        // Driver method to test the above function
        public static void Main()
        {

            Console.WriteLine("Maximum water that can be accumulated is " + findWater(arr.Length));
            /*
             Output: 



Maximum water that can be accumulated is 6
Complexity Analysis: 
Time Complexity: O(n). 
Only one traversal of the array is needed, So time Complexity is O(n).
Space Complexity: O(n). 
Two extra arrays are needed each of size n.
            */
        }
    }
}

