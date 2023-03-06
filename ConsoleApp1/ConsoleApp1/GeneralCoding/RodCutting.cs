using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/cutting-a-rod-dp-13/
    Given a rod of length n inches and an array of prices that includes prices of all pieces of size smaller than n. Determine the maximum value obtainable by cutting up the rod and selling the pieces. For example, if the length of the rod is 8 and the values of different pieces are given as the following, then the maximum obtainable value is 22 (by cutting in two pieces of lengths 2 and 6) 

length   | 1   2   3   4   5   6   7   8  
--------------------------------------------
price    | 1   5   8   9  10  17  17  20
And if the prices are as follows, then the maximum obtainable value is 24 (by cutting in eight pieces of length 1) 

length   | 1   2   3   4   5   6   7   8  
--------------------------------------------
price    | 3   5   8   9  10  17  17  20
    Method 1: A naive solution to this problem is to generate all configurations of different pieces and find the highest-priced configuration. 
    This solution is exponential in terms of time complexity. 
    Let us see how this problem possesses both important properties of a Dynamic Programming (DP) Problem and can efficiently be solved using Dynamic Programming.

1) Optimal Substructure: 


We can get the best price by making a cut at different positions and comparing the values obtained after a cut. 
    We can recursively call the same function for a piece obtained after a cut.
Let cutRod(n) be the required (best possible price) value for a rod of length n. cutRod(n) can be written as follows.
cutRod(n) = max(price[i] + cutRod(n-i-1)) for all i in {0, 1 .. n-1}
     */
    public class RodCutting
    {
        static int max(int a, int b)
        {
            if (a > b) return a;
            return b;
        }

        static int MIN_VALUE = -1000000000;

        /* Returns the best obtainable price for a rod of
        // length n and price[] as prices of different pieces */
        static int cutRod(int[] price, int index, int n)
        {
            // base case
            if (index == 0)
            {
                return n * price[0];
            }
            // At any index we have 2 options either
            // cut the rod of this length or not cut it
            int notCut = cutRod(price, index - 1, n);
            int cut = MIN_VALUE;
            int rod_length = index + 1;

            if (rod_length <= n)
                cut = price[index] + cutRod(price, index, n - rod_length);

            return max(notCut, cut);
        }

        // Driver program to test above functions
        public static void Main(string[] args)
        {
            int[] arr = { 1, 5, 8, 9, 10, 17, 17, 20 };
            int size = arr.Length;
            Console.WriteLine("Maximum Obtainable Value is " + cutRod(arr, size - 1, size));
            /*
             Output
Maximum Obtainable Value is 22
            */
        }
    }
}
