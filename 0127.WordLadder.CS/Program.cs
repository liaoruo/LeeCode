using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0127.WordLadder.CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            HashSet<string> wordList = new HashSet<string>() { "hot", "dot", "dog", "lot", "log" };
            System.Console.WriteLine(solution.LadderLength("hit", "abc", wordList));
        }
    }
    public class Solution
    {
        public int LadderLength(string beginWord, string endWord, ISet<string> wordDict)
        {
            HashSet<string> wordList = new HashSet<string>(wordDict);
            wordList.Add(beginWord);
            wordList.Add(endWord);

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            queue.Enqueue(string.Empty);
            wordList.Remove(beginWord);
            var layerCnt = 1;
            List<string> layerList = new List<string>();
            while (queue.Count != 0)
            {
                var pre = queue.Dequeue();
                if (pre == endWord)
                {
                    return layerCnt;
                }
                if (string.IsNullOrEmpty(pre))
                {
                    if (layerList.Count == 0)
                        return 0;
                    else
                    {
                        foreach (var e in layerList)
                        {
                            queue.Enqueue(e);
                        }
                        layerList.Clear();
                        queue.Enqueue(string.Empty);

                    }
                    layerCnt++;
                }
                else
                {
                    var candidate = GetConnectCandidate(pre);
                    foreach (var e in candidate)
                    {
                        if (wordList.Contains(e))
                        {
                            layerList.Add(e);
                        }
                    }
                    foreach (var e in layerList)
                    {
                        wordList.Remove(e);
                    }
                }

            }
            return 0;
        }
        public List<string> GetConnectCandidate(string a)
        {
            List<string> list = new List<string>();
            var charArr = a.ToCharArray();
            for (var i = 0; i < a.Length; i++)
            {
                var check = charArr[i];
                for (var c = 'a'; c <= 'z'; c++)
                {
                    if (c != check)
                    {
                        charArr[i] = c;
                        list.Add(new string(charArr));
                    }
                }
                charArr[i] = check;
            }
            return list;
        }
        public bool IsConnect(string a, string b)
        {
            if (a == null || a.Length == 0 || a.Length != b.Length || a == b)
            {
                return false;
            }
            var len = a.Length;
            var diff = 0;
            for (var i = 0; i < len; i++)
            {
                if (a[i] != b[i])
                {
                    diff++;
                    if (diff > 1)
                        return false;
                }
            }
            return true;
        }
    }
}
