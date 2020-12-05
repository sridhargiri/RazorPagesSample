using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     leetcode atoi implementaion
    Approach 4: Four corner cases needs to be handled: 

Discards all leading whitespaces
Sign of the number
Overflow
Invalid input

To remove the leading whitespaces run a loop until a character of the digit is reached. 
    If the number is greater than or equal to INT_MAX/10. Then return INT_MAX if the sign is positive and return INT_MIN if the sign is negative. 
    The other cases are handled in previous approaches.
     */
    class atoi
    {
        static int myAtoi(char[] str)
        {
            int sign = 1, Base = 0, i = 0;

            // if whitespaces then ignore.
            while (str[i] == ' ')
            {
                i++;
            }

            // sign of number
            if (str[i] == '-' || str[i] == '+')
            {
                sign = 1 - 2 * (str[i++] == '-' ? 1 : 0);
            }

            // checking for valid input
            while (
                i < str.Length
                && str[i] >= '0'
                && str[i] <= '9')
            {

                // handling overflow test case
                if (Base > int.MaxValue / 10 || (Base == int.MaxValue / 10 && str[i] - '0' > 7))
                {
                    if (sign == 1)
                        return int.MaxValue;
                    else
                        return int.MinValue;
                }
                Base = 10 * Base + (str[i++] - '0');
            }
            return Base * sign;
        }

        // Driver code
        public static void Main(String[] args)
        {
            char[] str = " -123".ToCharArray();
            int val = myAtoi(str);
            Console.Write("{0} ", val);
        }
    }
}
