using FluentValidation;

namespace TripleTriad.Validators
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .WithMessage("Informe o Id da carta");

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Informe o nome da carta");
        }
    }
}