using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class LimitNumberInstance
    {
        public static int InstanceCount { get; set; }
        public LimitNumberInstance()
        {
            InstanceCount++;
            if (InstanceCount > 2)
            {
                throw new Exception("Instance count exceeded two");
            }
        }
    }
    public class BeautifulBinary
    {
        /// <summary>
        /// Beautiful binary string
        /// If 010 is found then increment counter find min count to replace all 010
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        static int beautifulBinaryString(string b)
        {
            int counter = 0;
            for (int i = 0; i < b.Length - 2; i++)
            {
                if (b[i] == '0' && b[i + 1] == '1' && b[i + 2] == '0')
                {
                    counter++; i += 2;
                }

            }
            return counter;
        }

        /*
         James found a love letter that his friend Harry has written to his girlfriend. James is a prankster, so he decides to meddle with the letter. He changes all the words in the letter into palindromes.

To do this, he follows two rules:

He can only reduce the value of a letter by , i.e. he can change d to c, but he cannot change c to d or d to b.
The letter a may not be reduced any further.
Each reduction in the value of any letter is counted as a single operation. Find the minimum number of operations required to convert a given string into a palindrome.

For example, given the string , the following two operations are performed: cde → cdd → cdc.
        Sample Input

4
abc
abcba
abcd
cba
Sample Output

2
0
4
2
         */
        static int theLoveLetterMystery(String s)
        {
            int operationsPerformed = 0;
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                operationsPerformed += Math.Abs(s[i] - s[j]);
                i++;
                j--;
            }
            return operationsPerformed;
        }
        public static void Main(string[] args)
        {
            //int n = beautifulBinaryString("0110010");
            //int n = beautifulBinaryString("0101010");
            //Console.WriteLine(n);
            int love=theLoveLetterMystery("abcd");
            Console.WriteLine(love);
        }
    }
}
