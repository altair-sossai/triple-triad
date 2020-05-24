using System;
using System.Collections.Generic;
using System.Drawing;

namespace TripleTriad
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public List<Card> Cards { get; set; }
    }
}