using System;

namespace TDD_Algorithms.TicTacToe
{
    public class Game
    {
        public int MovesCounter { get; private set; }
        private readonly State[] _board = new State[9];

        public Game()
        {
            for (var i = 0; i < _board.Length; i++)
            {
                _board[i] = State.Unset;
            }
        }

        public void MakeMove(int index)
        {
            if (index < 1 || index > 9)
                throw new ArgumentOutOfRangeException();
            if(GetState(index) != State.Unset)
                throw new InvalidOperationException();

            MovesCounter++;
        }

        
    }
}