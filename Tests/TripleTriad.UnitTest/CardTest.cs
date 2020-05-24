using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TripleTriad.UnitTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void Level()
        {
            var card = new Card(Guid.NewGuid(), "Lorem card", 1000);

            for (var level = -1000; level <= 0; level++)
            {
                card.Level = level;
                Assert.AreEqual(1, card.Level);
            }

            for (var level = 1; level <= 10; level++)
            {
                card.Level = level;
                Assert.AreEqual(level, card.Level);
            }

            for (var level = 10; level <= 1000; level++)
            {
                card.Level = level;
                Assert.AreEqual(10, card.Level);
            }
        }

        [TestMethod]
        public void Index()
        {
            var card = new Card(Guid.NewGuid(), "Lorem card", 1000)
            {
                Left = 2,
                Top = 3,
                Right = 4,
                Bottom = 5
            };

            Assert.AreEqual(card[0], card.Left);
            Assert.AreEqual(card[1], card.Top);
            Assert.AreEqual(card[2], card.Right);
            Assert.AreEqual(card[3], card.Bottom);
        }
    }
}