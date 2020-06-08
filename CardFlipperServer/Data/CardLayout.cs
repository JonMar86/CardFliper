using System.Collections.Generic;

namespace CardFlipperServer.Data
{
    public class CardLayout : List<CardData>
    {
        public CardLayout(int capacity) : base(capacity)
        {
        }

        public int MaxRowColumn { get; set; }

        public int RngSeed { get; set; }
    }
}
