using TripleTriad.Commands;

namespace TripleTriad.Services
{
    public interface IGameService
    {
        Game CreateNewGame(NewGameCommand command);
    }
}