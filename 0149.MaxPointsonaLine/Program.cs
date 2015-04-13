using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace _0149.MaxPointsonaLine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> list = new List<Point>();
            Solution solution = new Solution();
            System.Console.WriteLine(solution.MaxPoints(list));
            //[(84,250),(0,0),(1,0),(0,-70),(0,-70),(1,-1),(21,10),(42,90),(-42,-230)]
            list.Add(new Point(84, 250));
            list.Add(new Point(0, 0));
            list.Add(new Point(1, 0));
            list.Add(new Point(0, -70));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));
            list.Add(new Point(0, 0));

            
            System.Console.WriteLine(solution.MaxPoints(list));

        }
    }

    public class Solution
    {
        public int MaxPoints(IList<Point> points)
        {
            if (points == null)
                return 0;

            var n = points.Count;
            if (n <= 2)
                return n;

            var maxMax = -1;
            for (var i = 0; i < n; i++)
            {
                var dupliate = 0;

                //For y=ax+b
                Dictionary<double, int> dic = new Dictionary<double, int>();
                //For x=k
                int s = 0;

                for (var j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var dx = points[j].X - points[i].X;
                    var dy = points[j].Y - points[i].Y;
                    if (dx == 0 && dy == 0)
                    {
                        dupliate++;
                        continue;
                    }

                    if (dx == 0)
                    {
                        s++;
                    }
                    else
                    {
                        var a=dy*1.0/dx;
                        if (dic.ContainsKey(a))
                        {
                            dic[a]++;
                        }
                        else
                        {
                            dic.Add(a, 1);
                        }
                    }
                }

                var max = s;
                foreach (var kvp in dic)
                {
                    if (kvp.Value > max)
                    {
                        max = kvp.Value;
                    }
                }

                max += dupliate + 1;
                if (max > maxMax)
                {
                    maxMax = max;
                }
            }
            return maxMax;

        }
    }
}
