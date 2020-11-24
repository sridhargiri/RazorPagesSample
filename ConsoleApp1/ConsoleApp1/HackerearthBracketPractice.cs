using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     
     A bracket sequence is a string that contains only characters '(' and ')'.

A correct bracket sequence is a bracket sequence that can be transformed into a correct arithmetic expression by inserting characters '1' and '+' between the original characters of the sequence. 
    For example, bracket sequences '()()' and '(())' are correct. 
    The resulting expressions of these sequences are: '(1)+(1)' and '((1+1)+1)'. However, '(', ')(', and '(' are incorrect bracket sequences. 
    */
    class HackerearthBracketPractice
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(CheckBrackets(")()()("));
        }
        public static int CheckBrackets(string st)
        {

            int count = 0;

            char[] ch = st.ToCharArray();




            for (int i = 0; i < ch.Length; i++)

            {

                int start = i;

                int flag = 0;

                for (int j = 0; j < ch.Length; j++)

                {

                    if (ch[(start + j) % ch.Length] == '(')

                    {

                        flag++;

                    }

                    else

                    {

                        flag--;

                        if (flag < 0)

                            break;

                    }

                }

                if (flag == 0)

                {

                    count++;

                }

            }

            return count;
        }
    }
}
