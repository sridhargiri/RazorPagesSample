using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MaxActivity
    {
        // Prints a maximum set of activities  
        // that can be done by a single 
        // person, one at a time. 
        // n --> Total number of activities 
        // s[] --> An array that contains start 
        //         time of all activities 
        // f[] --> An array that contains finish 
        //         time of all activities 
        public static void printMaxActivities(int[] s,
                                              int[] f, int n)
        {
            int i, j;

            Console.Write("Following activities are selected : ");

            // The first activity always gets selected 
            i = 0;
            Console.Write(i + " ");

            // Consider rest of the activities 
            for (j = 1; j < n; j++)
            {
                // If this activity has start time greater than or 
                // equal to the finish time of previously selected 
                // activity, then select it 
                if (s[j] >= f[i])
                {
                    //Console.Write(j + " ");
                    Console.WriteLine($"i {i} j {j}");
                    i = j;
                }
            }
        }

        // Driver Code 
        public static void Main()
        {
            int[] s = { 1, 3, 0, 5, 8, 5 };
            int[] f = { 2, 4, 6, 7, 9, 9 };
            int n = s.Length;

            printMaxActivities(s, f, n);
        }
    }
}
