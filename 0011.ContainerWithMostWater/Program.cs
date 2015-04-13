using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0011.ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            List<int> list = new List<int>() { 1,1};
            System.Console.WriteLine(solution.MaxArea(list));
        }
    }
    public class Solution
    {
        public int MaxArea(IList<int> height)
        {
            List<int> line = new List<int>(height);

            var i = 0;
            var j = line.Count - 1;
            var max = int.MinValue;

            while (i < j)
            {
                var a = Math.Min(line[i], line[j]) * Math.Abs(j - i);
                if (a > max)
                    max = a;

                if (line[i] < line[j])
                {
                    var k = 0;
                    for (k = i + 1; k <= j; k++)
                    {
                        if (line[k] > line[i])
                            break;
                    }
                    i = k;
                }
                else
                {
                    var k = 0;
                    for (k = j - 1; k >= i; k--)
                    {
                        if (line[k] > line[j])
                            break;
                    }
                    j = k;
                }
                
            }
          
            return max;
        }
    }
}
