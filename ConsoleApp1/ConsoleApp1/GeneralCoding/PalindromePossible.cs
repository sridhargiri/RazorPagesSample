using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Palindrome by swapping only one character
Difficulty Level : Hard
Last Updated : 17 Feb, 2020
Given a string, the task is to check if the string can be made palindrome by swapping a character only once.
[NOTE: only one swap and only one character should be swapped with another character]

Examples:

Input : bbg
Output : true
Explanation: Swap b(1st index) with g.

Input : bdababd
Output : true
Explanation: Swap b(0th index) with d(last index) or
             Swap d(1st index) with b(second index)

Input : gcagac
Output : false

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach:

This algorithm was based on a thorough analysis of the behavior and possibility of the forming string palindrome. By this analysis, I got the following conclusions :
1. Firstly, we will be finding the differences in the string that actually prevents it from being a palindrome.
…..a) To do this, We will start from both the ends and comparing one element from each end at a time, whenever it does match we store the values in a separate array as along with this we keep a count on the number of unmatched items.
 
2. If the number of unmatched items is more than 2, it is never possible to make it a palindrome string by swapping only one character.
 
3. If (number of unmatched items = 2) – it is possible to make the string palindrome iff the characters present in first unmatched set are same as the characters present in second unmatched set. (For example : try this out “bdababd”).
 
4. If (number of unmatched items = 1)
…..a) if (length of string is even) – it is not possible to make a palindrome string out of this.
…..b) if (length of string is odd) – it is possible to make a palindrome string out of this if one of the unmatched character matches with the middle character.
 
