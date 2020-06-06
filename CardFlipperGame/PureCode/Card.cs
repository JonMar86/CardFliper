namespace CardFlipperGame.PureCode
{
    public class Card
    {
        public const string DefaultText = "?";

        public Card(string displayedSide)
            : this(displayedSide, DefaultText)
        {            
        }

        public Card(string displayedSide, string hiddenSide)
        {
            this.HiddenSide = hiddenSide;
            this.DisplayedSide = displayedSide;
        }

        public bool IsHiding { get; set; } = true;

        public string HiddenSide { get; set; }

        public string DisplayedSide { get; set; }
    }
}
