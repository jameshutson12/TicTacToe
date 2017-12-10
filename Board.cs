using System;
namespace TicTacToe
{
    public class Board
    {
        private string[,] positions = new string[3, 3];

        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                // Initialise the board.
                for (int j = 0; j < 2; j++)
                {
                    positions[i, j] = " ";
                }
            }
        }

        /// <summary>
        /// Prints the board.
        /// </summary>
        public void PrintBoard()
        {
            // TODO: Need to add column, row numbers to board.

            // This will be the down.
            for (int i = 0; i < 3; i++)
            {
                // This will be the across.
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($" {positions[i, j]} |");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("-----------");
            }
        }


        /// <summary>
        /// Perform a move on the board.
        /// </summary>
        /// <param name="move">Move the player has made.</param>
        /// <param name="turn">True if turn is player 'X', otherwise False for player 'O'</param>
        public void MakeMove(string move, bool turn)
        {
            // Split move into it's two parts (Column, Row) i.e. '0', '1'.
            int column = Convert.ToInt32(move.Substring(0, 1));
            int row = Convert.ToInt32(move.Substring(1, 1));

            positions[column, row] = (turn) ? "X" : "O";
        }


        public void CheckWinner()
        {
            // TODO: Go through all permutations to see if we have a winner.
        }
    }
}
