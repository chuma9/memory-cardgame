namespace MemoryCardGameTests
{
    using MemoryCardGame.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void FlipCard()
        {
            Card card = new Card() { Suit = Suits.Clubs, Value = Values.Four };
            Assert.AreEqual(false, card.IsVisible);
            card.Flip();
            Assert.AreEqual(true, card.IsVisible);
            card.Flip();
            Assert.AreEqual(false, card.IsVisible);
        }
    }
}
