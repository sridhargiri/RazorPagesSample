using System;
using System.Linq;

namespace ConsoleApp1
{
    class TomJerryFriends
    {
        /// <summary>
        /// Talent recruit -> friends tom and jerry
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int index = 0;
            int T = int.Parse(Console.ReadLine());
            string isEqual = "NO";
            for (int i = 0; i < T; i++)
            {
                string s1 = Console.ReadLine();
                string s2 = Console.ReadLine();
                for (int j = 0; j < s1.Length; j++)
                {
                    if (s1[j] == s2[index])
                    {
                        index++;
                    }
                    if (index == s2.Length)
                    {
                        isEqual = "YES"; break;
                    }
                }
                index = 0; Console.WriteLine(isEqual);
            }
        }
    }
}
