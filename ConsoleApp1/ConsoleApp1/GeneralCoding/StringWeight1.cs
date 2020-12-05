using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StringWeight1
    {
        static void Main(String[] args)
        {
            string s = Console.ReadLine();
            int n = Convert.ToInt32(Console.ReadLine());

            var hash = new HashSet<int>();

            int weight = -1;
            int count = 0;
            foreach (var ch in s)
            {
                var w = ch - 'a' + 1;
                if (weight != w)
                {
                    weight = w;
                    count = 0;
                }

                count++;
                hash.Add(weight * count);
            }


            for (int a0 = 0; a0 < n; a0++)
            {
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(hash.Contains(x) ? "Yes" : "No");
            }
        }
    }
}
