using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.hackerrank.com/challenges/chocolate-feast/problem
    https://exploringbits.com/chocolate-feast-hackerrank-solution/
    Little Bobby loves chocolate. He frequently goes to his favorite 5 & 10 store, Penny Auntie, to buy them. They are having a promotion at Penny Auntie. If Bobby saves enough wrappers, he can turn them in for a free chocolate.

Example

n=15
c=3
m=2
He has 15 to spend, bars cost 3, and he can turn in 2 wrappers to receive another bar. Initially, he buys 5 bars and has 5 wrappers after eating them. He turns in 4 of them, leaving him with 1, for 2 more bars. After eating those two, he has 3 wrappers, turns in 2 leaving him with 1 wrapper and his new bar. Once he eats that one, he has wrappers and turns them in for another bar. After eating that one, he only has 1 wrapper, and his feast ends. Overall, he has eaten 5+2+1+1=9 bars.

Function Description

Complete the chocolateFeast function in the editor below.

chocolateFeast has the following parameter(s):

int n: Bobby’s initial amount of money
int c: the cost of a chocolate bar
int m: the number of wrappers he can turn in for a free bar
Returns

int: the number of chocolates Bobby can eat after taking full advantage of the promotion
Note: Little Bobby will always turn in his wrappers if he has enough to get a free chocolate.

Input Format

The first line contains an integer,t , the number of test cases to analyze.
Each of the next t lines contains three space-separated integers: n, c, and m. They represent money to spend, cost of a chocolate, and the number of wrappers he can turn in for a free chocolate.

Sample Input

STDIN Function
----- --------
3 t = 3 (test cases)
10 2 5 n = 10, c = 2, m = 5 (first test case)
12 4 4 n = 12, c = 4, m = 4 (second test case)
6 2 2 n = 6, c = 2, m = 2 (third test case)
Sample Output

6
3
5
     */
    class EmptyBarWrappers
    {
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine());
            for (int i = 0; i < cases; i++)
            {
                int res = 0;
                string[] temp = Console.ReadLine().Split(' ');
                int candies = int.Parse(temp[0]) / int.Parse(temp[1]);
                res += candies;
                int wrapper = res;
                while (wrapper >= int.Parse(temp[2]))
                {
                    int extra = wrapper / int.Parse(temp[2]);
                    wrapper %= int.Parse(temp[2]);
                    res += extra;
                    wrapper += extra;
                }
                Console.WriteLine(res);
            }
            Console.ReadLine();
        }
    }

    /*
     Attempt Service Lane HackerRank Challenge

Link – https://www.hackerrank.com/challenges/service-lane/

Next HackerRank Challenge Solution 

Link – https://exploringbits.com/lisas-workbook-hackerrank-solution/
    A driver is driving on the freeway. The check engine light of his vehicle is on, and the driver wants to get service immediately. Luckily, a service lane runs parallel to the highway. It varies in width along its length.

Paradise Highway
    You will be given an array of widths at points along the road (indices), then a list of the indices of entry and exit points. Considering each entry and exit point pair, calculate the maximum size vehicle that can travel that segment of the service lane safely.

Example
    n=4

width=[2,3,2,1]

cases=[[1,2],[2,4]]

If the entry index, i=1 and the exit, j=2 , there are two segment widths of 2 and 3 respectively. The widest vehicle that can fit through both is 2. If i=2 and j=4, the widths are [3,2,1] which limits vehicle width to 1.

Function Description

Complete the serviceLane function in the editor below.

serviceLane has the following parameter(s):

int n: the size of the width array
int cases[t][2]: each element contains the starting and ending indices for a segment to consider, inclusive
Returns

int[t]: the maximum width vehicle that can pass through each segment of the service lane described

Input Format

The first line of input contains two integers,n and t, where n denotes the number of width measurements and ,t the number of test cases. The next line has n space-separated integers which represent the array .

The next lines contain two integers, i and j, where i is the start index and j is the end index of the segment to check.

Sample Input

STDIN Function
----- --------
8 5 n = 8, t = 5
2 3 1 2 3 2 3 3 width = [2, 3, 1, 2, 3, 2, 3, 3]
0 3 cases = [[0, 3], [4, 6], [6, 7], [3, 5], [0, 7]]
4 6
6 7
3 5
0 7
Sample Output

1
2
3
2
1
Explanation

Below is the representation of the lane:

|HIGHWAY|Lane| -> Width

0: | |--| 2
1: | |---| 3
2: | |-| 1
3: | |--| 2
4: | |---| 3
5: | |--| 2
6: | |---| 3
7: | |---| 3

     */
    public class Lane
    {
        static void Main(string[] args)
        {
            var line1 = Console.ReadLine().Trim().Split();
            var N = Int32.Parse(line1[0]);
            var T = Int32.Parse(line1[1]);
            line1 = Console.ReadLine().Trim().Split();

            int[] w = new int[N];
            for (var i = 0; i < N; i++)
            {
                w[i] = int.Parse(line1[i]);
            }
            for (int i = 0; i < T; i++)
            {
                line1 = Console.ReadLine().Trim().Split();
                var a = int.Parse(line1[0]);
                var b = int.Parse(line1[1]);
                int min = int.MaxValue;
                for (int k = a; k <= b; k++)
                {
                    if (w[k] < min)
                    {
                        min = w[k];
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
