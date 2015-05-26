using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0026.RemoveDuplicatesfromSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1,1,2,2,3,3,4,4,5,5,5,5};
            Solution solution = new Solution();
            var ret = solution.RemoveDuplicates(nums);
            System.Console.WriteLine(ret);
            for (var i = 0; i < ret; i++)
                System.Console.Write(nums[i]);
        }
        public class Solution
        {
            public int RemoveDuplicates(int[] nums)
            {
                if (nums == null)
                    return 0;

                var n = nums.Count();
                if (n <= 1)
                    return n;

                var dup = 0;
                for (int i = 0, j = 0; i < n; i++)
                {
                    nums[i] = nums[j];
                    var k = 1;
                    while (j + k < n && nums[j + k] == nums[j])
                    {
                        k++;
                        dup++;
                    }
                    
                    if (j + k == n)
                    {
                        break;
                    }
                    j += k;
                }
                return n - dup;
            }
        }
    }
}
