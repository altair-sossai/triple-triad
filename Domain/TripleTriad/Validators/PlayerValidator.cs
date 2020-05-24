using FluentValidation;

namespace TripleTriad.Validators
{
    public class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator(IValidator<Card> cardValidator)
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .WithMessage("Informe o Id do jogador");

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Informe o nome do jogador");

            RuleFor(r => r.Cards)
                .NotNull()
                .WithMessage("Informe as cartas do jogador");

            RuleForEach(r => r.Cards)
                .SetValidator(cardValidator)
                .When(w => w.Cards != null);
        }
    }
}