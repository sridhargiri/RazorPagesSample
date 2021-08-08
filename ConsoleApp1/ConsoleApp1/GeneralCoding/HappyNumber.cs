using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
    https://www.geeksforgeeks.org/happy-number/
    Happy Number
Difficulty Level : Medium
Last Updated : 31 May, 2021
A number is called happy if it leads to 1 after a sequence of steps wherein each step number is replaced by the sum of squares of its digit that is if we start with Happy Number and keep replacing it with digits square sum, we reach 1. 

Examples : 

Input: n = 19
Output: True
19 is Happy Number,
1^2 + 9^2 = 82
8^2 + 2^2 = 68
6^2 + 8^2 = 100
1^2 + 0^2 + 0^2 = 1
As we reached to 1, 19 is a Happy Number.

Input: n = 20
Output: False
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
A number will not be a Happy Number when it makes a loop in its sequence that is it touches a number in sequence which already been touched. So to check whether a number is happy or not, we can keep a set, if the same number occurs again we flag result as not happy. A simple function on the above approach can be written as below

     */
    class HappyNumber
    {

        static int numSquareSum(int n)
        {
            int squareSum = 0;
            while (n != 0)
            {
                squareSum += (n % 10) *
                             (n % 10);
                n /= 10;
            }
            return squareSum;
        }

        // method return true if
        // n is Happy number
        static bool isHappynumber(int n)
        {
            int slow, fast;

            // initialize slow and
            // fast by n
            slow = fast = n;
            do
            {

                // move slow number
                // by one iteration
                slow = numSquareSum(slow);

                // move fast number
                // by two iteration
                fast = numSquareSum(numSquareSum(fast));

            }
            while (slow != fast);

            // if both number meet at 1,
            // then return true
            return (slow == 1);
        }

        // Driver code
        public static void Main()
        {
            int n = 13;
            if (isHappynumber(n))
                Console.WriteLine(n +
                " is a Happy number");
            else
                Console.WriteLine(n +
                " is not a Happy number");
        }
        /*
         Output : 

13 is a Happy Number
        */
    }
    /*
     Another approach for solving this problem using no extra space.
A number cannot be a happy number if, at any step, the sum of the square of digits obtained is a single-digit number except 1 or 7. This is because 1 and 7 are the only single-digit happy numbers. Using this information, we can develop an approach as shown in the code below –
    */
    public class HappyNumber1
    {

        // Method - returns true if the input is
        // a happy number else returns false
        static bool isHappynumber(int n)
        {
            if (n == 1 || n == 7)
                return true;

            int sum = n, x = n;

            // This loop executes till the sum
            // of square of digits obtained is
            // not a single digit number
            while (sum > 9)
            {
                sum = 0;

                // This loop finds the sum of
                // square of digits
                while (x > 0)
                {
                    int d = x % 10;
                    sum += d * d;
                    x /= 10;
                }
                if (sum == 1)
                    return true;

                x = sum;
            }
            if (sum == 7)
                return true;

            return false;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int n = 13;

            if (isHappynumber(n))
                Console.WriteLine(n + " is a Happy number");
            else
                Console.WriteLine(n + " is not a Happy number");
        }
    }
    /*
     Output
13 is a Happy number
    */
    /*
     Write a  program to check whether a specified character is happy or not. A character is happy when the same character appears to its left or right in a string
    */
    public class HappyCharacter
    {

        public static bool IsCharacterHappy(String str, char c)
        {
            int l = str.Length;
            bool char_happy = true;
            for (int i = 0; i < l; i++)
            {
                if (str[i] == c)
                {
                    if (i > 0 && str[i - 1] == c)
                        char_happy = true;
                    else if (i < l - 1 && str[i + 1] == c)
                        char_happy = true;
                    else
                        char_happy = false;
                }
            }
            return char_happy;
        }
        static void Main(string[] args)
        {
            String str1 = "azzlea"; char _c = 'z';
            Console.WriteLine(IsCharacterHappy(str1, _c));
            /*
             The given string is: azzlea
             Is z happy in the string: true
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/generate-a-string-consisting-of-characters-a-and-b-that-satisfy-the-given-conditions/
    Generate a string consisting of characters ‘a’ and ‘b’ that satisfy the given conditions
Last Updated : 28 May, 2021
Given two integers A and B, the task is to generate and print a string str such that: 
 

str must only contain the characters ‘a’ and ‘b’.
str has length A + B and the occurrence of character ‘a’ is equal to A and the occurrence of character ‘b’ is equal to B
The sub-strings “aaa” or “bbb” must not occur in str.
Note that for the given values of A and B, a valid string can always be generated.
Examples: 
 

Input: A = 1, B = 2 
Output: abb 
“abb”, “bab” and “bba” are all valid strings.
Input: A = 4, B = 1 
Output: aabaa 
 
Approach: 
 
If occurrence(a) > occurrence(b) then append “aab”
If occurrence(b) > occurrence(a) then append “bba”
If occurrence(a) = occurrence(b) then append “ab”
Since we reduce the difference between the occurrences of ‘a’ and ‘b’ by at most 1 in each iteration so “bba” and “aab” are guaranteed not to be followed by “aab” and “bba” respectively.
Below is the implementation of the above approach: 
     */
    public class HappyString
    {

        // Function to generate and
        // print the required string
        static void generateString(int A, int B)
        {
            string rt = "";
            while (0 < A || 0 < B)
            {

                // More 'b', append "bba"
                if (A < B)
                {
                    if (0 < B--)
                    {
                        rt += ('b');
                    }
                    if (0 < B--)
                    {
                        rt += ('b');
                    }
                    if (0 < A--)
                    {
                        rt += ('a');
                    }
                }

                // More 'a', append "aab"
                else if (B < A)
                {
                    if (0 < A--)
                    {
                        rt += ('a');
                    }
                    if (0 < A--)
                    {
                        rt += ('a');
                    }
                    if (0 < B--)
                    {
                        rt += ('b');
                    }
                }

                // Equal number of 'a' and 'b'
                // append "ab"
                else
                {
                    if (0 < A--)
                    {
                        rt += ('a');
                    }
                    if (0 < B--)
                    {
                        rt += ('b');
                    }
                }
            }
            Console.WriteLine(rt);
        }

        // Driver code
        public static void Main()
        {
            int A = 2, B = 6;
            generateString(A, B);
            //Output: bbabbabb
        }
    }

    public class HappyPairs
    {
        static string checkhappy(string[] arr, char K, int N)
        {
            List<string> visited = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i][0] == K)
                {
                    if (visited.Contains(arr[i][1].ToString())) return "Yes";
                }
                else if (visited.Contains(K + arr[i])) return "Yes";
                visited.Add(arr[i]);

            }
            return "No";
        }
        static void Main(string[] args)
        {
            string[] arr = { "a", "!a", "b", "!c", "d", "!d" }; char K = '!'; int n = arr.Length;
            Console.WriteLine(checkhappy(arr, K, n));
        }
    }
    /*
https://leetcode.com/problems/longest-happy-string/ 
Longest Happy String
Medium

643

115

Add to List

Share
A string is called happy if it does not have any of the strings 'aaa', 'bbb' or 'ccc' as a substring.

Given three integers a, b and c, return any string s, which satisfies following conditions:

s is happy and longest possible.
s contains at most a occurrences of the letter 'a', at most b occurrences of the letter 'b' and at most c occurrences of the letter 'c'.
s will only contain 'a', 'b' and 'c' letters.
If there is no such string s return the empty string "".

 

Example 1:

Input: a = 1, b = 1, c = 7
Output: "ccaccbcc"
Explanation: "ccbccacc" would also be a correct answer.
Example 2:

Input: a = 2, b = 2, c = 1
Output: "aabbc"
Example 3:

Input: a = 7, b = 1, c = 0
Output: "aabaa"
Explanation: It's the only correct answer in this case.
 

Constraints:

0 <= a, b, c <= 100
a + b + c > 0
    */
    public class LongestHappyString
    {
        public static string LongestDiverseString(int a, int b, int c)
        {
            /*Used to store the number of times each character appears*/
            int[] numsCount = { a, b, c };
            String res = "";
            int index = 0, isconflict = -1;
            while (true)
            {
                index = -1;
                /*Use this variable to record conflicting subscripts*/
                isconflict = -1;
                if (res.Length > 1 && res[res.Length - 2] == res[res.Length - 1]) isconflict = res[res.Length - 1] - 'a';
                for (int i = 0; i < 3; ++i)
                {
                    /*Skip this letter directly when there is a conflict*/
                    if (numsCount[i] == 0 || isconflict == i) continue;
                    /*Find the letter with the largest number to splice*/
                    if (index == -1 || numsCount[i] > numsCount[index]) index = i;
                }
                /*Wait until all the numbers are not available, then it will jump out of the loop*/
                if (index == -1) break;
                --numsCount[index];
                res += (char)('a' + index);
            }
            return res;
        }
        public static void Main(string[] args)
        {
            int a = 1, b = 1, c = 7;
            string s = LongestDiverseString(a, b, c);
            Console.WriteLine(s);
        }
    }
}
