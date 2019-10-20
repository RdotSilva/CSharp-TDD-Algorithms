using System;

namespace TDD_Algorithms.TicTacToe
{
    public class Game
    {
        public int MovesCounter { get; private set; }

        public void MakeMove(int index)
        {
            if (index < 1 || index > 9)
                throw new ArgumentOutOfRangeException();
            MovesCounter++;
        }
    }
}