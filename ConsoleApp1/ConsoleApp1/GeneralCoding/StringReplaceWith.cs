using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
SLK sotware: flatten array without built in in js
function flatten(arr)
{
var output=[];
for(var i in arr)
{
output.push(i);
}
console.log(arr.join(','));
}

flatten([1,2,3,[4,[5,[6]]]])
*/

namespace ConsoleApp1
{

/*
How to replace a substring of a string
Something related to ConcordOne hackathon held on 22 jul 2023
https://www.geeksforgeeks.org/find-and-replace-all-occurrence-of-a-substring-in-the-given-string/
Given three strings S, S1, and S2 consisting of N, M, and K characters respectively, the task is to modify the string S by replacing all the substrings S1 with the string S2 in the string S.

Examples:

Input: S = “abababa”, S1 = “aba”, S2 = “a”
Output: aba
Explanation:
Change the substrings S[0, 2] and S[4, 6](= S1) to the string S2(= “a”) modifies the string S to “aba”. Therefore, print “aba”.

Input: S = “geeksforgeeks”, S1 = “eek”, S2 = “ok”
Output: goksforgoks
    Naive Approach: The simplest approach to solve the given problem is to traverse the string S and when any string S1 is found as a substring in the string S then replace it by S2. Follow the steps below to solve this problem:

Initialize a string ans to store the resultant string after replacing all the occurrences of the substring S1 to S2 in the string S.
Iterate over the characters of the string S using variable i and perform the following steps:
If the prefix substring of the string S is equal to S1 from the index i, then add the string S2 in the string ans.
Otherwise, add the current character to the string ans.
After completing the above steps, print the string ans as the result.
Below is the implementation of the above approach:
Time Complexity: O(N*M)
Auxiliary Space: O(N)
     */
    public class StringReplaceWith
    {

        // Function to replace all the occurrences
        // of the subString S1 to S2 in String S
        static void modifyString(String s, String s1, String s2)
        {

            // Stores the resultant String
            String ans = "";

            // Traverse the String s
            for (int i = 0; i < s.Length; i++)
            {

                int k = 0;

                // If the first character of
                // String s1 matches with the
                // current character in String s
                if (s[i] == s1[k]
                    && i + s1.Length <= s.Length)
                {

                    int j;

                    // If the complete String
                    // matches or not
                    for (j = i; j < i + s1.Length; j++)
                    {

                        if (s[j] != s1[k])
                        {
                            break;
                        }
                        else
                        {
                            k = k + 1;
                        }
                    }

                    // If complete String matches
                    // then replace it with the
                    // String s2
                    if (j == i + s1.Length)
                    {
                        ans += (s2);
                        i = j - 1;
                    }

                    // Otherwise
                    else
                    {
                        ans += (s[i]);
                    }
                }

                // Otherwise
                else
                {
                    ans += (s[i]);
                }
            }

            // Print the resultant String
            Console.Write(ans);
        }

        // Driver Code
        public static void Main(String[] args)
        {
            String S = "geeksforgeeks";
            String S1 = "eek";
            String S2 = "ok";
            modifyString(S, S1, S2);
        }
    }
    /*
     Efficient Approach: The above approach can also be optimized by creating the longest proper prefix and suffix array for the string S1 and then perform the KMP Algorithm to find the occurrences of the string S1 in the string S. Follow the steps below to solve this problem:

Create a vector, say lps[] that stores the longest proper prefix and suffix for each character and fill this vector using the KMP algorithm for the string S1.
Initialize two variables say, i and j as 0 to store the position of current character in s and s1 respectively.
Initialize a vector found to store all the starting indexes from which string S1 occurs in S.
Iterate over the characters of the string S using variable i and perform the following steps:
If S[i] is equal to S1[j], then increment i and j by 1.
If j is equal to the length of s1, then add the value (i – j) to the vector found and update j as lps[j – 1].
Otherwise, if the value of S[i] is not equal to S1[j], then if j is equal to 0, then increment the value of i by 1. Otherwise, update j as lps[j – 1].
Initialize a variable say, prev as 0 to store the last changed index and an empty string ans to store the resultant string after replacing all the initial appearances of s1 by s2 in s.
Traverse the vector found[] and if the value of found[i] is greater than prev, then add the string S2 in place of S1 in ans.
After completing the above steps, print the string ans as the result.
Below is the implementation of the above approach
    
     
     */
    public class StringReplaceWithOptimised
    {
        // Function to calculate the LPS array
        // for the given string S1
        static List<int> ComputeLPS(string s1)
        {
            // Stores the longest proper prefix
            // and suffix for each character
            // in the string s1
            List<int> lps = new List<int>(s1.Length);
            int len = 0;
            // Set lps value 0 for the first
            // character of the string s1
            lps.Add(0);

            int i = 1;

            // Iterate to fill the lps vector
            while (i < s1.Length)
            {
                if (s1[i] == s1[len])
                {
                    len = len + 1;
                    lps.Add(len);
                    i = i + 1;
                }
                else
                {

                    // If there is no longest
                    // proper prefix which is
                    // suffix, then set lps[i] = 0
                    if (len == 0)
                    {
                        lps.Add(0);
                        i = i + 1;
                    }

                    // Otherwise
                    else
                        len = lps[len - 1];
                }
            }

            return lps;
        }

        // Function to replace all the occurrences
        // of the substring S1 to S2 in string S
        static void ModifyString(string s, string s1, string s2)
        {
            List<int> lps = ComputeLPS(s1);
            int i = 0;
            int j = 0;

            // Stores all the starting index
            // from character S1 occurs in S
            List<int> found = new List<int>();

            // Iterate to find all starting
            // indexes and store all indices
            // in a list found
            while (i < s.Length)
            {
                if (s[i] == s1[j])
                {
                    i = i + 1;
                    j = j + 1;
                }

                // The string s1 occurrence is
                // found and store it in found[]
                if (j == s1.Length)
                {
                    found.Add(i - j);
                    j = lps[j - 1];
                }
                else if (i < s.Length && s1[j] != s[i])
                {
                    if (j == 0)
                        i = i + 1;
                    else
                        j = lps[j - 1];
                }
            }

            // Stores the resultant string
            string ans = "";
            int prev = 0;

            // Traverse the list found[]
            for (int k = 0; k < found.Count; k++)
            {
                if (found[k] < prev)
                    continue;
                ans += s.Substring(prev, found[k] - prev);
                ans += s2;
                prev = found[k] + s1.Length;
            }

            ans += s.Substring(prev, s.Length - prev);

            // Print the resultant string
            Console.WriteLine(ans);
        }

        // Driver Code
        static void Main()
        {
            string S = "geeksforgeeks";
            string S1 = "eek";
            string S2 = "ok";
            ModifyString(S, S1, S2);
            /*
             Output
goksforgoks
Time Complexity: O(N + M)
Auxiliary Space: O(N)
            */
        }
    }
}
