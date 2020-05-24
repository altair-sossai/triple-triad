using System;
using System.Collections.Generic;

namespace TripleTriad.Extensions
{
    public static class ScoreboardExtensions
    {
        public static void Update(this Dictionary<Guid, int> scoreboard, Game game)
        {
            foreach (var player in game.Players)
            {
                if (!scoreboard.ContainsKey(player.Id))
                    scoreboard.Add(player.Id, 0);

                scoreboard[player.Id] = player.Cards.Count;
            }

            for (var row = 0; row < game.Board.Rows; row++)
            for (var column = 0; column < game.Board.Columns; column++)
            {
                var place = game.Board[row, column];
                if (place.Empty)
                    continue;

                scoreboard[place.Owner.Id]++;
            }
        }
    }
}