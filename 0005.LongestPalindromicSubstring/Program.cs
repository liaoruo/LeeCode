using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0005.LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "aaaabaaa";
            Solution solution = new Solution();
            System.Console.WriteLine(solution.LongestPalindrome(str));
        }
    }
    public class Solution
    {
        //Manacher's algorithm, O(n)
        public string Reformat(string s)
        {
            char tag = '#';
            var sb = new StringBuilder();
            sb.Append(tag);
            var len = s.Length;
            for (var i = 0; i < len; i++)
            {
                sb.Append(s[i]);
                sb.Append(tag);
            }
            return sb.ToString();
        }
        public int LongestPalindromic(string s, int middle)
        {
            int res = 0;
            int len = s.Length;
            while (middle - res - 1 >= 0 && middle + res + 1 < len && s[middle - res - 1] == s[middle + res + 1])
            {
                res++;
            }
            return res;
        }
        public int LongestReverse(string s, int middle, int right)
        {
            int res = 0;
            int len = s.Length;
            int left = middle - (right - middle);
            while (left - res >= 0 && right + res < len && s[left - res] == s[right + res])
            {
                res++;
            }
            return res;
        }
        public string LongestPalindrome(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return s;
            }
            else if (s.Length == 1)
            {
                return s;
            }

            s = Reformat(s);
            var len = s.Length;

            //L[i] is longest radio when i is the middle point, when L[i]=0, only middle point i;
            int[] L = new int[len];

            //Current middle point and max radio
            int id = 0, mx = 0;
            L[0] = mx;
            for (int i = 1; i < len; i++)
            {
                if (i < id + mx)
                {
                    var ri = id - (i - id);
                    if (i + L[ri] < id + mx)
                    {
                        L[i] = L[ri];
                    }
                    else
                    {
                        L[i] = id + mx - i + LongestReverse(s, i, id + mx + 1);
                        id = i;
                        mx = L[i]; 
                    }
                }
                else
                {
                    L[i] = LongestPalindromic(s, i);
                    id = i;
                    mx = L[i];
                }
            }

            id = mx = 0;
            for (int i = 0; i < len; i++)
            {
                if (L[i] > mx)
                {
                    mx = L[i];
                    id = i;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = id - mx; i <= id + mx; i++)
            {
                if (s[i] != '#')
                {
                    sb.Append(s[i]);
                }
            }
            return sb.ToString();

        }
    }
}
