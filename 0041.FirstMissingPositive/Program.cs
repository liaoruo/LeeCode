using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0041.FirstMissingPositive
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ret = solution.FirstMissingPositive(new int[] { });
            System.Console.WriteLine(ret);
        }
    }
    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            HashSet<int> hs = new HashSet<int>();
            foreach (var i in nums)
            {
                hs.Add(i);
            }
            for (var i = 1; i <= nums.Length + 1; i++)
            {
                if (!hs.Contains(i))
                {
                    return i;
                }
            }
            return 1;
        }
    }
}
