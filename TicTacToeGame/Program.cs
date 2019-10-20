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
        private static string GetPrintableState()
        {
            var sb = new StringBuilder();

            for (int i = 1; i <= 7; i += 3)
            {
                sb.AppendLine("     |     |     ")
                    .AppendLine(
                        $"  {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}  ")
                    .AppendLine("_____|_____|_____|");
            }

            return sb.ToString();
        }

        


    }
}