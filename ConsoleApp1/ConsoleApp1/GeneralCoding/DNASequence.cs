using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
https://cses.fi/problemset/task/1069
https://www.geeksforgeeks.org/program-print-dna-sequence/
    Program to print DNA sequence
Difficulty Level : Basic
Last Updated : 18 Apr, 2018
Given the value of n i.e, the number of lobes. Print the double-helix structure of Deoxyribonucleic acid(DNA).

Input: n = 8
Output:
   AT
  T--A
 A----T
T------A
T------A
 G----C
  T--A
   GC
   CG
  C--G
 A----T
A------T
T------A
 A----T
  A--T
   GC
   AT
  C--G
 T----A
C------G
C------G
 T----A
  G--C
   AT
   AT
  T--A
 A----T
T------A
T------A
 G----C
  T--A
   GC
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Explanation :
DNA primarily consists of 4 hydrocarbons i.e. cytosine [C], guanine [G], adenine[A], thymine [T].
DNA bases pair up with each other, A with T and C with G, to form units called base pairs.

Below is the implementation to print the double-helix DNA sequence :
     */
    class DNASequence
    {

        // Function to print upper half 
        // of the DNA or the upper lobe
        static void printUpperHalf(string str)
        {

            char first, second;
            int pos = 0;

            // Each half of the DNA is made of 
            // combination of two compounds
            for (int i = 1; i <= 4; i++)
            {

                // Taking the two carbon 
                // compounds from the string
                first = str[pos];
                second = str[pos + 1];
                pos += 2;

                for (int j = 4 - i; j >= 1; j--)
                    Console.Write(" ");

                Console.Write(first);

                for (int j = 1; j < i; j++)
                    Console.Write("--");

                Console.WriteLine(second);
            }
        }

        // Function to print lower half 
        // of the DNA or the lower lobe
        static void printLowerHalf(string str)
        {
            char first, second;
            int pos = 0;

            for (int i = 1; i <= 4; i++)
            {

                first = str[pos];
                second = str[pos + 1];
                pos += 2;

                for (int j = 1; j < i; j++)
                    Console.Write(" ");

                Console.Write(first);

                for (int j = 4 - i; j >= 1; j--)
                    Console.Write("--");

                Console.WriteLine(second);
            }
        }

        // Function to print 'n' parts of DNA
        static void printDNA(string[] str, int n)
        {
            for (int i = 0; i < n; i++)
            {

                int x = i % 6;

                // Calling for upperhalf
                if (x % 2 == 0)
                    printUpperHalf(str[x]);
                else

                    // Calling for lowerhalf
                    printLowerHalf(str[x]);
            }
        }

        public static void Main()
        {

            int n = 8;

            // combinations stored in the array
            string[] DNA = { "ATTAATTA", "TAGCTAGC",
                     "CGCGATAT", "TAATATGC",
                     "ATCGTACG", "CGTAGCAT" };

            printDNA(DNA, n);
            /*
             Output :
   AT
  T--A
 A----T
T------A
T------A
 G----C
  T--A
   GC
   CG
  C--G
 A----T
A------T
T------A
 A----T
  A--T
   GC
   AT
  C--G
 T----A
C------G
C------G
 T----A
  G--C
   AT
   AT
  T--A
 A----T
T------A
T------A
 G----C
  T--A
   GC
            */
        }
    }
}
