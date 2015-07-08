using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0039.CombinationSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] candidates = new int[] { 2,3,6 ,7};
            int target = 7;
            var ret=solution.CombinationSum(candidates, target);
            foreach (var line in ret)
            {
                System.Console.WriteLine(string.Join(" ", line));
            }
        }
    }
    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var sortedCandidates = candidates.OrderBy(p => p).ToArray();
            var ret = new List<IList<int>>();

            if (sortedCandidates[0] > target)
            {
                return ret;
            }

            CombinationSumLoop(sortedCandidates, target, 0, sortedCandidates.Length, new Stack<int>(), 0, ret);
            return ret;
        }
        public void CombinationSumLoop(int[] candidates, int target, int startIndex, int n, Stack<int> keep, int sum, List<IList<int>> ret)
        {
            for (var i = startIndex; i < n; i++)
            {
                if (sum + candidates[i] == target)
                {
                    keep.Push(candidates[i]);
                    var clone = (new List<int>(keep)).OrderBy(p=>p).ToList();
                    ret.Add(clone);
                    keep.Pop();
                    break;
                }
                else if (sum + candidates[i] < target)
                {
                    keep.Push(candidates[i]);
                    CombinationSumLoop(candidates, target, i, n, keep, sum + candidates[i], ret);
                    keep.Pop();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
