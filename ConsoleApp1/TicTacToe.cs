using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TicTacToe
    {
        int xWins = 0;
        int oWins = 0;
        int turnCount = 0;
        int[] board = { 0, 0, 0, 0, 0, 0, 0, 0, 0, };
        Dictionary<int, string> xoMap = new Dictionary<int, string>() { { 0, "_" },{ 1, "X" },{ 2, "O" } };

        public TicTacToe()
        {
            newTurn(true);
        }
        void newTurn(bool xTurn)
        {
            int row;
            int col;
            int coord;
            consoleDisplayBoard();
            if (turnCount == 9)
            {
                Console.WriteLine("Draw!!!");
                newGame();
                return;
            }
            if (xTurn)
            {
                Console.WriteLine("X turn");
                Console.WriteLine("Enter row (1 through 3): ");
                row = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Enter column (1 through 3): ");
                col = Int32.Parse(Console.ReadLine()) - 1;

                coord = 3 * row + col;
                if (row > 2 || row < 0 || col > 2 || col < 0)
                {
                    Console.WriteLine("Invalid coordinates!");
                    newTurn(true);
                }
                else if (board[coord] != 0)
                {
                    Console.WriteLine("position taken!");
                    newTurn(true);
                }
                else
                {
                    board[coord] = 1;
                    if (winCheck())
                    {
                        consoleDisplayBoard();
                        Console.WriteLine("X wins!!!");
                        xWins += 1;
                        newGame();
                        return;
                    }
                    turnCount += 1;
                    newTurn(false);
                }
                
            } else
            {
                Console.WriteLine("O turn");
                Console.WriteLine("Enter row (1 through 3): ");
                row = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Enter column (1 through 3): ");
                col = Int32.Parse(Console.ReadLine()) - 1;

                coord = 3 * row + col;
                if (row > 2 || row < 0 || col > 2 || col < 0)
                {
                    Console.WriteLine("Invalid coordinates!");
                    newTurn(false);
                }
                else if (board[coord] != 0)
                {
                    Console.WriteLine("position taken!");
                    newTurn(false);
                }
                else
                {
                    board[coord] = 2;
                    if (winCheck())
                    {
                        consoleDisplayBoard();
                        Console.WriteLine("O wins!!!");
                        oWins += 1;
                        newGame();
                        return;
                    }
                    turnCount += 1;
                    newTurn(true);
                }
            }
        }
        bool winCheck()
        {
            // horizontals
            if (board[0] != 0 && board[0] == board[1] && board[1] == board[2])
            {
                return true;
            }
            else if (board[3] != 0 && board[3] == board[4] && board[4] == board[5])
            {
                return true;
            }
            else if (board[6] != 0 && board[6] == board[7] && board[7] == board[8])
            {
                return true;
            }
            // verticals
            if (board[0] != 0 && board[0] == board[3] && board[3] == board[6])
            {
                return true;
            }
            else if (board[1] != 0 && board[1] == board[4] && board[4] == board[7])
            {
                return true;
            }
            else if (board[2] != 0 && board[2] == board[5] && board[5] == board[8])
            {
                return true;
            }
            // diagonals
            if (board[0] != 0 && board[0] == board[4] && board[4] == board[8])
            {
                return true;
            }
            else if (board[3] != 0 && board[3] == board[4] && board[4] == board[6])
            {
                return true;
            }
            return false;
        }

        void consoleDisplayBoard()
        {
            string[] xandos = new string[9];
            for (int i = 0; i < 9; i++)
            {
                xandos[i] = xoMap[board[i]];
            }
            Console.Write($"{xandos[0]}|{xandos[1]}|{xandos[2]}\n{xandos[3]}|{xandos[4]}|{xandos[5]}\n{xandos[6]}|{xandos[7]}|{xandos[8]}\n");
        }
        void newGame()
        {
            Console.WriteLine($"X wins: {xWins}; O wins: {oWins}");
            Console.WriteLine("Press Enter to start a new Game");
            Console.ReadLine();
            for (int i = 0; i < 9; i++)
            {
                board[i] = 0;
            }
            turnCount = 0;
            newTurn(true);
            return;
        }
    }
}
