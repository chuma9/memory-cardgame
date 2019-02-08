namespace MemoryCardGame.Models
{
    // Standard playing card with a suit and value that can be flipped to reveal hide/reveal its information
    public class Card
    {
        public Suits Suit { get; set; }

        public Values Value { get; set; }

        public bool IsVisible { get; private set; }

        public void Flip()
        {
            this.IsVisible = !this.IsVisible;
        }
    }
}
