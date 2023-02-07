using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class AppleOrange
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

    /*
     In this HackerRank Poker Nim problem solution, we have given the values of N piles of chips indexed from 0 to n -1 and an integer K to ensure that the games end infinite time and the number of chips in each of the N piles, 
    determine whether the person who wins the game is the first or second person to move. assume both players move optimally.
    https://www.hackerrank.com/challenges/poker-nim-1/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=30-day-campaign
    https://programs.programmingoneonone.com/2021/07/hackerrank-poker-nim-problem-solution.html
     */
    public class PokerNim
    {
        public static void Main(string[] args)
        {

            int T = int.Parse(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                int[] n = Array.ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp));

                int res = 0;
                int[] _t = Array.ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp));

                for (int i = 0; i < _t.Length; i++)
                {
                    res ^= _t[i];
                }
                if (res == 0)
                {
                    Console.WriteLine("Second");
                }
                else
                {
                    Console.WriteLine("First");
                }
            }
        }
    }
}
