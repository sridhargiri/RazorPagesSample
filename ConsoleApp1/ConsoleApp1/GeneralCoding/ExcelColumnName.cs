using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-excel-column-name-given-number/

    Find Excel column name from a given column number
    MS Excel columns have a pattern like A, B, C, …, Z, AA, AB, AC, …., AZ, BA, BB, … ZZ, AAA, AAB ….. etc. In other words, column 1 is named as “A”, column 2 as “B”, column 27 as “AA”.
Given a column number, find its corresponding Excel column name. The following are more examples.

Input          Output
 26             Z
 51             AY
 52             AZ
 80             CB
 676            YZ
 702            ZZ
 705            AAC

    Method 2 
The problem is similar to converting a decimal number to its binary representation but instead of a binary base system where we have two digits only 0 and 1, here we have 26 characters from A-Z.
So, we are dealing with base 26 instead of base binary. 
That’s not where the fun ends, we don’t have zero in this number system, as A represents 1, B represents 2 and so on Z represents 26. 
To make the problem easily understandable, we approach the problem in two steps:

Convert the number to base 26 representation, considering we have 0 also in the system.
Change the representation to the one without having 0 in its system.
HOW? Here is an example

Step 1: 
Consider we have number 676, How to get its representation in the base 26 system? The same way we do for a binary system, Instead of division and remainder by 2, we do division and remainder by 26.

Base 26 representation of 676 is : 100 
Step2
But Hey, we can’t have zero in our representation. Right? Because it’s not part of our number system. How do we get rid of zero? Well it’s simple, but before doing that let’s remind one simple math trick:

Subtraction: 
5000 - 9, How do you subtract 9 from 0 ? You borrow
from next significant bit, right.  
In a decimal number system to deal with zero, we borrow 10 and subtract 1 from the next significant.
In Base 26 Number System to deal with zero, we borrow 26 and subtract 1 from the next significant bit.
So Convert 10026 to a number system that does not have ‘0’, we get (25 26)26 
Symbolic representation of the same is: YZ 

Here is the implementation of the same:
     */
    class ExcelColumnName
    {

        static void printString(int n)
        {
            int[] arr = new int[10000];
            int i = 0;

            // Step 1: Converting to
            // number assuming 0 in
            // number system
            while (n > 0)
            {
                arr[i] = n % 26;
                n = n / 26;
                i++;
            }

            // Step 2: Getting rid of 0,
            // as 0 is not part of number
            // system
            for (int j = 0; j < i - 1; j++)
            {
                if (arr[j] <= 0)
                {
                    arr[j] += 26;
                    arr[j + 1] = arr[j + 1] - 1;
                }
            }

            for (int j = i; j >= 0; j--)
            {
                if (arr[j] > 0)
                    Console.Write((char)('A' +
                                   arr[j] - 1));
            }
            Console.WriteLine();
        }

        // Driver code
        public static void Main(String[] args)
        {
            printString(26);
            printString(51);
            printString(52);
            printString(80);
            printString(676);
            printString(702);
            printString(705);
            /*
             Output: 

Z
AY
AZ
CB
YZ
ZZ
AAC
            */
        }
    }
}
