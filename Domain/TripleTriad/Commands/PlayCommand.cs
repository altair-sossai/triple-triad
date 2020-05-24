using System;
using TripleTriad.Extensions;

namespace TripleTriad.Commands
{
    public class PlayCommand
    {
        public PlayCommand()
        {
        }

        public PlayCommand(Guid playerId, int cardId, int row, int column)
            : this(playerId, cardId.ToGuid(), row, column)
        {
        }

        public PlayCommand(Guid playerId, Guid cardId, int row, int column)
        {
            PlayerId = playerId;
            CardId = cardId;
            Row = row;
            Column = column;
        }

        public Guid PlayerId { get; set; }
        public Guid CardId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}