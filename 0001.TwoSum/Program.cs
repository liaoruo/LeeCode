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
                Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
                for (var i = 0; i < nums.Length; i++)
                {
                    if (dic.ContainsKey(nums[i]))
                    {
                        dic[nums[i]].Add(i);
                    }
                    else
                    {
                        dic.Add(nums[i], new List<int>(){i});
                    }
                }
                for (var i = 0; i < nums.Length; i++)
                {
                    var find = target - nums[i];
                    if (find != nums[i])
                    {
                        if (dic.ContainsKey(find))
                        {
                            return new int[2] { i + 1, dic[find][0] + 1 };
                        }
                    }
                    else
                    {
                        if (dic.ContainsKey(find)&&dic[find].Count>=2)
                        {
                            return new int[2] { dic[find][0] + 1, dic[find][1] + 1 };
                        }
                    }
                }
                return null;
            }
        }
    }
}
