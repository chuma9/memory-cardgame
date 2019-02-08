namespace MemoryCardGameTests
{
    using MemoryCardGame.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Shuffle()
        {
            Deck deck = new Deck();
            int length = deck.Cards.Length;
            deck.Shuffle();
            Assert.IsNotNull(deck);
            Assert.AreEqual(length, deck.Cards.Length);
        }
    }
}