5. If (number of unmatched items = 0) – palindrome is possible if we swap the position of any same characters.
    https://www.geeksforgeeks.org/palindrome-by-swapping-only-one-character/
    */
    public class PalindromePossible
    {

        public static bool isPalindromePossible(String input)
        {

            // convert the string to character array 
            char[] charStr = input.ToCharArray();
            int len = input.Length, i;

            // counts the number of differences 
            // which prevents the string
            // from being palindrome. 
            int diffCount = 0;

            // keeps a record of the 
            // characters that prevents 
            // the string from being palindrome. 
            char[,] diff = new char[2, 2];

            // loops from the start of a string 
            // till the midpoint of the string 
            for (i = 0; i < len / 2; i++)
            {

                // difference is encountered preventing 
                // the string from being palindrome 
                if (charStr[i] != charStr[len - i - 1])
                {

                    // 3rd differences encountered 
                    // and its no longer possible to
                    // make is palindrome by one swap 
                    if (diffCount == 2)
                        return false;

                    // record the different character 
                    diff[diffCount, 0] = charStr[i];

                    // store the different characters 
                    diff[diffCount++, 1] = charStr[len - i - 1];
                }
            }

            switch (diffCount)
            {

                // its already palindrome 
                case 0:
                    return true;

                // only one difference is found 
                case 1:
                    char midChar = charStr[i];

                    // if the middleChar matches either of the 
                    // difference producing characters, return true 
                    if (len % 2 != 0 &&
                        (diff[0, 0] == midChar ||
                        diff[0, 1] == midChar))
                        return true;
                    break;

                // two differences are found 
                case 2:

                    // if the characters contained in 
                    // the two sets are same, return true 
                    if ((diff[0, 0] == diff[1, 0] &&
                         diff[0, 1] == diff[1, 1]) ||
                         (diff[0, 0] == diff[1, 1] &&
                         diff[0, 1] == diff[1, 0]))
                        return true;
                    break;
            }
            return false;
        }

        // Driver code
        public static void Main(String[] args)
        {
            Console.WriteLine(isPalindromePossible("bbg"));
            Console.WriteLine(isPalindromePossible("bdababd"));
            Console.WriteLine(isPalindromePossible("gcagac"));
            /*
             Output:
true
true
false
Time Complexity : O(n)
Auxiliary Space : O(1)
            */
        }
    }
    /*
     
     https://www.geeksforgeeks.org/check-characters-given-string-can-rearranged-form-palindrome/
For nagarro, Check if characters of a given string can be rearranged to form a palindrome
Difficulty Level : Easy
Last Updated : 25 May, 2021
Given a string, Check if characters of the given string can be rearranged to form a palindrome. 
For example characters of “geeksogeeks” can be rearranged to form a palindrome “geeksoskeeg”, but characters of “geeksforgeeks” cannot be rearranged to form a palindrome. 

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
A set of characters can form a palindrome if at most one character occurs odd number of times and all characters occur even number of times.
A simple solution is to run two loops, the outer loop picks all characters one by one, the inner loop counts the number of occurrences of the picked character. We keep track of odd counts. Time complexity of this solution is O(n2).

We can do it in O(n) time using a count array. Following are detailed steps. 

Create a count array of alphabet size which is typically 256. Initialize all values of count array as 0.
Traverse the given string and increment count of every character.
Traverse the count array and if the count array has more than one odd values, return false. Otherwise, return true.
Below is the implementation of the above approach.
     */
    public class CanFormPalindrome
    {

        static int NO_OF_CHARS = 256;

        /* function to check whether characters
        of a string can form a palindrome */
        static bool canFormPalindrome(string str)
        {

            // Create a count array and initialize all
            // values as 0
            int[] count = new int[NO_OF_CHARS];
            Array.Fill(count, 0);

            // For each character in input strings,
            // increment count in the corresponding
            // count array
            for (int i = 0; i < str.Length; i++)
                count[(int)(str[i])]++;

            // Count odd occurring characters
            int odd = 0;
            for (int i = 0; i < NO_OF_CHARS; i++)
            {
                if ((count[i] & 1) == 1)
                    odd++;

                if (odd > 1)
                    return false;
            }

            // Return true if odd count is 0 or 1,
            return true;
        }

        // Driver code
        public static void Main()
        {
            if (canFormPalindrome("geeksforgeeks"))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            if (canFormPalindrome("geeksogeeks"))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            /*
             Output

No
Yes
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/check-if-given-string-can-be-made-palindrome-by-removing-only-single-type-of-character/
    Check if given string can be made Palindrome by removing only single type of character
    Given a string S, the task is to whether a string can be made palindrome after removing the occurrences of the same character, any number of times
     Input: S = “abczdzacb”
 Output: Yes
 Explanation: Remove first and second occurrence of character ‘a’, string S becomes “bczdzcb”, which is a palindrome . 
 
Input: S = “madem”
Output: No (bcos already palindrome)
    Approach: 
    The task can be solved by iterating over each unique character in the given string, and removing its occurrences wherever there is a mismatch, if a valid palindrome is found, after removing occurrences of the same character any number of times, return “Yes” else return “No“.

Follow the below steps to solve the problem:

Start iterating over each unique character of the string, whose occurrences are to be deleted
Use the two-pointer technique, to check for a mismatch, Place l at the start of the string and r at the end of the string
If S[l] == S[r], increment l, and decrement r.
If S[l]!= S[r], check if S[l[ == char, do l++, else if S[r] == char, do r–
If none of the conditions hold, means the given can’t be converted into a palindrome
 Below is the implementation of the above approach:

     */
    public class PalindromPossibleAfterRemoval
    {
        static string isPalindromePossible(string S)
        {
            int n = S.Length;
            HashSet<char> st = new HashSet<char>();
            for (int i = 0; i < n; i++)
            {
                st.Add(S[i]);
            }

            // Check if valid palindrome is
            // possible or not
            bool check = false;
            foreach (var ele in st)
            {
                // Pointers to check the condition
                int low = 0, high = n - 1;
                bool flag = true;

                // Iterating over the string
                for (int i = 0; i < n; i++)
                {
                    if (S[low] == S[high])
                    {

                        // Updating low and high
                        low++;
                        high--;
                    }

                    else
                    {
                        if (S[low] == ele)
                        {

                            // Updating low
                            low++;
                        }
                        else if (S[high] == ele)
                        {

                            // Updating high
                            high--;
                        }
                        else
                        {

                            // It is impossible
                            // to make palindrome
                            // by removing
                            // occurrences of char
                            flag = false;
                            break;
                        }
                    }
                }
                // If palindrome is formed
                // break the loop
                if (flag == true)
                {
                    check = true;
                    break;
                }
            }

            if (check)
                return "Yes";
            else
                return "No";
        }
        public static void Main(string[] args)
        {
            isPalindromePossible("abczdzacb");
            /*
             Output:Yes
Time Complexity: O(n*26)
Auxiliary Space:  O(n) 
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/check-if-a-number-is-palindrome-or-not-without-using-any-extra-space-set-2/
    Check if a number is palindrome or not without using any extra space | Set 2
    Given a number ‘n’ and our goal is to find out it is palindrome or not without using any extra space. We can’t make a new copy of number.
Examples
    Input: n = 2332
Output: Yes
Explanation:
original number = 2332
reversed number = 2332
Both are same hence the number is palindrome.

Input: n=1111
Output: Yes.
    Input: n = 1234
Output: No
Other Approach: The other recursive approaches and the approach to compare the digits are discussed in Set-1 of this article. 
    Here, we are discussing the other approaches. set 1 https://www.geeksforgeeks.org/check-number-palindrome-not-without-using-extra-space/

Approach: This approach depends upon 3 major steps, find the number of digits in the number. Partition the number into 2 parts from the middle. Take care of the case when the length is odd, in which we will have to use the middle element twice. Check whether the number in both numbers are the same or not. Follow the steps below to solve the problem:

Initialize the variable K as the length of the number n.
Initialize the variable ans as 0.
Iterate over the range [0, K/2) using the variable i and perform the following tasks:
Put the value of n%10 in the variable ans and divide n by 10.
If K%2 equals 1 then put the value of n%10 in the variable ans.
After performing the above steps, if ans equals n then it’s a pallindrome otherwise not.
Below is the implementation of the above approach.
     */
    public class CheckPalindrome
    {
        static bool CheckIfPalindromeNoExtraSpace(int n)
        {
            if (n < 0)
                return false;
            if (n < 10)
                return true;

            // Find the length of the number
            int K = (int)Math.Floor(Math.Log10(n) + 1);

            int ans = 0;

            // Partition the number into 2 halves
            for (int i = 0; i < K / 2; i++)
            {
                ans = ans * 10 + n % 10;
                n = n / 10;
            }
            if (K % 2 == 1)
                ans = ans * 10 + n % 10;

            // Equality Condition
            return (ans == n);
        }
        static void Main(string[] args)
        {
            string s = CheckIfPalindromeNoExtraSpace(1001) ? "yes" : "no";
            Console.WriteLine(s);
            /*
             Output yes

Time Complexity: O(K), where K is the number of digits
Auxiliary Approach: O(1)
            */
        }
    }
    // i got stuck in maxerience interview for this question on 17th aug 2022
    /*
     Program to Check if a Given String is Palindrome
    https://www.geeksforgeeks.org/c-program-check-given-string-palindrome/
    Given a string, write a c function to check if it is palindrome or not. 

A string is said to be palindrome if reverse of the string is same as string. For example, “abba” is palindrome, but “abbc” is not palindrome.
    Algorithm: 

isPalindrome(str) 

Find length of str. Let length be n. 
Initialize low and high indexes as 0 and n-1 respectively. 
 Do following while low index ‘l’ is smaller than high index ‘h’. 
If str[l] is not same as str[h], then return false. 
Increment l and decrement h, i.e., do l++ and h–. 
If we reach here, it means we didn’t find a mis
    see below code
     */
    public class CheckValidPalindrome
    {
        public static bool Check_Valid_Palindrome(string str)
        {
            int l = 0;
            int h = str.Length-1;
            while (h > l)
            {
                if (str[l++] != str[h--])
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string str = "maddam";
            bool b = Check_Valid_Palindrome(str);
            Console.WriteLine(b);
        }
    }
}
