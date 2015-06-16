using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _0030.SubstringwithConcatenationofAllWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            //var s = "lingmindraboofooowingdingbarrwingmonkeypoundcake";
            //var f = new string[] { "fooo","barr","wing","ding","wing" };
            //var s = "a";
            //var f = new string[] { "a" };

            var s = "abababab";
            var f = new string[] { "a", "b", "a" };
            var ret = solution.FindSubstring(s, f);
            foreach (var e in ret)
            {
                System.Console.WriteLine(e + " " + s.Substring(e, f.Count() * f[0].Length));
            }
        }
    }
    public class Solution
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            if (words == null || words.Count() == 0 || string.IsNullOrEmpty(words[0]))
            {
                return null;
            }

            var cnt = words.Count();
            var len = words[0].Length;
            var dic = new Dictionary<string, int>();
            var dup = new Dictionary<int, int>();
            for (var i = 0; i < cnt; i++)
            {
                if (!dic.ContainsKey(words[i]))
                {
                    dic.Add(words[i], i);
                    dup.Add(i, 1);
                }
                else
                {
                    dup[dic[words[i]]]++;
                }
                
            }

            var indexMap = new List<int>();
            for (var i = 0; i <= s.Length - len; i++)
            {
                var subStr = s.Substring(i, len);
                var index = -1;
                if (dic.TryGetValue(subStr, out index))
                {
                    indexMap.Add(index);
                }
                else
                {
                    indexMap.Add(-1);
                }
            }

            var ret = new List<int>();
            for (var i = 0; i < len; i++)
            {
                Queue<int> queue = new Queue<int>();
                //HashSet<int> hash = new HashSet<int>();
                Dictionary<int, int> dupCheck = new Dictionary<int, int>();

                var j = i;
                while (j <= s.Length - len)
                {
                    if (indexMap[j] == -1)
                    {
                        queue.Clear();
                        dupCheck.Clear();
                    }
                    else
                    {
                        if (!dupCheck.ContainsKey(indexMap[j]))
                        {
                            dupCheck.Add(indexMap[j], 1);
                            queue.Enqueue(indexMap[j]);
                        }
                        else if (dupCheck[indexMap[j]] < dup[indexMap[j]])
                        {
                            dupCheck[indexMap[j]]++;
                            queue.Enqueue(indexMap[j]);
                        }
                        else
                        {
                            dupCheck[indexMap[j]]++;
                            queue.Enqueue(indexMap[j]);
                            while (true)
                            {
                                var drop = queue.Dequeue();
                                dupCheck[drop]--;
                                if (drop == indexMap[j])
                                {
                                    break;
                                }
                            }
                        }

                        //find
                        if (queue.Count == cnt)
                        {
                            var drop = queue.Dequeue();
                            dupCheck[drop]--;
                            ret.Add(j - (cnt - 1) * len);
                        }
                    }
                    j += len;
                }


            }

            return ret;

        }
    }
}
