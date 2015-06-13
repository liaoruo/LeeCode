using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0028.ImplementstrStr
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ret = solution.StrStr("abcdddabceeabcdddabces", "bceeab");
            System.Console.WriteLine(ret);
        }
    }
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            //return haystack.IndexOf(needle);
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(haystack))
            {
                return -1;
            }

            //s1.subtring(s2):
            //If s1 is not changed, and s2 change many time, use Dictionary Tree
            //If s1 change many time, and s2 is not changed, use KMP

            //KMP
            var nextArr = CalNextArr(needle);
            var ret = KMP(haystack, needle, nextArr);

            return ret;
        }

        public int KMP(string mainStr, string searchStr, List<int> nextArr)
        {
            if (nextArr == null || string.IsNullOrEmpty(searchStr) || string.IsNullOrEmpty(mainStr) || nextArr.Count != searchStr.Length)
            {
                return -1;
            }

            var i = 0;
            var j = 0;
            var len1 = mainStr.Length;
            var len2 = searchStr.Length;
            while (i < len1 && j < len2)
            {
                if (mainStr[i] == searchStr[j])
                {
                    i++; j++;
                }
                else if (-1 != nextArr[j])
                {
                    j = nextArr[j];
                }
                else
                {
                    i++;
                    j = 0;
                }
            }

            if (j == len2)
            {
                return i - len2;
            }
            else
            {
                return -1;
            }
        }

        public List<int> CalNextArr(string s)
        {
            var nextArr = new List<int>();
            if (string.IsNullOrEmpty(s))
            {
                return nextArr;
            }

            var len = s.Length;
            nextArr.Add(-1);
            if (len >= 2)
                nextArr.Add(0);

            for (var i = 2; i < len; i++)
            {
                var next = 0;
                if (nextArr[i - 1] == -1)
                {
                    if (s[0] == s[i - 1])
                    {
                        next = 1;
                    }
                }
                else
                {
                    if (s[i - 1] == s[nextArr[i - 1]])
                    {
                        next = nextArr[i - 1] + 1;
                    }
                    else
                    {
                        var tryLen = nextArr[i - 1];
                        while (tryLen > 0)
                        {
                            //Compare 0~ tryLen-1 vs i-tryLen~i-1
                            if (s.Substring(0, tryLen) == s.Substring(i - tryLen, tryLen))
                            {
                                break;
                            }

                            tryLen--;
                        }

                        next = tryLen;
                    }                    
                }
                nextArr.Add(next);
            }

            //More
            for (var i = 1; i < len; i++)
            {
                var next = nextArr[i];
                while (next != -1 && s[i] == s[next])
                {

                    next = nextArr[next];
                }
                nextArr[i] = next;
            }
            
            return nextArr;
        }
    }
}
