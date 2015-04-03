using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0006.ZigZagConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            System.Console.WriteLine(solution.Convert("PAYPALISHIRING", 4));
        }
    }
    public class Solution
    {
        public string Convert(String s, int nRows)
        {
            if (nRows == 1)
            {
                return s;
            }
            var len = s.Length;
            var sb = new StringBuilder();
            for (int i = 0; i < nRows; i++)
            {
                var j = 0;
                var k = 0;
                while (true)
                {
                    if (i == 0)
                    {
                        k = (2 * nRows - 2) * j;
                    }
                    else if (i == nRows - 1)
                    {
                        k = (2 * nRows - 2) * j + nRows - 1;
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            k = (2 * nRows - 2) * (j / 2) + i;
                        }
                        else
                        {
                            k = (2 * nRows - 2) * (j / 2 + 1) - i;
                        }
                    }
                    if (k < len)
                    {
                        sb.Append(s[k]);
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }

            }
            return sb.ToString();
        }
    }
}
