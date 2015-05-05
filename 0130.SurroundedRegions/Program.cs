using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0130.SurroundedRegions
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[5, 4] { 
                { 'X', 'X', 'X', 'X' },
                { 'X', 'O', 'O', 'X' }, 
                { 'O', 'X', 'X', 'O' },
                { 'X', 'O', 'X', 'X' },
                { 'X', 'O', 'X', 'X' }
            };
            Solution s = new Solution();
            s.Solve(board);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    System.Console.Write(board[i,j]);
                }
                System.Console.WriteLine();
            }
        }
    }

    public class Solution
    {
        public void Solve(char[,] board)
        {

            if (board == null||board.Length==0)
                return;
            HashSet<int> oo = new HashSet<int>();



            var n = board.GetLength(0);
            var m = board.GetLength(1);

            Queue<int> queue = new Queue<int>();

            //Up to Down
            for (var i = 0; i < m; i++)
            {
                if (board[0,i] == 'O')
                {
                    var p = 0 * m + i;
                    if (!oo.Contains(p))
                    {
                        oo.Add(p);
                        queue.Enqueue(p);
                    }
                }
            }
            //Down to Up  
            for (var i = 0; i < m; i++)
            {
                if (board[n - 1,i] == 'O')
                {
                    var p = (n - 1) * m + i;
                    if (!oo.Contains(p))
                    {
                        oo.Add(p);
                        queue.Enqueue(p);
                    }
                }
            }
            //Left to Right    
            for (var i = 0; i < n; i++)
            {
                if (board[i,0] == 'O')
                {
                    var p = i * m + 0;
                    if (!oo.Contains(p))
                    {
                        oo.Add(p);
                        queue.Enqueue(p);
                    }
                }
            }
            //Right to Left 
            for (var i = 0; i < n; i++)
            {
                if (board[i,m-1] == 'O')
                {
                    var p = i * m + m-1;
                    if (!oo.Contains(p))
                    {
                        oo.Add(p);
                        queue.Enqueue(p);
                    }
                }
            }
            while (queue.Count != 0)
            {
                var e = queue.Dequeue();

                var x1 = e / m + 1;
                var y1 = e % m;
                if (!(x1 < 0 || x1 >= n || y1 < 0 || y1 >= m))
                {
                    if (board[x1,y1] == 'O')
                    {
                        var p = x1 * m + y1;
                        if (!oo.Contains(p))
                        {
                            queue.Enqueue(p);
                            oo.Add(p);
                        }
                    }
                }
                var x2 = e / m - 1;
                var y2 = e % m;
                if (!(x2 < 0 || x2 >= n || y2 < 0 || y2 >= m))
                {
                    if (board[x2,y2] == 'O')
                    {
                        var p = x2 * m + y2;
                        if (!oo.Contains(p))
                        {
                            queue.Enqueue(p);
                            oo.Add(p);
                        }
                    }
                }
                var x3 = e / m;
                var y3 = e % m + 1;
                if (!(x3 < 0 || x3 >= n || y3 < 0 || y3 >= m))
                {
                    if (board[x3,y3] == 'O')
                    {
                        var p = x3 * m + y3;
                        if (!oo.Contains(p))
                        {
                            queue.Enqueue(p);
                            oo.Add(p);
                        }
                    }
                }
                var x4 = e / m;
                var y4 = e % m - 1;
                if (!(x4 < 0 || x4 >= n || y4 < 0 || y4 >= m))
                {
                    if (board[x4,y4] == 'O')
                    {
                        var p = x4 * m + y4;
                        if (!oo.Contains(p))
                        {
                            queue.Enqueue(p);
                            oo.Add(p);
                        }
                    }
                }
            }

            //Ret
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    board[i,j] = 'X';
                }
            }
            foreach (var e in oo)
            {
                var xe = e / m;
                var ye = e % m;
                board[xe,ye] = 'O';
            }

        }
    }
}
