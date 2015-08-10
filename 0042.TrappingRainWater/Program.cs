using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0042.TrappingRainWater
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.Trap(new int[] { 5, 4, 3, 2, 1 }));
            System.Console.WriteLine(solution.Trap(new int[] { 5, 4, 3, 2, 3 }));
            System.Console.WriteLine(solution.Trap(new int[] { 5, 4, 3, 5, 1 }));
            System.Console.WriteLine(solution.Trap(new int[] { 2, 4, 3, 5, 3}));
            

        }
    }
    public class Solution
    {
        public int Trap(int[] height)
        {
            if (height == null || height.Length < 3)
            {
                return 0;
            }

            var start = 0;
            var end = height.Length - 1;
            var sum = 0;
            while (start < end - 1)
            {
                if (height[start] < height[end])
                {
                    if (height[start + 1] < height[start])
                    {
                        sum += height[start] - height[start + 1];
                        height[start + 1] = height[start];
                    }
                    start++;
                }
                else
                {
                    if (height[end - 1] < height[end])
                    {
                        sum += height[end] - height[end - 1];
                        height[end - 1] = height[end];
                    }
                    end--;
                }
            }
            return sum;
        }
    }
}
