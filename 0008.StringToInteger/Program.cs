using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0008.StringToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.Atoi("-0123"));
            System.Console.WriteLine(solution.Atoi("++0123"));
            System.Console.WriteLine(solution.Atoi("+3AC"));
            System.Console.WriteLine(solution.Atoi("-2147483647"));
            System.Console.WriteLine(solution.Atoi("-2147483648"));
            System.Console.WriteLine(solution.Atoi("-2147483649"));
            System.Console.WriteLine(solution.Atoi("2147483646"));
            System.Console.WriteLine(solution.Atoi("2147483647"));
            System.Console.WriteLine(solution.Atoi("2147483648"));
            System.Console.WriteLine(solution.Atoi("21474836482147483648"));
            System.Console.WriteLine(solution.Atoi("-21474836482147483648"));

        }
    }
    public class Solution
    {
        public int Atoi(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            str = str.Trim();
            var flag = false;
            var len = str.Length;
            var start = true;
            long resule = 0;
            for (int i = 0; i < len; i++)
            {
                if (start)
                {
                    start = false;
                    if (str[i] == '-')
                    {
                        flag = true;
                        continue;
                    }
                    else if (str[i] == '+')
                    {
                        continue;
                    }
                }

                if ('0' <= str[i] && str[i] <= '9')
                {
                    resule *= 10;
                    resule += str[i] - '0';

                    //check each time incase it overflow the LONG
                    long tmp = flag ? resule * -1 : resule;
                    if (tmp > int.MaxValue)
                    {
                        return int.MaxValue;
                    }
                    else if (tmp < int.MinValue)
                    {
                        return int.MinValue;
                    }
                }
                else 
                {
                    break;
                }
            }
            //check each time incase it overflow the LONG
            resule = flag ? resule * -1 : resule;
            if (resule > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (resule < int.MinValue)
            {
                return int.MinValue;
            }
            else
            {
                return (int)resule;
            }
        }
    }
}
