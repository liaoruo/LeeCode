using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0013.RomantoInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.RomanToInt(solution.intToRoman(1)));
            System.Console.WriteLine(solution.RomanToInt(solution.intToRoman(449)));
            System.Console.WriteLine(solution.RomanToInt(solution.intToRoman(2014)));
            System.Console.WriteLine(solution.RomanToInt(solution.intToRoman(3999)));
            System.Console.WriteLine(solution.RomanToInt(solution.intToRoman(555)));


        }
    }

    public class Solution
    {
        public string intToRoman(int num)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>() { 
                { 1, "I" }, {4,"IV"}, { 5, "V" }, {9,"IX"}, 
                { 10, "X" },{40,"XL"},{ 50, "L" }, {90,"XC"},
                { 100, "C" },{400,"CD"}, { 500, "D" },{900,"CM"} ,{ 1000, "M" } 
            };
            List<int> list = new List<int>() { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            StringBuilder sb = new StringBuilder();
            foreach (var e in list)
            {
                var m = num / e;
                num %= e;
                for (var i = 0; i < m; i++)
                {
                    sb.Append(dic[e]);
                }

            }
            return sb.ToString();
        }

        public int RomanToInt(string s)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>() { 
                { "I",1 }, {"IV",4}, { "V",5 }, {"IX",9}, 
                { "X",10 },{"XL",40},{ "L",50 }, {"XC",90},
                { "C",100 },{"CD",400}, {"D",500 },{"CM",900} ,{"M",1000}
            };
            List<string> list = new List<string>() { "M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"};
            int sum = 0;
            foreach (var e in list)
            {
                var cnt = 0;
                while (s.StartsWith(e))
                {
                    cnt++;
                    s = s.Substring(e.Length);
                }
                sum += cnt * dic[e];

            }
            return sum;
        }
    }
}
