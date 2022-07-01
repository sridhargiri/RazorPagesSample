using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
 singapore company 4 questions (codingame)
    1. find frequencies of words in an arry sorted alphabetically
    2. find the number closest to zero in an array
    3. find the sum of pairs for given k
    4. find sum of multiples of 3 or 5 or 7 less than n
    https://www.geeksforgeeks.org/sum-of-all-the-multiples-of-3-and-7-below-n/
    Sum of all the multiples of 3 and 7 below N
    Given a number N, the task is to find the sum of all the multiples of 3 and 7 below N. 
Note: A number must not repeat itself in the sum.

Examples:  

Input: N = 10 
Output: 25 
3 + 6 + 7 + 9 = 25

Input: N = 24 
Output: 105 
3 + 6 + 7 + 9 + 12 + 14 + 15 + 18 + 21 = 105 
    Approach:  

We know that multiples of 3 form an AP as S3 = 3 + 6 + 9 + 12 + 15 + 18 + 21 + …
And the multiples of 7 form an AP as S7 = 7 + 14 + 21 + 28 + …
Now, Sum = S3 + S7 i.e. 3 + 6 + 7 + 9 + 12 + 14 + 15 + 18 + 21 + 21 + …
From the previous step, 21 is repeated twice. In fact, all of the multiples of 21 (or 3*7) will be repeated as they are counted twice, once in the series S3 and again in the series S7. So, the multiples of 21 need to be discarded from the result.
So, the final result will be S3 + S7 – S21
    The formula for the sum of an AP series is : 
n * ( a + l ) / 2 
Where n is the number of terms, a is the starting term, and l is the last term. 
    approach:
     */
    public class MultipleSum
    {

        // Function to find sum of AP series
        static long sumAP(long n, long d)
        {
            // Number of terms
            n /= d;

            return (n) * (1 + n) * d / 2;
        }

        // Function to find the sum of all
        // multiples of 3 and 7 below N
        static long sumMultiples(long n)
        {
            // Since, we need the sum of
            // multiples less than N
            n--;

            return sumAP(n, 3) + sumAP(n, 7) -
                                 sumAP(n, 21);
        }

        // Driver code
        static public void Main(String[] args)
        {
            long n = 24;
            Console.WriteLine(sumMultiples(n));
            /*
             Output: 105
 

Time complexity: O(1)

Auxiliary Space: O(1)
            */
        }
    }
}
