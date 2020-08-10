using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class IsomorphicString
    {


        static int size = 256;
        static int countWords(String str)
        {
            int count = 1;

            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str[i] >= 65 && str[i] <= 90)
                    count++;
            }

            return count;
        }
        // Function returns true if str1 
        // and str2 are ismorphic 

        static bool areIsomorphic(String str1,
                                  String str2)
        {

            int m = str1.Length;
            int n = str2.Length;

            // Length of both strings must be same  
            // for one to one corresponance 
            if (m != n)
                return false;

            // To mark visited characters in str2 
            bool[] marked = new bool[size];

            for (int i = 0; i < size; i++)
                marked[i] = false;


            // To store mapping of every character 
            // from str1 to that of str2 and 
            // Initialize all entries of map as -1. 
            int[] map = new int[size];

            for (int i = 0; i < size; i++)
                map[i] = -1;

            // Process all characters one by on 
            for (int i = 0; i < n; i++)
            {

                // If current character of str1 is  
                // seen first time in it. 
                if (map[str1[i]] == -1)
                {

                    // If current character of str2 
                    // is already seen, one to 
                    // one mapping not possible 
                    if (marked[str2[i]] == true)
                        return false;

                    // Mark current character of  
                    // str2 as visited 
                    marked[str2[i]] = true;

                    // Store mapping of current characters 
                    map[str1[i]] = str2[i];
                }

                // If this is not first appearance of current 
                // character in str1, then check if previous 
                // appearance mapped to same character of str2 
                else if (map[str1[i]] != str2[i])
                    return false;
            }

            return true;
        }

        // Driver code 
        public static void Main()
        {
            bool res = areIsomorphic("aab", "xxy");
            Console.WriteLine(res);

            res = areIsomorphic("egg", "edd");
            Console.WriteLine(res);
            res = areIsomorphic("aab", "xyz");
            Console.WriteLine(res);
            res = areIsomorphic("abd", "ccy");
            Console.WriteLine(res);

            //String str = "geeksForGeeks";

            //Console.Write(countWords(str));
        }
    }
}
