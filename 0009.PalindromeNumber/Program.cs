using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0009.PalindromeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.IsPalindrome(0));
            System.Console.WriteLine(solution.IsPalindrome(-101));
            System.Console.WriteLine(solution.IsPalindrome(101));
            System.Console.WriteLine(solution.IsPalindrome(2147483647));
            

        }
    }
    public class Solution
    {
        public Boolean IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            long y = 0;
            int tmpx = x;
            while (tmpx != 0)
            {
                y *= 10;
                y += tmpx % 10;
                tmpx /= 10;
            }
            if (y > int.MaxValue)
                return false;
            else
                return ((int)y) == x;
            
        }
    }
}
