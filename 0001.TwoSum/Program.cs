using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0001.TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var ret = TwoSum(numbers, target);
            
            System.Console.WriteLine(ret == null ? "null" : ret.Item1 + "," + ret.Item2);
        }
        static public Tuple<int, int> TwoSum(int[] numbers, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int cnt = numbers.Count();
            for (int i = 0; i < cnt; i++)
            {
                int need = target - numbers[i];
                if (dic.ContainsKey(need))
                {
                    return new Tuple<int, int>(dic[need] + 1, i + 1);
                }
                else
                {
                    if (!dic.ContainsKey(numbers[i]))
                    {
                        dic.Add(numbers[i], i);
                    }
                }
            }
            return null;
        }
    }
}
