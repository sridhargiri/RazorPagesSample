using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     * We have to maximize the Area that can be formed between the vertical lines using the shorter line as length and the distance between the lines as the width of the rectangle forming the area.
     * 
     * container can't be slanted
     * 
     The intuition behind this approach is that the area formed between the lines will always be limited by the height of the shorter line. 
    Further, the farther the lines, the more will be the area obtained.

 We take two pointers, one at the beginning and one at the end of the array constituting the length of the lines.
    Futher, we maintain a variable to store the maximum area obtained till now. 
    At every step, we find out the area formed between them, update maxarea and move the pointer pointing to the shorter line towards the other end by one step.
     */
    class LeetcodeMostWater
    {
        public static void Main(string[] args)
        {
            int[] heigts = new int[9] { 1 ,8 ,6 ,2 ,5 ,4 ,8 ,3 ,7 };
            Console.WriteLine(maxArea(heigts));
        }
        public static int maxArea(int[] height)
        {
            int maxarea = 0, l = 0, r = height.Length - 1;
            while (l < r)
            {
                maxarea = Math.Max(maxarea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxarea;
        }
    }
}
