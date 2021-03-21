using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MultiplyWithoutMultiply
    {
        /*Multiply two integers without using multiplication, division and bitwise operators, and no loops
Difficulty Level : Easy
 Last Updated : 15 Mar, 2021
By making use of recursion, we can multiply two integers with the given constraints. 
To multiply x and y, recursively add x y times. 
        */
        static int multiply(int x, int y)
        {

            // 0 multiplied with anything gives 0 
            if (y == 0)
                return 0;

            // Add x one by one 
            if (y > 0)
                return x + multiply(x, y - 1);

            // the case where y is negative 
            if (y < 0)
                return -multiply(x, -y);

            return -1;
        }

        // Driver code 
        public static void Main()
        {

            Console.WriteLine(multiply(5, -11));
        }
        /*
         Output:
-55
Time Complexity: O(y) where y is the second argument to function multiply().
        */
    }
}
