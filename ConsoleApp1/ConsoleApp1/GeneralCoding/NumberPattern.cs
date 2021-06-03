// C# Program to illustrate the
// above given pattern of numbers
using System;
namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/c-program-to-print-a-pattern-of-numbers/?ref=rp
    Program to print a pattern of numbers
    Difficulty Level : Medium
    Last Updated : 07 Apr, 2021
    The idea of pattern based programs is to understand the concept of nesting of for loops and how and where to place the alphabets / numbers / stars to make the desired pattern.
    Write to program to print the pattern of numbers in the following manner using for loop 


        1
       232
      34543
     4567654
    567898765
    In almost all types of pattern programs, two things that you must take care: 


    No. of lines
    If the pattern is increasing or decreasing per line?
    Implementation 
    */
    class NumberPattern
    {

        public static void Main()
        {

            int n = 5, i, j, num = 1, gap;

            gap = n - 1;

            for (j = 1; j <= n; j++)
            {
                num = j;

                for (i = 1; i <= gap; i++)
                    Console.Write(" ");

                gap--;

                for (i = 1; i <= j; i++)
                {
                    Console.Write(num);
                    num++;
                }
                num--;
                num--;
                for (i = 1; i < j; i++)
                {
                    Console.Write(num);
                    num--;
                }
                Console.WriteLine();
            }
            /*
             Output: 
 

    1
   232
  34543
 4567654
567898765
            */
            // This code is contributed
            // by vt_m.
        }
    }
    /*
     print triangle pyramid stars like this
    *
   ***
  *****
 *******
*********
        
     */
    class StarPattern
    {
        public static void Print_stars_pattern_pyramid(int n)
        {
            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k <= 2 * i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public static void Main(string[] args)
        {
            Print_stars_pattern_pyramid(10);
        }
    }
    /*
Matrix Pattern:

1  2  4  7
3  5  8 11
6  9 12 14
10 13 15 16
    */
    public class MatrixPattern
    {
        static void print_matrix_pattern(int r)
        {
            int[,] a = new int[100, 100];
            int n, p = 1, j, m, k;
            for (j = 1; j <= r; j++)
            {
                m = 0;
                n = j;
                for (k = 1; k <= j; k++)
                    a[m++, --n] = p++;
            }

            for (j = 1; j <= r - 1; j++)
            {
                m = j;
                n = r - 1;
                for (k = 1; k <= r - j; k++)
                    a[m++, n--] = p++;
            }

            for (j = 0; j <= r - 1; j++)
            {
                for (k = 0; k <= r - 1; k++)
                    Console.Write(a[j, k] + " ");
                Console.WriteLine();
            }
        }
        public static void Main(string[] args)
        {
            print_matrix_pattern(4);
        }
    }
    /*
     Pattern:

   
   *
  *A*
 *A*A*
*A*A*A*
*/
    public class AStarPattern
    {
        static void a_star_pattern(int n)
        {
            int c, k;
            for (c = 1; c <= n; c++)
            {
                for (k = 1; k <= n - c; k++)
                    Console.Write(" ");
                for (k = 1; k < c; k++)
                    Console.Write("*A");
                Console.Write("*");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            a_star_pattern(9);
        }
    }
    public class StringAttain
    {
        /*
         It was a string manipulation question. Suppose input was string1, string2, and k seconds. 
        We have to choose every i from 1 to k and shift a character from the string by i index (eg: if i=3 then ‘a’ would be shifted to ‘d’). 
        Each i could be chosen only once. We need to check if we can convert string1 to string2. (20 marks)
Input:  
k=3
string1 = 'abc'
string2 = 'ddd'
Output:  
Yes
        */
        public static void CanStringAttain(string str1, string str2, int K)
        {
            string temp = "";
            for (int i = 0; i < K; i++)
            {
                temp += (char)(str1[i]+K-i);
            }
            if (temp == str2)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        public static void Main(string[] args)
        {
            CanStringAttain("abc", "ddd", 3);
        }
    }
}

