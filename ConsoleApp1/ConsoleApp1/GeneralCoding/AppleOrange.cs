using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class AppleOrange
    {
        // Complete the countApplesAndOranges function below.
        // https://www.hackerrank.com/challenges/apple-and-orange/problem
        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int apple = 0, orange = 0; int landingSpot = 0; int landingSpot1 = 0;
            for (int i = 0; i < apples.Length; i++)
            {
                landingSpot = apples[i] + a;
                if (landingSpot >= s && landingSpot <= t)
                {
                    apple++;
                }

            }

            for (int i = 0; i < oranges.Length; i++)
            {
                landingSpot1 = oranges[i] + b;
                if (landingSpot1 >= s && landingSpot1 <= t)
                {
                    orange++;
                }
            }
            Console.WriteLine(apple);
            Console.WriteLine(orange);
        }

        static void Main(string[] args)
        {
            string[] st = Console.ReadLine().Split(' ');

            int s = Convert.ToInt32(st[0]);

            int t = Convert.ToInt32(st[1]);

            string[] ab = Console.ReadLine().Split(' ');

            int a = Convert.ToInt32(ab[0]);

            int b = Convert.ToInt32(ab[1]);

            string[] mn = Console.ReadLine().Split(' ');

            int m = Convert.ToInt32(mn[0]);

            int n = Convert.ToInt32(mn[1]);

            int[] apples = Array.ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp))
            ;

            int[] oranges = Array.ConvertAll(Console.ReadLine().Split(' '), orangesTemp => Convert.ToInt32(orangesTemp))
            ;
            countApplesAndOranges(s, t, a, b, apples, oranges);
        }
    }
}
