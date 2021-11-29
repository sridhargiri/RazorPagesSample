using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    //Check if frequency of each digit is less than the digit
    //    Given an integer n, the task is to check if frequency of each digit of the number is less than or equal to digit itself.

    //Examples:

    //Input : 51241
    //Output : False

    //Input : 1425243
    //Output : True
    class DigitFrequency
    {
        //Naive Approach: 
        //Start from 0 and count the frequency for every digit upto 9, if at any place frequency is more than the digit value then return false, else return true.

        static bool validate(long n)
        {
            for (int i = 0; i < 10; i++)
            {
                long temp = n;
                int count = 0;
                while (temp > 0)
                {
                    // If current digit of  
                    // temp is same as i 
                    if (temp % 10 == i)
                        count++;

                    // if frequency is greater than  
                    // digit value, return false 
                    if (count > i)
                        return false;

                    temp /= 10;
                }
            }
            return true;
        }
        //Efficient Approach: is to store the frequency of each digit and if at any place frequency is more than the digit value then return false, else return true.

        static bool validate1(long n)
        {
            int[] count = new int[10];
            while (n > 0)
            {
                // calculate frequency  
                // of each digit  
                int r = (int)n % 10;

                // If count is already r, then   
                // incrementing it would invalidate,  
                // hence we return false.  
                if (count[r] == r)
                    return false;

                count[r]++;
                n /= 10;
            }

            return true;
        }
        static public void Main(String[] args)
        {
            long n = 15527931;
            if (validate(n))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            if (validate1(n))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            //output true
        }
    }

    public class FrequencyDigits
    {

        // Function to find counts of all elements
        // present in arr[0..n-1]. The array elements
        // must be range from 1 to n
        public static void findFrequencyOfDigits(int[] arr, int n)
        {

            // Hashmap
            int[] hash = new int[n];

            // Traverse all array elements
            int i = 0;
            while (i < n)
            {

                // Update the frequency of array[i]
                hash[arr[i] - 1]++;

                // Increase the index
                i++;
            }
            Console.WriteLine("\nBelow are counts "
                              + "of all elements");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine((i + 1) + " -> " + hash[i]);
            }
        }

        // Driver code
        static public void Main()
        {
            int[] arr = new int[] { 2, 3, 3, 2, 5 };
            findFrequencyOfDigits(arr, arr.Length);
            int[] arr1 = new int[] { 1 };
            findFrequencyOfDigits(arr1, arr1.Length);
            int[] arr3 = new int[] { 4, 4, 4, 4 };
            findFrequencyOfDigits(arr3, arr3.Length);
            int[] arr2
              = new int[] { 1, 3, 5, 7, 9, 1, 3, 5, 7, 9, 1 };
            findFrequencyOfDigits(arr2, arr2.Length);
            int[] arr4
              = new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
            findFrequencyOfDigits(arr4, arr4.Length);
            int[] arr5 = new int[] { 1, 2, 3, 4,  5, 6,
                            7, 8, 9, 10, 11 };
            findFrequencyOfDigits(arr5, arr5.Length);
            int[] arr6 = new int[] { 11, 10, 9, 8, 7, 6,
                            5,  4,  3, 2, 1 };
            findFrequencyOfDigits(arr6, arr6.Length);
        }
    }
}
