namespace TripleTriad
{
    public interface IRule
    {
        void ApplyRule(Player player, Board board, Place place);
    }
}