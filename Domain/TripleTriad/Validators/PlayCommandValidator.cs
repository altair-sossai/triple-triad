using FluentValidation;
using TripleTriad.Commands;
using TripleTriad.Extensions;

namespace TripleTriad.Validators
{
    public class PlayCommandValidator : AbstractValidator<PlayCommand>
    {
        public PlayCommandValidator(Game game)
        {
            RuleFor(r => r.PlayerId)
                .Must(playerId => game.Players.Contains(playerId))
                .WithMessage("Jogador não localizado")
                .Must(playerId => game.CurrentPlayer.Id == playerId)
                .WithMessage("Aguarde sua vez para jogar");

            RuleFor(r => r.CardId)
                .Must(cardId => game.CurrentPlayer.Cards.Contains(cardId))
                .WithMessage("O jogador não possui a carta informada");

            RuleFor(r => r)
                .Must(play => game.Board.IsValidPlace(play.Row, play.Column))
                .WithMessage("Informe um local válido");

            RuleFor(r => r)
                .Must(play => game.Board[play.Row, play.Column].Empty)
                .When(play => game.Board.IsValidPlace(play.Row, play.Column))
                .WithMessage("Local já ocupado");
        }
    }
}