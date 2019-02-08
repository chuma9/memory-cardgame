namespace MemoryCardGame
{
    using System;
    using Models;

    // Game play logic for memory card game.
    public class MemoryGame : IGame
    {
        private static Deck deck;
        private readonly int colCount = 13;
        private readonly int rowCount = 4;
        private int matchCount;
        private bool isGameOver;

        // If no deck is provided as input, the standard 52 card deck is used.
        public MemoryGame(Deck inDeck = null)
        {
            // Ensure suit characters which are UTF8 encoded are output correctly
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            deck = inDeck ?? new Deck();
            deck.Shuffle();
        }

        public bool IsGameOver => this.isGameOver;

        public void Start()
        {
            while (!this.isGameOver)
            {
                this.Play();
            }

            Console.WriteLine("THE GAME IS OVER :)");
        }

        public void GiveUp()
        {
            foreach (Card card in deck.Cards)
            {
                if (!card.IsVisible)
                {
                    card.Flip();
                }
            }

            this.isGameOver = true;
            this.PrintBoard();
        }

        public Card GetCard(int index)
        {
            return deck.Cards[index];
        }

        public Deck GetDeck()
        {
            return deck;
        }

        private void Play(string inIndices = null)
        {
            this.PrintBoard();

            string indices = inIndices ?? this.PromptUserChoice();

            Card card1 = null;
            Card card2 = null;

            try
            {
                string[] cardsidx = indices.Split(' ');
                card1 = this.ParseInputIndex(cardsidx[0]);
                card2 = this.ParseInputIndex(cardsidx[1]);
            }
            catch
            {
                return;
            }

            // check that the selected cards are valid, distinct and not already flipped over (visible)
            if (card1 == null || card2 == null || card1 == card2 || card1.IsVisible || card2.IsVisible)
            {
                return;
            }

            card1.Flip();
            card2.Flip();
            this.PrintBoard();

            if (this.IsMatch(card1, card2))
            {
                this.matchCount += 1;
                if (this.matchCount == deck.Cards.Length / 2)
                {
                    this.isGameOver = true;
                }
            }
            else
            {
                // prompt for input to give user time to look at and memorize selected cards
                // before flipping them over
                this.PromptAnyInput();
                card1.Flip();
                card2.Flip();
            }
        }

        private Card ParseInputIndex(string cardIndex)
        {
            int x;
            int y;
            try
            {
                string[] cardidx = cardIndex.Split(',');
                x = int.Parse(cardidx[0]);
                y = int.Parse(cardidx[1]);
            }
            catch
            {
                return null;
            }

            // check if valid index
            if (x < this.rowCount || x >= 0 || y < this.colCount || y >= 0)
            {
                return this.GetCard((x * this.colCount) + y);
            }

            return null;
        }

        // Checks if two cards are a match according to the rules of the game
        // To match, cards need to be of the same value and color (matching suit).
        // Diamond and Hearts (red) are matching suits and Clubs and Spades (black) are matching suits
        private bool IsMatch(Card card1, Card card2)
        {
            bool ret = false;
            if (card1.Value == card2.Value)
            {
                switch (card1.Suit)
                {
                    case Suits.Clubs:
                    case Suits.Spades:
                        if (card2.Suit == Suits.Clubs || card2.Suit == Suits.Spades)
                        {
                            ret = true;
                        }

                        break;
                    case Suits.Hearts:
                    case Suits.Diamonds:
                        if (card2.Suit == Suits.Hearts || card2.Suit == Suits.Diamonds)
                        {
                            ret = true;
                        }

                        break;
                }
            }

            return ret;
        }

        private void PrintBoard()
        {
            Console.Clear();

            Console.WriteLine("MEMORY CARD GAME" + Environment.NewLine);
            Console.WriteLine("Type 'Quit' at any point to give up and reveal all cards" + Environment.NewLine);

            string boardTop = $" \\Y |{Environment.NewLine} X\\ |  0     1     2     3     4     5     6     7     8     9    10    11    12   {Environment.NewLine}___\\|_________________________________________________________________________________{Environment.NewLine}    | {Environment.NewLine}";
            Console.Write(boardTop);

            for (int i = 0; i < this.rowCount; i++)
            {
                Console.Write($"  {i} |");
                for (int j = 0; j < this.colCount; j++)
                {
                    Card card = this.GetCard((i * this.colCount) + j);
                    if (card.IsVisible)
                    {
                        if (card.Suit == Suits.Diamonds || card.Suit == Suits.Hearts)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Console.Write($"{EnumExtension.ToDisplayString(card.Value)} {EnumExtension.ToDisplayString(card.Suit)}  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("+--+  ");
                    }
                }

                Console.Write(Environment.NewLine);
                Console.WriteLine("    | ");
            }
        }

        private string PromptUserChoice()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Enter the X and Y indices separated by spaces of the two cards you wish to flip");
            Console.WriteLine("For example typing '2,12 2,3' flips the cards in position X=2,Y=12 and X=2,Y=3");
            string input = Console.ReadLine();

            if (input != null && input.Equals("quit", StringComparison.InvariantCultureIgnoreCase))
            {
                this.GiveUp();
            }

            return input;
        }

        private void PromptAnyInput()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Press Any Key To Continue");
            Console.Read();
        }
    }
}
