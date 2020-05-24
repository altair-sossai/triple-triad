using System;

namespace TripleTriad
{
    public class Configuration
    {
        private double _probabilityOfElementary;
        public bool Same { get; set; }
        public bool SameWall { get; set; }
        public bool Plus { get; set; }
        public bool Combo { get; set; }
        public bool Elemental { get; set; }

        public double ProbabilityOfElementary
        {
            get => _probabilityOfElementary;
            set => _probabilityOfElementary = Math.Min(1, Math.Max(0, value));
        }
    }
}