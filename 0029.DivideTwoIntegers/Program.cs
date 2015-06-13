using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0029.DivideTwoIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.Divide(-8, 0));
            System.Console.WriteLine(solution.Divide(8, 0));
            System.Console.WriteLine(solution.Divide(8, 5));
            System.Console.WriteLine(solution.Divide(8, -5));
            System.Console.WriteLine(solution.Divide(-8, 5));
            System.Console.WriteLine(solution.Divide(-8, -5));
            System.Console.WriteLine(solution.Divide(4, 5));
            System.Console.WriteLine(solution.Divide(4, -5));
            System.Console.WriteLine(solution.Divide(-4, 5));
            System.Console.WriteLine(solution.Divide(-4, -5));
            System.Console.WriteLine(solution.Divide(8, 1));
            System.Console.WriteLine(solution.Divide(8, -1));
            System.Console.WriteLine(solution.Divide(-8, 1));
            System.Console.WriteLine(solution.Divide(-8, -1));
            System.Console.WriteLine(solution.Divide(int.MinValue, -1));
            System.Console.WriteLine(solution.Divide(int.MinValue, 1));
            System.Console.WriteLine(solution.Divide(int.MinValue, int.MinValue));
            System.Console.WriteLine(solution.Divide(int.MinValue, int.MaxValue));
            System.Console.WriteLine(solution.Divide(int.MaxValue, int.MaxValue));
            System.Console.WriteLine(solution.Divide(int.MaxValue, int.MinValue));
        }
    }
    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0 || (dividend == int.MinValue && divisor == -1))
            {
                return int.MaxValue;
            }

            var flag = true;
            if (divisor < 0)
            {
                if (divisor == int.MinValue)
                {
                    if (dividend == int.MinValue)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                divisor = 0 - divisor;
                flag = !flag;
            }

            var result = 0;
            if (dividend < 0)
            {
                if (dividend == int.MinValue)
                {
                    result = 1;
                    dividend += divisor;
                }
                dividend = 0 - dividend;
                flag = !flag;
            }

            if (dividend < divisor)
            {
                return flag ? result : 0 - result;
            }

            var tempDivisor = divisor;
            var tempResult = 1;
            while (dividend - tempDivisor >= tempDivisor)
            {
                tempDivisor <<= 1;
                tempResult <<= 1;
            }
           
            while (dividend >= divisor)
            {
                if (dividend >= tempDivisor)
                {
                    result += tempResult;
                    dividend -= tempDivisor;
                }
                tempResult >>= 1;
                tempDivisor >>= 1;
            }

            return flag ? result : 0 - result;
        }
    }
}
