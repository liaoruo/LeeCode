using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0034.SearchforaRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ret = solution.SearchRange(new int[] {8,8,8,8,8,8,8}, 8);
            System.Console.WriteLine(ret[0]);
            System.Console.WriteLine(ret[1]);
        }
    }
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var index1 = SearchRangeLeft(nums, target);
            var index2 = SearchRangeRight(nums, target);
            return new int[] { index1, index2 };
        }
        public int SearchRangeLeft(int[] nums, int target)
        {
            var start = 0;
            var end = nums.Length - 1;
            while (start < end)
            {
                var middle = (start + end) / 2;
                if (target <= nums[middle])
                {
                    end = middle;
                }
                else
                {
                    start = middle + 1;
                }
            }

            if (start == end && target == nums[start])
            {
                return start;
            }
            else
            {
                return -1;
            }
        }
        public int SearchRangeRight(int[] nums, int target)
        {
            var start = 0;
            var end = nums.Length - 1;
            while (start < end)
            {
                var middle = (start + end) / 2;
                if (target >= nums[middle])
                {
                    start = middle;
                    if (start == end - 1)
                    {
                        if (target == nums[end])
                        {
                            return end;
                        }
                        else if (target == nums[start])
                        {
                            return start;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                else
                {
                    end = middle - 1;
                }
            }

            if (start == end && target == nums[start])
            {
                return start;
            }
            else
            {
                return -1;
            }
        }
    }
}
