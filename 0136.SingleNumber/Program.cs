using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0136.SingleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.SingleNumber(new int[] { 1, 2, 100, 1, 100 }));
            System.Console.WriteLine(solution.SingleNumber(new int[] { 1, -2, -100, 1, -100 }));

        }
    }
    public class Solution
    {
        public int SingleNumber(int[] A)
        {
            int sum = 0;
            foreach (var a in A)
            {
                sum = sum ^ a;
            }
            return sum;
        }
    }
}
