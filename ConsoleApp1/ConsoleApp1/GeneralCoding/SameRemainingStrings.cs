using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Modify array of strings by replacing characters repeating in the same or remaining strings
Last Updated : 15 Mar, 2021
Given an array of strings arr[] consisting of lowercase and uppercase characters only, the task is to modify the array by removing the characters from the strings which are repeating in the same string or any other string. Print the modified array. 

Examples:

Input: arr[] = {“Geeks”, “For”, “Geeks”}
Output: {“Geks”, “For”}
Explanation:
In arr[0[, ‘e’ occurs twice in the string. Removing a single ‘e’ from the first string modifies “Geeks” to “Geks”. 
In arr[1], all characters are non-repeating. Therefore, the string remains unchanged.
In arr[2], the string is same as arr[0]. Therefore, the complete string is required to be removed.

Input: arr[] = {“Geeks”, “For”, “Geeks”, “Post”}
Output: {“Geks”, “For”, “Pt”}

Approach: Follow the steps to solve the problem :




Initialize an unordered set to store the characters of the string while traversing the array.
Traverse the array and for each string, perform the following operations:
Iterate over the characters of the string.
If the current character is already present in the Set, skip it. Otherwise, append it to the output string.
Push the newly generated string into the list initialized to store the output.
Print the list of strings obtained as the answer.
Below is the implementation of the above approach:
    */
    class SameRemainingStrings
    {
        static void remove_Duplicate_Characters_in_same__array_of_string(string[] arr)
        {
            // Stores distinct characters 
            HashSet<char> set = new HashSet<char>();
            List<string> outlist = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                // Stores the modiifed string 
                string out_curr = "";
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (!set.Add(arr[i][j]))
                    {
                        continue;
                    }
                    out_curr += arr[i][j];
                }
                if (out_curr.Length > 0) outlist.Add(out_curr);
            }
            for (int k = 0; k < outlist.Count; k++)
            {
                Console.Write(outlist[k] + " ");
            }
        }
        static void Main(string[] args)
        {
            string[] arr = { "Geeks", "For", "Geeks", "Post" };
            remove_Duplicate_Characters_in_same__array_of_string(arr);
        }
        /*
         Output:
Geks For Pt
Time Complexity: O(N * M) where M is the length of the longest string in the array.
Auxiliary Space: O(N)
        */
    }
}
