namespace CardFlipperServer.Data
{
    public class CardData
    {
        public bool IsMatched { get; set; }

        public bool IsFaceUp { get; set; }

        public string DisplayText { get; set; }

        public string BackSideText { get; set; } = "?";

        public int Index { get; set; }

        public int RowIndex { get; set; }

        public int ColumnIndex { get; set; }
    }
}
