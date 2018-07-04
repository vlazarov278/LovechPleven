using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Algorithms
{
    class Program
    {
        private static bool[,] placement;
        private static bool[,] board;
        static void Main(string[] args)
        {
            placement = new bool[8, 8];
            board = new bool[8, 8];
            PutQueen(0);
        }

        static void PutQueen(int row)
        {
            if (row == 7)
            {
                for(int i = 0; i < 8; i++)
                {
                    for(int j = 0; j < 8; j++)
                    {
                        if(placement[i,j] == true) Console.Write('0');
                        else Console.Write('-');
                        if(j!=7) Console.Write(" | ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-------");
                for(int i = 0; i < 8; i++)
                {
                    for(int j = 0; j < 8; j++)
                    {
                        placement[i,j] = false;
                    }
                }
            }
            else
            {
                for (int j = 0; j < 8; j++)
                {
                    if (CanPlace(row, j) == true)
                    {
                        placement[row, j] = true;
                        MarkAttackedPositions(row, j);
                        PutQueen(row+1);
                        UnMarkAttackedPositions(row, j);
                    }
                }
            }
        }

        static void MarkAttackedPositions(int row, int col)
        {
            for(int i = 0; i < 8; i++)
            {
                board[row, i] = false;
                board[i, col] = false;
            }
        }

        static void UnMarkAttackedPositions(int row, int col)
        {
            for(int i = 0; i < 8; i++)
            {
                board[row, i] = true;
                board[i, col] = true;
            }
        }

        static bool CanPlace(int row, int col)
        {
            for (int i = 0; i < 8; i++)
            {
                if (board[row, i] == false)
                {
                    return true;
                }
                if (board[i, col] == false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
