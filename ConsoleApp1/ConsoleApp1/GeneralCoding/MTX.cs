using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MTX
    {
        /*
https://www.geeksforgeeks.org/mtx-interview-experience-for-trainee-consultant-on-campus-2021/
         Print this pattern
ABCDEF
ABCDE
ABCD
ABC
AB
A
AB
ABC
ABCD
ABCDE
ABCDEF
        */
        static void PrintFormat()
        {
            for (int i = 6; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write((char)(65 + j));
                }
                Console.WriteLine();
            }
            for (int k = 0; k < 6; k++)
            {
                for (int m = 0; m <= k; m++)
                {
                    Console.Write((char)(65 + m));
                }
                Console.WriteLine();
            }
        }
        static int NO_OF_CHARS = 256;

        /* 
         * Print all the duplicates in the input string
Difficulty Level : Basic
 Last Updated : 10 Feb, 2021
Write an efficient program to print all the duplicates and their counts in the input string 

Method 1: Using hashing
Algorithm: Let input string be “geeksforgeeks” 
1: Construct character count array from the input string.
count[‘e’] = 4 
count[‘g’] = 2 
count[‘k’] = 2 
……
2: Print all the indexes from the constructed array which have values greater than 1.
 */
        static void fillCharCounts(String str,
                                     int[] count)
        {
            for (int i = 0; i < str.Length; i++)
                count[str[i]]++;
        }

        /* Print duplicates present in
        the passed string */
        static void printDups(String str)
        {

            // Create an array of size 256 and
            // fill count of every character in it
            int[] count = new int[NO_OF_CHARS];
            fillCharCounts(str, count);

            for (int i = 0; i < NO_OF_CHARS; i++)
                if (count[i] > 1)
                    Console.WriteLine((char)i + ", " +
                                  "count = " + count[i]);
        }
        /*
         Square root of an integer

Given an integer x, find it’s square root. If x is not a perfect square, then return floor(√x).

Examples :

Input: x = 4
Output: 2
Explanation:  The square root of 4 is 2.

Input: x = 11
Output: 3
Explanation:  The square root of 11 lies in between
3 and 4 so floor of the square root is 3.

There can be many ways to solve this problem. For example Babylonian Method is one way.

Simple Approach: To find the floor of the square root, try with all-natural numbers starting from 1. Continue incrementing the number until the square of that number is greater than the given number.

Algorithm:
Create a variable (counter) i and take care of some base cases, i.e when the given number is 0 or 1.
Run a loop until i*i <= n , where n is the given number. Increment i by 1.
The floor of the square root of the number is i – 1
         */
        static int floorSqrt(int x)
        {
            // Base cases 
            if (x == 0 || x == 1)
                return x;

            // Staring from 1, try all numbers until 
            // i*i is greater than or equal to x. 
            int i = 1, result = 1;
            while (result <= x)
            {
                i++;
                result = i * i;
            }
            return i - 1;
        }
        /*
         Find elements which are present in first array and not in second

Given two arrays, the task is that we find numbers which are present in first array, but not present in the second array.
Examples :

Input : a[] = {1, 2, 3, 4, 5, 10};
        b[] = {2, 3, 1, 0, 5};
Output : 4 10    
4 and 10 are present in first array, but
not in second array.

Input : a[] = {4, 3, 5, 9, 11};
        b[] = {4, 9, 3, 11, 10};
Output : 5  
        Method 1 (Simple)
A Naive Approach is to use two loops and check element which not present in second array.   
      Output :
6 5
        */
        static void findMissing(int[] a, int[] b,
                    int n, int m)
        {
            // Store all elements of  
            // second array in a hash table  
            HashSet<int> s = new HashSet<int>();
            for (int i = 0; i < m; i++)
                s.Add(b[i]);

            // Print all elements of first array  
            // that are not present in hash table  
            for (int i = 0; i < n; i++)
                if (!s.Contains(a[i]))
                    Console.Write(a[i] + " ");
        }
        /*
         
        Method 2 (Use Hashing)
In this method, we store all elements of second array in a hash table (unordered_set). 
        One by one check all elements of first array and print all those elements which are not present in the hash table.
        Output :
6 5
Time complexity : O(n)
Auxiliary Space : O(n)
        */
        static void findMissing1(int[] a, int[] b,
                            int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                int j;

                for (j = 0; j < m; j++)
                    if (a[i] == b[j])
                        break;

                if (j == m)
                    Console.Write(a[i] + " ");
            }
        }
        /*
         Question Marks In: "aa6?9" Out: false
which will contain single digit numbers, letters, and question marks, and check if there are exactly 3 question marks between every pair of two numbers that add up to 10.

If so, then your program should return the string true, otherwise it should return the string false.

If there aren't any two numbers that add up to 10 in the string, then your program should return false as well.

For example:
if str is "arrb6???4xxbl5???eee5" then your program should return true because there are exactly 3 question marks between 6 and 4, and 3 question marks between 5 and 5 at the end of the string.

Examples

Input: "aa6?9"
Output: false

Input: "acc?7??sss?3rr1??????5"
Output: true
        */
        static bool threequestionmark(string str)
        {
            int last_number = 0;
            int number_of_questions = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    if ((last_number + (str[i] - 48) == 10) && number_of_questions == 3)
                        return true;
                    else
                        last_number = str[i] - 48;
                    number_of_questions = 0;
                }
                if (str[i] == '?') number_of_questions += 1;
            }
            return false;
        }
        static void Main(string[] args)
        {
            string result = threequestionmark("acc?7??sss?3rr1??????5") ? "yes" : "no";
            Console.WriteLine(result);
            PrintFormat();
            String str = "test string";
            printDups(str);
            Console.WriteLine(floorSqrt(11));
        }
    }
    /*
     https://www.geeksforgeeks.org/replace-in-a-string-such-that-no-two-adjacent-characters-are-same/
    Replace ‘?’ in a string such that no two adjacent characters are same
Difficulty Level : Easy
Last Updated : 16 Jul, 2021
Given a string S of length N consisting of “?” and lowercase letters, the task is to replace “?” with lowercase letters such that no adjacent characters are the same. If more than one possible combination exists, print any one of them.

Examples:

Input: S = “?a?a”
Output: baba
Explanation:
Replacing all ‘?’s with ‘b’ modifies the string to “baba”.
Since no adjacent characters in “baba” are the same, print the string as the answer.

Input: S = “???”
Output: aca
Explanation:
Replace first ‘?’ with ‘a’.
Replace second ‘?’ with ‘c’.
Replace third ‘?’ with ‘a’. Now, the modified string is “aca”.
Therefore, there are no adjacent characters in “ca” which are same.

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Naive Approach: The simplest approach is to try generating all possible permutations of the given string consisting of lowercase letters. There can be 26N strings. In each of these strings, check whether adjacent characters matches or not and all lowercase characters in the given string matches the chosen permutation of the string. 



Time Complexity: O(N*26N), where N is the length of the given string.
Auxiliary Space: O(N)

Efficient Approach: To optimize the above approach, the idea is to replace every ‘?’ by the character ‘a’ and check if this character is equal to the adjacent character or not. If it is equal to the adjacent character then increment the current character. Below are the steps:

If the first character of the string is ‘?’ then replace it with ‘a’ and if it is equal to the next character then increment the current character by 1
Traverse the given string using a variable i over the range [1, N – 1] and if the current character is ‘?’ and do the following:
Update character at index i as s[i] = ‘a’.
Now if the character at index i and (i – 1) are the same then increment the current character by 1.
Now if the character at index i and (i + 1) are the same then increment the current character by 1.
Now if the character at index i and (i – 1) are the same again, then increment the current character by 1. This step is mandatory because after increment character in the above step it might be possible character at index i and  (i – 1) are the same.
If the last character of the string is ‘?’ then replace it with ‘a’ and if it is equal to the previous character then increment the last character by 1
Print the string after the above steps.
Below is the implementation of the above approach:
     */
    public class QuestionMarkReplace
    {

        // Function that replace all '?' with
        // lowercase alphabets such that each
        // adjacent character is different
        static string changeString(string S)
        {

            // Store the given String
            char[] s = S.ToCharArray();

            int N = S.Length;

            // If the first character is '?'
            if (s[0] == '?')
            {
                s[0] = 'a';
                if (s[0] == s[1])
                {
                    s[0]++;
                }
            }

            // Traverse the String [1, N - 1]
            for (int i = 1; i < N - 1; i++)
            {

                // If the current
                // character is '?'
                if (s[i] == '?')
                {

                    // Change the character
                    s[i] = 'a';

                    // Check equality with
                    // the previous character
                    if (s[i] == s[i - 1])
                    {
                        s[i]++;
                    }

                    // Check equality with
                    // the next character
                    if (s[i] == s[i + 1])
                    {
                        s[i]++;
                    }

                    // Check equality with
                    // the previous character
                    if (s[i] == s[i - 1])
                    {
                        s[i]++;
                    }
                }
            }

            // If the last character is '?'
            if (s[N - 1] == '?')
            {

                // Change character
                s[N - 1] = 'a';

                // Check with previous
                // character
                if (s[N - 1] == s[N - 2])
                {
                    s[N - 1]++;
                }
            }

            string ans = "";

            for (int i = 0; i < s.Length; i++)
            {
                ans += s[i];
            }

            // Return the resultant String
            return ans;
        }

        // Driver Code
        public static void Main()
        {
            // Given String S
            string S = "?a?a";

            // Function Call
            Console.WriteLine(changeString(S));
            /*
             Output:baba
Time Complexity: O(N), where N is the length of the given string.
Auxiliary Space: O(N)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/clone-a-stack-without-using-extra-space-set-2/
    Clone a stack without using extra space | Set 2
Difficulty Level : Medium
Last Updated : 25 Aug, 2021
Given a stack S, the task is to copy the content of the given stack S to another stack T maintaining the same order.

Examples:

Input: Source:- |5| 
                         |4|
                         |3|
                         |2|
                         |1|
Output: Destination:- |5| 
                                   |4|
                                   |3|
                                   |2|
                                   |1|

Input: Source:- |12| 
                         |13|
                         |14|
                         |15|
                         |16|
Output: Destination:- |12| 
                                   |13|
                                   |14|
                                   |15|
                                   |16|

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Reversing the Stack-Based Approach: Please refer to the previous post of this article for reversing the stack-based approach.



Time Complexity: O(N2)
Auxiliary Space: O(1)

Linked List-Based Approach: Please refer to the previous post of this article for the linked list-based approach.

Time Complexity: O(N)
Auxiliary Space: O(1)

Recursion-Based Approach: The given problem can also be solved by using recursion. Follow the steps below to solve the problem:

Define a recursive function, say RecursiveCloneStack(stack<int> S, stack<int>Des) where S is the source stack and Des is the destination stack:
Define a base case as if S.size() is 0 then return from the function.
Store the top element of the source stack in a variable, say val, and then remove the top element of the stack S.
Now call the recursive function with updated Source stack S i.e., RecursiveCloneStack(S, Des).
After the above step, push the val into the Des stack.
Initialize a stack, say Des to store the destination stack.
Now call the function RecursiveCloneStack(S, Des) to copy the elements of the source stack to the destination stack.
After completing the above steps, print the elements of the stack Des as the result.
Below is the implementation of the above approach:
     */
    public class CloneStack
    {

        static Stack<int> S = new Stack<int>();
        static Stack<int> Des = new Stack<int>(); // Stores the destination stack

        // Auxiliary function to copy elements
        // of source stack to destination stack
        static void RecursiveCloneStack()
        {
            // Base case for Recursion
            if (S.Count == 0)
                return;

            // Stores the top element of the
            // source stack
            int val = (int)S.Peek();

            // Removes the top element of the
            // source stack
            S.Pop();

            // Recursive call to the function
            // with remaining stack
            RecursiveCloneStack();

            // Push the top element of the source
            // stack into the Destination stack
            Des.Push(val);
        }

        // Function to copy the elements of the
        // source stack to destination stack
        static void cloneStack()
        {
            // Recursive function call to copy
            // the source stack to the
            // destination stack
            RecursiveCloneStack();

            Console.Write("Destination:- ");
            int f = 0;

            // Iterate until stack Des is
            // non-empty
            while (Des.Count > 0)
            {

                if (f == 0)
                {
                    Console.Write(Des.Peek());
                    f = 1;
                }

                else
                    Console.Write("              " + Des.Peek());
                Des.Pop();

                Console.WriteLine();
            }
        }

        static void Main()
        {
            S.Push(1);
            S.Push(2);
            S.Push(3);
            S.Push(4);
            S.Push(5);
            cloneStack();
            /*
             Output: 
Destination:- 5
              4
              3
              2
              1 

Time Complexity: O(N) 
Auxiliary Space: O(1)
            */
        }
    }
}
