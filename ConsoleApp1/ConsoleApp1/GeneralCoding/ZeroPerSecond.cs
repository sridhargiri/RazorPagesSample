using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/minimum-k-to-make-h-zero/
    Given integer H and array A[] of size N. A[] is a sorted array representing the start of the operation, 
    start subtracting 1 from H for every second from A[i] to A[i] + K, and the task for this problem is to find minimum K to make H zero.
    Note: For every second you can subtract 1 from H only once
    Examples:

Input: H = 5, A[] = {1, 5}
Output: 3
Explanation: For K = 3 , subtraction is done in seconds [1, 2, 3, 5, 6, 7]
    for A[0] = 1, subtraction will be done in {1, 2, 3}
for A[1] = 5, subtraction will be done in {5, 6, 7}
Input: H = 10, A[] = {2, 4, 10};
Output: 4

Explanation: For K = 4, subtraction is done in seconds [2, 3, 4, 5, 6, 7, 10, 11, 12, 13]

for A[0] = 2, subtraction will be done in {2, 3, 4, 5}
for A[1] = 4, subtraction will be done in {4, 5, 6, 7}
for A[2] = 10, subtraction will be done in {10, 11, 12, 13}
in A[0] and A[1], 4 and 5 are common while performing operations subtract 1 from H only once for time 4 and 5 (read note of this problem)
    Approach: To solve the problem follow the below idea:

Binary Search can be used to solve this problem. Monotonic function is for different K value of H is monotonic. We have monotonic function FFFFTTTTT for different K. problem require us to find minimum K value for which function is true for the first time.

Below are the steps for the above approach:

Create a test function that takes parameters as mid, A[], N, and H.
Create a CNT = 0 variable to store the maximum number that can be subtracted from H.
Iterate from 0 to N – 1 and if the difference of consecutive elements is less than equal to mid then add the difference of consecutive elements to CNT else add mid to CNT.
Finally, add mid to CNT and return CNT >= H.
Create low = 0 and high = 1e9 and mid variables.
Run while loop until high – low  > 1
set mid = (low + high) / 2.
if the test function for this mid is true set high = mid.
else set low = mid  + 1.
Finally, if the test function for low is true return low else return high.
Below is the implementation of the above approach: 
     */
    public class ZeroPerSecond
    {
        static bool ZeroTest(int mid, int[] A, int N, int H)
        {

            // Count variable to store largest
            // number subtracted from H
            int cnt = 0;

            // Iterating through A[]
            for (int i = 0; i < N - 1; i++)
            {

                if (A[i + 1] - A[i] <= mid)
                    cnt += A[i + 1] - A[i];

                else
                    cnt += mid;
            }

            // Adding mid to maximum number
            // subtracted from H
            cnt += mid;

            // Maximum number subtracted from H
            // is greater than equal return true
            // else false
            return cnt >= H;
        }
        static int MinimizeOperations(int[] A, int N, int H)
        {

            // low high and mid
            int low = 1, high = int.MaxValue, mid;

            // Run a while loop until
            // high-low > 1
            while (high - low > 1)
            {

                // Finding mid
                mid = (low + high) / 2;

                // Test the function on mid
                if (ZeroTest(mid, A, N, H))
                {

                    // Set high to mid
                    high = mid;
                }

                else
                {

                    // Set low to mid + 1
                    low = mid + 1;
                }
            }
            // If low returns true
            // return low else high
            if (ZeroTest(low, A, N, H))
                return low;
            else
                return high;
        }
        public static void Main(string[] args)
        {
            // Input 1
            int N = 2, H = 5;
            int[] A = { 1, 5 };

            // Function Call
            Console.WriteLine(MinimizeOperations(A, N, H));

            // Input 2
            int N1 = 3, H1 = 10;
            int[] A1 = { 2, 4, 10 };
            Console.WriteLine(MinimizeOperations(A, N1, H1));
            /*
             Output
3
4
Time Complexity: O(N*logN)  
Auxiliary Space: O(1)
            */
        }
    }
}
