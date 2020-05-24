using System.Collections.Generic;
using FluentValidation;
using TripleTriad.Commands;
using TripleTriad.Extensions;

namespace TripleTriad.Validators
{
    public class NewGameCommandValidator : AbstractValidator<NewGameCommand>
    {
        public NewGameCommandValidator(IValidator<Player> playerValidator)
        {
            RuleFor(r => r.Players)
                .NotEmpty()
                .WithMessage("Informe os jogadores");

            RuleFor(r => r.StartPlayerId)
                .Must((c, startPlayerId) => startPlayerId != null && c.Players.Contains(startPlayerId.Value))
                .When(w => w.StartPlayerId != null)
                .WithMessage("O jogador inicial deve estar presente no jogo");

            When(w => w.Players != null, () =>
            {
                RuleFor(r => r.Players)
                    .Must(HasTwoPlayersOrMore)
                    .WithMessage("Informe ao menos dois jogadores");

                RuleFor(r => r.Players)
                    .Must(p => p.AllHaveDifferentColors())
                    .WithMessage("Informe cores diferentes para todos os jogadores");

                RuleFor(r => r.Players)
                    .Must((c, p) => p.AllHaveTheCorrectNumberOfCards(c.Rows, c.Columns))
                    .WithMessage("Informe o número de cartas correto para todos os jogadores");

                RuleForEach(r => r.Players)
                    .SetValidator(playerValidator);
            });
        }

        private static bool HasTwoPlayersOrMore(List<Player> players)
        {
            return players.Count >= 2;
        }
    }
}