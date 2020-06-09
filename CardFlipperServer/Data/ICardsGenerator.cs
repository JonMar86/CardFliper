namespace CardFlipperServer.Data
{
    public interface ICardsGenerator
    {
        CardLayout GenerateCards(GameState priorGame);
        CardLayout GenerateCards(int uniqueCardLetters, int repeatsPerLetter);
        CardLayout GenerateCards(int uniqueCardLetters, int repeatsPerLetter, int rngSeed);
    }
}