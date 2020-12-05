using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
You are given with an array A of size N.An element Ai is said to be charged if its value(Ai) is greater than or equal to Ki. Ki is the 
total number of subsets of array A, that consist of element Ai. 
Total charge value of the array is defined as summation of all charged elements present in the array mod 109+7.
Your task is to output the total charge value of the given array A.

INPUT FORMAT:

The first line of input contains number of test cases T.
The first line of each test case consists of N, the size of the array.
Next line contains N space-separated integers corresponding to each element Ai.

OUTPUT FORMAT:

For each test case, output a single number corresponding to total charge value of the given array.

CONSTRAINTS:
1≤T≤1001≤N≤1050≤Ai≤1018

SAMPLE INPUT 
2
3
3 4 5
2
1 6
SAMPLE OUTPUT 
9
6
Explanation

CASE 1:
Possible subsets are: {3}, {4}, {5}, {3,4}, {3,5}, {4,5}, {3,4,5}, {}.
Element 3 is present in 4 subsets. As 3<4, it is not charged.
Element 4 is present in 4 subsets. As 4>=4, it is charged.
Element 5 is present in 4 subsets. As 5>=4, it is charged.
Total charge=4+5=9

CASE 2:
Possible subsets are: {1}, {6}, {1,6}, {}.
Element 1 is present in 2 subsets. As 1<2, it is not charged.
Element 6 is present in 2 subsets. As 6>=2, it is charged.
Total charge=6

*/
    class HackerearthChargedUpArray
    {
        static void Main(string[] args)
        {
            const long m = 1000000007;
            long[] a = null;
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                long s = 0; long n = 0;
                n = int.Parse(Console.ReadLine());
                a = Console.ReadLine().Split(' ').Select(n1 => long.Parse(n1)).ToArray();
                for (int j = 0; j < n; j++)
                {
                    if (a[j] >= Math.Pow(2, n - 1))
                        s = (s + a[j]) % m;
                }

                Console.WriteLine(s);
            }
        }
    }
}
