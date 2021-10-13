using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     * https://www.geeksforgeeks.org/check-if-any-point-exists-in-a-plane-whose-manhattan-distance-is-at-most-k-from-n-given-points/
     Check if any point exists in a plane whose Manhattan distance is at most K from N given points
Last Updated : 01 Apr, 2021
Given two arrays A[] and B[] consisting of X and Y coordinates of N distinct points in a plane, and a positive integer K, the task is to check if there exists any point P in the plane such that the Manhattan distance between the point and all the given points is at most K. If there exists any such point P, then print “Yes”. Otherwise, print “No”.

Examples:

Input: A[] = {1, 0, 2, 1, 1}, B[] = {1, 1, 1, 0, 2}, K = 1
Output: Yes
Explanation: 
Consider a point P(1, 1), then the Manhattan distance between P and all the given points are:

Distance between P and (A[0], B[0]) is |1 – 1| + |1 – 1| = 0.
Distance between P and (A[1], B[1]) is |1 – 0| + |1 – 1| = 1.
Distance between P and (A[2], B[2]) is |1 – 2| + |1 – 1| = 1.
Distance between P and (A[3], B[3]) is |1 – 1| + |1 – 0| = 1.
Distance between P and (A[4], B[4]) is |1 – 1| + |1 – 2| = 1.
The distance between all the given points and P is at most K(= 1). Therefore, print “Yes”.

Input: A[] = {0, 3, 1}, B[] = {0, 3, 1}, K = 2
Output: No

Approach: The given problem can be solved by finding the Manhattan distance between every pair of N given points. After checking for all pairs of points, if the count of the distance between pairs of points is at most K, then print “Yes”. Otherwise, print “No”. 
    */
    class ManhattanDIstance
    {
        public static String find(
        int[] a, int[] b, int N, int K)
        {
            // Traverse the given N points
            for (int i = 0; i < N; i++)
            {

                // Stores the count of pairs
                // of coordinates having
                // Manhattan distance <= K
                int count = 0;

                for (int j = 0; j < N; j++)
                {

                    // For the same coordinate
                    if (i == j)
                    {
                        continue;
                    }

                    // Calculate Manhattan distance
                    long dis = Math.Abs(a[i] - a[j])
                               + Math.Abs(b[i] - b[j]);

                    // If Manhattan distance <= K
                    if (dis <= K)
                    {

                        count++;
                    }

                    // If all coordinates
                    // can meet
                    if (count == N - 1)
                    {
                        return "Yes";
                    }
                }
            }

            // If all coordinates can't meet
            return "No";
        }
        static void Main(string[] args)
        {
            int N = 5;
            int[] A = { 1, 0, 2, 1, 1 };
            int[] B = { 1, 1, 1, 0, 2 };
            int K = 1;
            Console.WriteLine(find(A, B, N, K));
            /*
             Output:
Yes
Time Complexity: O(N2)
Auxiliary Space: O(1)
            */
        }
    }
    /*
https://www.geeksforgeeks.org/distance-from-next-greater-element/
Distance from Next Greater element
Last Updated : 14 Apr, 2021
Given an array arr[] of size N, the task is to print the distance of every array element from its next greater element. For array elements having no next greater element, print 0.

Examples: 

Input: arr[] = {73, 74, 75, 71, 69, 72, 76, 73} 
Output: {1, 1, 4, 2, 1, 1, 0, 0} 
Explanation: 
The next greater element for 73 is 74, which is at position 1. Distance = 1 – 0 = 1 
The next greater element for 74 is 75, which is at position 2. Distance = 2 – 1 = 1 
The next greater element for 75 is 76, which is at position 6. Distance = 6 – 2 = 4 
The next greater element for 71 is 72, which is at position 5. Distance = 5 – 3 = 2 
The next greater element for 69 is 72, which is at position 5. Distance = 5 – 4 = 1 
The next greater element for 72 is 76, which is at position 6. Distance = 6 – 5 = 1 
No, next greater element for 76. Distance = 0 
No, next greater element for 73. Distance = 0 

Input: arr[] = {5, 4, 3, 2, 1} 
Output: {0, 0, 0, 0, 0}

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Naive Approach: The simplest approach is to traverse the array and for every array element, traverse to its right to obtain its next greater element and calculate the difference between the indices.

Time Complexity: O(N2) 
Auxiliary Space: O(1)

Efficient Approach: To optimize the above approach, the idea is to use Stack to find the next greater element. 
Below are the steps: 

Maintain a Stack which will contain the elements in non-increasing order.
Check if the current element arr[i]is greater than the element at the top of the stack.
Keep popping all the elements from the stack one by one from the top, that are found to be smaller than arr[i] and calculate the distance for each of them as the difference of current index and the index of the popped element.
Push the current element into the stack and repeat the above steps.
Below is the implementation of the above approach:
     */
    public class NextGreaterDistance
    {

        public static int[] distance_from_next_greater_element(int[] arr)
        {
            int N = arr.Length;

            // Stores the required distances
            int[] ans = new int[N];
            int st = 0;

            // Maintain a stack of elements
            // in non-increasing order
            for (int i = 0; i < N - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    ans[i] = 1;
                }
                else
                {
                    st = i + 1;
                    while (st <= N - 1)
                    {
                        if (arr[i] < arr[st])
                        {
                            ans[i] = st - i;
                            break;
                        }
                        else
                        {
                            st++;
                        }
                    }
                }
            }
            return ans;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] arr = new int[]{ 73, 74, 75, 71,
                           69, 72, 76, 73 };

            int[] x = distance_from_next_greater_element(arr);

            Console.Write("[");
            for (int i = 0; i < x.Length; i++)
                Console.Write(x[i] + ", ");

            Console.Write("]");
            /*
             Output: 
[1, 1, 4, 2, 1, 1, 0, 0]
 

Time Complexity: O(N) 
Auxiliary Space: O(N)

             */
        }
    }
}
