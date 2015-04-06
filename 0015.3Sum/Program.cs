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
            var ret = solution.ThreeSum(new int[] { 7, -1, 14, -12, -8, 7, 2, -15, 8, 8, -8, -14, -4, -5, 7, 9, 11, -4, -15, -6, 1, -14, 4, 3, 10, -5, 2, 1, 6, 11, 2, -2, -5, -7, -6, 2, -15, 11, -6, 8, -4, 2, 1, -1, 4, -6, -15, 1, 5, -15, 10, 14, 9, -8, -6, 4, -6, 11, 12, -15, 7, -1, -9, 9, -1, 0, -4, -1, -12, -2, 14, -9, 7, 0, -3, -4, 1, -2, 12, 14, -10, 0, 5, 14, -1, 14, 3, 8, 10, -8, 8, -5, -2, 6, -11, 12, 13, -7, -12, 8, 6, -13, 14, -2, -5, -11, 1, 3, -6 });
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
        public IList<IList<int>> ThreeSum(int[] num)
        {
            List<int> list = new List<int>(num);
            list.Sort();
            Dictionary<int, int> dic = new Dictionary<int, int>();
            HashSet<string> dedupe = new HashSet<string>();
            foreach (var e in list)
            {
                if (e >= 0)
                {
                    if (dic.ContainsKey(e))
                    {
                        dic[e]++;
                    }
                    else
                    {
                        dic.Add(e, 1);
                    }
                }
            }

            List<IList<int>> ret = new List<IList<int>>();
            var len = list.Count;
            for (var i = 0; i < len; i++)
            {
                for (var j = i + 1; j < len; j++)
                {
                    var need = 0 - list[i] - list[j];
                    if (need < 0 || need < list[j])
                    {
                        break;
                    }
                    var needCnt = 1 + (list[i] == need ? 1 : 0) + (list[j] == need ? 1 : 0);
                    if (dic.ContainsKey(need) && dic[need] >= needCnt)
                    {
                        var str = list[i] + "\t" + list[j] + "\t" + need;
                        if (!dedupe.Contains(str))
                        {
                            dedupe.Add(str);
                            ret.Add(new List<int>() { list[i], list[j], need });
                        }
                    }
                }
            }
            return ret;
        }
    }
}
