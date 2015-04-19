using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0014.LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.LongestCommonPrefix(new string[]{"aa","a"}));
        }
    }
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            var start = 0;
            var strCnt = strs.Length;
            while (true)
            {
                if (start >= strs[0].Length)
                    return sb.ToString();
                var c = strs[0][start];
                for (var i = 1; i < strCnt; i++)
                {
                    if (start>=strs[i].Length || c != strs[i][start])
                    {
                        return sb.ToString();
                    }
                }
                sb.Append(c);
                start++;
            }
        }
    }
}
