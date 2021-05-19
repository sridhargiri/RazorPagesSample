using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/program-to-check-the-validity-of-a-password/
     Program to check the validity of a Password
Difficulty Level : Hard
Last Updated : 01 Sep, 2020
Password checker program basically checks if the password is valid or not based on password policies mention below:

Password should not contain any space.
Password should contain at least one digit(0-9).
Password length should be between 8 to 15 characters.
Password should contain at least one lowercase letter(a-z).
Password should contain at least one uppercase letter(A-Z).
Password should contain at least one special character ( @, #, %, &, !, $, etc….).
Example:

Input: GeeksForGeeks 
Output: Invalid Password!
This input contains lowercase 
as well as uppercase letters 
but does not contain digits 
and special characters.

Input: Geek$ForGeeks7
Output: Valid Password
This input satisfies all password
policies mentioned above.
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach:

In this program,

we are using String contains () method to check the passwords. This method accepts a CharSequence as an argument and returns true if the argument is present in a string otherwise returns false.
Firstly the length of the password has to be checked then whether it contains uppercase, lowercase, digits and special characters.
If all of them are present then the method isValid(String password) returns true.
Below is the implementation of the above approach
     */
    class PasswordValidator
    {
        public static bool isValid(String password)
        {

            // for checking if password length
            // is between 8 and 15
            if (!((password.Length >= 8)
                && (password.Length <= 15)))
            {
                return false;
            }

            // to check space
            if (password.Contains(" "))
            {
                return false;
            }
            if (true)
            {
                int count = 0;

                // check digits from 0 to 9
                for (int i = 0; i <= 9; i++)
                {

                    // to convert int to string
                    String str1 = i.ToString();

                    if (password.Contains(str1))
                    {
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    return false;
                }
            }

            // for special characters
            if (!(password.Contains("@") || password.Contains("#")
                || password.Contains("!") || password.Contains("~")
                || password.Contains("$") || password.Contains("%")
                || password.Contains("^") || password.Contains("&")
                || password.Contains("*") || password.Contains("(")
                || password.Contains(")") || password.Contains("-")
                || password.Contains("+") || password.Contains("/")
                || password.Contains(":") || password.Contains(".")
                || password.Contains(", ") || password.Contains("<")
                || password.Contains(">") || password.Contains("?")
                || password.Contains("|")))
            {
                return false;
            }

            if (true)
            {
                int count = 0;

                // checking capital letters
                for (int i = 65; i <= 90; i++)
                {

                    // type casting
                    char c = (char)i;

                    String str1 = c.ToString();
                    if (password.Contains(str1))
                    {
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    return false;
                }
            }

            if (true)
            {
                int count = 0;

                // checking small letters
                for (int i = 90; i <= 122; i++)
                {

                    // type casting
                    char c = (char)i;
                    String str1 = c.ToString();

                    if (password.Contains(str1))
                    {
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    return false;
                }
            }

            // if all conditions fails
            return true;
        }

        // Driver code
        public static void Main(String[] args)
        {

            String password1 = "GeeksForGeeks";

            if (isValid(password1))
            {
                Console.WriteLine("Valid Password");
            }
            else
            {
                Console.WriteLine("Invalid Password!!!");
            }

            String password2 = "Geek$ForGeeks7";
            if (isValid(password2))
            {
                Console.WriteLine("Valid Password");
            }
            else
            {
                Console.WriteLine("Invalid Password!!!");
            }
            /*
             Output:
Invalid Password!!!
Valid Password
            */
        }
    }

}
