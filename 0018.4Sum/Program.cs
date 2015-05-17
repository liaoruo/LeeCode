using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0018._4Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ret = solution.FourSum(new int[] { 455, -408, -383, -374, -347, -344, -320, -319, -266, -252, -170, -120, -113, -104, -100, -81, -64, -48, -46, -44, -4, -1, 26, 28, 30, 62, 69, 84, 100, 119, 126, 134, 144, 145, 170, 179, 230, 246, 264, 269, 272, 289, 294, 323, 328, 331, 335, 336, 370, 370, 388, 394, 397, 400, 427, 431, 452, 483 }, 5842);
            foreach (var item in ret)
            {
                foreach (var e in item)
                {
                    System.Console.Write(e + " ");
                }
                System.Console.WriteLine();
            }
        }
    }
    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<int> sortList = new List<int>(nums);
            sortList.Sort();

            List<IList<int>> ret = new List<IList<int>>();
            var cnt = sortList.Count;
            for (var i1 = 0; i1 < cnt - 3; i1++)
            {
                if (sortList[i1] * 4 > target)
                {
                    break;
                }
                for (var i2 = i1 + 1; i2 < cnt - 2; i2++)
                {
                    if (sortList[i1] + sortList[i2] * 3 > target)
                    {
                        break;
                    }

                    var i3 = i2 + 1;
                    var i4 = cnt - 1;

                    while (i3 < i4)
                    {
                        if (sortList[i1] + sortList[i2] + sortList[i3] * 2 > target || sortList[i1] + sortList[i2] + sortList[i4] * 2 < target)
                        {
                            break;
                        }

                        var sum = sortList[i1] + sortList[i2] + sortList[i3] + sortList[i4];
                        if (sum < target)
                        {
                            i3++;
                        }
                        else if (sum > target)
                        {
                            i4--;
                        }
                        else
                        {
                            ret.Add(new List<int>() { sortList[i1], sortList[i2], sortList[i3], sortList[i4] });
                            while (i3 + 1 < i4 && sortList[i3] == sortList[i3 + 1])
                            {
                                i3++;
                            }
                            i3++;
                            while (i3 < i4 - 1 && sortList[i4] == sortList[i4 - 1])
                            {
                                i4--;
                            }
                            i4--;
                        }
                    }


                    //dedupe
                    while (i2 + 1 < cnt - 2 && sortList[i2] == sortList[i2 + 1])
                    {
                        i2++;
                    }
                }

                //dedupe
                while (i1 + 1 < cnt - 3 && sortList[i1] == sortList[i1 + 1])
                {
                    i1++;
                }
            }

            return ret;
        }
    }
}
