using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0065.ValidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            System.Console.WriteLine(solution.IsNumber("0"));
            System.Console.WriteLine(solution.IsNumber(" 0.1"));
            System.Console.WriteLine(solution.IsNumber("abc"));
            System.Console.WriteLine(solution.IsNumber("1 a"));
            System.Console.WriteLine(solution.IsNumber("2e10"));
            System.Console.WriteLine(solution.IsNumber("078332e437"));
            System.Console.WriteLine(solution.IsNumber("e-.437"));
            System.Console.WriteLine(solution.IsNumber("078.332e"));
            System.Console.WriteLine(solution.IsNumber("-0783.32e+4.37"));
            System.Console.WriteLine(solution.IsNumber("+.1e+.1"));
            System.Console.WriteLine(solution.IsNumber("+.e-.1"));
        }
    }
    public class Solution
    {
        public bool IsNumber(string s)
        {
            s = s.Trim().ToLower();
            //e  1.23e-2.3
            int id = s.IndexOf('e');
            if (id == -1)
            {
                return IsSimpleDouble(s, false);
            }
            else if (id != s.LastIndexOf('e'))
            {
                return false;
            }
            else
            {
                return IsSimpleDouble(s.Substring(0, id), false) && IsSimpleIntergrate(s.Substring(id + 1), true, false);
            }
        }
        public bool IsSimpleDouble(string s, bool emptyable)
        {
            if (string.IsNullOrEmpty(s))
                return emptyable;

            int id = s.IndexOf('.');
            if (id == -1)
            {
                return IsSimpleIntergrate(s, true, emptyable);
            }
            else if (id != s.LastIndexOf('.'))
            {
                return false;
            }
            else
            {
                return (IsSimpleIntergrate(s.Substring(0, id), true, true) && IsSimpleIntergrate(s.Substring(id + 1), false, false)) ||
                    (IsSimpleIntergrate(s.Substring(0, id), true, false) && IsSimpleIntergrate(s.Substring(id + 1), false, true));
            }
        }
        public bool IsSimpleIntergrate(string s, bool signable, bool emptyable)
        {
            if (string.IsNullOrEmpty(s))
                return emptyable;

            if (signable)
            {
                if (s[0] == '-' || s[0] == '+')
                    s = s.Substring(1);

                if (string.IsNullOrEmpty(s))
                    return emptyable;
            }

            foreach (var c in s)
            {
                if (c >= '0' && c <= '9')
                    continue;
                else
                    return false;
            }
            return true;
        }

    }
}
