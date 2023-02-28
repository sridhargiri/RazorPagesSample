using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/urlify-a-given-string-replace-spaces-with-%20/
    URLify a given string (Replace spaces with %20)
    Write a method to replace all the spaces in a string with ‘%20’. You may assume that the string has sufficient space at the end to hold the additional characters and that you are given the “true” length of the string.
Examples: 

Input: "Mr John Smith", 13
Output: Mr%20John%20Smith

Input: "Mr John Smith   ", 13
Output: Mr%20John%20Smith
    A simple solution is to create an auxiliary string and copy characters one by one. Whenever space is encountered, place %20 in place of it.

Approach 1: using string.replace() function :

    Time complexity: O(N2) where N is the length of the string. because it is using replace method inside for loop
Auxiliary space: O(1). 

Approach 2: A better solution to do in-place assuming that we have extra space in the input string. We first count the number of spaces in the input string. Using this count, we can find the length of the modified (or result) string. After computing the new length we fill the string in-place from the end. 

Below is the implementation of the above approach:

     */
    public class Urlify
    {

        // Maximum length of string
        // after modifications.
        static int MAX = 1000;

        // Replaces spaces with %20 in-place
        // and returns new length of modified string.
        // It returns -1 if modified string
        // cannot be stored in []str
        static char[] replaceSpaces(char[] str)
        {

            // count spaces and find current length
            int space_count = 0, i = 0;
            for (i = 0; i < str.Length; i++)
                if (str[i] == ' ')
                    space_count++;

            // count spaces and find current length
            while (str[i - 1] == ' ')
            {
                space_count--;
                i--;
            }

            // Find new length.
            int new_length = i + space_count * 2;

            // New length must be smaller than
            // length of string provided.
            if (new_length > MAX)
                return str;

            // Start filling character from end
            int index = new_length - 1;

            char[] new_str = str;
            str = new char[new_length];

            // Fill rest of the string from end
            for (int j = i - 1; j >= 0; j--)
            {

                // inserts %20 in place of space
                if (new_str[j] == ' ')
                {
                    str[index] = '0';
                    str[index - 1] = '2';
                    str[index - 2] = '%';
                    index = index - 3;
                }
                else
                {
                    str[index] = new_str[j];
                    index--;
                }
            }
            return str;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            char[] str = "Mr John Smith ".ToCharArray();

            // Prints the replaced string
            str = replaceSpaces(str);

            for (int i = 0; i < str.Length; i++)
                Console.Write(str[i]);
            /*
             Output: Mr%20John%20Smith
Time Complexity: O(n), where n is the true length of the string. 
Auxiliary Space: O(1), because the above program is an inplace algorithm.
            */
        }
    }
    class Department
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int BuildingId { get; set; }
    }
    public class Ask2
    {
        static void Main(string[] args)
        {
            var idx = FirstIndexOfElement("2", new object[] { "1", "2", "3" ,"2"});
            Console.WriteLine(idx);
            var s=RecursiveStringReverse("sridhar");
            Console.WriteLine(s);
            var lst=ReverseList<int>(new List<int> {4,3,2,1 });
            lst.ForEach((j) => Console.WriteLine(j));
            Console.WriteLine(   GetBitStringForInt(12));
            var list = new List<Department>()
 {
 new Department() { Name ="Finance",Number = 1,BuildingId = 15 },
 new Department() { Name ="HR",Number = 2,BuildingId = 3 },
 new Department() { Name ="IT",Number = 3,BuildingId = 15 },
 new Department() { Name ="Sales", Number = 4, BuildingId = 3 }
 };
            var newList = from department in list
                          group department by department.BuildingId into dp
                          select new { counter = dp.Key, department = dp };
            Console.Out.WriteLine(newList.Count());
        }
        public static int FirstIndexOfElement( object element, object[] array)
        {
            for (int i = 0; i < array.Length;)
            {
                if (array[++i] == element) return i;
            }
            return -1;
        }

        // Method returns new list with elements from input list in reversed order
        public static List<T> ReverseList<T>(List<T> elems)
        {
            var newList = new List<T>();
            for (int i = 1; i <= elems.Count; i++)
            {
                newList.Add(elems[elems.Count - i ]);
            }
            return newList;
        }
        public static string GetBitStringForInt(int n)
        {
            StringBuilder rtn = new StringBuilder();
            for (int i = 31; i >= 0; i--)
            {
                int v = (1 << i) & n;
                rtn.Append(v == 1 ? "1" : "0");
            }
            return rtn.ToString();
        }

        public static string RecursiveStringReverse(string input)
        {
            if (input.Length <= 1)
                return input;
            char firstChar = input[0];
            string lastChars = input.Substring(1);
            return RecursiveStringReverse(lastChars) + firstChar;

        }
    }
}
