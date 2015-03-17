using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0007.ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.Reverse(-1230));
        }
    }
    public class Solution
    {
        public int Reverse(int x)
        {
            long y = 0;
            bool flag = x < 0 ? true : false;
            x = x < 0 ? x * -1 : x;
            while (x != 0)
            {
                y *= 10;
                y += x % 10;
                x /= 10;
            }
            if (flag)
                y *= -1;

            if (y < int.MinValue || y > int.MaxValue)
            {
                y = 0;
            }
            return (int)y;
        }
    }
}
