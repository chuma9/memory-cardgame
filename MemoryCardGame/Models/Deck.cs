namespace MemoryCardGame.Models
{
    using System;

    public class Deck
    {
        private const int SuitCount = 4;
        private const int ValueCount = 13;

        // Creates a standard 52 card deck that can be shuffled
        public Deck()
        {
            this.Cards = new Card[SuitCount * ValueCount];
            int idx = 0;
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Values value in Enum.GetValues(typeof(Values)))
                {
                    Card card = new Card() { Suit = suit, Value = value };
                    this.Cards[idx++] = card;
                }
            }
        }

        public Card[] Cards { get; }

        // Fisher-Yates shuffle
        public void Shuffle()
        {
            Random random = new Random();
            int size = SuitCount * ValueCount;

            for (int i = 0; i < size - 1; i++)
            {
                int k = random.Next(i, size);
                Card randomCard = this.Cards[k];
                this.Cards[k] = this.Cards[i];
                this.Cards[i] = randomCard;
            }
        }
    }
}