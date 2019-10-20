using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TDD_Algorithms.Tests.TicTacToeTests
{
    [TestFixture]
    public class TicTacToeTests
    {
        [Test]
        public void CreateGame_ZeroMoves()
        {
            Game game = new Game();
            Assert.AreEqual(0, game.MovesCounter);
        }

        [Test]
        public void MakeMove_CounterShifts()
        {
            Game game = new Game();
            game.MakeMove(1);
            Assert.AreEqual(1, game.MovesCounter);
        }

        [Test]
        public void MakeInvalidMove_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var game = new Game();
                game.MakeMove(0);
            });
        }
        [Test]
        public void MoveOnTheSameSquare_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var game = new Game();
                game.MakeMove(1);
                game.MakeMove(1);
            });
        }
    }

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
