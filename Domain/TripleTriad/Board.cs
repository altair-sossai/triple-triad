using System;
using System.Collections.Generic;
using TripleTriad.Builders;

namespace TripleTriad
{
    public class Board
    {
        private readonly Game _game;
        private List<IRule> _rules;

        public Board(Game game, int rows, int columns)
        {
            _game = game;

            Rows = rows;
            Columns = columns;

            Places = new Place[rows, columns];

            for (var row = 0; row < rows; row++)
            for (var column = 0; column < columns; column++)
            {
                Places[row, column] = new Place(row, column, game.Configuration);
                Places[row, column].OnCardAdded += PlaceOnCardAdded;
            }
        }

        private IEnumerable<IRule> Rules => _rules ??= _game.Configuration.BuildRules();

        public int Rows { get; }
        public int Columns { get; }
        public Place[,] Places { get; }
        public Place this[int row, int column] => Places[row, column];


        public event EventHandler<Place> AfterPlacedCard;

        private void PlaceOnCardAdded(object sender, Card e)
        {
            var place = (Place) sender;

            foreach (var rule in Rules)
                rule.ApplyRule(_game.CurrentPlayer, this, place);

            AfterPlacedCard?.Invoke(this, place);
        }

        public Place Left(Place place)
        {
            return place.Column == 0 ? null : this[place.Row, place.Column - 1];
        }

        public Place Top(Place place)
        {
            return place.Row == 0 ? null : this[place.Row - 1, place.Column];
        }

        public Place Right(Place place)
        {
            return place.Column == Columns - 1 ? null : this[place.Row, place.Column + 1];
        }

        public Place Bottom(Place place)
        {
            return place.Row == Rows - 1 ? null : this[place.Row + 1, place.Column];
        }
    }
}