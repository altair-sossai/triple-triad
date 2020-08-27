using System;
using System.Collections.Generic;
using FluentValidation;
using TripleTriad.Builders;
using TripleTriad.Commands;
using TripleTriad.Extensions;
using TripleTriad.Validators;

namespace TripleTriad
{
    public class Game
    {
        public Game(NewGameCommand command)
        {
            Configuration = RulesConfigurationBuilder.Build(command);

            Board = new Board(this, command.Rows, command.Columns);
            Players = command.Players;
            CurrentPlayer = command.Players.Find(command.StartPlayerId) ?? Players.Random();

            UpdateScoreboard();

            Board.AfterPlacedCard += AfterPlacedCard;
        }

        public Guid Id { get; } = Guid.NewGuid();
        public Configuration Configuration { get; }
        public Board Board { get; }
        public List<Player> Players { get; }
        public Player CurrentPlayer { get; private set; }
        public bool Finished => Board.AllPlacesOccupied();
        public Dictionary<Guid, int> Scoreboard { get; private set; }

        public void Play(PlayCommand play)
        {
            var validator = new PlayCommandValidator(this);
            validator.ValidateAndThrow(play);

            var place = Board[play.Row, play.Column];
            var card = CurrentPlayer.Cards.Find(play.CardId);
            place.PutCard(CurrentPlayer, card);
        }

        private void AfterPlacedCard(object sender, Place place)
        {
            CurrentPlayer.Cards.Remove(place.Card);

            NextPlayer();
            UpdateScoreboard();
        }

        private void NextPlayer()
        {
            CurrentPlayer = Players.Next(CurrentPlayer);
        }

        private void UpdateScoreboard()
        {
            Scoreboard ??= new Dictionary<Guid, int>();
            Scoreboard.Update(this);
        }
    }
}