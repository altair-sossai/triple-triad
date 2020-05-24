using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripleTriad.Builders;
using TripleTriad.Extensions;

namespace TripleTriad.UnitTest.Extensions
{
    [TestClass]
    public class CardExtensionsTest
    {
        [TestMethod]
        public void Contains()
        {
            var cards = new List<Card>
            {
                CardBuilder.Build(new Guid("0541D8C7-60F1-4B17-8EF8-B0CF7DC84AAB")).WithPoints(5, 6, 5, 4),
                CardBuilder.Build(new Guid("3DF588B1-EDB8-43B4-8E81-9A740D1575A7")).WithPoints(5, 7, 2, 3),
                CardBuilder.Build(new Guid("A30E1A89-6C5A-4B57-8B46-833D97C99788")).WithPoints(3, 6, 2, 6),
                CardBuilder.Build(new Guid("F85DD7C4-4FD1-4D0E-A359-D7AA0DFD37BF")).WithPoints(7, 1, 6, 4),
                CardBuilder.Build(new Guid("FD9E90D1-F053-4AD7-BDB2-625B757B8C5D")).WithPoints(3, 6, 2, 7)
            };

            foreach (var card in cards)
                Assert.IsTrue(cards.Contains(card.Id));

            for (var i = 0; i < 1000; i++)
                Assert.IsFalse(cards.Contains(Guid.NewGuid()));
        }

        [TestMethod]
        public void Find()
        {
            var cards = new List<Card>
            {
                CardBuilder.Build(new Guid("0541D8C7-60F1-4B17-8EF8-B0CF7DC84AAB")).WithPoints(5, 6, 5, 4),
                CardBuilder.Build(new Guid("3DF588B1-EDB8-43B4-8E81-9A740D1575A7")).WithPoints(5, 7, 2, 3),
                CardBuilder.Build(new Guid("A30E1A89-6C5A-4B57-8B46-833D97C99788")).WithPoints(3, 6, 2, 6),
                CardBuilder.Build(new Guid("F85DD7C4-4FD1-4D0E-A359-D7AA0DFD37BF")).WithPoints(7, 1, 6, 4),
                CardBuilder.Build(new Guid("FD9E90D1-F053-4AD7-BDB2-625B757B8C5D")).WithPoints(3, 6, 2, 7)
            };

            foreach (var card in cards)
            {
                var find = cards.Find(card.Id);

                Assert.IsNotNull(find);
                Assert.AreEqual(card.Id, find.Id);
            }

            for (var i = 0; i < 1000; i++)
                Assert.IsNull(cards.Find(Guid.NewGuid()));
        }
    }
}