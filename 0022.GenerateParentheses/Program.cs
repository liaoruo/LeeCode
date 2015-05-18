using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0022.GenerateParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ret = solution.GenerateParenthesis(10);
            foreach (var line in ret)
            {
                System.Console.WriteLine(line);
            }
        }
    }
    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> ret = new List<string>();
            if (n == 0)
                return ret;
            SubFun("", n, n, ref ret);
            return ret;
        }
        public void SubFun(string prefix, int i, int j, ref List<string> list)
        {
            if (i == 0 && j == 0)
            {
                list.Add(prefix);
                return;
            }

            if (i > 0)
            {
                SubFun(prefix + "(", i - 1, j, ref list);
            }
            if (i < j)
            {
                SubFun(prefix + ")", i, j - 1, ref list);
            }

        }
    }
}
