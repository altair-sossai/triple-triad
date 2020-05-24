using System;
using TripleTriad.Helpers;

namespace TripleTriad
{
    public class Card
    {
        private int _bottom;
        private int _left;
        private int _level = 1;
        private int _right;
        private int _top;

        public Card()
        {
        }

        public Card(Guid id, string name, int level, Element? element = null)
        {
            Id = id;
            Name = name;
            Level = level;
            Element = element;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Level
        {
            get => _level;
            set => _level = Math.Max(1, Math.Min(10, value));
        }

        public int Left
        {
            get => _left;
            set => _left = PointHelper.MaxMin(value);
        }

        public int Top
        {
            get => _top;
            set => _top = PointHelper.MaxMin(value);
        }

        public int Right
        {
            get => _right;
            set => _right = PointHelper.MaxMin(value);
        }

        public int Bottom
        {
            get => _bottom;
            set => _bottom = PointHelper.MaxMin(value);
        }

        public Element? Element { get; set; }

        public int? this[int index] => index switch
        {
            0 => Left,
            1 => Top,
            2 => Right,
            3 => Bottom,
            _ => null
        };
    }
}