using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/check-if-two-given-strings-are-isomorphic-to-each-other/
    Check if two given strings are isomorphic to each other
    Two strings str1 and str2 are called isomorphic if there is a one-to-one mapping possible for every character of str1 to every character of str2. And all occurrences of every character in ‘str1’ map to the same character in ‘str2’.

Examples: 

Input:  str1 = "aab", str2 = "xxy"
Output: True
'a' is mapped to 'x' and 'b' is mapped to 'y'.

Input:  str1 = "aab", str2 = "xyz"
Output: False
One occurrence of 'a' in str1 has 'x' in str2 and 
other occurrence of 'a' has 'y'.
    A Simple Solution is to consider every character of ‘str1’ and check if all occurrences of it map to the same character in ‘str2’. 
    The time complexity of this solution is O(n*n).

An Efficient Solution can solve this problem in O(n) time. The idea is to create an array to store mappings of processed characters. 

1) If lengths of str1 and str2 are not same, return false.
2) Do following for every character in str1 and str2
   a) If this character is seen first time in str1, 
      then current of str2 must have not appeared before.
      (i) If current character of str2 is seen, return false.
          Mark current character of str2 as visited.
      (ii) Store mapping of current characters.
   b) Else check if previous occurrence of str1[i] mapped
      to same character.
