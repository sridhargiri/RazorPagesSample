using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class BinaryRepresentation
    {
        /*
         Method 1: Iterative 
For any number, we can check whether its ‘i’th bit is 0(OFF) or 1(ON) by bitwise ANDing it with “2^i” (2 raise to i). 

1) Let us take number 'NUM' and we want to check whether it's 0th bit is ON or OFF    
    bit = 2 ^ 0 (0th bit)
    if  NUM & bit == 1 means 0th bit is ON else 0th bit is OFF

2) Similarly if we want to check whether 5th bit is ON or OFF    
    bit = 2 ^ 5 (5th bit)
    if NUM & bit == 1 means its 5th bit is ON else 5th bit is OFF.
Let us take unsigned integer (32 bit), which consist of 0-31 bits. To print binary representation of unsigned integer, start from 31th bit, check whether 31th bit is ON or OFF, if it is ON print “1” else print “0”. Now check whether 30th bit is ON or OFF, if it is ON print “1” else print “0”, do this for all bits from 31 to 0, finally we will get binary representation of number.


void bin(unsigned n)
{
    unsigned i;
    for (i = 1 << 31; i > 0; i = i / 2)
        (n & i) ? printf("1") : printf("0");
}
         */

        //Method 2: Recursive
        //Following is recursive method to print binary representation of ‘NUM’. 

        //step 1) if NUM > 1
        //    a) push NUM on stack
        //    b) recursively call function with 'NUM / 2'
        //step 2)
        //    a) pop NUM from stack, divide it by 2 and print it's remainder.

        static void bin(int n)
        {

            // step 1
            if (n > 1)
                bin(n / 2);

            // step 2
            Console.Write(n % 2);
        }
        /*
         Method 3: Recursive using bitwise operator 
Steps to convert decimal number to its binary representation are given below: 

step 1: Check n > 0
step 2: Right shift the number by 1 bit and recursive function call
step 3: Print the bits of number
        */


        // Function to convert decimal
        // to binary number
        static void bin1(int n)
        {
            if (n > 1)
                bin1(n >> 1);

            Console.Write(n & 1);
        }


        // Driver code
        static public void Main()
        {
            bin(7);
            Console.WriteLine();
            bin(4);
            bin1(131);
            Console.WriteLine();
            bin1(3);
        }
    }
}
