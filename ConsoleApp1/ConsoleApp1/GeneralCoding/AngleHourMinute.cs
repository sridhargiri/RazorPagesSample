using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AngleHourMinute
    {
        /*
            hcl appscan speedexam online test attended 16/02/2024
        https://www.geeksforgeeks.org/calculate-angle-hour-hand-minute-hand/
        Calculate the angle between hour hand and minute hand
        This problem is known as Clock angle problem where we need to find angle between hands of an analog clock at a given time.
Examples: 

Input:  
h = 12:00
m = 30.00
Output: 
165 degree

Input:  
h = 3.00
m = 30.00
Output: 
75 degree
The idea is to take 12:00 (h = 12, m = 0) as a reference. Following are detailed steps.

1. Calculate the angle made by hour hand with respect to 12:00 in h hours and m minutes. 
2. Calculate the angle made by minute hand with respect to 12:00 in h hours and m minutes. 
3. The difference between the two angles is the angle between the two hands.

How to calculate the two angles with respect to 12:00? 
The minute hand moves 360 degrees in 60 minute(or 6 degrees in one minute) and hour hand moves 360 degrees in 12 hours(or 0.5 degrees in 1 minute). 
In h hours and m minutes, the minute hand would move (h*60 + m)*6 and hour hand would move (h*60 + m)*0.5.
         */
        static int CalculateAngle(double h, double m)
        {
            // validate the input
            if (h < 0 || m < 0 ||
                h > 12 || m > 60)
                Console.Write("Wrong input");

            if (h == 12)
                h = 0;

            if (m == 60)
            {
                m = 0;
                h += 1;
                if (h > 12)
                    h = h - 12;
            }

            // Calculate the angles moved by hour and
            // minute hands with reference to 12:00
            int hour_angle = (int)(0.5 * (h * 60 + m));
            int minute_angle = (int)(6 * m);

            // Find the difference between two angles
            int angle = Math.Abs(hour_angle - minute_angle);

            // smaller angle of two possible angles
            angle = Math.Min(360 - angle, angle);

            return angle;
        }

        // Driver code
        public static void Main()
        {
            Console.WriteLine(CalculateAngle(10, 0));
            Console.Write(CalculateAngle(3, 30));
            /*
             Output 60 75
Time Complexity: O(1)
Auxiliary Space: O(1)
            */
        }
    }
}
