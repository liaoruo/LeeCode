using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0043.MultiplyStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.Multiply("12345123456723456723456745673456", "12345123456723456723456745673456"));
            
        }
    }
    public class Solution
    {
        public string Multiply(string num1, string num2)
        {
            dic.Clear();
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }

            if (num1.Length < num2.Length)
            {
                var num3 = num1;
                num1 = num2;
                num2 = num3;
            }

            var result = "0";
            var n = 0;
            foreach (var c in num2.Reverse())
            {
                if (c != '0')
                {
                    var one = Multiply(num1, c, n);
                    result = Add(result, one);
                }
                n++;                
            }
            return result;
        }

        public Dictionary<char, string> dic = new Dictionary<char, string>();
        public string Add(string num1, string num2)
        {
            num1 = ReverseString(num1);
            num2 = ReverseString(num2);
            var add = 0;
            var sb = new StringBuilder();
            var i = 0;
            while (num1.Length > i || num2.Length > i)
            {
                var i1 = num1.Length <= i ? 0 : int.Parse(num1[i].ToString());
                var i2 = num2.Length <= i ? 0 : int.Parse(num2[i].ToString());
                var result = i1 + i2 + add;
                sb.Append(result % 10);
                add = result / 10;
                i++;
            }

            if (add != 0)
            {
                sb.Append(add);
            }

            return ReverseString(sb.ToString());
        }
        public string ReverseString(string s)
        {
            var arr = s.ToArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public string Multiply(string num1, char c, int n)
        {
            var sb = new StringBuilder();
            if (!dic.ContainsKey(c))
            {
                var r = num1.Reverse();
                var add = 0;
                foreach (var rc in r)
                {
                    var i1 = int.Parse(rc.ToString());
                    var i2 = int.Parse(c.ToString());
                    var result = i1 * i2 + add;
                    sb.Append(result % 10);
                    add = result / 10;
                }
                if (add != 0)
                {
                    sb.Append(add);
                }

                dic.Add(c, ReverseString(sb.ToString())); 
            }

            sb.Clear();
            sb.Append(dic[c]);
            for (var i = 0; i < n; i++)
            {
                sb.Append('0');
            }
            return sb.ToString();
        }

    }
}
