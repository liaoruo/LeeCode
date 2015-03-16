using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0003.LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.LengthOfLongestSubstring("abcdadec"));
        }
    }
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            var len = s.Length;
            var max = 0;
            var min = 0;
            for (int i = 0; i < len; i++)
            {
                if (!dic.ContainsKey(s[i]))
                {
                    dic.Add(s[i], i);
                    if (max < i - min + 1)
                    {
                        max = i - min + 1;
                    }
                }
                else if (dic[s[i]] < min)
                {
                    dic[s[i]] = i;
                    if (max < i - min + 1)
                    {
                        max = i - min + 1;
                    }
                }
                else
                {
                    if (max < i - dic[s[i]])
                    {
                        max = i - dic[s[i]];
                    }
                    min = dic[s[i]] + 1;
                    dic[s[i]] = i;
                }

            }
            return max;
        }
    }
}
