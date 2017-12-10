using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private string[,] positions = new string[3, 3];
        private List<int> validMoves = new List<int>();

        public Board()
        {
            // Initialise all board positions to " ".
            for (int i = 0; i < 3; i++)
            {
                // Initialise the board.
                for (int j = 0; j < 3; j++)
                {
                    positions[i, j] = " ";
                }
            }

            // Initialise out valid moves list.
            validMoves.Add(0);
            validMoves.Add(1);
            validMoves.Add(2);
        }

        /// <summary>
        /// Prints the board to the console.
        /// </summary>
        public void PrintBoard()
        {
            // This represent the columns.
            for (int i = 0; i < 3; i++)
            {
                // This represent the rows.
                for (int j = 0; j < 3; j++)
                {
                    // Logic around pretty printing the board.
                    if (i == 0 && j== 0) Console.WriteLine($"  0   1   2");
                    if (j == 0) Console.Write(i);
                    if (j == 2) 
                    {
                        Console.Write($" {positions[i, j]}");   
                    }
                    else
                    {
                        Console.Write($" {positions[i, j]} |");   
                    }
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("  ----------");
            }
        }


        /// <summary>
        /// Perform a move on the board.
        /// </summary>
        /// <param name="MoveRow">The player's row to insery symbol onto.</param>
        /// <param name="MoveColumn">The player's column to insery symbol onto.</param>
        /// <param name="CurrentPlayer">Current player's symbol.</param>
        public void MakeMove(int MoveRow, int MoveColumn, string CurrentPlayer)
        {
            positions[MoveColumn, MoveRow] = (CurrentPlayer == "X") ? "X" : "O";
        }


        /// <summary>
        /// Checks if we have a winner.
        /// </summary>
        /// <returns>True, if we have a winner, False otherwise.</returns>
        /// <param name="CurrentPlayer">Current player symbol</param>
        public bool CheckWinner(ref string CurrentPlayer)
        {
            bool retVal = false;

            // Loop through all winning combinations to check for a winner.
            // First loop through rows for a winner.
            for (int i = 0; i < 3; i++)
            {
                if (positions[i, 0] == CurrentPlayer && positions[i, 1] == CurrentPlayer && positions[i, 2] == CurrentPlayer)
                {
                    retVal = true;
                }
            }

            // Next loop through columns for a winner.
            for (int i = 0; i < 3; i++)
            {
                if (positions[0, i] == CurrentPlayer && positions[1, i] == CurrentPlayer && positions[2, i] == CurrentPlayer)
                {
                    retVal = true;
                }
            }

            // Finally check diagonals for a winner.
            if (positions[0, 0] == CurrentPlayer && positions[1, 1] == CurrentPlayer && positions[2, 2] == CurrentPlayer)
            {
                retVal = true;
            }

            if (positions[0, 2] == CurrentPlayer && positions[1, 1] == CurrentPlayer && positions[2, 0] == CurrentPlayer)
            {
                retVal = true;
            }

            // Have we come across a winning combination so far.
            if (!retVal)
            {
                bool isTie = true;
                // No, let's check for a draw. Loop through game board looking for a empty tile.
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Is this an empty tile.
                        if (positions[i, j] == " ")
                        {
                            // Yes, so we have not tied yet.
                            isTie = false;
                        }
                    }
                }
                if (isTie)
                {
                    CurrentPlayer = null;
                    retVal = true;
                }
            }

            return retVal;
        }


        /// <summary>
        /// Is the player's move valid on the current game board.
        /// </summary>
        /// <param name="MoveRow">The row for the move.</param>
        /// <param name="MoveColumn">The column for the move.</param>
        /// <returns>True is move is valid, otherwise False.</returns>
        public bool IsMoveValid(int MoveRow, int MoveColumn)
        {
            bool retVal = false;

            // Is the move within the valid moves list.
            if (validMoves.Contains(MoveRow) && validMoves.Contains(MoveColumn))
            {
                // Is the move onto an empty tile.
                if (positions[MoveColumn, MoveRow] == " ")
                {
                    retVal = true;
                }
            }

            return retVal;
        }

    }
}
