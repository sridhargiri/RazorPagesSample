using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class NonRepeatingSubstring
    {

        // Function to count all unique 
        // distinct character subStrings 
        static int distinctSubString(String P, int N)
        {
            // Hashmap to store all subStrings 
            HashSet<String> S = new HashSet<String>();

            // Iterate over all the subStrings 
            for (int i = 0; i < N; ++i)
            {

                // Boolean array to maintain all 
                // characters encountered so far 
                bool[] freq = new bool[26];

                // Variable to maintain the 
                // subString till current position 
                String s = "";

                for (int j = i; j < N; ++j)
                {

                    // Get the position of the 
                    // character in the String 
                    int pos = P[j] - 'a';

                    // Check if the character is 
                    // encountred 
                    if (freq[pos] == true)
                        break;

                    freq[pos] = true;

                    // Add the current character 
                    // to the subString 
                    s += P[j];

                    // Insert subString in Hashmap 
                    S.Add(s);
                }
            }
            return S.Count;
        }

        // Driver code 
        public static void Main(String[] args)
        {
            String S = "abcd";
            int N = S.Length;

            Console.Write(distinctSubString(S, N));
        }
    }
    /*
     https://www.geeksforgeeks.org/count-of-substrings-having-all-distinct-characters/
    Given a string str consisting of lowercase alphabets, the task is to find the number of possible substrings (not necessarily distinct) that consists of distinct characters only.
Examples: 

Input: Str = “gffg” 
Output: 6 
Explanation: 
All possible substrings from the given string are, 
( “g“, “gf“, “gff”, “gffg”, “f“, “ff”, “ffg”, “f“, “fg“, “g” ) 
Among them, the highlighted ones consists of distinct characters only.

Input: str = “gfg” 
Output: 5 
Explanation: 
All possible substrings from the given string are, 
( “g“, “gf“, “gfg”, “f“, “fg“, “g” ) 
Among them, the highlighted consists of distinct characters only. 
 

Naive Approach: 
The simplest approach is to generate all possible substrings from the given string and check for each substring whether it contains all distinct characters or not. If the length of string is N, then there will be N*(N+1)/2 possible substrings. 


Time complexity: O(N3) 
Auxiliary Space: O(1)

Efficient Approach: 
The problem can be solved in linear time using Two Pointer Technique, with the help of counting frequencies of characters of the string.

Detailed steps for this approach are as follows: 

Consider two pointers i and j, initially both pointing to the first character of the string i.e. i = j = 0.
Initialize an array Cnt[ ] to store the count of characters in substring from index i to j both inclusive.
Now, keep on incrementing j pointer until some a repeated character is encountered. While incrementing j, add the count of all the substrings ending at jth index and starting at any index between i and j to the answer. All these substrings will contain distinct characters as no character is repeated in them.
If some repeated character is encountered in substring between index i to j, to exclude this repeated character, keep on incrementing the i pointer until repeated character is removed and keep updating Cnt[ ] array accordingly.
Continue this process until j reaches the end of string. Once the string is traversed completely, print the answer.
Below is the implementation of the above approach: 
    
Asked in XA Group on 27/04/2023
     */
    public class XAGroupDistinctSubstring
    {

        // Function to count total
        // number of valid subStrings
        static int countSub(String str)
        {
            int n = (int)str.Length;

            // Stores the count of
            // subStrings
            int ans = 0;

            // Stores the frequency
            // of characters
            int[] cnt = new int[26];

            // Initialised both pointers
            // to beginning of the String
            int i = 0, j = 0;

            while (i < n)
            {

                // If all characters in
                // subString from index i
                // to j are distinct
                if (j < n &&
                   (cnt[str[j] - 'a'] == 0))
                {

                    // Increment count of j-th
                    // character
                    cnt[str[j] - 'a']++;

                    // Add all subString ending
                    // at j and starting at any
                    // index between i and j
                    // to the answer
                    ans += (j - i + 1);

                    // Increment 2nd pointer
                    j++;
                }

                // If some characters are repeated
                // or j pointer has reached to end
                else
                {

                    // Decrement count of j-th
                    // character
                    cnt[str[i] - 'a']--;

                    // Increment first pointer
                    i++;
                }
            }

            // Return the final
            // count of subStrings
            return ans;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            String str = "gffg";

            Console.Write(countSub(str));
            /*
             Output: 6
 for inout xxxxxxxxxxxxxxxxx op is 17

Time complexity: O(N) 
Auxiliary Space: O(1)
 

*/
        }
    }
    /*
     https://www.geeksforgeeks.org/count-of-substrings-with-at-least-k-pairwise-distinct-characters-having-same-frequency/
    Count of Substrings with at least K pairwise Distinct Characters having same Frequency
    Given a string S and an integer K, the task is to find the number of substrings which consists of at least K pairwise distinct characters having same frequency.

Examples:

Input: S = “abasa”, K = 2 
Output: 5 
Explanation: 
The substrings in having 2 pairwise distinct characters with same frequency are {“ab”, “ba”, “as”, “sa”, “bas”}.
Input: S = “abhay”, K = 3 
Output: 4 
Explanation: 
The substrings having 3 pairwise distinct characters with same frequency are {“abh”, “bha”, “hay”, “bhay”}.
    Naive Approach: The simplest approach to solve this problem is to generate all possible substrings of the given string and check if both the conditions are satisfied. If found to be true, increase count. Finally, print count.

    Time Complexity: O(N3)
Auxiliary Space: O(1)

Efficient Approach: To optimize the above approach, follow the steps below to solve the problem:

Check if the frequencies of each character is same. If found to be true, simply generate all the substrings to check if each character satisfies the condition of at least N pairwise distinct characters.
Precompute the frequencies of characters to check the conditions for each substring.
Below is the implementation of the above approach:


    */
    public class SubstringsPairwise
    {

        // Function to find the subString with K
        // pairwise distinct characters and
        // with same frequency
        static int no_of_subString(String s, int N)
        {

            // Stores the occurrence of each
            // character in the subString
            int[] fre = new int[26];

            int str_len;

            // Length of the String
            str_len = (int)s.Length;

            int count = 0;

            // Iterate over the String
            for (int i = 0; i < str_len; i++)
            {

                // Set all values at each index to zero
                fre = new int[26];

                int max_index = 0;

                // Stores the count of
                // unique characters
                int dist = 0;

                // Moving the subString ending at j
                for (int j = i; j < str_len; j++)
                {

                    // Calculate the index of
                    // character in frequency array
                    int x = s[j] - 'a';

                    if (fre[x] == 0)
                        dist++;

                    // Increment the frequency
                    fre[x]++;

                    // Update the maximum index
                    max_index = Math.Max(max_index, fre[x]);

                    // Check for both the conditions
                    if (dist >= N && ((max_index * dist) ==
                                      (j - i + 1)))
                        count++;
                }
            }

            // Return the answer
            return count;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            String s = "abhay";
            int N = 3;

            // Function call
            Console.Write(no_of_subString(s, N));
            /*
             output 4
            Time Complexity: O(N2)
            Auxiliary Space: O(1)
             */
        }
    }
}
