using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0012.IntegertoRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.intToRoman(1));
            System.Console.WriteLine(solution.intToRoman(449));
            System.Console.WriteLine(solution.intToRoman(2014));
            System.Console.WriteLine(solution.intToRoman(3999));
            System.Console.WriteLine(solution.intToRoman(555));


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
    }
}
