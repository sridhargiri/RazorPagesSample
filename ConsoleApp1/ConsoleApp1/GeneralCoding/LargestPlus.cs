using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-size-of-the-largest-formed-by-all-ones-in-a-binary-matrix/
    Find size of the largest ‘+’ formed by all ones in a binary matrix
Difficulty Level : Hard
Last Updated : 08 Apr, 2021
Given a N X N binary matrix, find the size of the largest ‘+’ formed by all 1s.
Example: 
    For above matrix, largest ‘+’ would be formed by highlighted part of size 17.
 



Recommended: Please try your approach on {IDE} first, before moving on to the solution.
The idea is to maintain four auxiliary matrices left[][], right[][], top[][], bottom[][] to store consecutive 1’s in every direction. For each cell (i, j) in the input matrix, we store below information in these four matrices –
 

left(i, j) stores maximum number of
consecutive 1's to the left of cell (i, j) 
including cell (i, j).

right(i, j) stores maximum number of
consecutive 1's to the right of cell (i, j) 
including cell (i, j).

top(i, j) stores maximum number of
consecutive 1's at top of cell (i, j) 
including cell (i, j).

bottom(i, j) stores maximum number of
consecutive 1's at bottom of cell (i, j) 
including cell (i, j).
After computing value for each cell of above matrices, the largest + would be formed by a cell of input matrix that has maximum value by considering minimum of (left(i, j), right(i, j), top(i, j), bottom(i, j) )
We can use Dynamic Programming to compute the total amount of consecutive 1’s in every direction. 
 

if mat(i, j) == 1
    left(i, j) = left(i, j - 1) + 1
else left(i, j) = 0

if mat(i, j) == 1
    top(i, j) = top(i - 1, j) + 1;
else
    top(i, j) = 0;

if mat(i, j) == 1
    bottom(i, j) = bottom(i + 1, j) + 1;
else
    bottom(i, j) = 0;    

if mat(i, j) == 1
    right(i, j) = right(i, j + 1) + 1;
else
    right(i, j) = 0;
