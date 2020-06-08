using System;
using System.Collections.Generic;

namespace CardFlipperServer.Data
{
    public class CardsGenerator
    {
        public CardLayout GenerateCards(GameState priorGame)
        {
            return GenerateCards(priorGame.UniqueCards, priorGame.RepeatsPerCard, priorGame.Seed);
        }

        public CardLayout GenerateCards(int uniqueCardLetters, int repeatsPerLetter)
        {
            int seed = GenerateRngSeed();
            return GenerateCards(uniqueCardLetters, repeatsPerLetter, seed);
        }        

        public CardLayout GenerateCards(int uniqueCardLetters, int repeatsPerLetter, int rngSeed)
        {
            CardLayout list = BuildStartingList(uniqueCardLetters, repeatsPerLetter);

            Scramble(list, rngSeed);

            return CalculateRowsColumns(list);
        }

        private static CardLayout BuildStartingList(int uniqueCardLetters, int repeatsPerLetter)
        {
            int totalCards = uniqueCardLetters * 2 * repeatsPerLetter;

            var list = new CardLayout(totalCards);

            char letter = 'A';
            for (int i = 0; i < totalCards; i += 2)
            {
                string display = letter.ToString();

                for (int r = 0; r < repeatsPerLetter * 2; r++)
                {
                    list.Add(new CardData
                    {
                        Index = i,
                        DisplayText = display,
                    });
                }

                letter++;
            }

            return list;
        }

        private static void Scramble(CardLayout list, int rngSeed)
        {
            list.RngSeed = rngSeed;

            var rng = new Random(rngSeed);

            int lastIndex = list.Count - 1;
            for (int i = 0; i < list.Count; i++)
            {
                int randoIndex = rng.Next(0, lastIndex);
                var temp = list[i];
                list[i] = list[randoIndex];
                list[randoIndex] = temp;
            }
        }

        private static CardLayout CalculateRowsColumns(CardLayout list)
        {
            int maxCardPerColumn = (int)Math.Ceiling(Math.Sqrt(list.Count));

            int row = 0;
            int col = 0;
            foreach (var card in list)
            {
                card.RowIndex = row;
                card.ColumnIndex = col;

                col++;
                if (col == maxCardPerColumn)
                {
                    col = 0;
                    row++;
                }
            }

            list.MaxRowColumn = maxCardPerColumn;

            return list;
        }

        private static int GenerateRngSeed()
        {
            DateTime now = DateTime.Now;
            return (now.Millisecond * (now.Hour + 1)) + (now.DayOfYear * (now.Minute + 1));
        }

    }
}
