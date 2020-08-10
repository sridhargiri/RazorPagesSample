using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class LengthOfConsecutiveOnes
    { // Function to find length of the  
      // longest consecutive 1s in binary 
      // reprsentation of a number  
        private static int maxConsecutiveOnes(int x)
        {

            // Initialize result 
            int count = 0;

            // Count the number of iterations 
            // to reach x = 0. 
            while (x != 0)
            {

                // This operation reduces length 
                // of every sequence of 1s by one. 
                x = (x & (x >> 1));

                count++;
            }

            return count;
        }
        // Driver code 
        public static void Main()
        {
            Console.WriteLine(maxConsecutiveOnes(239));
            Console.WriteLine(maxConsecutiveOnes(14));
            Console.Write(maxConsecutiveOnes(222));
        }

    }
}
