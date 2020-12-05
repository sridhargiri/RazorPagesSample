using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class SmallLargeString
    {

        static String minWord = "", maxWord = "";

        static void minMaxLengthWords(String input)
        {
            // minWord and maxWord are received by reference  
            // and not by value 
            // will be used to store and return output 
            int len = input.Length;
            int si = 0, ei = 0;
            int min_length = len, min_start_index = 0,
                max_length = 0, max_start_index = 0;

            // Loop while input string is not empty 
            while (ei <= len)
            {
                if (ei < len && input[ei] != ' ')
                {
                    ei++;
                }
                else
                {
                    // end of a word 
                    // find curr word length 
                    int curr_length = ei - si;

                    if (curr_length < min_length)
                    {
                        min_length = curr_length;
                        min_start_index = si;
                    }

                    if (curr_length > max_length)
                    {
                        max_length = curr_length;
                        max_start_index = si;
                    }
                    ei++;
                    si = ei;
                }
            }

            // store minimum and maximum length words 
            minWord = input.Substring(min_start_index, min_length);
            maxWord = input.Substring(max_start_index, max_length);
        }

        // Driver code 
        public static void Main(String[] args)
        {
            String a = "GeeksforGeeks A Computer Science portal for Geeks";

            minMaxLengthWords(a);

            // to take input in string use getline(cin, a); 
            Console.Write("Minimum length word: "
                    + minWord
                    + "\nMaximum length word: "
                    + maxWord);
        }
    }
}
