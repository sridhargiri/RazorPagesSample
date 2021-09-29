using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     An avid hiker keeps meticulous records of their hikes. During the last hike that took exactly  steps, for every step it was noted if it was an uphill, , or a downhill,  step. Hikes always start and end at sea level, and each step up or down represents a  unit change in altitude. We define the following terms:
  •	A mountain is a sequence of consecutive steps above sea level, starting with a step up from sea level and ending with a step down to sea level.
  •	A valley is a sequence of consecutive steps below sea level, starting with a step down from sea level and ending with a step up to sea level.
  Given the sequence of up and down steps during a hike, find and print the number of valleys walked through.
  Example

  The hiker first enters a valley  units deep. Then they climb out and up onto a mountain  units high. Finally, the hiker returns to sea level and ends the hike.
  Function Description
  Complete the countingValleys function in the editor below.
  countingValleys has the following parameter(s):
  •	int steps: the number of steps on the hike
  •	string path: a string describing the path
  Returns
  •	int: the number of valleys traversed
  Input Format
  The first line contains an integer , the number of steps in the hike.
  The second line contains a single string , of  characters that describe the path.
  Constraints
  •	
  •	
  Sample Input
  8
  UDDDUDUU
  Sample Output
  1
  Explanation
  If we represent _ as sea level, a step up as /, and a step down as \, the hike can be drawn as:
  _/\      _
     \    /
      \/\/
  The hiker enters and leaves one valley.
