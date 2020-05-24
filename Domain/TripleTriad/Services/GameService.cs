using FluentValidation;
using TripleTriad.Commands;

namespace TripleTriad.Services
{
    public class GameService : IGameService
    {
        private readonly IValidator<NewGameCommand> _validator;

        public GameService(IValidator<NewGameCommand> validator)
        {
            _validator = validator;
        }

        public Game CreateNewGame(NewGameCommand command)
        {
            _validator.ValidateAndThrow(command);

            var game = new Game(command);

            return game;
        }
    }
}