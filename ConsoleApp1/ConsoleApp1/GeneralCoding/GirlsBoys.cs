using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Place N boys and M girls in different rows such that count of persons placed in each row is maximized
Last Updated : 10 Mar, 2021
Given two integers N and M representing the number of boys and girls, the task is to arrange them in number of different rows of same size such that each row contains the maximum number of students possible and each row should contain either boys or girls.
Note: No row can contain both boys and girls.

Example:

Input: N = 4, M = 2
Output: 2
Explanation:
The following order of arrangement satisfies the given conditions:
1st Row: B1, B2 
2nd Row: B3, B4
3rd Row: G1, G2
Clearly, every row has either boys or girls.

Input: N = 6, M = 6
Output: 6
Explanation:
The following order of arrangement satisfies the given conditions:
1st Row: B1, B2, B3, B4, B5, B6
2nd Row: G1, G2, G3, G4, G5, G6

Approach: Follow the steps below to solve the problem 

Since each row can contain either boys or girls and size of all rows must be same, the most optimal arrangement possible is by placing greater common divisor of (N, M) number of elements in each row.
Therefore, print GCD(N, M) as the required answer.
Below is the implementation of the above approach:
    */
    class GirlsBoys
    {
        static int gcd(int a, int b)
        {
            if (b == 0)
                return a;

            return gcd(b, a % b);
        }

        // Function to count maximum persons 
        // that can be placed in a row 
        static int maximumRowValue(int n, int m) { return gcd(n, m); }

        // Driver Code 
        static void main()
        {
            // Input 
            int N = 4;
            int M = 2;

            // Function to count maximum 
            // persons that can be placed in a row 
            Console.WriteLine(maximumRowValue(N, M));
        }
        //        Output:
        //2
        //Time Complexity: O(log N)
        //Auxiliary Space: O(1)
    }
}
