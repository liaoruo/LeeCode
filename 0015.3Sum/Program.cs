using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0015._3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ret = solution.ThreeSum(
                new int[] { 2, 0, -2, -5, -5, -3, 2, -4 });
                //new int[] { 1, 2, -3, 0, 0, 0, 0 });
                //new int[] { 7, -1, 14, -12, -8, 7, 2, -15, 8, 8, -8, -14, -4, -5, 7, 9, 11, -4, -15, -6, 1, -14, 4, 3, 10, -5, 2, 1, 6, 11, 2, -2, -5, -7, -6, 2, -15, 11, -6, 8, -4, 2, 1, -1, 4, -6, -15, 1, 5, -15, 10, 14, 9, -8, -6, 4, -6, 11, 12, -15, 7, -1, -9, 9, -1, 0, -4, -1, -12, -2, 14, -9, 7, 0, -3, -4, 1, -2, 12, 14, -10, 0, 5, 14, -1, 14, 3, 8, 10, -8, 8, -5, -2, 6, -11, 12, 13, -7, -12, 8, 6, -13, 14, -2, -5, -11, 1, 3, -6 });
            foreach (var e in ret)
            {
                foreach (var ee in e)
                {
                    System.Console.Write(ee + "\t");
                }
                System.Console.WriteLine();
            }
        }
    }
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            List<int> orderList = new List<int>(nums);
            orderList.Sort();
            var cnt = orderList.Count();
            for (var i = 0; i < cnt - 2; i++)
            {
                if (orderList[i] * 3 > 0)
                {
                    break;
                }

                var j = i + 1;
                var k = cnt - 1;

                if (orderList[i] + orderList[j] * 2 > 0 || orderList[i] + orderList[k] * 2 < 0)
                {
                    continue;
                }

                while (j < k)
                {
                    if (orderList[i] + orderList[j] + orderList[k] < 0)
                    {
                        j++;
                    }
                    else if (orderList[i] + orderList[j] + orderList[k] > 0)
                    {
                        k--;
                    }
                    else
                    {
                        ret.Add(new List<int>() { orderList[i], orderList[j], orderList[k] });
                        while (j + 1 < k && orderList[j + 1] == orderList[j])
                        {
                            j++;
                        }
                        j++;
                        while (j < k - 1 && orderList[k - 1] == orderList[k])
                        {
                            k--;
                        }
                        k--;
                    }
                }

                while (i + 1 < cnt - 2 && orderList[i] == orderList[i + 1])
                {
                    i++;
                }
            }
            return ret;
        }
    }
}
