using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0017.Letter_CombinationsofaPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ret = solution.LetterCombinations("23");
            foreach (var line in ret)
            {
                System.Console.WriteLine(line);
            }
        }
    }
    public class Solution
    {
        public Dictionary<char, List<char>> dic = new Dictionary<char, List<char>>() { 
                {'0',new List<char>(){' '}},
                {'1',new List<char>()},
                {'2',new List<char>(){'a','b','c'}},
                {'3',new List<char>(){'d','e','f'}},
                {'4',new List<char>(){'g','h','i'}},
                {'5',new List<char>(){'j','k','l'}},
                {'6',new List<char>(){'m','n','o'}},
                {'7',new List<char>(){'p','q','r','s'}},
                {'8',new List<char>(){'t','u','v'}},
                {'9',new List<char>(){'w','x','y','z'}}
            };
        public IList<string> LetterCombinations(string digits)
        {
            List<string> ret = new List<string>();
            if (string.IsNullOrEmpty(digits))
                return ret;
            char[] charArr = digits.ToArray();
            LoopRun(ret, charArr, digits, 0);
            return ret;
        }
        void LoopRun(List<string> ret, char[] charArr, string digits, int index)
        {
            if (index == digits.Length)
            {
                ret.Add(new string(charArr));
            }
            else
            {
                var c = digits[index];
                var mapList = dic[c];
                if (mapList != null && mapList.Count != 0)
                {
                    for (var i = 0; i < mapList.Count(); i++)
                    {
                        charArr[index] = mapList[i];
                        LoopRun(ret, charArr, digits, index + 1);
                    }
                }
            }
        }
    }

}
