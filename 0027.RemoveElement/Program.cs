using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0027.RemoveElement
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Count() == 0)
            {
                return 0;
            }
                
            var n = nums.Count();
            var newLen = 0;
            for (var i = 0; i < n; i++)
            {
                if(nums[i]!=val)
                {
                    nums[newLen++]=nums[i];
                }
            }

            return newLen;
        }
    }
}
