using System;
using System.Text;
using TDD_Algorithms.Tests.TicTacToeTests;
using TDD_Algorithms.TicTacToe;

namespace TicTacToeGame
{
    class Program
    {
        private static Game g = new Game();

        static void Main(string[] args)
        {
            Console.WriteLine(GetPrintableState());

            while (g.GetWinner() == Winner.GameIsUnfinished)
            {
                int index = int.Parse(Console.ReadLine());
                g.MakeMove(index);

                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }

            Console.WriteLine($"Result: {g.GetWinner()}");
            Console.ReadLine();
        }

        
    }
}