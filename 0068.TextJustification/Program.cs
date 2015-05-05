using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0068.TextJustification
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ret = solution.FullJustify(new List<string>() { "This", "is", "an", "example", "of", "text", "a.","b" }, 16);
            foreach (var line in ret)
            {
                System.Console.WriteLine(line);
            }

        }
    }
    public class Solution
    {
        public string JustifyOneLine(IList<string> words, int L, bool justified)
        {
            var ret = new StringBuilder();
            var cnt = words.Count;
            var sumWordLen = 0;
            if (justified)
            {

                foreach (var word in words)
                {
                    sumWordLen += word.Length;
                }

                if (cnt == 1)
                {
                    ret = ret.Append(words[0]);
                    for (var i = 0; i < L - words[0].Length; i++)
                        ret.Append(' ');
                    return ret.ToString();
                }

                var spaceMinLen = (L - sumWordLen) / (cnt - 1);
                var spaceMaxLen = spaceMinLen + 1;
                var maxCnt = (L - sumWordLen) - spaceMinLen * (cnt - 1);
                for (var i = 0; i < cnt; i++)
                {
                    ret.Append(words[i]);
                    if (i < maxCnt)
                    {
                        for (var j = 0; j < spaceMaxLen; j++)
                            ret.Append(' ');
                    }
                    else if (i < cnt - 1)
                    {
                        for (var j = 0; j < spaceMinLen; j++)
                            ret.Append(' ');
                    }
                }
            }
            else
            {
                for (var i = 0; i < cnt - 1; i++)
                {
                    ret.Append(words[i]);
                    ret.Append(' ');
                    sumWordLen += words[i].Length + 1;
                }
                ret.Append(words[cnt - 1]);
                sumWordLen += words[cnt - 1].Length;
                for (var j = sumWordLen; j < L; j++)
                {
                    ret.Append(' ');
                }
            }
            return ret.ToString();
        }
        public IList<string> FullJustify(IList<string> words, int L)
        {
            var ret = new List<string>();
            var wordsInLine = new List<string>();
            var sumCurrentLen = 0;
            foreach (var word in words)
            {
                if (sumCurrentLen == 0)
                {
                    if (word.Length <= L)
                    {
                        wordsInLine.Add(word);
                        sumCurrentLen = word.Length;
                    }
                    else
                    {
                        var start = 0;
                        for (; start + L < word.Length; start += L)
                        {
                            ret.Add(word.Substring(start, L));
                        }
                        wordsInLine.Add(word.Substring(start));
                        sumCurrentLen = word.Length - start;
                    }
                    continue;
                }

                if (sumCurrentLen + word.Length + 1 <= L)
                {
                    wordsInLine.Add(word);
                    sumCurrentLen += word.Length + 1;
                }
                else
                {
                    ret.Add(JustifyOneLine(wordsInLine, L, true));
                    wordsInLine.Clear();
                    sumCurrentLen = 0;

                    if (word.Length <= L)
                    {
                        wordsInLine.Add(word);
                        sumCurrentLen = word.Length;
                    }
                    else
                    {
                        var start = 0;
                        for (; start + L < word.Length; start += L)
                        {
                            ret.Add(word.Substring(start, L));
                        }
                        wordsInLine.Add(word.Substring(start));
                        sumCurrentLen = word.Length - start;
                    }
                }
            }
            if (wordsInLine.Count != 0)
            {
                ret.Add(JustifyOneLine(wordsInLine, L, false));
            }
            return ret;

        }
    }
}
