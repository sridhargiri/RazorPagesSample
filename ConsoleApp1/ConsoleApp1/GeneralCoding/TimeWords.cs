using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     asked in amazon PA-2 to display time difference as sentence
     first consider seconds difference, then minutes, then hours, then years etc
     example : seconds ago, minutes ago, hours ago
     */
    class TimeWords
    {
        public static void Main(string[] args)
        {
            String R = Console.ReadLine();
            int N = int.Parse(Console.ReadLine());
            String[] P = new String[N];
            for (int i_P = 0; i_P < N; i_P++)
            {
                P[i_P] = Console.ReadLine();
            }

            String[] out_ = solve(R, N, P);
            for (int i_out_ = 0; i_out_ < out_.Length; i_out_++)
            {
                Console.WriteLine((out_[i_out_]));
            }
        }

        private static string[] solve(string r, int n, string[] p)
        {

            var ms_Min = 60; // milliseconds in Minute 
            var ms_Hour = ms_Min * 60; // milliseconds in Hour 
            var ms_Day = ms_Hour * 24; // milliseconds in day 
            var ms_Mon = ms_Day * 30; // milliseconds in Month 
            var ms_Yr = ms_Day * 365; // milliseconds in Year 

            String[] P = new String[n];
            DateTime curr = DateTime.Parse(r);
            for (int i = 0; i < p.Length; i++)
            {
                var prev = DateTime.Parse(p[i]);
                var diff = ((curr.Hour * 60 * 60) + (curr.Minute * 60) + curr.Second) - ((prev.Hour * 60 * 60) + (prev.Minute * 60) + prev.Second); //difference between dates.
                if (diff == ms_Min)
                {
                    P[i] = "now";
                }                                  // If the diff is less then milliseconds in a minute 
                else if (diff < ms_Min)
                {
                    P[i] = Math.Round((double)(diff)) + " seconds ago";

                    // If the diff is less then milliseconds in a Hour 
                }
                else if (diff < ms_Hour)
                {
                    P[i] = Math.Round((double)(diff / ms_Min)) + " minutes ago";

                    // If the diff is less then milliseconds in a day 
                }
                else if (diff < ms_Day)
                {
                    P[i] = Math.Round((double)(diff / ms_Hour)) + " hours ago";

                    // If the diff is less then milliseconds in a Month 
                }
                else if (diff < ms_Mon)
                {
                    P[i] = Math.Round((double)(diff / ms_Day)) + " days ago";

                    // If the diff is less then milliseconds in a year 
                }
                else if (diff < ms_Yr)
                {
                    P[i] = Math.Round((double)(diff / ms_Mon)) + " months ago";
                }
                else
                {
                    P[i] = Math.Round((double)(diff / ms_Yr)) + " years ago";
                }
            }
            return P;
        }
    }
}
