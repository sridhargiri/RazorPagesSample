using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Pascal’s triangle is a triangular array of the binomial coefficients. 
    Write a function that takes an integer value n as input and prints first n lines of the Pascal’s triangle. Following are the first 6 rows of Pascal’s Triangle.
1  
1 1 
1 2 1 
1 3 3 1 
1 4 6 4 1 
1 5 10 10 5 1 
      
     
     Method 3 ( O(n^2) time and O(1) extra space )
This method is based on method 1. We know that ith entry in a line number line is Binomial Coefficient C(line, i) and all lines start with value 1. 
    The idea is to calculate C(line, i) using C(line, i-1). It can be calculated in O(1) time using the following.

C(line, i)   = line! / ( (line-i)! * i! )
C(line, i-1) = line! / ( (line - i + 1)! * (i-1)! )
We can derive following expression from above two expressions.
C(line, i) = C(line, i-1) * (line - i + 1) / i

So C(line, i) can be calculated from C(line, i-1) in O(1) time
     */
    class PascalTriangle
    {

        // Pascal function  
        public static void printPascal(int n)
        {
            for (int line = 1;
                    line <= n; line++)
            {

                int C = 1;// used to represent C(line, i)  
                for (int i = 1; i <= line; i++)
                {
                    // The first value in a 
                    // line is always 1  
                    Console.Write(C + " ");
                    C = C * (line - i) / i;
                }
                Console.Write("\n");
            }
        }

        // Driver code  
        public static void Main()
        {
            int n = 5;
            printPascal(n);
        }
    }
}
