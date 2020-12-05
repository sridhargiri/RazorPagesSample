using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Rec
    {

        // function to demonstrate  
        // working of recursion 
        static void printFun(int test)
        {
            if (test < 1)
                return;
            else
            {
                Console.Write(test + " ");

                // statement 2 
                printFun(test - 1);

                
            }
        }

        // Driver Code 
        public static void Main(String[] args)
        {
            int test = 3;
            printFun(test);
        }
    }
}
