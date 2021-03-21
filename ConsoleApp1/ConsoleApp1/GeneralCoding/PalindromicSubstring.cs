using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     * https://www.geeksforgeeks.org/rearrange-characters-of-a-string-to-make-it-a-concatenation-of-palindromic-substrings/
     Rearrange characters of a string to make it a concatenation of palindromic substrings
Difficulty Level : Basic
 Last Updated : 18 Mar, 2021
Given a string S consisting of lowercase alphabets, the task is to check whether the given string can be rearranged such that the string can be split into non-overlapping palindromic substrings of at least length 2. If found to be true, then print “Yes”. Otherwise, print “No”.

Examples:

Input: S = “aaaabbcdd”
Output: Yes
Explanation: Rearrange the given string S to “acaaabbdd”, which can be split into non-overlapping palindromic substrings “aca”, “aa”, “bb”, “dd”.

Input: S = “ccddgggggefs”
Output: No

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The given problem can be solved by rearranging the characters of the string into substrings of length 2, consisting of single distinct character. If there exists any character with odd frequency, then it place them in the middle of the palindromic substrings of length 2. 
Follow the steps below to solve the problem:




Initialize an auxiliary array, say frequency[] of size 26, to store the frequency of every character present in the string S.
Traverse the given string S and update the frequency of each character in the array frequency[].
Initialize two variables, say odd and even both as 0, to store the frequency of odd elements and the number of palindromic substrings of length 2 formed.
Traverse the array frequency[] and if the value of frequency[i] is greater than 0, then add the value (frequency[i] & 1) and (frequency[i] / 2) to the variable odd and even respectively.
After completing the above steps, if the value of odd is at most even, then print “Yes”. Otherwise, print “No”.
Below is the implementation of the above approach:
    */
    class PalindromicSubstring
    {

        // Function to check if a string can be
        // modified such that it can be split into
        // palindromic substrings of length >= 2
        static void canSplit(String S)
        {
            // Stores frequencies of characters
            int[] frequency = new int[26];

            int cnt_singles = 0;

            int k = 0;

            // Traverse the string
            for (int i = 0; i < S.Length; i++)

                // Update frequency
                // of each character
                frequency[S[i] - 'a']++;

            int odd = 0, eve = 0;

            // Traverse the frequency array
            for (int i = 0; i < 26; i++)
            {

                // Update values of odd and eve
                if (frequency[i] != 0)
                {
                    odd += (frequency[i] & 1);
                    eve += frequency[i] / 2;
                }
            }

            // Print the result
            if (eve >= odd)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
        /*
         Count All Palindrome Sub-Strings in a String | Set 1
Difficulty Level : Hard
 Last Updated : 21 Dec, 2020
Given a string, the task is to count all palindrome sub string in a given string. Length of palindrome sub string is greater than or equal to 2. 

Examples: 

Input : str = "abaab"
Output: 3
Explanation : 
All palindrome substring are :
 "aba" , "aa" , "baab" 

Input : str = "abbaeae"
Output: 4
Explanation : 
All palindrome substring are : 
"bb" , "abba" ,"aea","eae"
We have discussed a similar problem below. 
Find all distinct palindromic sub-strings of a given string

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
The above problem can be recursively defined. 

Initial Values : i = 0, j = n-1;
Given string 'str'

CountPS(i, j)
   
   // If length of string is 2 then we 
   // check both character are same or not 
   If (j == i+1)
      return str[i] == str[j]
   //this condition shows that in recursion if i crosses j then it will be a invalid substring or
   //if i==j that means only one character is remaining and we require substring of length 2 
   //in both the conditions we need to return 0
   Else if(i == j ||  i > j) return 0;
   Else If str[i..j] is PALINDROME 
      // increment count by 1 and check for 
      // rest palindromic substring (i, j-1), (i+1, j)
      // remove common palindrome substring (i+1, j-1)
      return  countPS(i+1, j) + countPS(i, j-1) + 1 -
                                   countPS(i+1, j-1);

    Else // if NOT PALINDROME 
       // We check for rest palindromic substrings (i, j-1)
       // and (i+1, j)
       // remove common palindrome substring (i+1 , j-1)
       return  countPS(i+1, j) + countPS(i, j-1) - 
                             countPS(i+1 , j-1);
If we draw recursion tree of above recursive solution, we can observe overlapping Subprolems. Since the problem has overlapping sub-problems, we can solve it efficiently using Dynamic Programming. Below is a Dynamic Programming based solution. 
        https://www.geeksforgeeks.org/count-palindrome-sub-strings-string/
        */

        // Returns total number of
        // palindrome substring of
        // length greater then equal to 2
        public static int CountPS(char[] str, int n)
        {
            // create empty 2-D matrix that counts
            // all palindrome substring. dp[i][j]
            // stores counts of palindromic
            // substrings in st[i..j]

            int[][] dp
                = RectangularArrays.ReturnRectangularIntArray(
                    n, n);

            // P[i][j] = true if substring str[i..j]
            // is palindrome, else false

            bool[][] P
                = RectangularArrays.ReturnRectangularBoolArray(
                    n, n);

            // palindrome of single length
            for (int i = 0; i < n; i++)
            {
                P[i][i] = true;
            }

            // palindrome of length 2
            for (int i = 0; i < n - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    P[i][i + 1] = true;
                    dp[i][i + 1] = 1;
                }
            }

            // Palindromes of length more then 2.
            // This loop is similar to Matrix Chain
            // Multiplication. We start with a gap
            // of length 2 and fill DP table in a
            // way that gap between starting and
            // ending indexes increases one by one
            // by outer loop.
            for (int gap = 2; gap < n; gap++)
            {
                // Pick starting point for current gap
                for (int i = 0; i < n - gap; i++)
                {
                    // Set ending point
                    int j = gap + i;

                    // If current string is palindrome
                    if (str[i] == str[j] && P[i + 1][j - 1])
                    {
                        P[i][j] = true;
                    }

                    // Add current palindrome substring
                    // ( + 1) and rest palindrome substring
                    // (dp[i][j-1] + dp[i+1][j]) remove common
                    // palindrome substrings (- dp[i+1][j-1])
                    if (P[i][j] == true)
                    {
                        dp[i][j] = dp[i][j - 1] + dp[i + 1][j]
                                   + 1 - dp[i + 1][j - 1];
                    }
                    else
                    {
                        dp[i][j] = dp[i][j - 1] + dp[i + 1][j]
                                   - dp[i + 1][j - 1];
                    }
                }
            }

            // return total palindromic substrings
            return dp[0][n - 1];
        }

        public static class RectangularArrays
        {
            public static int[][] ReturnRectangularIntArray(
                int size1, int size2)
            {
                int[][] newArray = new int[size1][];
                for (int array1 = 0; array1 < size1; array1++)
                {
                    newArray[array1] = new int[size2];
                }

                return newArray;
            }

            public static bool[][] ReturnRectangularBoolArray(
                int size1, int size2)
            {
                bool[][] newArray = new bool[size1][];
                for (int array1 = 0; array1 < size1; array1++)
                {
                    newArray[array1] = new bool[size2];
                }

                return newArray;
            }
        }
        /*
         Method 2:
This approach uses Top Down DP i.e memoized version of recursion.

Recursive soln:
1. Here base condition comes out to be i>j if we hit this condition, return 1.
2. We check for each and every i and j, if the characters are equal, 
   if that is not the case, return 0.
3. Call the is_palindrome function again with incremented i  and decremented j.
4. Check this for all values of i and j by applying 2 for loops.
        */

        // 2D matrix
        static int[,] dp = new int[1001, 1001];

        static int isPal(string s, int i, int j)
        {

            // Base condition
            if (i > j)
                return 1;

            // Check if the recursive tree
            // for given i, j
            // has already been executed
            if (dp[i, j] != -1)
                return dp[i, j];

            // If first and last characters of 
            // substring are unequal
            if (s[i] != s[j])
                return dp[i, j] = 0;

            // Memoization
            return dp[i, j] = isPal(s, i + 1, j - 1);
        }

        static int countSubstrings(string s)
        {
            for (int i = 0; i < 1001; i++)
            {
                for (int j = 0; j < 1001; j++)
                {
                    dp[i, j] = -1;
                }
            }

            int n = s.Length;
            int count = 0;

            // 2 for loops are required to check for
            // all the palindromes in the string.
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {

                    // Increment count for every palindrome
                    if (isPal(s, i, j) != 0)
                        count++;
                }
            }

            // Return total palindromic substrings
            return count;
        }
        /*
         We can easily extend this solution to print all palindromic substrings also. We need to simply traverse the map m and print its content.

Another Approach is to use Java String Class, to do so,

Iterate the loop twice for substring, get the substring of a string using substring() method.
Reverse the substring using StringBuffer Class method reverse()
Check for palindrome with substring and reverse substring
If it is palindrome increment the count and return the count at last
        https://www.geeksforgeeks.org/count-palindrome-sub-strings-string-set-2/
         */


        // Method which return count palindrome substring 
        static int countPS_2(String str)
        {
            String temp = "";
            String stf;
            int count = 0;

            // Iterate the loop twice 
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 1;
                         j <= str.Length; j++)
                {
                    // Get each substring 
                    temp = str.Substring(i, j - i);

                    // If length is greater than or equal to two 
                    // Check for palindrome  
                    if (temp.Length >= 2)
                    {
                        // Use StringBuffer class to reverse  
                        // the string 
                        stf = temp;
                        stf = reverse(temp);

                        // Compare substring wih reverse of substring 
                        if (stf.ToString().CompareTo(temp) == 0)
                            count++;
                    }
                }
            }

            // return the count 
            return count;
        }

        static String reverse(String input)
        {
            char[] a = input.ToCharArray();
            int l, r = 0;
            r = a.Length - 1;

            for (l = 0; l < r; l++, r--)
            {
                // Swap values of l and r  
                char temp = a[l];
                a[l] = a[r];
                a[r] = temp;
            }
            return String.Join("", a);
        }
        public static void main(String[] args)
        {

            String S = "aaabbbccc";
            canSplit(S);
            /*
             Output: 
    Yes


    Time Complexity: O(N)
    Auxiliary Space: O(1)
            */
            string str = "abaab";
            Console.WriteLine(
                CountPS(str.ToCharArray(), str.Length));
            /*
             Output: 

3
Time complexity: O(n2) 
Auxiliary Space: O(n2) 
            */
            string s = "abbaeae";

            Console.WriteLine(countSubstrings(s));//op - 4
                                                  //https://www.geeksforgeeks.org/count-palindrome-sub-strings-string/
                                                  // Declare and initialize the string 
            str = "abbaeae";

            // Call the method 
            Console.WriteLine(countPS_2(str));
            /*
             Output:
4
Time complexity O(n2)
Auxiliary Space O(n)
            */
        }
    }
}
