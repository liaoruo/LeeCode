using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0032.LongestValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.LongestValidParentheses(")()(())))("));
            System.Console.WriteLine(solution.LongestValidParentheses("()()()"));
            System.Console.WriteLine(solution.LongestValidParentheses(")()()()()((()"));
        }
    }
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            var start = s.IndexOf('(');
            var end = s.LastIndexOf(')');
            if (start == -1 || end == -1 || start >= end)
            {
                return 0;
            }
            s = s.Substring(start, end - start + 1);

            var maxLenEndAt = new List<int>();
            var maxLenStartAt = new List<int>();
            Stack<int> stack = new Stack<int>();


            var len = s.Length;
            var max = 0;
            for (var i = 0; i < len; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                    maxLenEndAt.Add(0);
                }
                else if (s[i] == ')')
                {
                    if (stack.Count == 0)
                    {
                        maxLenEndAt.Add(0);
                    }
                    else
                    {
                        var last = stack.Pop();
                        var maxLen = 0;
                        if (last > 0 && maxLenEndAt[last - 1] > 0)
                        {
                            maxLen = i - last + 1 + maxLenEndAt[last - 1];
                        }
                        else
                        {
                            maxLen = i - last + 1;
                        }

                        maxLenEndAt.Add(maxLen);
                        if (maxLen > max)
                        {
                            max = maxLen;
                        }

                    }
                }
            }


            return max;
        }
    }
}
