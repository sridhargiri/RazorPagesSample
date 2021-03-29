using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/maximum-difference-zeros-ones-binary-string/
    Maximum difference of zeros and ones in binary string
Difficulty Level : Medium
Last Updated : 11 Jan, 2019
Given a binary string of 0s and 1s. The task is to find the length of substring which is having maximum difference of number of 0s and number of 1s (number of 0s – number of 1s). In case of all 1s print -1.

Examples:

Input : S = "11000010001"
Output : 6
From index 2 to index 9, there are 7
0s and 1 1s, so number of 0s - number
of 1s is 6.

Input : S = "1111"
Output : -1
Recommended: Please solve it on PRACTICE first, before moving on to the solution.
The idea is to use Dynamic Programming to solve the problem.
Before that we will convert given binary string into integer array of value 1s and -1s, say arr[]. That can be easily done by traversing the given binary string and if ith index contain ‘0’ make -1 in corresponding position in array. Similarly, if ith index contain ‘1’, make 1 in the array.
Now, at each index i we need to make decision whether to take it or skip it. So, declare a 2D array of size n x 2, where n is the length of the given binary string, say dp[n][2].

dp[i][0] define the maximum value upto 
         index i, when we skip the i-th
         index element.
dp[i][1] define the maximum value upto 
         index i after taking the i-th
         index element.

Therefore, we can derive dp[i][] as:
dp[i][0] = max(dp[i+1][0], dp[i+1][1] + arr[i])
dp[i][1] = max(dp[i+1][1] + arr[i], 0)
For all ones we check this case explicitly.
    */
    class BinaryStringMaxDiff
    {
        static int MAX = 100;

        // Return true if there all 1s 
        public static bool allones(string s, int n)
        {
            // Checking each index is 0 or not. 
            int co = 0;
            for (int i = 0; i < s.Length; i++)
                co += (s[i] == '1' ? 1 : 0);

            return (co == n);
        }

        // Find the length of substring with maximum 
        // difference of zeroes and ones in binary 
        // string 
        public static int findlength(int[] arr, string s,
                        int n, int ind, int st, int[,] dp)
        {
            // If string is over. 
            if (ind >= n)
                return 0;

            // If the state is already calculated. 
            if (dp[ind, st] != -1)
                return dp[ind, st];

            if (st == 0)
                return dp[ind, st] = Math.Max(arr[ind] +
                findlength(arr, s, n, ind + 1, 1, dp),
                findlength(arr, s, n, ind + 1, 0, dp));

            else
                return dp[ind, st] = Math.Max(arr[ind] +
            findlength(arr, s, n, ind + 1, 1, dp), 0);
        }

        // Returns length of substring which is 
        // having maximum difference of number 
        // of 0s and number of 1s 
        public static int maxLen(string s, int n)
        {
            // If all 1s return -1. 
            if (allones(s, n))
                return -1;

            // Else find the length. 
            int[] arr = new int[MAX];

            for (int i = 0; i < n; i++)
                arr[i] = (s[i] == '0' ? 1 : -1);

            int[,] dp = new int[MAX, 3];
            for (int i = 0; i < MAX; i++)
                for (int j = 0; j < 3; j++)
                    dp[i, j] = -1;

            return findlength(arr, s, n, 0, 0, dp);
        }
        /*
         In the post we seen an efficient method that work in O(n) time and in O(1) extra space. Idea behind that if we convert all zeros into 1 and all ones into -1.now our problem reduces to find out the maximum sum sub_array Using Kadane’s Algorithm.

https://www.geeksforgeeks.org/maximum-difference-zeros-ones-binary-string-set-2-time/


Input : S = "11000010001"
     After converting '0' into 1 and
     '1' into -1 our S Look Like
      S  = -1 -1 1 1 1 1 -1 1 1 1 -1
 Now we have to find out Maximum Sum sub_array 
 that is  : 6 is that case 
    
Output : 6
        */
        public static int findLength(string str,
                             int n)
        {

            int current_sum = 0;
            int max_sum = 0;

            // traverse a binary string 
            // from left to right 
            for (int i = 0; i < n; i++)
            {

                // add current value to the current_sum 
                // according to the Character 
                // if it's '0' add 1 else -1 
                current_sum += (str[i] == '0' ? 1 : -1);

                if (current_sum < 0)
                {
                    current_sum = 0;
                }

                // update maxium sum 
                max_sum = Math.Max(current_sum, max_sum);
            }
            // return -1 if string does not contain 
            // any zero that means string contains 
            // all ones otherwise max_sum 
            return max_sum == 0 ? -1 : max_sum;
        }
        static void Main()
        {
            string s = "11000010001";
            int n = 11;
            Console.Write(maxLen(s, n));

            string str = "11000010001";
            n = str.Length;

            Console.WriteLine(findLength(str, n));
        }
        // op 6

        //        Time Complexity : O(n)
        //Space complexity : O(1)
    }
}
