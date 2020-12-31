using System;
using System.Text;
public class MinSwapAlternateSequence{
/*
2 problems asked in DealerSocket js codility
 question mark from a String so that same letter does not occur next to each other. For example:

Input

ab?ac?
Output

abcaca
Please note that ? should be replaced by any lowercase letter: [a-z]
*/
public String solution(String riddle) {
    if (riddle == null || riddle.IndexOf('?') == -1) {
        return riddle;
    }
    StringBuilder sb = new StringBuilder("");
    char prev = '\0';
    for (int i = 0; i < riddle.Length; i++) {
        char current = riddle[i];
        if (current == '?') {
            char next = '\0';
            if (i != riddle.Length - 1) {
                next = riddle[i + 1];
            }
            current = prev != 'a' && next != 'a' ? 'a'
                    : prev != 'b' && next != 'b' ? 'b'
                    : 'c';
        }
        sb.Append(current);
        prev = current;
    }
    return sb.ToString();
}

/*
Minimum number of replacements to make the binary string alternating | Set 2
Last Updated: 18-03-2019
Given a binary string str, the task is to find the minimum number of characters in the string that have to be replaced in order to make the string alternating (i.e. of the form 01010101… or 10101010…).

Examples:

Input: str = “1100”
Output: 2
Replace 2nd character with ‘0’ and 3rd character with ‘1’

Input: str = “1010”
Output: 0
The string is already alternating.


Approach: For the string str, there can be two possible solutions. Either the resultant string can be

010101… or
101010…
In order to find the minimum replacements, count the number of replacements to convert the string in type 1 and store it in count then minimum replacement will be min(count, len – count) where len is the length of the string. len – count is the number of replacements to convert the string in type 2.

*/

class GFG  
{ 
  
    // Function to return the minimum number of 
    // characters of the given binary string 
    // to be replaced to make the string alternating
    
    static int minReplacement(String s, int len) 
    { 
        int ans = 0; 
        for (int i = 0; i < len; i++)  
        { 
  
            // If there is 1 at even index positions 
            if (i % 2 == 0 && s[i] == '1') 
                ans++; 
  
            // If there is 0 at odd index positions 
            if (i % 2 == 1 && s[i] == '0') 
                ans++; 
        } 
        return Math.Min(ans, len - ans); 
    } 
  
    // Driver code 
    public static void Main(String []args) 
    { 
        String s = "1100"; 
        int len = s.Length; 
        Console.Write(minReplacement(s, len)); 
    } 
} 
}
