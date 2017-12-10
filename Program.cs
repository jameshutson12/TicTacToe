using System;

namespace TicTacToe
{
    class Program
    {
        static Board board;
        static bool lastMoveSuccess = true;

        static void Main(string[] args)
        {
            // TODO: Make it possible to play against the computer.
            // First we need to decide if we are playing the computer or human.
            Console.WriteLine("Do you want to play .vs the computer? Y/N");
            board = new Board();
            string currentPlayer = "O";

            // Loop until we have a satisfactory answer.
            string response = Console.ReadLine();
            while (response.ToUpper() != "N")
            {
                response = Console.ReadLine();
            }

            Console.WriteLine("Enter Co-Ordindate in Row/Column");
            // Print the initial game board.
            board.PrintBoard();

            // Play main game loop until we have a winner or tie.
            while(!board.CheckWinner(ref currentPlayer))
            {
                // Was our last iteration a sucessful move.
                if (!lastMoveSuccess)
                {
                    Console.WriteLine($"Invalid move, try again player '{currentPlayer}'");
                }
                else
                {
                    currentPlayer = SetNextPlayer(currentPlayer);
                    Console.WriteLine($"Make your Move... Player '{currentPlayer}'");
                }

                // Get the move.
                string move = Console.ReadLine();
                int moveRow = -1;
                int moveColumn = -1;
                parseMove(move, ref moveRow, ref moveColumn);

                // Do we have a valid move entered.
                if (moveRow != -1 && moveColumn != -1)
                {
                    // Yes, let's make the move in the board.
                    board.MakeMove(moveRow, moveColumn, currentPlayer);
                    lastMoveSuccess = true;
                }
                else
                {
                    lastMoveSuccess = false;
                }

                // Print the board to show the last move.
                board.PrintBoard();
            }

            // Stop the program quitting when we have a winner.
            if (currentPlayer == null)
            {
                Console.WriteLine($"We have a TIE");
            }
            else
            {
                Console.WriteLine($"We have a winner! Player {currentPlayer} WINS!");    
            }

            Console.ReadLine();
        }


        /// <summary>
        /// Switches the current player
        /// </summary>
        /// <returns>The next player.</returns>
        /// <param name="CurrentPlayer">Current player.</param>
        private static string SetNextPlayer(string CurrentPlayer)
        {
            string retVal = "";
            if (CurrentPlayer == "X")
            {
                retVal = "O";
            }
            else
            {
                retVal = "X";
            }

            return retVal;
        }


        /// <summary>
        /// Parses the move.
        /// </summary>
        /// <param name="move">The player's move, non-parsed.</param>
        /// <param name="MoveRow">The player's row move, parsed</param>
        /// <param name="MoveColumn">Move column.</param>
        /// <remarks>Ref parameters as they are used in the calling method to determine a valid move has been entered.</remarks>
        public static void parseMove(string move, ref int MoveRow, ref int MoveColumn)
        {
            // Do we have two characters to represent co-ordinates.
            if (move.Length == 2)
            {
                // Split move into it's two parts (Column, Row) i.e. '0', '1'.
                MoveColumn = Convert.ToInt32(move.Substring(0, 1));
                MoveRow = Convert.ToInt32(move.Substring(1, 1));
                // Check whether the move is valid on the current game board.
                if (!board.IsMoveValid(MoveRow, MoveColumn))
                {
                    // No, so set ref values to signify failure.
                    MoveColumn = -1;
                    MoveRow = -1;
                }
            }
        }

    }
}
