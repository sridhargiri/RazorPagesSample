using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     The numbers that can be arranged to form a rectangle are called Rectangular Numbers (also known as Pronic numbers). The first few Pronic numbers are:
0, 2, 6, 12, 20, 30, 42, 56, 72, 90, 110, 132, 156, 182, 210, 240, 272, 306, 342, 380, 420, 462 . . . . . .
    https://www.geeksforgeeks.org/rectangular-numbers/
Pronic number is a number which is the product of two consecutive integers, that is, a number n is a product of x and (x+1). The task is to check and print Pronic Numbers in a range.

Examples :

Input  : 6
Output : Pronic Number
Explanation: 6 = 2 * 3 i.e 6 is a product
of two consecutive integers 2 and 3.

Input :56
Output :Pronic Number
Explanation: 56 = 7 * 8 i.e 56 is a product 
of two consecutive integers 7 and 8. 

Input  : 8
Output : Not a Pronic Number
Explanation: 8 = 2 * 4 i.e 8 is a product of 
2 and 4 which are not consecutive integers.
    */
    class PronicNumber
    {
        static bool checkPronic(int x)
        {
            for (int i = 0;
                     i <= (int)(Math.Sqrt(x));
                     i++)

                // Checking Pronic Number by  
                // multiplying consecutive numbers 
                if (x == i * (i + 1))
                    return true;

            return false;
        }

        // Driver Code 
        public static void Main()
        {
            // Printing Pronic  
            // Numbers upto 200 
            for (int i = 0; i <= 200; i++)
                if (checkPronic(i))
                    Console.Write(i + " ");
        }
        //        Output :
        //0 2 6 12 20 30 42 56 72 90 110 132 156 182
    }
}

