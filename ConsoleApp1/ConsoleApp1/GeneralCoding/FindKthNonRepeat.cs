using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*

     https://www.geeksforgeeks.org/kth-non-repeating-character/
    K’th Non-repeating Character
Difficulty Level : Medium
Last Updated : 10 Mar, 2021
Given a string and a number k, find the k’th non-repeating character in the string. Consider a large input string with lacs of characters and a small character set. How to find the character by only doing only one traversal of input string? 
Examples: 
 

Input : str = geeksforgeeks, k = 3
Output : r
First non-repeating character is f,
second is o and third is r.

Input : str = geeksforgeeks, k = 2
Output : o

Input : str = geeksforgeeks, k = 4
Output : Less than k non-repeating
         characters in input.
 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
This problem is mainly an extension of First non-repeating character problem.
Method 1 (Simple : O(n2) 
A Simple Solution is to run two loops. Start traversing from left side. For every character, check if it repeats or not. If the character doesn’t repeat, increment count of non-repeating characters. When the count becomes k, return the character.
Method 2 (O(n) but requires two traversals) 
 

Create an empty hash.
Scan input string from left to right and insert values and their counts in the hash.
Scan input string from left to right and keep count of characters with counts more than 1. When count becomes k, return the character.
Method 3 (O(n) and requires one traversal) 
The idea is to use two auxiliary arrays of size 256 (Assuming that characters are stored using 8 bits). The two arrays are: 
 

count[x] : Stores count of character 'x' in str.
           If x is not present, then it stores 0.

index[x] : Stores indexes of non-repeating characters
           in str. If a character 'x' is not  present
           or x is repeating, then it stores  a value
           that cannot be a valid index in str[]. For 
           example, length of string.
 



Initialize all values in count[] as 0 and all values in index[] as n where n is length of string.
Traverse the input string str and do following for every character c = str[i]. 
Increment count[x].
If count[x] is 1, then store index of x in index[x], i.e., index[x] = i
If count[x] is 2, then remove x from index[], i.e., index[x] = n
Now index[] has indexes of all non-repeating characters. Sort index[] in increasing order so that we get k’th smallest element at index[k]. Note that this step takes O(1) time because there are only 256 elements in index[].
Below is implementation of above idea.
     */
    class FindKthNonRepeat
    {

        public static int MAX_CHAR = 256;

        // Returns index of k'th non-repeating
        // character in given string str[]
        static int kthNonRepeating(String str, int k)
        {

            int n = str.Length;

            // count[x] is going to store count of
            // character 'x' in str. If x is not
            // present, then it is going to store 0.
            int[] count = new int[MAX_CHAR];

            // index[x] is going to store index of
            // character 'x' in str. If x is not
            // present or x is repeating, then it
            // is going to store a value (for
            // example, length of string) that
            // cannot be a valid index in str[]
            int[] index = new int[MAX_CHAR];

            // Initialize counts of all characters
            // and indexes of non-repeating
            // characters.
            for (int i = 0; i < MAX_CHAR; i++)
            {
                count[i] = 0;

                // A value more than any index
                // in str[]
                index[i] = n;
            }

            // Traverse the input string
            for (int i = 0; i < n; i++)
            {

                // Find current character and
                // increment its count
                char x = str[i];
                ++count[x];

                // If this is first occurrence,
                // then set value in index as
                // index of it.
                if (count[x] == 1)
                    index[x] = i;

                // If character repeats, then
                // remove it from index[]
                if (count[x] == 2)
                    index[x] = n;
            }

            // Sort index[] in increasing order.
            // This step takes O(1) time as size
            // of index is 256 only
            Array.Sort(index);

            // After sorting, if index[k-1] is
            // value, then return it, else
            // return -1.
            return (index[k - 1] != n) ?
                               index[k - 1] : -1;
        }

        // driver program
        public static void Main()
        {
            String str = "geeksforgeeks";
            int k = 3;
            int res = kthNonRepeating(str, k);

            Console.Write(res == -1 ? "There are less"
                 + " than k non-repeating characters" :
                    "k'th non-repeating character is "
                                           + str[res]);
            /*
             Output: 
k'th non-repeating character is  r
 

Space Optimized Solution : 

This can be space optimized and can be solved using single index array only. Below is the space optimized solution
            */
        }


        public static int kthNonRepeating1(string input, int k)
        {
            int inputLength = input.Length;

            /*
             * indexArr will store index of non-repeating characters,
             * inputLength for characters not in input and
             * inputLength+1 for repeated characters.
             */
            int[] indexArr = new int[MAX_CHAR];

            // initialize all values in indexArr as inputLength.
            Array.Fill(indexArr, inputLength);

            for (int i = 0; i < inputLength; i++)
            {
                char c = input[i];
                if (indexArr[i] == inputLength)
                {
                    indexArr[i] = i;
                }
                else
                {
                    indexArr[i] = inputLength + 2;
                }
            }

            Array.Sort(indexArr);
            return (indexArr[k - 1] != inputLength) ? indexArr[k - 1] : -1;
            //Output: 
            //k'th non-repeating character is  r
        }
    }
}

