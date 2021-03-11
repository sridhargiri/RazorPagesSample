using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class EquationA
    {
        /*
         Find the missing value from the given equation a + b = c
        Difficulty Level : Basic
         Last Updated : 25 Jan, 2021
        Given an equation of the form: 

        a + b = c 


        Out of which any one of the terms a    , b    or c    is missing. The task is to find the missing term.

        Examples:  

        Input: 2 + 6 = ?
        Output: 8

        Input: ? + 3 =6
        Output: 3
        Recommended: Please try your approach on {IDE} first, before moving on to the solution.
        Approach: Missing number can be found simply using the equation a + b = c    . First, we will find two known numbers from the given equation(read as a string in the program) and convert them into integers and put into the equation. In this way, we can find the third missing number. We can implement it by storing the equation into the string.

        **********single digit operands i.e. without 3x 9x like that, simply x (own implementaion)


        Below is the step by step algorithm: 

        Split the string into smaller strings from the position of spaces and store in an array. So that the array will contain:
        arr[0] = "a"
        arr[1] = "+"
        arr[2] = "b"
        arr[3] = "="
        arr[4] = "c"
        The missing character can occur at the position 0 or 2 or 4 in the vector. Find the position of missing character.
        Convert known characters to integer.
        Find missing character using the equation.
        Below is the implementation of the above approach:  
        */
        static int findMissing(string str)
        {

            // Array of String to store individual
            // strings after splitting the strings
            // from spaces
            string[] arrStr = str.Split(" ");
            int pos = -1;
            string op = arrStr[1];
            // Find position of missing character
            if (arrStr[0].Equals("?"))
                pos = 0;
            else if (arrStr[2].Equals("?"))
                pos = 2;
            else
                pos = 4;
            if (pos == 0)
            {
                string b, c;
                b = arrStr[2];
                c = arrStr[4];
                int a = 0;
                // Using Integer.parseInt() to
                // convert strings to int
                if (op == "+")
                    a = int.Parse(c) - int.Parse(b);
                else
                if (op == "-")
                    a = int.Parse(c) + int.Parse(b);
                else
                if (op == "*")
                    a = int.Parse(c) / int.Parse(b);
                else
                    a = int.Parse(c) * int.Parse(b);
                return a;
            }
            else if (pos == 2)
            {
                string a, c;
                a = arrStr[0];
                c = arrStr[4]; int b = 0;
                if (op == "+")
                    b = int.Parse(c) - int.Parse(a);
                else
                if (op == "-")
                    b = int.Parse(a) - int.Parse(c);
                else
                if (op == "*")
                    b = int.Parse(c) / int.Parse(a);
                else
                    b = int.Parse(a) / int.Parse(c);
                return b;
            }

            else if (pos == 4)
            {
                string b, a;
                a = arrStr[0];
                b = arrStr[2]; int c = 0;
                if (op == "+")
                    c = int.Parse(a) + int.Parse(b);
                else
                if (op == "-")
                    c = int.Parse(a) - int.Parse(b);
                else
                if (op == "*")
                    c = int.Parse(a) * int.Parse(b);
                else
                    c = int.Parse(a) / int.Parse(b);
                return c;
            }
            return 0;
        }

        // Driver code
        public static void Main(string[] args)
        {
            //string str = "100000 + ? = 500000";
            string[] str = { "? + 3 = 7", "? - 3 = 7", "? * 3 = 12", "? / 3 = 5",
             "3 + ? = 7", "3 - ? = 1", "3 * ? = 12", "15 / ? = 5", "5 + 3 = ?", "10 - 3 = ?", "4 * 3 = ?", "15 / 3 = ?"};
            foreach (var s in str)
            {
                Console.WriteLine($"{s} : {findMissing(s)}");
            }
        }
    }
}
