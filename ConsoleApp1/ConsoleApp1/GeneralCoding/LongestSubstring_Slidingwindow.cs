using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // Leetcode C# program to find the length of the  
    // longest substring without repeating 
    // characters  
    /*
     Given a string str, find the length of the longest substring without repeating characters. 

For “ABDEFGABEF”, the longest substring are “BDEFGA” and “DEFGAB”, with length 6.
For “BBBB” the longest substring is “B”, with length 1.
For “GEEKSFORGEEKS”, there are two longest substrings shown in the below diagrams, with length 
     */
    class LongestSubstring_Slidingwindow
    {

        static int longestUniqueSubsttr(string str)
        {
            int n = str.Length;

            // Result  
            int res = 0;

            for (int i = 0; i < n; i++)
            {

                // Note : Default values in visited are false  
                bool[] visited = new bool[256];

                // visited = visited.Select(i => false).ToArray(); 
                for (int j = i; j < n; j++)
                {

                    // If current character is visited  
                    // Break the loop  
                    if (visited[str[j]] == true)
                        break;

                    // Else update the result if  
                    // this window is larger, and mark  
                    // current character as visited.  
                    else
                    {
                        res = Math.Max(res, j - i + 1);
                        visited[str[j]] = true;
                    }
                }

                // Remove the first character of previous  
                // window  
                visited[str[i]] = false;
            }
            return res;
        }

        // Driver code 
        static void Main()
        {
            string str = "geeksforgeeks";
            Console.WriteLine("The input string is " + str);

            int len = longestUniqueSubsttr(str);
            Console.WriteLine("The length of the longest " +
                              "non-repeating character " +
                              "substring is " + len);
        }
    }

    // This code is contributed by divyeshrabadiya07
}
