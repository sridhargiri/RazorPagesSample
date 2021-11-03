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
    public class NumberPattern
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
                temp += (char)(str1[i] + K - i);
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
    /*
     https://www.geeksforgeeks.org/program-to-print-the-trapezium-pattern/
    Program to Print the Trapezium Pattern
Last Updated : 30 May, 2021
Given ‘num’ which indicates number of lines.The task is to print a trapezium pattern in num lines.
Examples: 
 

Input  : 4 
Output :
1*2*3*4*17*18*19*20
  5*6*7*14*15*16
    8*9*12*13
      10*11


Input : 2
Output :
1*2*5*6
  3*4
Algorithm : 
step 1. To read num which indicates the number of lines. 
step 2.We are diving the pattern into 2 halves that is LHS part and the RHS part. 
Ex : When num = 2 
LHS – 
1*2* 
3*
RHS – 
5*6 
4 
step 3.Combining LHS and RHS we get the complete pattern.
     */
    public class TrapeziumPattern
    {

        public static void Main(String[] args)
        {

            // Scanner scn = new Scanner(System.in);
            int num = 3;
            int space;
            // System.out.println("Enter number of lines : ");
            // num = scn.nextInt();

            int i, j, lterm, rterm;

            lterm = 1; // The terms on the LHS of the pattern

            // The terms on the RHS of the pattern
            rterm = num * num + 1;

            for (i = num; i > 0; i--)
            {

                // To print number of spaces
                for (space = num; space > i; space--)
                    Console.Write(" ");

                for (j = 1; j <= i; j++)
                {
                    Console.Write(lterm);
                    Console.Write("*");
                    lterm++;
                }
                for (j = 1; j <= i; j++)
                {
                    Console.Write(rterm);
                    if (j < i)
                        Console.Write("*");
                    rterm++;
                }

                // To get the next term on RHS of the Pattern
                rterm = rterm - (i - 1) * 2 - 1;
                Console.WriteLine();
                /*
                 Output: 

Enter number of lines : 3
1*2*3*10*11*12
  4*5*8*9
    6*7
                */
            }
        }
    }
    /*
     https://www.geeksforgeeks.org/print-following-pyramid-pattern/
    Print the following pyramid pattern
Difficulty Level : Medium
Last Updated : 29 Apr, 2021
Given a positive integer n. The problem is to print the pyramid pattern as described in the examples below.

Examples: 
Input : n = 4
Output : 
1
3*2
4*5*6
10*9*8*7

Input : n = 5
Output :
1
3*2
4*5*6
10*9*8*7
11*12*13*14*15
Source: Amdocs Interview Experience | Set 1- https://www.geeksforgeeks.org/amdocs-interview-experience-set-1-on-campus/
Approach: For odd number row, values are being displayed in increasing order and for even number row, values are being displayed in decreasing order. 
    The only other trick is to how to iterate the loops.

Algorithm: 

printPattern(int n)
    Declare j, k
    Initialize k = 0

    for i = 1 to n

    if i%2 != 0
        for j = k+1, j < k+i, j++
        print j and "*"
        print j and new line    
        k = ++j

    else
        k = k+i-1
        for j = k, j > k-i+1, j--
        print j and "*";
        print j and new line
     */
    public class PeculiarPyramidPattern
    {

        // function to print the following pyramid
        // pattern
        static void printPattern(int n)
        {
            int j, k = 0;

            // loop to decide the row number
            for (int i = 1; i <= n; i++)
            {

                // if row number is odd
                if (i % 2 != 0)
                {

                    // print numbers with the '*'
                    // sign in increasing order
                    for (j = k + 1; j < k + i; j++)
                        Console.Write(j + "*");
                    Console.WriteLine(j);

                    // update value of 'k'
                    k = ++j;
                }

                // if row number is even
                else
                {

                    // update value of 'k'
                    k = k + i - 1;

                    // print numbers with the '*' in
                    // decreasing order
                    for (j = k; j > k - i + 1; j--)
                        Console.Write(j + "*");
                    Console.WriteLine(j);
                }
            }
        }

        // Driver program to test above
        public static void Main()
        {
            int n = 5;
            printPattern(n);
            /*
             Output: 

1
3*2
4*5*6
10*9*8*7
11*12*13*14*15
Time Complexity: O((n * (n + 1)) / 2)
            */
        }
    }
    /*
Print below pattern
A
BB
CCC
DDDD
EEEEE
    */
    class AlphabetPattern
    {
        public static void Main(string[] args)
        {
            int i, j, n = 5;
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= i; j++)
                {
                    Console.Write((char)(i + 64));
                }
                Console.WriteLine();
            }
        }
    }
}

