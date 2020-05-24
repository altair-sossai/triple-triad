/*using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripleTriad.Builders;
using TripleTriad.Commands;
using TripleTriad.Extensions;
using TripleTriad.Services;
using TripleTriad.Validators;

namespace TripleTriad.UnitTest.Cases
{
    [TestClass]
    public class GameWithCommonRuleCase02Test
    {
        [TestMethod]
        public void Run()
        {
            var player01 = new Player
            {
                Id = 1.ToGuid(),
                Name = "Squall Leonhart",
                Color = Color.LightSteelBlue,
                Cards = new List<Card>
                {
                    CardBuilder.Build(1).WithPoints(7, 3, 6, 5),
                    CardBuilder.Build(2).WithPoints(4, 5, 6, 2),
                    CardBuilder.Build(3).WithPoints(2, 6, 6, 3),
                    CardBuilder.Build(4).WithPoints(2, 4, 4, 7),
                    CardBuilder.Build(5).WithPoints(3, 7, 5, 1)
                }
            };

            var player02 = new Player
            {
                Id = new Guid("E8B58C27-EA8E-41D2-A2BF-0E65E31944C6"),
                Name = "Rinoa Heartilly",
                Color = Color.Magenta,
                Cards = new List<Card>
                {
                    CardBuilder.Build(6).WithPoints(6, 8, 5, 10),
                    CardBuilder.Build(7).WithPoints(2, 9, 6, 10),
                    CardBuilder.Build(8).WithPoints(3, 5, 10, 8),
                    CardBuilder.Build(9).WithPoints(4, 6, 9, 10),
                    CardBuilder.Build(10).WithPoints(10, 4, 10, 2)
                }
            };

            var newGameCommand = new NewGameCommand
            {
                Rows = 3,
                Columns = 3,
                EnableSameRule = false,
                EnableSameWallRule = false,
                EnablePlusRule = false,
                EnableComboRule = false,
                EnableElementalRule = false,
                ProbabilityOfElementary = 0.2d,
                StartPlayer = player01,
                Players = new List<Player>
                {
                    player01,
                    player02
                }
            };

            var cardValidator = new CardValidator();
            var playerValidator = new PlayerValidator(cardValidator);
            var newGameCommandValidator = new NewGameCommandValidator(playerValidator);

            var gameService = new GameService(newGameCommandValidator);

            var game = gameService.CreateNewGame(newGameCommand);

            Assert.AreEqual(game.Board.Rows, 3);
            Assert.AreEqual(game.Board.Columns, 3);

            for (var row = 0; row < game.Board.Rows; row++)
            for (var column = 0; column < game.Board.Columns; column++)
                Assert.IsTrue(game.Board[row, column].Empty);

            Assert.AreEqual(player01.Cards.Count, 5);
            Assert.AreEqual(player02.Cards.Count, 5);
            Assert.AreEqual(game.CurrentPlayer.Id, player02.Id);

            Assert.AreEqual(5, game.Scoreboard[player01.Id]);
            Assert.AreEqual(5, game.Scoreboard[player02.Id]);

            Assert.IsFalse(game.Finished);

            /* 1� JOGADA #1#

            game.Play(new PlayCommand(player01.Id, 1, 0, 0));

            Assert.IsTrue(game.Board[0, 0].Empty);
            Assert.IsTrue(game.Board[0, 1].Empty);
            Assert.IsTrue(game.Board[0, 2].Empty);

            Assert.IsTrue(game.Board[1, 0].Empty);
            Assert.IsTrue(game.Board[1, 1].Empty);
            Assert.IsTrue(game.Board[1, 2].Empty);

            Assert.IsTrue(game.Board[2, 0].Empty);
            Assert.IsTrue(game.Board[2, 1].Empty);
            Assert.IsTrue(game.Board[2, 2].Empty);

            Assert.AreEqual(5, game.Scoreboard[player01.Id]);
            Assert.AreEqual(5, game.Scoreboard[player02.Id]);

            Assert.IsFalse(game.Finished);

            /* 2� JOGADA #1#

            game.Play(new PlayCommand(player01.Id, 1, 2, 0));

            Assert.IsFalse(game.Board[0, 0].Empty);
            Assert.AreEqual(game.Board[0, 0].Card.Id, 10.ToGuid());
            Assert.AreEqual(game.Board[0, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[0, 1].Empty);
            Assert.IsTrue(game.Board[0, 2].Empty);

            Assert.IsTrue(game.Board[1, 0].Empty);
            Assert.IsTrue(game.Board[1, 1].Empty);
            Assert.IsTrue(game.Board[1, 2].Empty);

            Assert.IsFalse(game.Board[2, 0].Empty);
            Assert.AreEqual(game.Board[2, 0].Card.Id, 1.ToGuid());
            Assert.AreEqual(game.Board[2, 0].Owner.Id, player01.Id);
            Assert.IsTrue(game.Board[2, 1].Empty);
            Assert.IsTrue(game.Board[2, 2].Empty);

            Assert.AreEqual(5, game.Scoreboard[player01.Id]);
            Assert.AreEqual(5, game.Scoreboard[player02.Id]);

            Assert.IsFalse(game.Finished);

            /* 3� JOGADA #1#

            game.Play(new PlayCommand(player01.Id, 6, 1, 0));

            Assert.IsFalse(game.Board[0, 0].Empty);
            Assert.AreEqual(game.Board[0, 0].Card.Id, 10.ToGuid());
            Assert.AreEqual(game.Board[0, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[0, 1].Empty);
            Assert.IsTrue(game.Board[0, 2].Empty);

            Assert.IsFalse(game.Board[1, 0].Empty);
            Assert.AreEqual(game.Board[1, 0].Card.Id, 6.ToGuid());
            Assert.AreEqual(game.Board[1, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[1, 1].Empty);
            Assert.IsTrue(game.Board[1, 2].Empty);

            Assert.IsFalse(game.Board[2, 0].Empty);
            Assert.AreEqual(game.Board[2, 0].Card.Id, 1.ToGuid());
            Assert.AreEqual(game.Board[2, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[2, 1].Empty);
            Assert.IsTrue(game.Board[2, 2].Empty);

            Assert.AreEqual(4, game.Scoreboard[player01.Id]);
            Assert.AreEqual(6, game.Scoreboard[player02.Id]);

            Assert.IsFalse(game.Finished);

            /* 4� JOGADA #1#

            game.Play(new PlayCommand(player01.Id, 2, 1, 2));

            Assert.IsFalse(game.Board[0, 0].Empty);
            Assert.AreEqual(game.Board[0, 0].Card.Id, 10.ToGuid());
            Assert.AreEqual(game.Board[0, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[0, 1].Empty);
            Assert.IsTrue(game.Board[0, 2].Empty);

            Assert.IsFalse(game.Board[1, 0].Empty);
            Assert.AreEqual(game.Board[1, 0].Card.Id, 6.ToGuid());
            Assert.AreEqual(game.Board[1, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[1, 1].Empty);
            Assert.IsFalse(game.Board[1, 2].Empty);
            Assert.AreEqual(game.Board[1, 2].Card.Id, 2.ToGuid());
            Assert.AreEqual(game.Board[1, 2].Owner.Id, player01.Id);

            Assert.IsFalse(game.Board[2, 0].Empty);
            Assert.AreEqual(game.Board[2, 0].Card.Id, 1.ToGuid());
            Assert.AreEqual(game.Board[2, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[2, 1].Empty);
            Assert.IsTrue(game.Board[2, 2].Empty);

            Assert.AreEqual(4, game.Scoreboard[player01.Id]);
            Assert.AreEqual(6, game.Scoreboard[player02.Id]);

            Assert.IsFalse(game.Finished);

            /* 5� JOGADA #1#

            game.Play(new PlayCommand(player01.Id, 8, 2, 2));

            Assert.IsFalse(game.Board[0, 0].Empty);
            Assert.AreEqual(game.Board[0, 0].Card.Id, 10.ToGuid());
            Assert.AreEqual(game.Board[0, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[0, 1].Empty);
            Assert.IsTrue(game.Board[0, 2].Empty);

            Assert.IsFalse(game.Board[1, 0].Empty);
            Assert.AreEqual(game.Board[1, 0].Card.Id, 6.ToGuid());
            Assert.AreEqual(game.Board[1, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[1, 1].Empty);
            Assert.IsFalse(game.Board[1, 2].Empty);
            Assert.AreEqual(game.Board[1, 2].Card.Id, 2.ToGuid());
            Assert.AreEqual(game.Board[1, 2].Owner.Id, player02.Id);

            Assert.IsFalse(game.Board[2, 0].Empty);
            Assert.AreEqual(game.Board[2, 0].Card.Id, 1.ToGuid());
            Assert.AreEqual(game.Board[2, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[2, 1].Empty);
            Assert.IsFalse(game.Board[2, 2].Empty);
            Assert.AreEqual(game.Board[2, 2].Card.Id, 8.ToGuid());
            Assert.AreEqual(game.Board[2, 2].Owner.Id, player02.Id);

            Assert.AreEqual(3, game.Scoreboard[player01.Id]);
            Assert.AreEqual(7, game.Scoreboard[player02.Id]);

            Assert.IsFalse(game.Finished);

            /* 6� JOGADA #1#

            game.Play(new PlayCommand(player01.Id, 3, 2, 1));

            Assert.IsFalse(game.Board[0, 0].Empty);
            Assert.AreEqual(game.Board[0, 0].Card.Id, 10.ToGuid());
            Assert.AreEqual(game.Board[0, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[0, 1].Empty);
            Assert.IsTrue(game.Board[0, 2].Empty);

            Assert.IsFalse(game.Board[1, 0].Empty);
            Assert.AreEqual(game.Board[1, 0].Card.Id, 6.ToGuid());
            Assert.AreEqual(game.Board[1, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[1, 1].Empty);
            Assert.IsFalse(game.Board[1, 2].Empty);
            Assert.AreEqual(game.Board[1, 2].Card.Id, 2.ToGuid());
            Assert.AreEqual(game.Board[1, 2].Owner.Id, player02.Id);

            Assert.IsFalse(game.Board[2, 0].Empty);
            Assert.AreEqual(game.Board[2, 0].Card.Id, 1.ToGuid());
            Assert.AreEqual(game.Board[2, 0].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[2, 1].Empty);
            Assert.AreEqual(game.Board[2, 1].Card.Id, 3.ToGuid());
            Assert.AreEqual(game.Board[2, 1].Owner.Id, player01.Id);
            Assert.IsFalse(game.Board[2, 2].Empty);
            Assert.AreEqual(game.Board[2, 2].Card.Id, 8.ToGuid());
            Assert.AreEqual(game.Board[2, 2].Owner.Id, player02.Id);

            Assert.AreEqual(3, game.Scoreboard[player01.Id]);
            Assert.AreEqual(7, game.Scoreboard[player02.Id]);

            Assert.IsFalse(game.Finished);

            /* 7� JOGADA #1#

            game.Play(new PlayCommand(player01.Id, 9, 1, 1));

            Assert.IsFalse(game.Board[0, 0].Empty);
            Assert.AreEqual(game.Board[0, 0].Card.Id, 10.ToGuid());
            Assert.AreEqual(game.Board[0, 0].Owner.Id, player02.Id);
            Assert.IsTrue(game.Board[0, 1].Empty);
            Assert.IsTrue(game.Board[0, 2].Empty);

            Assert.IsFalse(game.Board[1, 0].Empty);
            Assert.AreEqual(game.Board[1, 0].Card.Id, 6.ToGuid());
            Assert.AreEqual(game.Board[1, 0].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[1, 1].Empty);
            Assert.AreEqual(game.Board[1, 1].Card.Id, 9.ToGuid());
            Assert.AreEqual(game.Board[1, 1].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[1, 2].Empty);
            Assert.AreEqual(game.Board[1, 2].Card.Id, 2.ToGuid());
            Assert.AreEqual(game.Board[1, 2].Owner.Id, player02.Id);

            Assert.IsFalse(game.Board[2, 0].Empty);
            Assert.AreEqual(game.Board[2, 0].Card.Id, 1.ToGuid());
            Assert.AreEqual(game.Board[2, 0].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[2, 1].Empty);
            Assert.AreEqual(game.Board[2, 1].Card.Id, 3.ToGuid());
            Assert.AreEqual(game.Board[2, 1].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[2, 2].Empty);
            Assert.AreEqual(game.Board[2, 2].Card.Id, 8.ToGuid());
            Assert.AreEqual(game.Board[2, 2].Owner.Id, player02.Id);

            Assert.AreEqual(2, game.Scoreboard[player01.Id]);
            Assert.AreEqual(8, game.Scoreboard[player02.Id]);

            Assert.IsFalse(game.Finished);

            /* 8� JOGADA #1#

            game.Play(new PlayCommand(player01.Id, 4, 0, 1));

            Assert.IsFalse(game.Board[0, 0].Empty);
            Assert.AreEqual(game.Board[0, 0].Card.Id, 10.ToGuid());
            Assert.AreEqual(game.Board[0, 0].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[0, 1].Empty);
            Assert.AreEqual(game.Board[0, 1].Card.Id, 4.ToGuid());
            Assert.AreEqual(game.Board[0, 1].Owner.Id, player01.Id);
            Assert.IsTrue(game.Board[0, 2].Empty);

            Assert.IsFalse(game.Board[1, 0].Empty);
            Assert.AreEqual(game.Board[1, 0].Card.Id, 6.ToGuid());
            Assert.AreEqual(game.Board[1, 0].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[1, 1].Empty);
            Assert.AreEqual(game.Board[1, 1].Card.Id, 9.ToGuid());
            Assert.AreEqual(game.Board[1, 1].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[1, 2].Empty);
            Assert.AreEqual(game.Board[1, 2].Card.Id, 2.ToGuid());
            Assert.AreEqual(game.Board[1, 2].Owner.Id, player02.Id);

            Assert.IsFalse(game.Board[2, 0].Empty);
            Assert.AreEqual(game.Board[2, 0].Card.Id, 1.ToGuid());
            Assert.AreEqual(game.Board[2, 0].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[2, 1].Empty);
            Assert.AreEqual(game.Board[2, 1].Card.Id, 3.ToGuid());
            Assert.AreEqual(game.Board[2, 1].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[2, 2].Empty);
            Assert.AreEqual(game.Board[2, 2].Card.Id, 8.ToGuid());
            Assert.AreEqual(game.Board[2, 2].Owner.Id, player02.Id);

            Assert.AreEqual(2, game.Scoreboard[player01.Id]);
            Assert.AreEqual(8, game.Scoreboard[player02.Id]);

            Assert.IsFalse(game.Finished);

            /* 9� JOGADA #1#

            game.Play(new PlayCommand(player01.Id, 7, 0, 2));

            Assert.IsFalse(game.Board[0, 0].Empty);
            Assert.AreEqual(game.Board[0, 0].Card.Id, 10.ToGuid());
            Assert.AreEqual(game.Board[0, 0].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[0, 1].Empty);
            Assert.AreEqual(game.Board[0, 1].Card.Id, 4.ToGuid());
            Assert.AreEqual(game.Board[0, 1].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[0, 2].Empty);
            Assert.AreEqual(game.Board[0, 2].Card.Id, 7.ToGuid());
            Assert.AreEqual(game.Board[0, 2].Owner.Id, player02.Id);

            Assert.IsFalse(game.Board[1, 0].Empty);
            Assert.AreEqual(game.Board[1, 0].Card.Id, 6.ToGuid());
            Assert.AreEqual(game.Board[1, 0].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[1, 1].Empty);
            Assert.AreEqual(game.Board[1, 1].Card.Id, 9.ToGuid());
            Assert.AreEqual(game.Board[1, 1].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[1, 2].Empty);
            Assert.AreEqual(game.Board[1, 2].Card.Id, 2.ToGuid());
            Assert.AreEqual(game.Board[1, 2].Owner.Id, player02.Id);

            Assert.IsFalse(game.Board[2, 0].Empty);
            Assert.AreEqual(game.Board[2, 0].Card.Id, 1.ToGuid());
            Assert.AreEqual(game.Board[2, 0].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[2, 1].Empty);
            Assert.AreEqual(game.Board[2, 1].Card.Id, 3.ToGuid());
            Assert.AreEqual(game.Board[2, 1].Owner.Id, player02.Id);
            Assert.IsFalse(game.Board[2, 2].Empty);
            Assert.AreEqual(game.Board[2, 2].Card.Id, 8.ToGuid());
            Assert.AreEqual(game.Board[2, 2].Owner.Id, player02.Id);

            Assert.AreEqual(1, game.Scoreboard[player01.Id]);
            Assert.AreEqual(9, game.Scoreboard[player02.Id]);

            Assert.IsTrue(game.Finished);
        }
    }
}*/