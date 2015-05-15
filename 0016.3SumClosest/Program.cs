using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0016._3SumClosest
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.ThreeSumClosest(new int[]{-1,2,1,-4},1));
        }
    }
    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            List<int> orderList = new List<int>(nums);
            orderList.Sort();
            var cnt = orderList.Count();
            var closest = nums[0] + nums[1] + nums[2];
            for (var i = 0; i < cnt - 2; i++)
            {

                var j = i + 1;
                var k = cnt - 1;

                while (j < k)
                {
                    if (Math.Abs(orderList[i] + orderList[j] + orderList[k] - target) < Math.Abs(closest - target))
                    {
                        closest = orderList[i] + orderList[j] + orderList[k];
                    }

                    if (orderList[i] + orderList[j] + orderList[k] < target)
                    {
                        j++;
                    }
                    else if (orderList[i] + orderList[j] + orderList[k] > target)
                    {
                        k--;
                    }
                    else
                    {
                        return target;
                    }
                }

                while (i + 1 < cnt - 2 && orderList[i] == orderList[i + 1])
                {
                    i++;
                }
            }

            return closest;
        }

    }
}
