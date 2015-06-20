using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0031.NextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            var input = new int[] { 1, 2, 5, 9, 6, 4, 2, 1 };
            solution.NextPermutation(input);
            foreach (var e in input)
            {
                System.Console.Write(e + " ");
            }
            System.Console.WriteLine();

            input = new int[] {9, 8,7,5,5,5 };
            solution.NextPermutation(input);
            foreach (var e in input)
            {
                System.Console.Write(e + " ");
            }
            System.Console.WriteLine();

            input = new int[] { 1, 2, 5, 9, 5, 4, 1, 1 };
            solution.NextPermutation(input);
            foreach (var e in input)
            {
                System.Console.Write(e + " ");
            }
            System.Console.WriteLine();


        }
    }
    public class Solution
    {
        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return;
            }

            var index = nums.Length - 2;
            while (index >= 0)
            {
                if (nums[index] < nums[index + 1])
                {
                    break;
                }
                index--;
            }

            if (index < 0)
            {
                RevertArray(nums, 0, nums.Length - 1);
                return;
            }

            RevertArray(nums, index + 1, nums.Length - 1);
            var index2 = index + 1;
            while (nums[index2] <= nums[index])
            {
                index2++;
            }

            var t = nums[index];
            nums[index] = nums[index2];
            nums[index2] = t;
            //x x x 5 9 6 4 2 1
            //x x x 5 1 2 4 6 9
            //x x x 6 1 2 4 5 9
        }
        public void RevertArray(int[] nums, int start, int end)
        {
            if (nums == null || nums.Length == 0 | start > end || start < 0 || end > nums.Length - 1)
            {
                return;
            }
            while (start < end)
            {
                var t = nums[start];
                nums[start] = nums[end];
                nums[end] = t;
                start++;
                end--;
            }
        }
    }
}
