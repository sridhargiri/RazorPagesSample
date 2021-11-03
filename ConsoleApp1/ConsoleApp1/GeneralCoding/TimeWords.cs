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
            // Given n is in seconds 
            int n = 129600;

            ConvertSectoDay(n);
            string T = "21:39";
            int K = 43;
            TimeToWords(T, K);

            //lag
            int h1 = 12, m1 = 0;
            int h2 = 12, m2 = 58;
            int k = 1;

            int lag = lagDuration(h1, m1, h2, m2, k);
            Console.WriteLine("Lag = " + lag +
                              " minutes");
        }
        /*
         Find the number of ways to divide number into four parts such that a = c and b = d
        Given a number N. Find the number of ways to divide a number into four parts(a, b, c, d) such that a = c and b = d and a not equal to b.

Examples:

Input : N = 6
Output : 1
Expalantion : four parts are {1, 2, 1, 2}

Input : N = 20
Output : 4
Expalantion : possible ways are {1, 1, 9, 9}, {2, 2, 8, 8}, {3, 3, 7, 7} and {4, 4, 6, 6}.
        Approach :
If the given N is odd the answer is 0, because the sum of four parts will not be even number.

        If n is divisible by 4 then answer will be n/4 -1(here a equals to b can be possible so subtract that possibility) otherwise n/4.

Below is the implementation of the above approach :

         */
        // Function to find the number of ways to divide 
        // N into four parts such that a = c and b = d 
        int possibleways(int n)
        {
            if (n % 2 == 1)
                return 0;
            else if (n % 4 == 0)
                return n / 4 - 1;
            else
                return n / 4;
        }
        /*
         Time difference between expected time and given time
Difficulty Level : Easy
 Last Updated : 27 Feb, 2019
Given the initial clock time h1:m1 and the present clock time h2:m2, denoting hour and minutes in 24-hours clock format. The present clock time h2:m2 may or may not be correct. Also given a variable K which denotes the number of hours passed. The task is to calculate the delay in seconds i.e. time difference between expected time and given time.

Examples :

Input: h1 = 10, m1 = 12, h2 = 10, m2 = 17, k = 2
Output: 115 minutes
The clock initially displays 10:12. After 2 hours it must show 12:12. But at this point, the clock displays 10:17. Hence, the clock must be lagging by 115 minutes. so the answer is 115.

Input: h1 = 12, m1 = 00, h2 = 12, m2 = 58, k = 1
Output: 2 minutes
The clock initially displays 12:00. After 1 hour it must show 13:00. But at this point, the clock displays 12:58. Hence, the clock must be lagging by 2 minutes. so the answer is 2.
        Approach
1. Convert given time in h:m format to number of minutes. It is simply 60*h+m.
2. Calculate both the computed time(adding K hours to the initial time).
3. Find the difference in minutes which will be the answer.
         */


        // Function definition 
        // with logic 
        static int lagDuration(int h1, int m1,
                               int h2, int m2,
                               int k)
        {
            int lag, t1, t2;

            // Conversion to minutes 
            t1 = (h1 + k) * 60 + m1;

            // Conversion to minutes 
            t2 = h2 * 60 + m2;

            // Calculating difference 
            lag = t1 - t2;
            return lag;
        }
        /// <summary>
        /// function to display time difference expressed in words
        /// </summary>
        /// <param name="r"></param>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <returns></returns>
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
        // function convert second into day  
        // hours, minutes and seconds 


        //Output :
        //1 days 12 hours 0 minutes 0 seconds
        //Given an integer n(in seconds).Convert it into days, hours, minutes and seconds.

        //Examples:

        //        Input: 369121517
        //Output: 4272 days 5 hours 45 minutes 17 seconds

        //Input : 129600
        //Output: 1 days 12 hours 0 minutes 0 seconds
        static void ConvertSectoDay(int n)
        {
            int day = n / (24 * 3600);

            n = n % (24 * 3600);
            int hour = n / 3600;

            n %= 3600;
            int minutes = n / 60;

            n %= 60;
            int seconds = n;

            Console.WriteLine(day + " "
                  + "days " + hour + " "
              + "hours " + minutes + " "
            + "minutes " + seconds + " "
                            + "seconds ");
        }
        //        Program to find the time after K minutes from given time
        //            You are given a time T in 24-hour format(hh:mm) and a positive integer K, you have to tell the time after K minutes in 24-hour time.
        //            Examples:

        //Input: T = 12:43, K = 21
        //Output: 13:04

        //Input: T = 20:39, K = 534
        //Output: 05:33
        //                Approach:

        //Convert the given time in minutes
        //Add K to it let it be equal to M.
        //Convert the M minutes in 24 hours format accordingly.
        //Below is the implementation of the above approach:

        static void TimeToWords(string T, int K)
        {

            // convert the given time in minutes  
            int minutes = ((T[0] - '0')
                            * 10
                        + T[1] - '0')
                            * 60
                        + ((T[3] - '0')
                                * 10
                            + T[4] - '0');

            // Add K to current minutes  
            minutes += K;

            // Obtain the new hour  
            // and new minutes from minutes  
            int hour = (minutes / 60) % 24;

            int min = minutes % 60;

            // Print the hour in appropriate format  
            if (hour < 10)
            {
                Console.Write("0" + hour + ":");
            }
            else
            {
                Console.Write(hour + ":");
            }

            // Print the minute in appropriate format  
            if (min < 10)
            {
                Console.Write("0" + min);
            }
            else
            {
                Console.Write(min);
            }
        }
    }
    /*
     https://www.geeksforgeeks.org/maximum-possible-time-that-can-be-formed-from-four-digits/
    Maximum possible time that can be formed from four digits
Difficulty Level : Medium
Last Updated : 10 Jun, 2021
Given an array arr[] having 4 integer digits only. The task is to return the maximum 24 hour time that can be formed using the digits from the array. 
Note that the minimum time in 24 hour format is 00:00, and the maximum is 23:59. If a valid time cannot be formed then return -1.
Examples: 
 

Input: arr[] = {1, 2, 3, 4} 
Output: 23:41
Input: arr[] = {5, 5, 6, 6} 
Output: -1 
 
 
Approach: Create a HashMap and store the frequency of each digit in the map which can be used to know how many of such digits are available. 
Now, in order to generate a valid time following conditions must be satisfied: 
 

First digit of hours must be from the range [0, 2]. Start checking in decreasing order in order to maximize the time i.e. from 2 to 0. Once the digit is chosen, decrement its occurrence in the map by 1.
Second digit of hours must be from the range [0, 3] if first digit was chosen as 2 else [0, 9]. Update the HashMap accordingly after choosing the digit.
First digit of minutes must be from the range [0, 5] and second digit of minutes must be from the range [0, 9].
If any of the above condition fails i.e. no digit could be chosen at any point then print -1 else print the time.
Below is the implementation of the above approach: 
     */
    public class MaxTimeFromArray
    {

        // Function to return the updated frequency map
        // for the array passed as argument
        static Dictionary<int, int> getFrequencyMap(int[] arr)
        {
            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (hashMap.ContainsKey(arr[i]))
                {
                    hashMap[arr[i]] = hashMap[arr[i]] + 1;
                }
                else
                {
                    hashMap.Add(arr[i], 1);
                }
            }
            return hashMap;
        }

        // Function that returns true if the passed digit is present
        // in the map after decrementing it's frequency by 1
        static bool hasDigit(Dictionary<int, int> hashMap, int digit)
        {

            // If map contains the digit
            if (hashMap.ContainsKey(digit) && hashMap[digit] > 0)
            {

                // Decrement the frequency of the digit by 1
                hashMap[digit] = hashMap[digit] - 1;

                // True here indicates that the
                // digit was found in the map
                return true;
            }

            // Digit not found
            return false;
        }

        // Function to return the maximum
        // possible time in 24-Hours format
        static String getMaxTime(int[] arr)
        {
            Dictionary<int, int> hashMap = getFrequencyMap(arr);
            int i;
            bool flag;
            String time = "";

            flag = false;

            // First digit of hours can be from the range [0, 2]
            for (i = 2; i >= 0; i--)
            {
                if (hasDigit(hashMap, i))
                {
                    flag = true;
                    time += i;
                    break;
                }
            }

            // If no valid digit found
            if (!flag)
            {
                return "-1";
            }

            flag = false;

            // If first digit of hours was chosen as 2 then
            // the second digit of hours can be
            // from the range [0, 3]
            if (time[0] == '2')
            {
                for (i = 3; i >= 0; i--)
                {
                    if (hasDigit(hashMap, i))
                    {
                        flag = true;
                        time += i;
                        break;
                    }
                }
            }

            // Else it can be from the range [0, 9]
            else
            {
                for (i = 9; i >= 0; i--)
                {
                    if (hasDigit(hashMap, i))
                    {
                        flag = true;
                        time += i;
                        break;
                    }
                }
            }
            if (!flag)
            {
                return "-1";
            }

            // Hours and minutes separator
            time += ":";

            flag = false;

            // First digit of minutes can be from the range [0, 5]
            for (i = 5; i >= 0; i--)
            {
                if (hasDigit(hashMap, i))
                {
                    flag = true;
                    time += i;
                    break;
                }
            }
            if (!flag)
            {
                return "-1";
            }

            flag = false;

            // Second digit of minutes can be from the range [0, 9]
            for (i = 9; i >= 0; i--)
            {
                if (hasDigit(hashMap, i))
                {
                    flag = true;
                    time += i;
                    break;
                }
            }
            if (!flag)
            {
                return "-1";
            }

            // Return the maximum possible time
            return time;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] arr = { 0, 0, 0, 9 };
            Console.WriteLine(getMaxTime(arr));
            //Output:            09:00
        }
    }
}
