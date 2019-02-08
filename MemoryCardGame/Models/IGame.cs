namespace MemoryCardGame.Models
{
    // Game play logic interface.
    public interface IGame
    {
        bool IsGameOver { get; }

        void Start();

        void GiveUp();

        Card GetCard(int index);

        Deck GetDeck();
    }
}
