using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class NonRepeatingChar
    {

        // Function to find the 
        // required output string 
        static void findString(int N, int K)
        {

            // Each element at index 
            // i is modulus of K 
            for (int i = 0; i < N; i++)
            {
                Console.Write((char)('A' + i % K));
            }
        }

        // Driver code 
        public static void Main(String[] args)
        {

            // Initialise integers N and K 
            int N = 10;
            int K = 3;

            findString(N, K);
        }
    }
}


