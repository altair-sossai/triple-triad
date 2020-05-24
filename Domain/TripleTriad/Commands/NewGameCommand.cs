using System;
using System.Collections.Generic;

namespace TripleTriad.Commands
{
    public class NewGameCommand
    {
        private int _columns = 3;
        private double _probabilityOfElementary = 0.2d;
        private int _rows = 3;

        public int Rows
        {
            get => _rows;
            set => _rows = Math.Max(1, value);
        }

        public int Columns
        {
            get => _columns;
            set => _columns = Math.Max(1, value);
        }

        public bool EnableSameRule { get; set; }
        public bool EnableSameWallRule { get; set; }
        public bool EnablePlusRule { get; set; }
        public bool EnableComboRule { get; set; }
        public bool EnableElementalRule { get; set; }

        public double ProbabilityOfElementary
        {
            get => _probabilityOfElementary;
            set => _probabilityOfElementary = Math.Min(1, Math.Max(0, value));
        }

        public Guid? StartPlayerId { get; set; }
        public List<Player> Players { get; set; }
    }
}