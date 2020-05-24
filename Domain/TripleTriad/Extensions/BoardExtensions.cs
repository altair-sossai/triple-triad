namespace TripleTriad.Extensions
{
    public static class BoardExtensions
    {
        public static bool IsValidPlace(this Board board, int row, int column)
        {
            if (row < 0 || column < 0)
                return false;

            return row < board.Rows && column < board.Columns;
        }

        public static bool AllPlacesOccupied(this Board board)
        {
            for (var row = 0; row < board.Rows; row++)
            for (var column = 0; column < board.Columns; column++)
                if (board[row, column].Empty)
                    return false;

            return true;
        }
    }
}