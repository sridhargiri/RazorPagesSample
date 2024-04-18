using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Q1 testgorilla frodoe (convergent) 31/03/2024
    // if leap year print 1 else -1
    // print century and leap year result as comma separated. if year < 1000 return -1
    // 1759 = 18,-1
    // 999 = -1
    // 1665 = 16, -1
    public class CenturyLeap
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(FinalOutput(2024));
        }
        static string FinalOutput(int year)
        {
            return find_century(year) + "," + IsLeapYear(year);
        }
        static int find_century(int year)
        {

            // No negative value is allow for year 
            if (year <= 0)
                return -1;

            // If year is between 1 to 100 it 
            // will come in 1st century 
            else if (year <= 100)
                return 1;

            else if (year % 100 == 0)
                return year / 100;

            else
                return year / 100 + 1;
        }
        static int IsLeapYear(int y)
        {
            if ((y % 400 == 0) ||
               (y % 100 != 0) &&
               (y % 4 == 0))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

    }
    // Q2 testgorilla frodoe (convergint) 31/03/2024
    // asked to debug and correct it
    // Task is first convert binary to decimal, reverse binary string then convert to decimal print output
    public class Frodoe
    {
        public static void Main(string[] args)
        {
            int t = FormatNumber(10);
            Console.WriteLine(t);
        }
        static string decToBinary(int n)
        {
            // array to store binary number
            int[] binaryNum = new int[32];

            // counter for binary array
            int i = 0;
            while (n > 0)
            {
                // storing remainder in
                // binary array
                binaryNum[i] = n % 2;
                n = n / 2;
                i++;
            }
            string bin = "";
            // printing binary array
            // in reverse order
            for (int j = i - 1; j >= 0; j--)
                bin += binaryNum[j].ToString();
            return bin;
        }

        public static string stringReverse(string str)
        {
            char[] chars = str.ToCharArray();
            char[] result = new char[chars.Length];
            for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
            {
                result[i] = chars[j];
            }
            return new string(result);
        }
        static int binaryToDecimal(String n)
        {
            String num = n;
            int dec_value = 0;

            // Initializing base value to 1,
            // i.e 2^0
            int base1 = 1;

            int len = num.Length;
            for (int i = len - 1; i >= 0; i--)
            {
                if (num[i] == '1')
                    dec_value += base1;
                base1 = base1 * 2;
            }

            return dec_value;
        }
        public static int FormatNumber(int number)
        {
            var binaryRep = decToBinary(number);
            string reversed = stringReverse(binaryRep);
            int result = binaryToDecimal(reversed);

            return result;
        }

        /*
converging coderpad test
        ----------------
Fist of positive integers (numbers]).
a positive integer (k), representing the target sum.
For example:
numbers = [1, 5, 8, 1, 2]
k = 13
Your FindSumPair method should return a list of two integers, containing the
indices of a pair of integers in the list that sums to k. Note that:
The first index of the list is 0.
• The first integer you return should represent the lower index.

[0, 0] should be returned if no pair is found.
In the case that there are multiple possible pairs that sum to the target,
return the pair whose left index is the lowest.
• In the case of two pairs having the same left index, favor the pair with the
lower right index.
For the above example, the correct return value would be: [[1, 2]
         */
    }
}
