// C# program for the above approach
using System;
using System.Collections.Generic;
/*
 
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
    }
}