Below is the implementation of above idea 

     */
    public class IsomorphicString
    {
        static int CHAR = 26;
        static int size = 256;
        static int countWords(String str)
        {
            int count = 1;

            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str[i] >= 65 && str[i] <= 90)
                    count++;
            }

            return count;
        }
        // Function returns true if str1 
        // and str2 are ismorphic 

        static bool areIsomorphic(String str1,
                                  String str2)
        {

            int m = str1.Length;
            int n = str2.Length;

            // Length of both strings must be same  
            // for one to one corresponance 
            if (m != n)
                return false;

            // To mark visited characters in str2 
            bool[] marked = new bool[size];

            for (int i = 0; i < size; i++)
                marked[i] = false;


            // To store mapping of every character 
            // from str1 to that of str2 and 
            // Initialize all entries of map as -1. 
            int[] map = new int[size];

            //for (int i = 0; i < size; i++)
            //    map[i] = -1;

            // Process all characters one by on 
            for (int i = 0; i < n; i++)
            {

                // If current character of str1 is  
                // seen first time in it. 
                if (map[str1[i]] == 0)
                {

                    // If current character of str2 
                    // is already seen, one to 
                    // one mapping not possible 
                    if (marked[str2[i]] == true)
                        return false;

                    // Mark current character of  
                    // str2 as visited 
                    marked[str2[i]] = true;

                    // Store mapping of current characters 
                    map[str1[i]] = str2[i];
                }

                // If this is not first appearance of current 
                // character in str1, then check if previous 
                // appearance mapped to same character of str2 
                else if (map[str1[i]] != str2[i])
                    return false;
            }

            return true;
        }
        /*
         another Approach:

In this approach, we will count the number of occurrences of a particular character in both the string using two arrays, 
        while we will compare the two arrays if at any moment with the loop the count of the current character in both strings becomes different we return false, else after the loop ends we return true.
Follow the code given below you will understand everything.
Note: There is no need to create here array of 256 characters. We can reduce it to only 26 characters 
by storing count of ch-'a' (ch is the ith character of the string) in count array .This gives the same 
result as string consists of only small case characters.
         */
        static bool IsIsomorphic(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;

            // Length of both strings must be
            // same for one to one
            // correspondence
            if (n != m)
                return false;

            // For counting the previous appearances
            // of character in both the strings
            int[] countChars1 = new int[CHAR];
            int[] countChars2 = new int[CHAR];

            // Process all characters one by one
            for (int i = 0; i < n; i++)
            {
                countChars1[str1[i] - 'a']++;
                countChars2[str2[i] - 'a']++;

                // For string to be isomorphic the
                // previous counts of appearances of
                // current character in both string
                // must be same if it is not same we
                // return false.
                if (countChars1[str1[i] - 'a'] != countChars2[str2[i] - 'a'])
                {
                    return false;
                }
            }
            return true;
        }
        // Driver code 
        public static void Main()
        {
            bool res = areIsomorphic("aab", "xxy");//op true
            Console.WriteLine(res);
            res = areIsomorphic("egg", "edd");//op true
            Console.WriteLine(res);
            res = areIsomorphic("aab", "xyz");//op false
            Console.WriteLine(res);
            res = areIsomorphic("abd", "ccy");//op false
            Console.WriteLine(res);
            res = areIsomorphic("aba", "yxx");//op false
            Console.WriteLine(res);

            //String str = "geeksForGeeks";

            //Console.Write(countWords(str));
        }
    }
    /*
     At 0 min, use o' clock. For , < 30 min use past, and for >30 use to. 
    Note the space between the apostrophe and clock in o' clock. Write a program which prints the time in words for the input given in the format described.

Function Description
     https://www.hackerrank.com/challenges/the-time-in-words/problem
     https://exploringbits.com/the-time-in-words-hackerrank-solution/
    */
    public class TimeInWords
    {
        static string[] numbers = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
    "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty",
    "twenty one", "twenty two", "twenty three", "twenty four", "twenty five", "twenty six", "twenty seven", "twenty eight", "twenty nine"};
        static void Main(String[] args)
        {
            int h = Int32.Parse(Console.ReadLine());
            int m = Int32.Parse(Console.ReadLine());
            if (m == 0)
                Console.WriteLine(numbers[h] + " o' clock");
            else if (m < 30)
            {
                if (m == 1)
                    Console.WriteLine(numbers[m] + " minute past " + numbers[h]);
                else if (m == 15)
                    Console.WriteLine("quarter" + " past " + numbers[h]);
                else
                    Console.WriteLine(numbers[m] + " minutes past " + numbers[h]);
            }
            else if (m == 30)
            {
                Console.WriteLine("half past " + numbers[h]);
            }
            else if (m < 45)
            {
                if (h + 1 > 12)
                    h -= 12;
                Console.WriteLine(numbers[60 - m] + " minutes to " + numbers[h + 1]);
            }
            else if (m == 45)
            {
                if (h + 1 > 12)
                    h -= 12;
                Console.WriteLine("quarter to " + numbers[h + 1]);
            }
            else if (m < 60)
            {
                if (h + 1 > 12)
                    h -= 12;
                if (60 - m == 1)
                    Console.WriteLine(numbers[60 - m] + " minute to " + numbers[h + 1]);
                else
                    Console.WriteLine(numbers[60 - m] + " minutes to " + numbers[h + 1]);
            }
            /*
             Sample Input 0

5
47
Sample Output 0

thirteen minutes to six
Sample Input 1

3
00
Sample Output 1

three o' clock
Sample Input 2

7
15
Sample Output 2

quarter past seven
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/check-if-digits-from-concatenation-of-date-and-month-can-be-used-to-form-given-year/
    Check if digits from concatenation of date and month can be used to form given year
Last Updated : 28 Oct, 2021
Given three strings D, M, and Y representing a date. The task is to check whether concatenation of date and month results in the same digits as of the year. 

Examples:
Input: D = 20, M = 12, Y = 2001
Output: Yes
Explanation: Below are the operations performed:
D + M = 2012, Set1 = 0, 1, 2                      
Y = 2001, Set2 = 0, 1, 2
Set1 = Set2, Therefore the answer is Yes. 

Input: D = 26, M = 07, Y = 2001
Output: No
Approach: The given problem can be solved by using Hashing. Follow the steps below to solve the given problem. 

Declare two unordered maps, say s1 and s2 which will store (char, boolean) pair.
Create strings total_concat which will store D + M.
Traverse both total_concat and Y and store characters in s1 and s2 respectively. 
Run a for loop and insert all numbers of total_concat in set1 and Y in set2.
Compare the two maps s1 and s2: 
If s1 = s2, return Yes. 
Else return No. 
Below is the implementation of the above approach:
     */
    public class DateYear
    {
        static bool check(string D, string M, string Y)
        {

            bool[] s1 = new bool[10]; bool[] s2 = new bool[10];


            // Concatenate date and month
            string total_concat = D + M;

            // Insert the elements in set
            for (int i = 0; i < 4; i++)
            {
                s1[total_concat[i] - '0'] = true;
                s2[Y[i] - '0'] = true;
            }


            // Return 1 if both set contains
            // same set of numbers otherwise
            // return 0
            return compareArray(s1, s2);
        }
        static bool compareArray(bool[] one, bool[] two)
        {
            if (one.Length != two.Length)
                return false;
            for (int i = 0; i < one.Length; i++)
            {
                if (one[i] != two[i])
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string D = "20";
            string M = "12";
            string Y = "2001";

            if (check(D, M, Y)) Console.WriteLine("true");
            else Console.WriteLine("false");
            /*
             Output:Yes
Time Complexity: O(Y), where Y is size of year. 

Auxiliary Space: O(1)
            */
        }
    }
}
