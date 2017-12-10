using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // First we need to decide if we are playing the computer or human.
            Console.WriteLine("Do you want to play .vs the computer? Y/N");
            Board board = new Board();
            board.PrintBoard();

            // TOOD: Need to make the main game loop.

            Console.ReadLine();
        }
    }
}
