using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    /*
     https://www.hackerrank.com/challenges/sock-merchant/problem
    socks merchant problemk hackerrank
    There is a large pile of socks that must be paired by color. Given an array of integers representing the color of each sock, determine how many pairs of socks with matching colors there are.

Example
    n=7 arr={1,2,1,2,1,3,2}
    There is one pair of color  and one of color . There are three odd socks left, one of each color. The number of pairs is .

Function Description

Complete the sockMerchant function in the editor below.

sockMerchant has the following parameter(s):

int n: the number of socks in the pile
int ar[n]: the colors of each sock
Returns

int: the number of pairs
Input Format

The first line contains an integer n, the number of socks represented in .
The second line contains n space-separated integers,ar[i] , the colors of the socks in the pile.

Constraints - 1<n<1000
    Sample Input

STDIN                       Function
-----                       --------
9                           n = 9
10 20 20 10 10 30 50 10 20  ar = [10, 20, 20, 10, 10, 30, 50, 10, 20]
    sample output - 3
    10<->10,10<->10,20<->20,50,30,20 so 3 pairs
     */
    class Socks
    {
        static void SocksMerchant()
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Array.Sort(A);
            int ans = 0;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] == A[i - 1])
                {
                    ans++;
                    i++;
                }
            }
            Console.WriteLine(ans);
        }
        /*
         * https://www.techrbun.com/sock-merchant-hacker-rank/
         Question
In this question, we are given an array of integers, where each number represents a particular colour of socks. We need to count how many pairs of socks are present, such that two socks of the same colour form a pair.

It is also mentioned that the highest number of distinct colours in the given array is 100.

Explanation
Let us take the following example:-

Suppose, the input is {1,2,5,1,1,5}
Where, 1=Green, 2=Purple, and 5=Yellow.

So, 3 Green, 2 Yellow, 1 purple

Sock Merchant Hacker Rank
As we know, a pair consists of two same coloured socks. Thus, to find the number of pairs of a particular colour of socks, we can simply divide the number of socks of that colour by 2.

Thus on counting, we find that:
        We have 3 green socks, 1 purple sock and 2 yellow socks.

Now we perform integer division to find the number of pairs of socks of each colour.

No. of pairs of green socks= 3/2=1.
No. of pairs of purple socks=1/2=0.
No. of pairs of yellow socks=2/2=1.

Thus, the final answer would be 1+0+1=2.
       Solution
We will count the number of each sock of each colour using a frequency array, in O(n) time complexity.

We declare a frequency array of size 101. Thus, it will have indices starting from 0 to 100, which is exactly what we want, as the maximum number of distinct colours is 100.
 Now we traverse the array using a linear for-loop. For every element, we increment the value of that index of the frequency array, which is the same value as the integer value representing the colour. This operation also takes O(n) time.

So, the total time complexity of this solution is O(n).

Thus in the above example {1,2,5,1,1,5}, the for-loop operations can be visualised as:

Array Element	Operation On Frequency Array (f)
1	f(1)=f(1)+1=0+1=1
2	f(2)=f(2)+1=0+1=1
5	f(5)=f(5)+1=0+1=1
1	f(1)=f(1)+1=1+1=2
1	f(1)=f(1)+1=2+1=3
5	f(5)=f(5)+1=1+1=2
After the for-loop has run, we get the updated frequency array as:


f(0)=0
f(1)=3
f(2)=1
f(3)=0
f(4)=0
f(5)=2
….(All the remaning elements are 0).

Now, divide the frequency of each colour of sock by 2 and add the results to a variable ‘c’.

At the start, c=0.

Array Element	Value of ‘c’
f(0)=0	c = c+f(0)/2 = 0+0/2 = 0+0 = 0
f(1)=3	c = c+f(1)/2 = 0+3/2 = 0+1 = 1
f(2)=1	c = c+f(2)/2 = 1+1/2 = 1+0 = 1
f(3)=0	c = c+f(3)/2 = 1+0/2 = 1+0 = 1
f(4)=0	c = c+f(4)/2 = 1+0/2 = 1+0 = 1
f(5)=2	c = c+f(5)/2 = 1+2/2 = 1+1 = 2
Thus, the total number of pairs of socks is stored in c (=2).

So, we finally return c.       
         */
        static void SocksMerchant_TechRBun(int[] arr)
        {
            int[] f = new int[101]; int c = 0; int i = 0;
            //filling up the frequency array

            for (i = 0; i < arr.Length; i++)
                f[arr[i]]++;

            //counting the total number of pairs

            for (i = 1; i <= 100; i++)
                c += f[i] / 2;
            Console.WriteLine(c);
        }
        static void Main(String[] args)
        {

            /*
            before sort:
            ar = [10, 20, 20, 10, 10, 30, 50, 10, 20]
            after sort:
            ar = [10, 10, 10, 10, 20, 20, 20, 30, 50]
            */
            int[] ar = new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
            //SocksMerchant();
            SocksMerchant_TechRBun(ar);
        }
    }
    /*
    https://www.geeksforgeeks.org/minimum-number-of-socks-required-to-picked-to-have-at-least-k-pairs-of-the-same-color/
    Minimum number of socks required to picked to have at least K pairs of the same color
Last Updated : 21 Apr, 2021
Given an array arr[] consisting of N integers such that arr[i] representing the number of socks of the color i and an integer K, the task is to find the minimum number of socks required to be picked to get at least K pairs of socks of the same color.

Examples:

Input: arr[] = {3, 4, 5, 3}, K = 6
Output: 15
Explanation: One will need to pick all the socks to get at least 6 pairs of matching socks.

Input: arr[] = {4, 5, 6}, K = 3
Output: 8

Approach: The given problem can be solved based on the following observations: 



According to Pigeonhole’s Principle i.e., in the worst-case scenario if N socks of different colors have been picked then the next pick will form a matching pair of socks.
Suppose one has picked N socks of different colors then, for each (K – 1) pairs one will need to pick two socks, one for forming a pair and another for maintaining N socks of all different colors, and for the last pair, there is only need to pick a single sock of any color available.
Therefore, the idea is to find the total number of pairs that can be formed by the same colors and if the total count is at most K then print (2*K + N – 1) as the minimum count of pairs to be picked. Otherwise, print “-1” as there are not enough socks to formed K pairs.

Below is the implementation of the above approach:
    
     */
    class SocksPairs
    {

        // Function to count the minimum
        // number of socks to be picked
        public static int findMin(
            int[] arr, int N, int k)
        {
            // Stores the total count
            // of pairs of socks
            int pairs = 0;

            // Find the total count of pairs
            for (int i = 0; i < N; i++)
            {
                pairs += arr[i] / 2;
            }

            // If K is greater than pairs
            if (k > pairs)
                return -1;

            // Otherwise
            else
                return 2 * k + N - 1;
        }

        // Driver Code
        public static void main(String[] args)
        {
            int[] arr = { 4, 5, 6 };
            int K = 3;
            Console.WriteLine(findMin(arr, arr.Length, K));
            /*
             Output:
8
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}