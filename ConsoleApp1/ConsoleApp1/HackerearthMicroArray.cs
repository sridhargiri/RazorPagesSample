using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
     
     Micro purchased an array A having N integer values. After playing it for a while, he got bored of it and decided to update value of its element. In one second he can increase value of each array element by 1. He wants each array element's value to become greater than or equal to K. Please help Micro to find out the minimum amount of time it will take, for him to do so.

Input:
First line consists of a single integer, T, denoting the number of test cases.
First line of each test case consists of two space separated integers denoting N and K.
Second line of each test case consists of N space separated integers denoting the array A.

Output:
For each test case, print the minimum time in which all array elements will become greater than or equal to K. Print a new line after each test case.
    */
    class HackerearthMicroArray
    {
        public static int minItem(int[] array)
        {
            int min = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }
        static int findMinCount(int[] array, int k)
        {
            int minnumber = minItem(array);
            return k - minnumber < 0 ? 0 : k - minnumber;
        }
        /*
    
2
3 4
1 2 5
3 2
2 5 5
Output
0
Expected Correct Output
3
0
         */
        static void Main(string[] args)
        {
            int[] firstarray = null, secondarray = null;
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                firstarray = Console.ReadLine().Split(' ').Select(n1 => Int32.Parse(n1)).ToArray();
                secondarray = Console.ReadLine().Split(' ').Select(n1 => Int32.Parse(n1)).ToArray();

                Console.WriteLine(findMinCount(secondarray, firstarray[1]));
            }
        }
    }
}
