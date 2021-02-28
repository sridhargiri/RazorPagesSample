using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
coderbyte => Letter Count
    http://wiki.alexjslessor.com/en/coderbyte-answers
Take the str parameter being passed and return the first word with the greatest number of repeated letters.

For example:

"Today, is the greatest day ever!"

Should return greatest because it has 2 e's (and 2 t's) and it comes before ever which also has 2 e's.

If there are no words with repeating letters return -1.

Words will be separated by spaces.

Examples

Input: "Hello apple pie"
Output: Hello
Input: "No words"
Output: -1
    */
    class LetterCount
    {
        static string LetterCountI(string str)
        {

            str = str.ToLower();

            var arr = str.Split(" ");

            var count = 0;
            var word = "-1";

            for (var i = 0; i < arr.Length; i++)
            {
                for (var a = 0; a < arr[i].Length; a++)
                {
                    var countNew = 0;
                    for (var b = a + 1; b < arr[i].Length; b++)
                    {
                        if (arr[i][a] == arr[i][b])
                            countNew += 1;
                    }
                    if (countNew > count)
                    {
                        count = countNew;
                        word = arr[i];
                        return word;
                    }
                }
            }
            return "-1";

        }
        static void Main(string[] args)
        {
            Console.WriteLine(LetterCountI("Today, is the greatest day ever!"));
        }
    }
}
