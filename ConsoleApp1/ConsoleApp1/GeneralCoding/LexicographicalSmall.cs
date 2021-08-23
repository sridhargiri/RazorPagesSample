// C# program for the above approach
using System;
using System.Collections.Generic;
/*
https://www.geeksforgeeks.org/lexicographically-smallest-string-formed-by-removing-duplicates/ 
Lexicographically smallest string formed by removing duplicates
Last Updated: 06-11-2020
Given a string S consisting of lowercase alphabets, the task is to find the lexicographically smallest string that can be obtained by removing duplicates from the given string S.

Examples:

Input: S = “yzxyz”
Output: xyz
Explanation: Removing the duplicate characters at indices 0 and 1 in the given string, the remaining string “xyz” consists only of unique alphabets only and is the smallest possible string in lexicographical order.

Input: S = “acbc”
Output: “abc”

Explanation: Removing the duplicate characters at index 3 in the given string, the remaining string “abc” consists only of unique alphabets only and is the smallest possible string in lexicographical order.
 Initialize a string res to store the resultant string.
Store the frequency of each character present in the given string in an array freq[].
Maintain an array vis[] for marking the characters that are already present in the resultant string res.
Traverse the given string S and for each character S[i], perform the following:
    Decrease the frequency of the current character by 1.
    If the current character is not marked visited in the array vis[], then perform the following:
        If the last letter of res is less than S[i], add S[i] to res.
        If the last letter of res is greater than S[i] and the count of the last letter of res exceeds 0, then remove that character and mark visit[S[i]] as 0 and continue this step till the above condition is satisfied.
        After breaking out from the above condition, add S[i] to res and mark visit[S[i]] as 1.
After completing the above steps, print the string res as the result.
 */
namespace ConsoleApp1
{

    public class LexicographicSmall
    {

        // Function that finds lexicographically
        // smallest string after removing the
        // duplicates from the given string
        static string removeDuplicateLetters(string s)
        {

            // Stores the frequency of characters
            int[] cnt = new int[26];

            // Mark visited characters
            int[] vis = new int[26];

            int n = s.Length;

            // Stores count of each character
            for (int i = 0; i < n; i++)
                cnt[s[i] - 'a']++;

            // Stores the resultant string
            String res = "";

            for (int i = 0; i < n; i++)
            {

                // Decrease the count of
                // current character
                cnt[s[i] - 'a']--;

                // If character is not already
                // in answer
                if (vis[s[i] - 'a'] == 0)
                {

                    // Last character > S[i]
                    // and its count > 0
                    int size = res.Length;
                    while (size > 0 && res[size - 1] > s[i] &&
                            cnt[res[size - 1] - 'a'] > 0)
                    {

                        // Mark letter unvisited
                        vis[res[size - 1] - 'a'] = 0;
                        res = res.Substring(0, size - 1);
                        size--;
                    }

                    // Add s[i] in res and
                    // mark it visited
                    res += s[i];
                    vis[s[i] - 'a'] = 1;
                }
            }

            // Return the resultant string
            return res;
        }

