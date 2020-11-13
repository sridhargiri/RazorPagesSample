using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ZigZag
    {
        /*
         Approach 1: Sort by Row
Intuition

By iterating through the string from left to right, we can easily determine which row in the Zig-Zag pattern that a character belongs to.

Algorithm

We can use min(numRows,len(s) lists to represent the non-empty rows of the Zig-Zag Pattern.

Iterate through ss from left to right, appending each character to the appropriate row. The appropriate row can be tracked using two variables: the current row and the current direction.

The current direction changes only when we moved up to the topmost row or moved down to the bottommost row.
         */

        public String convert(String s, int numRows)
        {

            if (numRows == 1) return s;

            List<StringBuilder> rows = new List<StringBuilder>();
            for (int i = 0; i < Math.Min(numRows, s.Length); i++)
                rows.Add(new StringBuilder());

            int curRow = 0;
            bool goingDown = false;

            foreach (char c in s.ToCharArray())
            {
                rows[curRow].Append(c);
                if (curRow == 0 || curRow == numRows - 1) goingDown = !goingDown;
                curRow += goingDown ? 1 : -1;
            }

            StringBuilder ret = new StringBuilder();
            foreach (StringBuilder row in rows) ret.Append(row);
            return ret.ToString();
        }
        //Approach 2 visit by row

        public String convert_(String s, int numRows)
        {

            if (numRows == 1) return s;

            StringBuilder ret = new StringBuilder();
            int n = s.Length;
            int cycleLen = 2 * numRows - 2;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j + i < n; j += cycleLen)
                {
                    ret.Append(s[j + i]);
                    if (i != 0 && i != numRows - 1 && j + cycleLen - i < n)
                        ret.Append(s[j + cycleLen - i]);
                }
            }
            return ret.ToString();
        }
    }
}