https://www.hackerrank.com/challenges/counting-valleys/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=7-day-campaign
     */
    public class CountingValley
    {
        public static void countValleyHackerrank(String str)
        {
            int currLevel = 0;
            int valley = 0;
            bool isFound = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'U')
                {
                    currLevel++;
                }
                else
                {
                    currLevel--;
                }
                if (currLevel < 0)
                {
                    isFound = true;
                }
                if (currLevel >= 0 && isFound)
                {
                    isFound = false;
                    valley++;
                }
            }
            Console.WriteLine(valley);
        }
        static void Main(string[] args)
        {
            string s = "UDDDUDUU";
            countValleyHackerrank(s);
        }
    }
    /*
Equalize the Array
Given an array of integers, determine the minimum number of elements to delete to leave only elements of equal value.

Example Arr = [1,2,2,3]

Delete the 2 elements 1 and 3 leaving arr=[2,2]. If both twos plus either the 1 or 3  are deleted, it takes 3 deletions to leave either [3] or [1]. The minimum number of deletions is 2.
https://www.geeksforgeeks.org/equalize-array-using-array-elements/
    Equalize an array using array elements only
Difficulty Level : Medium
Last Updated : 24 May, 2021
Given an array of integers, the task is to count minimum number of operations to equalize the array (make all array elements same). And return -1 if it is not possible to equalize. To equalize an array, we need to move values from higher numbers to smaller numbers. Number of operations is equal to number of movements.
Examples : 
 

Input :  arr[] = {1, 3, 2, 0, 4}
Output : 3
We can equalize the array by making value
of all elements equal to 2. To achieve this
we need to do minimum 3 operations (moving
Moving 1 value from arr[1] to arr[0]
Moving 2 values from arr[4] to arr[3]

Input : arr[] = {1, 7, 1}
Output : 4 
 

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
Method 1 (Simple): First one is brute force approach in which we fix an element and then check for the neighboring elements and then borrow (or give) the required amount of operation. In this approach, we will be needing two loops first one would be used for fixing the elements of the array and the second one would be used to check whether the other neighbors of the present element are able to give them their contribution in equalizing the array. Time complexity of this solution is O(n2);
Method 2 (Efficient): 
1) Find the sum array elements. If sum % n is not 0, return -1. 
2) Compute average or equalized value as eq = sum/n 
3) Traverse the array. For every element arr[i] compute absolute value of difference between eq and arr[i]. And keep track of sum of these differences. Let this sum be diff_sum. 
4) Return diff_sum / 2. 
    */
    class EqualizeArray
    {

        // Returns minimum operations needed to
        // equalize an array.
        static int minOperations(int[] arr, int n)
        {
            // Compute sum of array elements
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += arr[i];

            // If average of array is not integer,
            // then it is not possible to equalize
            if (sum % n != 0)
                return -1;

            // Compute sum of absolute differences
            // between array elements and average
            // or equalized value
            int diff_sum = 0;
            int eq = sum / n;
            for (int i = 0; i < n; i++)
                diff_sum += Math.Abs(arr[i] - eq);

            return (diff_sum / 2);
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 5, 3, 2, 6 };
            int n = arr.Length;
            Console.WriteLine(minOperations(arr, n));
        }
        //op 3
    }
    /*
     https://www.geeksforgeeks.org/range-sum-queries-without-updates/
    Range sum queries without updates
Difficulty Level : Medium
Last Updated : 04 Aug, 2021
Given an array arr of integers of size n. We need to compute the sum of elements from index i to index j. The queries consisting of i and j index values will be executed multiple times.

Examples: 

Input : arr[] = {1, 2, 3, 4, 5}
        i = 1, j = 3
        i = 2, j = 4
Output :  9
         12         

Input : arr[] = {1, 2, 3, 4, 5}
        i = 0, j = 4 
        i = 1, j = 2 
Output : 15
          5

A Simple Solution is to compute the sum for every query.

An Efficient Solution is to precompute prefix sum. Let pre[i] stores sum of elements from arr[0] to arr[i]. To answer a query (i, j), we return pre[j] – pre[i-1].

Below is the implementation of the above approach:
     */
    public class RangeSumQuery
    {
        public static void preCompute(int[] arr, int n,
                                      int[] pre)
        {
            pre[0] = arr[0];
            for (int i = 1; i < n; i++)
                pre[i] = arr[i] + pre[i - 1];
        }

        // Returns sum of elements in
        // arr[i..j]
        // It is assumed that i <= j
        public static int rangeSum(int i, int j, int[] pre)
        {
            if (i == 0)
                return pre[j];

            return pre[j] - pre[i - 1];
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int n = arr.Length;

            int[] pre = new int[n];

            // Function call
            preCompute(arr, n, pre);
            Console.WriteLine(rangeSum(1, 3, pre));
            Console.WriteLine(rangeSum(2, 4, pre));
        }
        /*
         Output
9
12
Here time complexity of every range sum query is O(1) and the overall time complexity is O(n).

The question becomes complicated when updates are also allowed. In such situations when using advanced data structures like Segment Tree or Binary Indexed Tree.
        https://www.geeksforgeeks.org/segment-tree-set-1-sum-of-given-range/
        https://www.geeksforgeeks.org/binary-indexed-tree-or-fenwick-tree-2/
         */
    }
    /*
     https://www.geeksforgeeks.org/find-subfactorial-of-a-number/
    Find subfactorial of a number
Last Updated : 29 Sep, 2021
Given an integer N, the task is to find the subfactorial of the number represented as !N. The subfactorial of a number is defined using below recurrence relation of a number N:

!N = (N-1) [ !(N-2) + !(N-1) ]

where !1 = 0 and !0 = 1

Some of the subfactorials are:

n	0	1	2	3	4	5	6	7	8	9	10	11	12	13
!n	1	0	1	2	9	44	265	1, 854	14, 833	133, 496	1, 334, 961	14, 684, 570	176, 214, 841	2, 290, 792, 932
Examples:



Input: N = 4
Output: 9
Explanation: 
!4 = !(4-1)*4 + (-1)4 = !3*4 + 1
!3 = !(3 – 1)*3 + (-1)3 = !2*3 – 1
!2 = !(2 – 1)*2 + (-1)2 = !1*2 + 1
!1 = !(1 – 1)*1 + (-1)1 = !0*1 – 1
Since !0 = 1, therefore !1 = 0, !2 = 1, !3 = 2 and !4 = 9. 

Input: N = 0
Output: 1

 
Approach: The subfactorial of the number N can also be calculated as:

{\displaystyle !n={\begin{cases}1&{\text{if }}n=0, \\n\left(!(n-1)\right)+(-1)^{n}&{\text{if }}n>0.\end{cases}}}

Expanding this gives

{\displaystyle !n=\sum _{i=0}^{n-1}i(!i)+{\frac {1+(-1)^{n}}{2}}}

=> !N = ( N! )*( 1 – 1/(1!) + (1/2!) – (1/3!)  …….. (1/N!)*(-1)N )

Therefore the above series can be used to find the subfactorial of number N. Follow the steps below to see how:

Initialize variables, say res = 0, fact = 1 and count = 0.
Iterate over the range from 1 to N using i and do the following:
Update fact as fact*i.
If the count is even then update res as res = res – (1 / fact).
If the count is odd then update res as res = res + (1 / fact).
Increase the value of count by 1.
Finally, return fact*(1 + res).
Below is the implementation of the above approach:
     */
    public class SubFactorial
    {
        static double Subfactorial(int N)
        {

            // Initialize variables
            double res = 0, fact = 1;
            int count = 0;

            // Iterating over range N
            for (int i = 1; i <= N; i++)
            {

                // Fact variable store
                // factorial of the i
                fact = fact * i;

                // If count is even
                if (count % 2 == 0)
                    res = res - (1 / fact);
                else
                    res = res + (1 / fact);

                // Increase the value of
                // count by 1
                count++;
            }
            return fact * (1 + res);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Subfactorial(4));
            /*
             Output
9
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/check-if-its-possible-to-completely-fill-every-container-with-same-ball/
    Check if it’s possible to completely fill every container with same ball
Last Updated : 29 Sep, 2021
Given two arrays, arr[ ] C of containers and arr[ ] B of balls, the task is to find if it’s possible to completely fill every container with the given balls, if each container can only store balls of the same type. In array C, C[i] stores the maximum number of balls that the i-th container can store. In array B, B[i] stores the type of the i-th ball.

Examples:

Input: C = [1, 2, 3], B = [1, 2, 2, 2, 3, 3, 4, 4, 4]
Output: YES
Explanation: fill first container with ball 1, second with 2 balls with number 3 and third container with ball having number 2

Input: C = [2], B = [1, 2, 3]
Output: NO
Explanation: there’s no possible combination to fill the containers

Approach: The idea is to use Backtracking to check if it’s possible to fill every container or not. It can be observed that there is only a need for the frequency of each type of ball, so we store the frequency of each type of balls in a map. Lets look at the steps involved in implementation of our approach:

Store the frequency of the same type of balls in a map.
Call the function getans to check if its possible to fill the containers.
Try to fill the container with balls whose frequency is more that equal to the container’s capacity. If its possible return true else backtrack and check for other balls.
If no combination exists return false.
Below is the implementation of the above approach.
     */
    public class BallsContainer
    {
        static bool getans(int i, List<int> v, List<int> q)
        {
            // Base Case
            if (i == q.Count)
                return true;

            // Backtracking
            for (int j = 0; j < v.Count; j++)
            {
                if (v[j] >= q[i])
                {
                    v[j] -= q[i];
                    if (getans(i + 1, v, q))
                    {
                        return true;
                    }
                    v[j] += q[i];
                }
            }
            return false;
        }
        // Fucntion to check the conditions
        static void SameBallsContainer(List<int> c, List<int> b)
        {

            // Storing frequencies
            Dictionary<int, int> m=new Dictionary<int, int> ();
            for (int i = 0; i < b.Count; i++)
            {
                if (!m.ContainsKey(b[i])) m.Add(b[i], 1); else m[b[i]]++;
            }
            List<int> v=new List<int> ();
            foreach (var i in m)
            {
                v.Add(i.Value);
            }

            // Function Call for backtracking
            bool check = getans(0, v, c);
            if (check)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
        static void Main(string[] args)
        {
            // Given Input
            List<int> c =new List<int> { 1, 3, 3 };
            List<int> b =new List<int>  { 2, 2, 2, 2, 4, 4, 4 };

            // Function Call
            SameBallsContainer(c, b);
        }
        /*
         Output:YES
Time Complexity: O(m^n), where n is the size of arr[ ] C and m is the size of arr[ ] B.
 
Auxiliary Space: O(m)
        */
    }
}
