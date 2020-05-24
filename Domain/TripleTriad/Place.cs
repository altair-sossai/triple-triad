using System;
using TripleTriad.Helpers;

namespace TripleTriad
{
    public class Place
    {
        public Place(int row, int column, Configuration configuration)
        {
            Row = row;
            Column = column;

            if (configuration.Elemental && RandomHelper.NextBool(configuration.ProbabilityOfElementary))
                Element = EnumHelper.RandomValue<Element>();
        }

        public int Row { get; }
        public int Column { get; }
        public Player Owner { get; private set; }
        public Card Card { get; private set; }
        public int? Left => PointHelper.Sum(Card?.Left, AdditionalPoint);
        public int? Top => PointHelper.Sum(Card?.Top, AdditionalPoint);
        public int? Right => PointHelper.Sum(Card?.Right, AdditionalPoint);
        public int? Bottom => PointHelper.Sum(Card?.Bottom, AdditionalPoint);
        public Element? Element { get; set; }
        public bool Empty => Card == null;

        private int? AdditionalPoint
        {
            get
            {
                if (Empty || Element == null || Card.Element == null)
                    return null;

                return Card.Element == Element ? 1 : -1;
            }
        }

        public int? this[int index] => index switch
        {
            0 => Left,
            1 => Top,
            2 => Right,
            3 => Bottom,
            _ => null
        };

        public event EventHandler<Card> OnCardAdded;

        public void PutCard(Player player, Card card)
        {
            Owner = player;
            Card = card;

            OnCardAdded?.Invoke(this, card);
        }

        public void ChangeOwner(Player player)
        {
            Owner = player;
        }
    }
}