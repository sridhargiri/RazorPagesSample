using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Nagarro
    {
        //this_is_a_variable
        //thisIsAVariable
        static string c_variable_to_java_variable(string input)
        {
            String result = "";


            char[] c = input.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {

                if (c[i] == '_')
                {

                    i++;

                    char chr = char.ToUpper(c[i]);

                    result += chr;

                }
                else
                {

                    result += c[i];

                }

            }
            return result;

        }
        static int MAX = 26;
        //Print no of characters in lexicographical order
        static string compressString(string s)
        {
            // To store the frequency
            // of the characters
            int n = s.Length;
            int[] freq = new int[MAX];
            string temp = "";
            // Update the frequency array
            for (int i = 0; i < n; i++)
            {
                freq[s[i] - 'a']++;
            }

            // Print the frequency in alphatecial order
            for (int i = 0; i < MAX; i++)
            {

                // If the current alphabet doesn't
                // appear in the string
                if (freq[i] == 0)
                    continue;

                temp += (char)(i + 'a') + "" + freq[i];
            }
            return temp;
        }
        public static void Main(string[] args)
        {
            string s = compressString("babdc"); Console.WriteLine(s);
            //input babdc output a1b2c1d1
            //input geeksforgeeks output e4f1g2k2o1r1s2
            s = c_variable_to_java_variable("this_is_a_variable"); Console.WriteLine(s);
            //Input this_is_a_variable output thisIsAVariable
            //for 3rd question see majorityelement.cs
        }
    }
}
