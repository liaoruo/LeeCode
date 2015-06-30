using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0037.SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            char[,] board = {
                            { '5', '3', '.', '.', '7', '.', '.', '.' ,'.'}, 
                            { '6', '.', '.', '1', '9', '5', '.', '.', '.' }, 
                            { '.', '9', '8', '.', '.', '.', '.', '6', '.' }, 
                            { '8', '.', '.', '.', '6', '.', '.', '.', '3' }, 
                            { '4', '.', '.', '8', '.', '3', '.', '.', '1' }, 
                            { '7', '.', '.', '.', '2', '.', '.', '.', '6' }, 
                            { '.', '6', '.', '.', '.', '.', '2', '8', '.' }, 
                            { '.', '.', '.', '4', '1', '9', '.', '.', '5' }, 
                            { '.', '.', '.', '.', '8', '.', '.', '7', '9' } };
             * */
            //["..9748...","7........",".2.1.9...","..7...24.",".64.1.59.",".98...3..","...8.3.2.","........6","...2759.."]
            char[,] board = {
                            { '.', '.', '9', '7', '4', '8', '.', '.' ,'.'}, 
                            { '7', '.', '.', '.', '.', '.', '.', '.' ,'.'},
                            { '.', '2', '.', '1', '.', '9', '.', '.' ,'.'},
                            { '.', '.', '7', '.', '.', '.', '2', '4' ,'.'},
                            { '.', '6', '4', '.', '1', '.', '5', '9' ,'.'},
                            { '.', '9', '8', '.', '.', '.', '3', '.' ,'.'},
                            { '.', '.', '.', '8', '.', '3', '.', '2' ,'.'},
                            { '.', '.', '.', '.', '.', '.', '.', '.' ,'6'},
                            { '.', '.', '.', '2', '7', '5', '9', '.' ,'.'} };
            Solution solution = new Solution();
            solution.SolveSudoku(board);
        }
    }
    public class Solution
    {
        public HashSet<char>[,] find;
        public void SolveSudoku(char[,] board)
        {
            find = new HashSet<char>[9, 9];
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (board[i, j] == '.')
                    {
                        find[i, j] = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    }
                    else
                    {
                        find[i, j] = new HashSet<char>();
                    }
                }
            }

            //Update the candidate limitation
            while (true)
            {
                var doUpdate = false;
                for (var i = 0; i < 9; i++)
                {
                    for (var j = 0; j < 9; j++)
                    {
                        doUpdate |= UpdateLimitation(board, find, i, j);
                        if (find[i, j].Count == 1)
                        {
                            //Find one 
                            var c=find[i, j].ToList()[0];
                            //System.Console.WriteLine(i + "," + j + ":\t" + c);
                            board[i, j] = c;
                            find[i, j].Remove(c);
                        }
                    }
                }
                if (!doUpdate)
                {
                    break;
                }
            }

            //Loop
            SolveSudokuLoop(board);

        }
        public bool SolveSudokuLoop(char[,] board)
        {
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    //Only search for the 1st '.'
                    if (board[i, j] == '.')
                    {
                        foreach (var c in find[i, j])
                        {
                            board[i, j] = c;
                            if (IsValidSudokuPoint(board, i, j) && SolveSudokuLoop(board))
                            {
                                return true;
                            }
                        }
                        board[i, j] = '.';
                        return false;
                    }
                }
            }
            return true;
        }
        public bool UpdateLimitation(char[,] board, HashSet<char>[,] find, int i, int j)
        {
            if (find[i, j].Count == 0)
            {
                return false;
            }

            var doUpdate = false;
            var x = i / 3 * 3;
            var y = j / 3 * 3;
            for (var e = 0; e < 9; e++)
            {
                if (board[i, e] != '.')
                {
                    var ret=find[i, j].Remove(board[i, e]);
                    doUpdate |= ret;
                }

                if (board[e, j] != '.')
                {
                    var ret = find[i, j].Remove(board[e, j]);
                    doUpdate |= ret;
                }

                if (board[x + e / 3, y + e % 3] != '.')
                {
                    var ret = find[i, j].Remove(board[x + e / 3, y + e % 3]);
                    doUpdate |= ret;
                }
            }

            return doUpdate;
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
