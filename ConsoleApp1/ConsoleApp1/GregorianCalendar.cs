﻿using System;
using System.Collections.Generic;
using System.Text;
/*
 Tomohiko Sakamoto’s Algorithm- Finding the day of the week
Last Updated: 08-01-2020
Given any date according to the Gregorian Calendar, the task is to return the day(Monday, Tuesday…etc) on that particular day.

Examples:

Input :  Date: 13 July 2017 [13.07.2017]
Output : 4 i.e Thursday

Input : Date: 15 August 2012 [15.08.2012]
Output : 3 i.e Wednesday

Input : Date: 24 December 2456 [24.12.2456]
Output : 0 i.e Sunday
Although there are a plenty of methods to solve this question but one of the least known and most powerful method is Tomohiko Sakamoto’s Algorithm.
Explanation
Jan 1st 1 AD is a Monday in Gregorian calendar.
Let us consider the first case in which we do not have leap years, hence total number of days in each year is 365.January has 31 days i.e 7*4+3 days so the day on 1st feb will always be 3 days ahead of the day on 1st January.Now february has 28 days(excluding leap years) which is exact multiple of 7 (7*4=28) Hence there will be no change in the month of march and it will also be 3 days ahead of the day on 1st January of that respective year.Considering this pattern, if we create an array of the leading number of days for each month then it will be given as t[] = {0, 3, 3, 6, 1, 4, 6, 2, 5, 0, 3, 5}.
Now let us look at the real case when there are leap years. Every 4 years, our calculation will gain one extra day. Except every 100 years when it doesn’t. Except every 400 years when it does. How do we put in these additional days? Well, just add y/4 – y/100 + y/400. Note that all division is integer division. This adds exactly the required number of leap days.But here is a problem, the leap day is 29 Feb and not 0 January.This means that the current year should not be counted for the leap day calculation for the first two months.Suppose that if the month were January or February, we subtracted 1 from the year. This means that during these months, the y/4 value would be that of the previous year and would not be counted. If we subtract 1 from the t[] values of every month after February? That would fill the gap, and the leap year problem is solved.That is, we need to make the following changes:
1.t[] now becomes {0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4}.
2.if m corresponds to Jan/Feb (that is, month<3) we decrement y by 1.
3.the annual increment inside the modulus is now y + y/4 – y/100 + y/400 in place of y.
 */
namespace ConsoleApp1
{
    class GregorianCalendar
    {

        // function to implement tomohiko  
        // sakamoto algorithm 
        public static int day_of_the_week(int y,
                                     int m, int d)
        {

            // array with leading number of days 
            // values 
            int[] t = { 0, 3, 2, 5, 0, 3, 5, 1,
                                4, 6, 2, 4 };

            // if month is less than 3 reduce 
            // year by 1 
            if (m < 3)
                y -= 1;

            return (y + y / 4 - y / 100 + y / 400
                              + t[m - 1] + d) % 7;
        }

        // Driver Code 
        public static void Main()
        {
            int day = 13, month = 7, year = 2017;

            Console.WriteLine(day_of_the_week(year,
                                       month, day));
        }
    }
}
