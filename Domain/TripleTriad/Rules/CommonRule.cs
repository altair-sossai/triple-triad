using TripleTriad.Extensions;

namespace TripleTriad.Rules
{
    public class CommonRule : IRule
    {
        public void ApplyRule(Player player, Board board, Place place)
        {
            TryCatchLeftPlace(player, board, place);
            TryCatchTopPlace(player, board, place);
            TryCatchRightPlace(player, board, place);
            TryCatchBottomPlace(player, board, place);
        }

        private static void TryCatchLeftPlace(Player player, Board board, Place place)
        {
            var left = board.Left(place);

            if (left == null)
                return;

            if (!player.OwnerOf(left) && place.Left > left.Right)
                left.ChangeOwner(player);
        }

        private static void TryCatchTopPlace(Player player, Board board, Place place)
        {
            var top = board.Top(place);

            if (top == null)
                return;

            if (!player.OwnerOf(top) && place.Top > top.Bottom)
                top.ChangeOwner(player);
        }

        private static void TryCatchRightPlace(Player player, Board board, Place place)
        {
            var right = board.Right(place);

            if (right == null)
                return;

            if (!player.OwnerOf(right) && place.Right > right.Left)
                right.ChangeOwner(player);
        }

        private static void TryCatchBottomPlace(Player player, Board board, Place place)
        {
            var bottom = board.Bottom(place);

            if (bottom == null)
                return;

            if (!player.OwnerOf(bottom) && place.Bottom > bottom.Top)
                bottom.ChangeOwner(player);
        }
    }
}