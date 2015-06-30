using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0038.CountandSay
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.Say("1"));
            System.Console.WriteLine(solution.Say("11"));
            System.Console.WriteLine(solution.Say("21"));
            System.Console.WriteLine(solution.Say("1211"));
            System.Console.WriteLine(solution.Say("111221"));
            System.Console.WriteLine(solution.CountAndSay(1));
            System.Console.WriteLine(solution.CountAndSay(2));
            System.Console.WriteLine(solution.CountAndSay(3));
            System.Console.WriteLine(solution.CountAndSay(4));
            System.Console.WriteLine(solution.CountAndSay(5));
            System.Console.WriteLine(solution.CountAndSay(5));
            System.Console.WriteLine(solution.CountAndSay(4));
            System.Console.WriteLine(solution.CountAndSay(3));
            System.Console.WriteLine(solution.CountAndSay(2));
            System.Console.WriteLine(solution.CountAndSay(1));
            
        }
    }
    public class Solution
    {
        public static List<string> his = new List<string>() { "", "1", "11" };
        public string CountAndSay(int n)
        {
            if (his != null && his.Count >= n + 1)
            {
                return his[n];
            }

            var i = his.Count - 1;
            for (; i <= n; i++)
            {
                his.Add(Say(his[i]));            
            }

            return his[n];
        }
        public string Say(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            var pre = ' ';
            var cnt = 1;
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if (c == pre)
                {
                    cnt++;
                }
                else
                {
                    if(pre!=' ')
                    {
                        sb.Append(cnt);
                        sb.Append(pre);
                    }

                    pre = c;
                    cnt = 1;
                }
            }

            sb.Append(cnt);
            sb.Append(pre);

            return sb.ToString();
        }
    }
}
