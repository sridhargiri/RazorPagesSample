using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-the-single-digit-sum-of-alphabetical-values-of-a-string/
     Find the single digit sum of alphabetical values of a string
Last Updated : 08 Oct, 2021
Given string S of size N, the task is to find the single-digit sum by the repetitive sum of digits of the value obtained by the sum of order of all alphabets in the given string.

The order of alphabets is given by the position at which they occur in English Alaphabets.

Input: S = “geek”
Output: 1
Explanation:
The value obtained by the sum order of alphabets is 7 + 5 + 5 + 11 = 28.
The single digit sum obtained by sum of 28 = 2 + 8 = 10 = 1 + 0 = 1.

Input: S = “GeeksforGeeks”
Output: 7

Approach: The given problem can be solved by first find the sum of orders of all the alphabets present in the given string S by adding the value (S[i] – ‘a’ + 1) or (S[i] – ‘A’ + 1) if S[i] is lowercase or uppercase character. After finding the value of sum, find the single digit of this value using the approach discussed in this article.

Below is the implementation of the above approach:
    */
    class AlphabetSingleDigitSum
    {
       static int findTheSum(string str)
        {
            string alpha="";

            // Traverse the given string
            for (int i = 0; i < str.Length; i++)
            {

                // If character is an alphabet
                if ((str[i] >= 'A' && str[i] <= 'Z')
                    || (str[i] >= 'a' && str[i] <= 'z'))
                    alpha+=str[i];
            }

            // Stores the sum of order of values
            int score = 0, n = 0;

            for (int i = 0; i < alpha.Length; i++)
            {

                // Find the score
                if (alpha[i] >= 'A' && alpha[i] <= 'Z')
                    score += alpha[i] - 'A' + 1;
                else
                    score += alpha[i] - 'a' + 1;
            }

            // Find the single digit sum
            while (score > 0 || n > 9)
            {
                if (score == 0)
                {
                    score = n;
                    n = 0;
                }
                n += score % 10;
                score /= 10;
            }

            // Return the resultant sum
            return n;
        }
        public static void Main(string[] args)
        {
            string S = "GeeksforGeeks";
            Console.WriteLine(findTheSum(S));
            /*
             Output:
7
Time Complexity: O(N)
Auxiliary Space: O(1)
            */
        }
    }
}
