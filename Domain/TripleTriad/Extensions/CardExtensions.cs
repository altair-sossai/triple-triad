using System;
using System.Collections.Generic;
using System.Linq;

namespace TripleTriad.Extensions
{
    public static class CardExtensions
    {
        public static bool Contains(this IEnumerable<Card> cards, Guid cardId)
        {
            return cards.Any(p => p.Id == cardId);
        }

        public static Card Find(this IEnumerable<Card> cards, Guid cardId)
        {
            return cards.FirstOrDefault(p => p.Id == cardId);
        }
    }
}