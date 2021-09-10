using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Check if an integer is rotation of another given integer
Last Updated : 12 Feb, 2021
Given two integers A and B, the task is to check if the integer A is rotation of the digits of the integer B or not. If found to be true, then print “Yes”. Otherwise print “No”.

Examples:

Input: A= 976, B= 679
Output: Yes

Input: A= 974, B= 2345
Output: No

Approach: Follow the steps below to solve the problem:
    If A == B, then print “Yes”.
Calculate the count of digits of integer present in the integer A and B in variables, say dig1 and dig2.
If dig1 != dig2 is found ot be true, then print “No”.
Initialize a variable, say temp. Assign temp = A.
Now, iterate and perform the following operations:
Find the position of the first digit value of A and store it in a variable, say X = A / 10(dig1 – 1).
Rotate the digits of the integer A by performing A = (A – X*10(dig1 – 1))*10 + X.
Print “Yes” if A is equal to B and break.
Check if (A== temp) i.e A becomes equal to original integer temp. If found to be true, then print “No” and break.
Below is the implementation of the above approach:
    */
    class NumberRotation
    {
        static bool check(double A, double B)
        {

            if (A == B)
            {
                return true;
            }

            // Stores the count of digits in A 
            double dig1 = Math.Floor(Math.Log10(A) + 1);

            // Stores the count of digits in B 
            double dig2 = Math.Floor(Math.Log10(B) + 1);

            // If dig1 not equal to dig2 
            if (dig1 != dig2)
            {
                return false;
            }

            double temp = A;

            while (true)
            {

                // Stores position of first digit 
                double power = Math.Pow(10, dig1 - 1);

                // Stores the first digit 
                double firstdigit = A / power;

                // Rotate the digits of the integer 
                A = A - firstdigit * power;
                A = A * 10 + firstdigit;

                // If A is equal to B 
                if (A == B)
                {
                    return true;
                }
                // If A is equal to the initial 
                // value of integer A 
                if (A == temp)
                {
                    return false;
                }
            }
        }
        public static void Main(string[] args)
        {
            double A = 967, B = 679;
            if (check(A, B))
                Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
    /*
     https://www.geeksforgeeks.org/a-program-to-check-if-strings-are-rotations-of-each-other/
    
     A Program to check if strings are rotations of each other or not
Difficulty Level : Easy
Last Updated : 09 Sep, 2021
Given a string s1 and a string s2, write a snippet to say whether s2 is a rotation of s1? 
(eg given s1 = ABCD and s2 = CDAB, return true, given s1 = ABCD, and s2 = ACBD , return false)

Algorithm: areRotations(str1, str2)

    1. Create a temp string and store concatenation of str1 to
       str1 in temp.
                          temp = str1.str1
    2. If str2 is a substring of temp then str1 and str2 are 
       rotations of each other.

    Example:                 
                     str1 = "ABACD"
                     str2 = "CDABA"

     temp = str1.str1 = "ABACDABACD"
     Since str2 is a substring of temp, str1 and str2 are 
     rotations of each other.
    */
    public class StringRotation
    {

        /* Function checks if passed strings
        (str1 and str2) are rotations of
        each other */
        static bool areRotations(String str1,
                                     String str2)
        {

            // There lengths must be same and
            // str2 must be a substring of
            // str1 concatenated with str1.
            return (str1.Length == str2.Length)
                 && ((str1 + str1).IndexOf(str2)
                                         != -1);
        }

        // Driver method
        public static void Main()
        {
            String str1 = "FGABCDE";
            String str2 = "ABCDEFG";

            if (areRotations(str1, str2))
                Console.Write("Strings are"
                + " rotation s of each other");
            else
                Console.Write("Strings are not rotations of each other");
            //Output
            //Strings are rotations of each other
        }
    }
}
