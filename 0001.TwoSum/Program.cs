using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0001.TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 2, 7, 11, 2 };
            var target = 4;
            var solution = new Solution();
            var ret = solution.TwoSum(numbers, target);
            
            System.Console.WriteLine(ret == null ? "null" : ret[0] + "," + ret[1]);
        }
        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                Dictionary<int, int> dic = new Dictionary<int, int>();
                var cnt = nums.Length;
                for (var i = 0; i < cnt; i++)
                {
                    var need = target - nums[i];
                    if (dic.ContainsKey(need))
                    {
                        return new int[] { dic[need] + 1, i + 1 };
                    }
                    else
                    {
                        if (!dic.ContainsKey(nums[i]))
                        {
                            dic.Add(nums[i], i);
                        }
                    }
                }
                return null;
            }
        }
    }
}
