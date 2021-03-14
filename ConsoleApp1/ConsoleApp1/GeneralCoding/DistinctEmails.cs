using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Count distinct emails present in a given array
Last Updated : 12 Mar, 2021
Given an array arr[] consisting of N strings where each string represents an email address consisting of English alphabets, ‘.’, ‘+’ and ‘@’, the task is to count the number of distinct emails present in the array according to the following rules:

An email address can be split into two substrings, the prefix and suffix of ‘@’, which are the local name and domain name respectively.
The ‘.’ character in the string in the local name is ignored.
In the local name, every character after ‘+‘ is ignored.
Examples:

Input: arr[] = {“raghav.agg@geeksforgeeks.com”, “raghavagg@geeksforgeeks.com”}
Output: 1
Explanation: Removing all the ‘.’s before ‘@’ modifies the strings to {“raghavagg@geeksforgeeks.com”, “raghavagg@geeksforgeeks.com”}. Therefore, the total number of distinct emails present in the string are 1.

Input: arr[] = {“avruty+dhir+gfg@geeksforgeeks.com”, “avruty+gfg@geeksforgeeks.com”, “av.ruty@geeksforgeeks.com”}
Output: 1

Approach: The given problem can be solved by storing each email in a HashSet after populating it according to the given rule and print the size of the HashSet obtained. Follow the steps below to solve the problem:


https://www.geeksforgeeks.org/count-distinct-emails-present-in-a-given-array/

Initialize a HashSet, say S, to store all the distinct strings after populating according to the given rules.
Traverse the given array arr[] and perform the following steps:
Find the position of ‘@’ and store it in a variable, say pos2.
Delete all the ‘.’ characters before pos2 using erase() function.
Update the position of ‘@’ i.e., pos2 = find(‘@’) and find the position of ‘+’ and store it in a variable say pos1 as S.find(‘+’).
Now, erase all the characters after pos1 and before pos2.
Insert all the updated strings in a HashSet S.
After completing the above steps, print the size of HashSet S as the result.
Below is the implementation of the above approach:

Output: 1
Time Complexity: O(N2)
Auxiliary Space: O(N)
    */
    class DistinctEmails
    {
        static void findDistinctEmails(string[] emails)
        {
            HashSet<string> hash = new HashSet<string>();
            for (int i = 0; i < emails.Length; i++)
            {
                int atindex = emails[i].IndexOf('@');
                string b4at = emails[i].Substring(0, atindex);
                string afterat = emails[i].Substring(atindex, emails[i].Length - atindex);
                if (atindex < emails[i].Length)
                    b4at = b4at.Replace(".", "");
                int plusidex = b4at.IndexOf('+');
                if (plusidex != -1)
                    b4at = b4at.Substring(0, plusidex);
                hash.Add(string.Concat(b4at, afterat));
            }
            Console.WriteLine(hash.Count);
        }
        static void Main(string[] args)
        {
            string[] arr
        = new string[] { "raghav.agg+abc@geeksforgeeks.com",
            "raghavagg@geeksforgeeks.com" };
            findDistinctEmails(arr);
        }
    }
}
