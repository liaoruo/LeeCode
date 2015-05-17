using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0020.ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution2 solution = new Solution2();
            System.Console.WriteLine(solution.IsValid("()"));
            System.Console.WriteLine(solution.IsValid("(){}[]"));
            System.Console.WriteLine(solution.IsValid("((([)]))"));
            System.Console.WriteLine(solution.IsValid("{([[({}{}())]{}])}"));
            System.Console.WriteLine(solution.IsValid("()[]"));
        }
    }

    public class Solution2
    {
        static public Dictionary<char, char> closeOpenMapping = new Dictionary<char, char>() 
        { { ')', '(' }, { ']', '[' }, { '}', '{' } };
        static public HashSet<char> opens = new HashSet<char>(closeOpenMapping.Values);
        static public HashSet<char> closes = new HashSet<char>(closeOpenMapping.Keys);

        public bool IsValid(string s)
        {
            Dictionary<char, Stack<int>> openStacks = new Dictionary<char, Stack<int>>();
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (opens.Contains(c))
                {
                    if (!openStacks.ContainsKey(c))
                    {
                        openStacks.Add(c, new Stack<int>());
                    }
                    openStacks[c].Push(i);
                }
                else if (closes.Contains(c))
                {
                    var open = closeOpenMapping[c];
                    if (!openStacks.ContainsKey(open) || openStacks[open].Count == 0)
                    {
                        return false;
                    }
                    var openIndex = openStacks[open].Peek();
                    foreach (var kvp in openStacks)
                    {
                        if (kvp.Value.Count > 0 && kvp.Value.Peek() > openIndex)
                        {
                            return false;
                        }
                    }
                    openStacks[open].Pop();
                }
                else
                {
                    throw new Exception("Error char in string: " + c);
                }
            }
            foreach (var kvp in openStacks)
            {
                if (kvp.Value.Count != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Solution
    {
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            var open1 = new Stack<int>();
            var open2 = new Stack<int>();
            var open3 = new Stack<int>();
            var openHash = new HashSet<int>();
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == '(')
                {
                    open1.Push(i);
                }
                else if (c == ')')
                {
                    if (open1.Count == 0)
                        return false;
                    var j = open1.Pop();

                    if (open2.Count != 0)
                    {
                        var k = open2.Peek();
                        if (k > j)
                            return false;
                    }
                    if (open3.Count != 0)
                    {
                        var k = open3.Peek();
                        if (k > j)
                            return false;
                    }
                }
                else if (c == '[')
                {
                    open2.Push(i);
                }
                else if (c == ']')
                {
                    if (open2.Count == 0)
                        return false;
                    var j = open2.Pop();

                    if (open1.Count != 0)
                    {
                        var k = open1.Peek();
                        if (k > j)
                            return false;
                    }
                    if (open3.Count != 0)
                    {
                        var k = open3.Peek();
                        if (k > j)
                            return false;
                    }
                }
                else if (c == '{')
                {
                    open3.Push(i);
                }
                else if (c == '}')
                {
                    if (open3.Count == 0)
                        return false;
                    var j = open3.Pop();

                    if (open2.Count != 0)
                    {
                        var k = open2.Peek();
                        if (k > j)
                            return false;
                    }
                    if (open1.Count != 0)
                    {
                        var k = open1.Peek();
                        if (k > j)
                            return false;
                    }
                }
                else
                {
                    throw new Exception("Error char in string: " + c);
                }
            }
            if (open1.Count != 0 || open2.Count != 0 || open3.Count != 0)
            {
                return false;
            }
            return true;
        }
    }
}
