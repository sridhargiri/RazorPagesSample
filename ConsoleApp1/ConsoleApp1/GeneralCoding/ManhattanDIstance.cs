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
}
