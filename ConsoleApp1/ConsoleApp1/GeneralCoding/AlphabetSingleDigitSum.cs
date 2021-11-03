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
            string alpha = "";

            // Traverse the given string
            for (int i = 0; i < str.Length; i++)
            {

                // If character is an alphabet
                if ((str[i] >= 'A' && str[i] <= 'Z')
                    || (str[i] >= 'a' && str[i] <= 'z'))
                    alpha += str[i];
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
    /*
     https://www.geeksforgeeks.org/sum-of-the-alphabetical-values-of-the-characters-of-a-string/
    Sum of the alphabetical values of the characters of a string
Difficulty Level : Medium
Last Updated : 19 Mar, 2021
You are given an array of strings str, the task is to find the score of a given string s from the array. The score of a string is defined as the product of the sum of its characters’s alphabetical values with the position of the string in the array.
Examples: 
 

Input: str[] = {“sahil”, “shashanak”, “sanjit”, “abhinav”, “mohit”}, s = “abhinav” 
Output: 228 
Sum of alphabetical values of “abhinav” = 1 + 2 + 8 + 9 + 14 + 1 + 22 = 57 
Position of “abhinav” in str is 4, 57 x 4 = 228 
Input: str[] = {“geeksforgeeks”, “algorithms”, “stack”}, s = “algorithms” 
Output: 244 Approach: 
 

Find the given string in the array and store the position of the string.
Then calculate the sum of the alphabetical values of the given string.
Multiply the position of the string in the given array with the value calculated in the previous step and print the result.
Below is the implementation of the above approach: 
     */
    public class AlphabetSum
    {

        // Function to find string score
        static int sum_of_alphabets_in_strings(String[] str,
                            String s, int n)
        {
            int score = 0, index = 0;
            for (int i = 0; i < n; i++)
            {
                if (str[i] == s)
                {
                    for (int j = 0; j < s.Length; j++)
                        score += s[j] - 'a' + 1;
                    index = i + 1;
                    break;
                }
            }

            score = score * index;
            return score;
        }

        // Driver code
        public static void Main(String[] args)
        {
            String[] str = { "sahil", "shashanak", "sanjit",
                     "abhinav", "mohit" };
            String s = "abhinav";
            int n = str.Length;
            int score = sum_of_alphabets_in_strings(str, s, n);
            Console.Write(score);
        }
    }
}
