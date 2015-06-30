using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0036.ValidSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = { { '.', '2', '3', '4', '5', '6', '7', '8' ,'9'}, 
                            { '4', '.', '.', '.', '.', '.', '.', '.', '.' }, 
                            { '5', '.', '2', '.', '.', '.', '.', '.', '.' }, 
                            { '2', '.', '.', '.', '.', '.', '.', '.', '.' }, 
                            { '3', '.', '.', '.', '.', '.', '.', '.', '.' }, 
                            { '6', '.', '.', '.', '.', '.', '.', '.', '.' }, 
                            { '7', '.', '.', '.', '.', '.', '.', '.', '.' }, 
                            { '8', '.', '.', '.', '.', '.', '.', '.', '.' }, 
                            { '9', '.', '.', '.', '.', '.', '.', '.', '.' } };
            Solution solution = new Solution();
            System.Console.WriteLine(solution.IsValidSudoku(board));
        }
    }
    public class Solution
    {
        public bool IsValidSudoku(char[,] board)
        {
            if (board == null || board.GetUpperBound(0) - board.GetLowerBound(0) + 1 != 9 || board.GetUpperBound(1) - board.GetLowerBound(1) + 1 != 9)
            {
                return false;
            }

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (!IsValidSudokuPoint(board, i, j))
                    {
                        return false;
                    }
                }

            }

            return true;
        }
        public bool IsValidSudokuPoint(char[,] board, int i, int j)
        {
            if (board[i, j] == '.')
            {
                return true;
            }

            if (board[i, j] < '0' || board[i, j] > '9')
            {
                return false;
            }

            //Check Row
            for (var e = 0; e < 9; e++)
            {
                if (e != j && board[i, e] == board[i, j])
                {
                    return false;
                }
            }
            
            //Check Column
            for (var e = 0; e < 9; e++)
            {
                if (e != i && board[e, j] == board[i, j])
                {
                    return false;
                }
            }


            //Check Rec
            var x = i / 3 * 3;
            var y = j / 3 * 3;
            for (var e = 0; e < 9; e++)
            {
                var e1 = x + e / 3;
                var e2 = y + e % 3;
                if ((e1 != i || e2 != j) && board[e1, e2] == board[i, j])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
