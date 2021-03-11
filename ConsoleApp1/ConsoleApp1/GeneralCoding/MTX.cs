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
}
