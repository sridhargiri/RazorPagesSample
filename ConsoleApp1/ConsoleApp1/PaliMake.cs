// A Naive recursive C# program  
// to find minimum number  
// insertions needed to make  
// a string palindrom 
using System;
using System.Diagnostics;

class PaliMake
{
    // Recursive function to  
    // find minimum number of 
    // insertions 
    static int findMinInsertions(char[] str,
                                 int l, int h)
    {
        // Base Cases 
        if (l > h) return int.MaxValue;
        if (l == h) return 0;
        if (l == h - 1)
            return (str[l] == str[h]) ? 0 : 1;

        // Check if the first and  
        // last characters are same.  
        // On the basis of the  
        // comparison result, decide  
        // which subrpoblem(s) to call 
        return (str[l] == str[h]) ?
                findMinInsertions(str, l + 1, h - 1) :
                (Math.Min(findMinInsertions(str, l, h - 1),
                          findMinInsertions(str, l + 1, h)) + 1);
    }

    // Recursive function to count number of appends  
    static int noOfAppends(String s)
    {
        if (isPalindrome(s.ToCharArray()))
            return 0;

        // Removing first character of string by  
        // incrementing base address pointer.  
        s = s.Substring(1);

        return 1 + noOfAppends(s);
    }
    // Checking if the string is palindrome or not  
    static Boolean isPalindrome(char[] str)
    {
        int len = str.Length;

        // single character is always palindrome  
        if (len == 1)
            return true;

        // pointing to first character  
        char ptr1 = str[0];

        // pointing to last character  
        char ptr2 = str[len - 1];

        while (ptr2 > ptr1)
        {
            if (ptr1 != ptr2)
                return false;
            ptr1++;
            ptr2--;
        }

        return true;
    }


    // Driver Code 
    public static void Main()
    {
        string str = "ebada";// "abede";// "leetcode";// "Ab3bd";
        //Console.WriteLine(findMinInsertions(str.ToCharArray(), 0, str.Length - 1));
        Console.WriteLine("{0}\n", noOfAppends(str));
    }
}