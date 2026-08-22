using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    22.08.2026 saturday embassy splendid tech park
     problem 1
    find sum of all numbers that are divisible by all of its digits between a range L,R
    */
    public class QuessCorp
    {
        static void Main()
        {
            Console.Write("Enter an integer: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (IsDivisibleByAllDigits(number))
                {
                    Console.WriteLine($"{number} is divisible by all of its digits.");
                }
                else
                {
                    Console.WriteLine($"{number} is NOT divisible by all of its digits.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        /// <summary>
        /// Checks if the given number is perfectly divisible by each of its individual digits.
        /// </summary>
        static bool IsDivisibleByAllDigits(int number)
        {
            // 0 is typically excluded or considered invalid since you cannot divide by 0
            if (number == 0) return false;

            // Use Math.Abs to properly handle negative numbers
            int originalNumber = Math.Abs(number);
            int temp = originalNumber;

            while (temp > 0)
            {
                // Extract the last digit
                int digit = temp % 10;

                // Edge Case 1: Avoid division by zero (e.g., 102)
                // Edge Case 2: Check if the original number is not divisible by the current digit
                if (digit == 0 || originalNumber % digit != 0)
                {
                    return false;
                }

                // Remove the last digit to move to the next one
                temp /= 10;
            }

            return true;
        }
    }

    /*
     problem 2
    c# program tthere are n number of professors n no of relations print the nearest neighbor for each professor
     */

}