        // Driver Code
        public static void Main()
        {

            // Given string S
            string S = "acbc";

            // Function Call
            Console.WriteLine(removeDuplicateLetters(S));
            /*
             Output: abc

Time Complexity: O(N)
Auxiliary Space: O(N)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/lexicographically-largest-string-with-sum-of-characters-equal-to-n/
    Lexicographically largest string with sum of characters equal to N
    Last Updated : 27 Apr, 2021
    Given a positive integer N, the task is to find the lexicographically largest string consisting of lower-case English alphabets such that the sum of the characters of the string equals N where ‘a’ = 1, ‘b’ = 2, ‘c’ = 3, ….. , and ‘z’ = 26.

    Examples:

    Input: N = 30
    Output: zd
    Explanation:
    The lexicographically largest string formed is “zd” whose sum of position of characters is (26 + 4) = 30(= N).

    Input: N = 14
    Output: n

    Approach: To make lexicographically the largest string, the idea is to print the character z, N/26 number of times and then the character at (N%26 + 1)th position in the English alphabets. Follow the steps below to solve the problem:

    Initialize a string, say ans, that stores the required lexicographically largest string.
    Iterate until N is at least 26 and perform the following steps:
    Add the character z to the string ans.
    Decrement the value of N by 26.
    Add the value of char(N + ‘a’) to the string ans.
    After completing the above steps, print the value of ans as the resultant string.
    Below is the implementation of the above approach:
     */
    public class LexicographicLarge
    {
        static string getString(int n)
        {
            // Stores the resulting string
            string ans = "";

            // Iterate until N is at least 26
            while (n >= 26)
            {

                // Append 'z' to the string ans
                ans += 'z';

                // Decrement N by 26
                n -= 26;
            }

            // Append  character at index (N + 'a')
            ans += (char)(n + 'a' - 1);

            // Return the resultant string
            return ans;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(getString(30));
            /*
             Output:
    zd
    Time Complexity: O(N)
    Auxiliary Space: O(N)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/sort-a-string-lexicographically-by-reversing-a-substring/
    Sort a string lexicographically by reversing a substring
Last Updated : 27 Apr, 2021
Given a string S consisting of N lowercase characters, the task is to find the starting and the ending indices ( 0-based indexing ) of the substring of the given string S that needed to be reversed to make the string S sorted. If it is not possible to sort the given string S by reversing any substring, then print “-1”.

Examples:

Input: S = “abcyxuz”
Output: 3 5
Explanation: Reversing the substring from indices [3, 5] modifies the string to “abcuxyz”, which is sorted.
Therefore, print 3 and 5.

Input: S = “GFG”
Output: 0 1

Naive Approach: The simplest approach to solve the given problem is to generate all possible substring of the given string S and if there exists any substring such reversing it makes the string sorted, then print the indices of that substrings. Otherwise, print “-1”.



Time Complexity: O(N3)
Auxiliary Space: O(1)

Efficient Approach: The above approach can also be optimized based on the observation that to sort the string by only reversing one substring, the original string must be in one of the following formats:

Decreasing string
Increasing substring + Decreasing substring
Decreasing substring + Increasing substring
Increasing substring + Decreasing substring + Increasing substring
Follow the steps below to solve the problem:

Initialize two variables, say start and end as -1, that stores the starting and ending indices of the substring to be reversed respectively.
Initialize a variable, say flag as 1, that stores if it is possible to sort the string or not.
Iterate over the range [1, N] and perform the following operations:
If the characters S[i] is less than characters S[i – 1] then find the index of the right boundary of the decreasing substring starting from the index (i – 1) and store it in end.
Check if reversing the substring S[i – 1, end] makes the string sorted or not. If found to be false then print “-1” and return. Otherwise, mark the flag as false.
After completing the above steps update the value of i with the right boundary of the substring.
If the characters S[i] is less than characters S[i – 1] and the flag is false, then print “-1” and return.
If the start is equal to -1, then update the value of start and end as 1.
After completing the above steps, print the value of start and end as the result.
Below is the implementation of the above approach:
     */
    public class LexicographicallySortString
    {
        static bool adjust(string S, int i,
            int start, int end)
        {
            // Stores the size of the string
            int N = S.Length;

            // Stores the starting point
            // of the substring
            start = i - 1;

            // Iterate over the string S
            // while i < N
            while (i < N && S[i] < S[i - 1])
            {

                // Increment the value of i
                i++;
            }

            // Stores the ending index of
            // the substring
            end = i - 1;

            // If start <= 0 or i >= N
            if (start <= 0 && i >= N)
                return true;

            // If start >= 1 and i <= N
            if (start >= 1 && i <= N)
            {

                // Return the boolean value
                return (S[end] >= S[start - 1]
                        && S[start] <= S[i]);
            }

            // If start >= 1
            if (start >= 1)
            {

                // Return the boolean value
                return S[end] >= S[start - 1];
            }

            // If i < N
            if (i < N)
            {

                // Return true if S[start]
                // is less than or equal to
                // S[i]
                return S[start] <= S[i];
            }

            // Otherwise
            return false;
        }
        static void isPossible(string S, int N)
        {
            // Stores the starting and the
            // ending index of substring
            int start = -1, end = -1;

            // Stores whether it is possible
            // to sort the substring
            bool flag = true;

            // Traverse the range [1, N]
            for (int i = 1; i < N; i++)
            {

                // If S[i] is less than S[i-1]
                if (S[i] < S[i - 1])
                {

                    // If flag stores true
                    if (flag)
                    {

                        // If adjust(S, i, start,
                        // end) return false
                        if (adjust(S, i, start, end)
                            == false)
                        {

                            Console.WriteLine(-1);

                            return;
                        }

                        // Unset the flag
                        flag = false;
                    }

                    // Otherwise
                    else
                    {

                        // Print -1
                        Console.WriteLine(-1);
                        return;
                    }
                }
            }

            // If start is equal to -1
            if (start == -1)
            {
                // Update start and end
                start = end = 1;
            }

            // Print the value of start
            // and end
            Console.WriteLine(start + " " + end);
        }
        public static void Main(string[] args)
        {
            string S = "abcyxuz";
            isPossible(S, S.Length);
        }
    }
}