using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-if-a-string-is-interleaved-of-two-other-strings-dp-33/
    Three strings A, B, C are given. Check whether C contains all the characters of A and B and also in the same sequence as present in A and B
    Find if a string is interleaved of two other strings | DP-33
    Given three strings A, B and C. Write a function that checks whether C is an interleaving of A and B. C is said to be interleaving A and B, if it contains all and only characters of A and B and order of all characters in individual strings is preserved. 
    Input: strings: "XXXXZY", "XXY", "XXZ"
Output: XXXXZY is interleaved of XXY and XXZ
The string XXXXZY can be made by 
interleaving XXY and XXZ
String:    XXXXZY
String 1:    XX Y
String 2:  XX  Z

Input: strings: "XXY", "YX", "X"
Output: XXY is not interleaved of YX and X
XXY cannot be formed by interleaving YX and X.
The strings that can be formed are YXX and XYX

     Efficient Solution: Dynamic Programming. 
Approach: The above recursive solution certainly has many overlapping sub-problems. For example, if we consider A = “XXX”, B = “XXX” and C = “XXXXXX” and draw a recursion tree, there will be many overlapping subproblems. Therefore, like any other typical Dynamic Programming problems, we can solve it by creating a table and store results of sub-problems in a bottom-up manner. The top-down approach of the above solution can be modified by adding a Hash Map.

Algorithm: 

Create a DP array (matrix) of size M*N, where m is the size of the first string and n is the size of the second string. Initialize the matrix to false.
If the sum of sizes of smaller strings is not equal to the size of the larger string then return false and break the array as they cant be the interleaved to form the larger string.
Run a nested loop the outer loop from 0 to m and the inner loop from 0 to n. Loop counters are i and j.
If the values of i and j are both zeroes then mark dp[i][j] as true. If the value of i is zero and j is non zero and the j-1 character of B is equal to j-1 character of C the assign dp[i][j] as dp[i][j-1] and similarly if j is 0 then match i-1 th character of C and A and if it matches then assign dp[i][j] as dp[i-1][j].
Take three characters x, y, z as (i-1)th character of A and (j-1)th character of B and (i + j – 1)th character of C.
if x matches with z and y does not match with z then assign dp[i][j] as dp[i-1][j] similarly if x is not equal to z and y is equal to z then assign dp[i][j] as dp[i][j-1]
if x is equal to y and y is equal to z then assign dp[i][j] as bitwise OR of dp[i][j-1] and dp[i-1][j].
return value of dp[m][n].
    */
    class InterleavingString
    {

        // The main function that returns 
        // true if C is an interleaving of A 
        // and B, otherwise false.  
        static bool isInterleaved(string A, string B,
                                     string C)
        {

            // Find lengths of the two strings
            int M = A.Length, N = B.Length;

            // Let us create a 2D table to store
            // solutions of subproblems. C[i][j] 
            // will br true if C[0..i+j-1] is an
            // interleaving of A[0..i-1] and B[0..j-1].
            bool[,] IL = new bool[M + 1, N + 1];

            // IL is default initialised by false      
            // C can be an interleaving of A and B
            // only if the sum of lengths of A and B
            // is equal to length of C
            if ((M + N) != C.Length)
                return false;

            // Process all characters of A and B 
            for (int i = 0; i <= M; i++)
            {
                for (int j = 0; j <= N; j++)
                {

                    // Two empty strings have an
                    // empty strings as interleaving
                    if (i == 0 && j == 0)
                        IL[i, j] = true;

                    // A is empty
                    else if (i == 0)
                    {
                        if (B[j - 1] == C[j - 1])
                            IL[i, j] = IL[i, j - 1];
                    }

                    // B is empty
                    else if (j == 0)
                    {
                        if (A[i - 1] == C[i - 1])
                            IL[i, j] = IL[i - 1, j];
                    }

                    // Current character of C matches
                    // with current character of A, 
                    // but doesn't match with current
                    // character if B
                    else if (A[i - 1] == C[i + j - 1] &&
                             B[j - 1] != C[i + j - 1])
                        IL[i, j] = IL[i - 1, j];

                    // Current character of C matches
                    // with current character of B, but
                    // doesn't match with current
                    // character if A
                    else if (A[i - 1] != C[i + j - 1] &&
                             B[j - 1] == C[i + j - 1])
                        IL[i, j] = IL[i, j - 1];

                    // Current character of C matches
                    // with that of both A and B
                    else if (A[i - 1] == C[i + j - 1] &&
                             B[j - 1] != C[i + j - 1])
                        IL[i, j] = (IL[i - 1, j] ||
                                 IL[i, j - 1]);
                }
            }
            return IL[M, N];
        }

        // Function to run test cases
        static void interleave_test(string A, string B, string C)
        {
            if (isInterleaved(A, B, C))
                Console.WriteLine(C + " is interleaved of " +
                                   A + " and " + B);
            else
                Console.WriteLine(C + " is not interleaved of " +
                                   A + " and " + B);
        }

        // Driver code
        static void Main()
        {
            interleave_test("XXY", "XXZ", "XXZXXXY");
            interleave_test("XY", "WZ", "WZXY");
            interleave_test("XY", "X", "XXY");
            interleave_test("YX", "X", "XXY");
            interleave_test("XXY", "XXZ", "XXXXZY");
            /*
             Output: 

XXZXXXY is not interleaved of XXY and XXZ
WZXY is interleaved of XY and WZ
XXY is interleaved of XY and X
XXY is not interleaved of YX and X
XXXXZY is interleaved of XXY and XXZ
See this for more test cases.
Complexity Analysis: 

Time Complexity: O(M*N). 
Since a traversal of DP array is needed, so the time complexity is O(M*N).
Space Complexity: O(M*N). 
This is the space required to store the DP array.
https://youtu.be/WBXy-sztEwI 
            */
        }
    }

}
