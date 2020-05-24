using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TripleTriad.Extensions
{
    public static class PlayerExtensions
    {
        public static bool OwnerOf(this Player player, Place place)
        {
            if (place.Owner == null)
                return false;

            return player.Id == place.Owner.Id;
        }

        public static bool AllHaveDifferentColors(this IEnumerable<Player> players)
        {
            var colors = new HashSet<Color>();

            foreach (var player in players)
            {
                if (colors.Contains(player.Color))
                    return false;

                colors.Add(player.Color);
            }

            return true;
        }

        public static bool AllHaveTheCorrectNumberOfCards(this List<Player> players, int rows, int columns)
        {
            var numberOfPlaces = NumberOfPlaces(rows, columns);

            return players.AllHaveTheCorrectNumberOfCards(numberOfPlaces);
        }

        private static bool AllHaveTheCorrectNumberOfCards(this IReadOnlyCollection<Player> players, int numberOfPlaces)
        {
            var numberOfCards = NumberOfCards(players.Count, numberOfPlaces);

            return players.All(p => p.Cards.Count == numberOfCards);
        }

        public static Player Find(this IEnumerable<Player> players, Guid? playerId)
        {
            return playerId == null ? null : players.FirstOrDefault(p => p.Id == playerId.Value);
        }

        public static Player Find(this IEnumerable<Player> players, Guid playerId)
        {
            return players.FirstOrDefault(p => p.Id == playerId);
        }

        public static bool Contains(this IEnumerable<Player> players, Guid playerId)
        {
            return players.Any(p => p.Id == playerId);
        }

        public static Player Random(this IEnumerable<Player> players)
        {
            return players?.OrderBy(o => Guid.NewGuid()).First();
        }

        public static Player Next(this List<Player> players, Player currentPlayer)
        {
            var nextPlayer = players.IndexOf(currentPlayer) + 1;
            if (nextPlayer == players.Count)
                nextPlayer = 0;

            return players[nextPlayer];
        }

        private static int NumberOfPlaces(int rows, int columns)
        {
            return rows * columns;
        }

        private static int NumberOfCards(int numberOfPlayers, int numberOfPlaces)
        {
            return (int) Math.Ceiling(numberOfPlaces / (double) numberOfPlayers);
        }
    }
}