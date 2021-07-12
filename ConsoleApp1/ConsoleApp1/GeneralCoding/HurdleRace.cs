using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    //Question - https://www.hackerrank.com/challenges/the-hurdle-race/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
    //answer - https://github.com/RyanFehr/HackerRank/blob/master/Algorithms/Implementation/The%20Hurdle%20Race/Solution.cs
    class HurdleRace
    {
        public static int hurdleRace(int k, List<int> heights)
        {
            int b = 0;
            var maxHurdleHeight = heights.Max();
            if (maxHurdleHeight <= k)
                b = 0;
            else
                b = maxHurdleHeight - k;
            return b;

        }
    }
}
