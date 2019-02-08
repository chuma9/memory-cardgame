namespace MemoryCardGameTests
{
    using System;
    using MemoryCardGame;
    using MemoryCardGame.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MemoryCardGameTests
    {
        private readonly Random random = new Random();

        [TestMethod]
        public void GiveUp()
        {
            MemoryGame game = new MemoryGame();
            game.GiveUp();
            int cardCount = game.GetDeck().Cards.Length;
            Assert.IsTrue(game.IsGameOver);
            Assert.IsTrue(game.GetCard(this.random.Next(0, cardCount)).IsVisible);
        }

        [TestMethod]
        public void GetCard()
        {
            MemoryGame game = new MemoryGame();
            int cardCount = game.GetDeck().Cards.Length;
            int cardIdx = this.random.Next(0, cardCount);
            Card card = game.GetCard(cardIdx);
            Assert.IsNotNull(card);
            Assert.IsNotNull(card.Suit);
            Assert.IsNotNull(card.Value);
            Assert.IsFalse(card.IsVisible);
        }

        [TestMethod]
        public void GetDeck()
        {
            Deck deck = new Deck();
            MemoryGame game = new MemoryGame(deck);
            Assert.IsNotNull(game.GetDeck());
            Assert.AreEqual(deck, game.GetDeck());
        }
    }
}
