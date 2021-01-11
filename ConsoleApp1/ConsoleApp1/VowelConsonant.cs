using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class VowelConsonant
    {
        static String remVowel(String str)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            List<char> al = vowels.OfType<char>().ToList(); ;

            StringBuilder sb = new StringBuilder(str);

            for (int i = 0; i < sb.Length; i++)
            {

                if (al.Contains(sb[i]))
                {
                    sb.Replace(sb[i].ToString(), "");
                    ///i--;
                }
            }


            return sb.ToString();
        }


        // Function that returns true
        // if the character is an alphabet

        static bool isAlphabet(char ch)
        {

            if (ch >= 'a' && ch <= 'z')

                return true;

            if (ch >= 'A' && ch <= 'Z')

                return true;



            return false;
        }

        // Function to return the string after
        // removing all the consonants from it

        static string remConsonants(string str)
        {

            char[] vowels = { 'a', 'e', 'i', 'o', 'u',

                      'A', 'E', 'I', 'O', 'U' };



            string sb = "";


            for (int i = 0; i < str.Length; i++)

            {

                bool present = false;

                for (int j = 0; j < vowels.Length; j++)

                {

                    if (str[i] == vowels[j])

                    {

                        present = true;

                        break;

                    }

                }



                if (!isAlphabet(str[i]) || present)

                {

                    sb += str[i];

                }

            }

            return sb;
        }

        // Driver method to test the above function 
        //i/p - GeeeksforGeeks - A Computer Science Portal for Geeks
        //o/p GksfrGks - Cmptr Scnc Prtl fr Gks
        public static void Main()
        {
            String str = "GeeeksforGeeks - A Computer Science Portal for Geeks";

            Console.Write(remVowel(str));

            str = "GeeeksforGeeks - A Computer Science Portal for Geeks";
            //Output: 
            //eeeoee - A oue iee oa o ee

            Console.Write(remConsonants(str));
        }
    }
}
