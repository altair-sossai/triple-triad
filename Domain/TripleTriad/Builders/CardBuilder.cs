using System;
using TripleTriad.Extensions;

namespace TripleTriad.Builders
{
    public static class CardBuilder
    {
        public static Card Build(int id)
        {
            return new Card(id.ToGuid(), $"Card name {id:000}", 1);
        }

        public static Card Build(Guid id)
        {
            return new Card(id, id.ToString(), 1);
        }

        public static Card Build(Guid id, string name, int level, Element? element = null)
        {
            return new Card(id, name, level, element);
        }

        public static Card WithElement(this Card card, Element element)
        {
            card.Element = element;

            return card;
        }

        public static Card WithPoints(this Card card, int left, int top, int right, int bottom)
        {
            card.Left = left;
            card.Top = top;
            card.Right = right;
            card.Bottom = bottom;

            return card;
        }
    }
}