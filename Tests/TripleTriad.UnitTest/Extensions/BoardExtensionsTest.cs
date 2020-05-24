using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripleTriad.Commands;
using TripleTriad.Extensions;

namespace TripleTriad.UnitTest.Extensions
{
    [TestClass]
    public class BoardExtensionsTest
    {
        [TestMethod]
        public void IsValidPlace()
        {
            var command = new NewGameCommand
            {
                Players = new List<Player>
                {
                    new Player {Cards = new List<Card>()}
                }
            };

            var game = new Game(command);

            Assert.IsFalse(game.Board.IsValidPlace(-1, -1));
            Assert.IsFalse(game.Board.IsValidPlace(-1, 0));
            Assert.IsFalse(game.Board.IsValidPlace(0, -1));

            for (var row = 0; row < 3; row++)
            for (var column = 0; column < 3; column++)
                Assert.IsTrue(game.Board.IsValidPlace(row, column));

            Assert.IsFalse(game.Board.IsValidPlace(3, 3));
            Assert.IsFalse(game.Board.IsValidPlace(3, 0));
            Assert.IsFalse(game.Board.IsValidPlace(0, 3));
        }
    }
}