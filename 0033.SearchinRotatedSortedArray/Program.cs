using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0033.SearchinRotatedSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums=new int[]{3,4,6,7,1,2,3};
            System.Console.WriteLine(solution.Search(nums,5));
        }
    }
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }
            
            var start = 0;
            var end = nums.Length - 1;
            if (target == nums[start])
            {
                return start;
            }
            else if (target == nums[end])
            {
                return end;
            }

            while (start < end)
            {
                var middle = (start + end) / 2;
                if (target == nums[middle])
                {
                    return middle;
                }
                else if (target == nums[middle + 1])
                {
                    return middle + 1;
                }

                if (nums[start] < nums[middle])
                {
                    if (target > nums[start] && target < nums[middle])
                    {
                        return BinSearch(nums, target, start, middle);
                    }
                    start = middle + 1;
                    continue;
                }

                if (nums[middle + 1] < nums[end])
                {
                    if (target > nums[middle + 1] && target < nums[end])
                    {
                        return BinSearch(nums, target, middle + 1, end);
                    }
                    end = middle;
                    continue;
                }

                return -1;
            }

            return -1;
        }
        public int BinSearch(int[] nums, int target, int start, int end)
        {
            while (start <= end)
            {
                var middle = (start + end) / 2;
                if (target == nums[middle])
                {
                    return middle;
                }
                else if (target < nums[middle])
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }
            return -1;
        }
    }
}
