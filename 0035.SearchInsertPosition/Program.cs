using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0035.SearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.SearchInsert(new int[] { 1, 3, 5, 6 }, 5));
            System.Console.WriteLine(solution.SearchInsert(new int[] { 1, 3, 5, 6 }, 2));
            System.Console.WriteLine(solution.SearchInsert(new int[] { 1, 3, 5, 6 }, 7));
            System.Console.WriteLine(solution.SearchInsert(new int[] { 1, 3, 5, 6 }, 0));
            System.Console.WriteLine(solution.SearchInsert(new int[] { }, 5));
        }
    }
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var start = 0;
            var end = nums.Length - 1;
            if (target < nums[0])
            {
                return 0;
            }
            else if (target > nums[end])
            {
                return end + 1;
            }

            while (start < end)
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

            if (target <= nums[start])
            {
                return start;
            } 
            else
            {
                return start + 1;
            }
        }
    }
}