Below is the implementation of above idea –
     */
    class LargestPlus
    {

        // size of binary square matrix
        static int N = 10;

        // Function to find the size of the largest '+'
        // formed by all 1's in given binary matrix
        static int findLargestPlus(int[,] mat)
        {

            // left[j][j], right[i][j], top[i][j] and
            // bottom[i][j] store maximum number of
            // consecutive 1's present to the left,
            // right, top and bottom of mat[i][j]
            // including cell(i, j) respectively
            int[,] left = new int[N, N];
            int[,] right = new int[N, N];
            int[,] top = new int[N, N];
            int[,] bottom = new int[N, N];

            // initialize above four matrix
            for (int i = 0; i < N; i++)
            {

                // initialize first row of top
                top[0, i] = mat[0, i];

                // initialize last row of bottom
                bottom[N - 1, i] = mat[N - 1, i];

                // initialize first column of left
                left[i, 0] = mat[i, 0];

                // initialize last column of right
                right[i, N - 1] = mat[i, N - 1];
            }

            // fill all cells of above four matrix
            for (int i = 0; i < N; i++)
            {
                for (int j = 1; j < N; j++)
                {

                    // calculate left matrix
                    // (filled left to right)
                    if (mat[i, j] == 1)
                        left[i, j] = left[i, j - 1] + 1;
                    else
                        left[i, j] = 0;

                    // calculate top matrix
                    if (mat[j, i] == 1)
                        top[j, i] = top[j - 1, i] + 1;
                    else
                        top[j, i] = 0;

                    // calculate new value of j to
                    // calculate value of bottom(i, j)
                    // and right(i, j)
                    j = N - 1 - j;

                    // calculate bottom matrix
                    if (mat[j, i] == 1)
                        bottom[j, i] = bottom[j + 1, i] + 1;
                    else
                        bottom[j, i] = 0;

                    // calculate right matrix
                    if (mat[i, j] == 1)
                        right[i, j] = right[i, j + 1] + 1;
                    else
                        right[i, j] = 0;

                    // revert back to old j
                    j = N - 1 - j;
                }
            }

            // n stores length of longest + found so far
            int n = 0;

            // compute longest +
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {

                    // find minimum of left(i, j),
                    // right(i, j), top(i, j),
                    // bottom(i, j)
                    int len = Math.Min(Math.Min(top[i, j],
                        bottom[i, j]), Math.Min(left[i, j],
                                            right[i, j]));

                    // largest + would be formed by a
                    // cell that has maximum value
                    if (len > n)
                        n = len;
                }
            }

            // 4 directions of length n - 1 and 1 for
            // middle cell
            if (n > 0)
                return 4 * (n - 1) + 1;

            // matrix contains all 0's
            return 0;
        }

        /* Driver function to test above functions */
        public static void Main()
        {

            // Binary Matrix of size N
            int[,] mat = {
            { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
            { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1 },
            { 1, 1, 1, 0, 1, 1, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
            { 1, 1, 1, 0, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            { 1, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 1, 0, 1, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 0, 1, 0, 0 }
        };

            Console.Write(findLargestPlus(mat));
            /*
             Output: 17
Time complexity of above solution is O(n2).
Auxiliary space used by the program is O(n2).
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/find-the-maximum-sum-of-plus-shape-pattern-in-a-2-d-array/
    Find the maximum sum of Plus shape pattern in a 2-D array
Difficulty Level : Medium
Last Updated : 17 May, 2021
Given a 2-D array of size N*M where, 3\leq N, M \leq 1000  . The task is to find the maximum value achievable by a + shaped pattern. The elements of the array can be negative.
The plus(+) shape pattern is formed by taking any element with co-ordinate (x, y) as a center and then expanding it in all four directions(if possible). 
A plus(+) shape has atleast five elements which are { (x-1, y), (x, y-1), (x, y), (x+1, y), (x, y+1) } i.e. the arms should have length>1 but not necessarily need to have same length.
Examples: 
 

Input: N = 3, M = 4
       1 1 1 1
      -6 1 1 -4
       1 1 1 1
Output: 0
Here, (x, y)=(2, 3) center of pattern(+).
Other four arms are, left arm = (2, 2), right arm = (2, 4), 
up arm = (1, 3), down arm = (2, 3).
Hence sum of all elements are ( 1 + 1 + (-4) + 1 + 1 ) = 0.

Input: N = 5, M = 3
       1 2 3
      -6 1 -4
       1 1 1
       7 8 9
       6 3 2
Output: 31
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: This problem is an application of the standard Largest Sum Contiguous Subarray.
We quickly pre-compute the maximum contiguous sub-sequence (subarray) sum for each row and column, in 4 directions, namely, Up, Down, Left and Right. This can be done using the standard Maximum contiguous sub-sequence sum of a 1-D array.
We make four 2-D array’s 1 for each direction. 
 



up[i][j]– Maximum sum contiguous sub-sequence of elements in upward direction, from rows 1, 2, 3, …, i More formally, it represents the maximum sum obtained by adding a contiguous sub-sequence of elements from list of arr[1][j], arr[2][j], …, arr[i][j]
down[i][j] -Maximum sum contiguous sub-sequence of elements in downward direction, from rows i, i+1, i+2,,…, N More formally, it represents the maximum sum obtained by adding a contiguous sub-sequence of elements from list of arr[i][j], arr[i+1][j], …, arr[N][j]
left[i][j]– Maximum sum contiguous sub-sequence of elements in left direction, from columns 1, 2, 3, …, j More formally, it represents the maximum sum obtained by adding a contiguous sub-sequence of elements from list of arr[i][1], arr[i][2], …, arr[i][j]
right[i][j]– Maximum sum contiguous sub-sequence of elements in right direction, from columns j, j+1, j+2, …, M More formally, it represents the maximum sum obtained by adding a contiguous sub-sequence of elements from list of arr[i][j], arr[i][j+1], …, arr[i][M]
All that’s left is, to check each cell as a possible center of the + and use pre-computed data to find the value achieved by + shape in O(1). 
Ans_{i, j} = up[i-1][j] + down[i+1][j] + left[i][j-1]+right[i][j+1]+arr[i][j]_{adding\;the\;value\;at \;center\; of\; +}  
Below is the implementation of above approach:
     */
    public class PlusSign
    {
        public static int N = 100;

        public static int n = 3, m = 4;

        // Function to return maximum Plus value
        public static int maxPlus(int[,] arr)
        {

            // Initializing answer with the minimum value
            int ans = int.MinValue;

            // Initializing all four arrays
            int[,] left = new int[N, N];
            int[,] right = new int[N, N];
            int[,] up = new int[N, N];
            int[,] down = new int[N, N];

            // Initializing left and up array.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    left[i, j] = Math.Max(0, ((j != 0) ? left[i, j - 1] : 0))
                                                     + arr[i, j];
                    up[i, j] = Math.Max(0, ((i != 0) ? up[i - 1, j] : 0))
                                                      + arr[i, j];
                }
            }

            // Initializing right and down array.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    right[i, j] = Math.Max(0, (j + 1 == m ? 0 : right[i, j + 1]))
                                                                    + arr[i, j];
                    down[i, j] = Math.Max(0, (i + 1 == n ? 0 : down[i + 1, j]))
                                                                    + arr[i, j];
                }
            }

            // calculating value of maximum Plus (+) sign
            for (int i = 1; i < n - 1; ++i)
                for (int j = 1; j < m - 1; ++j)
                    ans = Math.Max(ans, up[i - 1, j] + down[i + 1, j]
                                + left[i, j - 1] + right[i, j + 1] + arr[i, j]);

            return ans;
        }

        // Driver code
        static void Main()
        {
            int[,] arr = new int[,]{ { 1, 1, 1, 1 },
                      { -6, 1, 1, -4 },
                      { 1, 1, 1, 1 } };

            // Function call to find maximum value
            Console.Write(maxPlus(arr));
            /*
             Output: 0

Time Complexity: O(N2)
            */
        }
    }

}
