using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TripleTriad.UnitTest
{
    [TestClass]
    public class PlaceTest
    {
        [TestMethod]
        public void WithoutElement()
        {
            var configuration = new Configuration();
            var place = new Place(0, 0, configuration);

            Assert.IsNull(place.Left);
            Assert.IsNull(place.Top);
            Assert.IsNull(place.Right);
            Assert.IsNull(place.Bottom);

            var player = new Player();

            var card = new Card(Guid.NewGuid(), "Lorem card", 1000)
            {
                Left = 2,
                Top = 3,
                Right = 4,
                Bottom = 5
            };

            place.PutCard(player, card);

            Assert.AreEqual(card.Left, place.Left);
            Assert.AreEqual(card.Top, place.Top);
            Assert.AreEqual(card.Right, place.Right);
            Assert.AreEqual(card.Bottom, place.Bottom);
        }

        [TestMethod]
        public void RightElement()
        {
            var configuration = new Configuration();
            var place = new Place(0, 0, configuration)
            {
                Element = Element.Fire
            };

            Assert.IsNull(place.Left);
            Assert.IsNull(place.Top);
            Assert.IsNull(place.Right);
            Assert.IsNull(place.Bottom);

            var player = new Player();

            var card = new Card(Guid.NewGuid(), "Lorem card", 1000)
            {
                Left = 2,
                Top = 3,
                Right = 4,
                Bottom = 5,
                Element = Element.Fire
            };

            place.PutCard(player, card);

            Assert.AreEqual(card.Left + 1, place.Left);
            Assert.AreEqual(card.Top + 1, place.Top);
            Assert.AreEqual(card.Right + 1, place.Right);
            Assert.AreEqual(card.Bottom + 1, place.Bottom);
        }

        [TestMethod]
        public void WrongElement()
        {
            var configuration = new Configuration();
            var place = new Place(0, 0, configuration)
            {
                Element = Element.Fire
            };

            Assert.IsNull(place.Left);
            Assert.IsNull(place.Top);
            Assert.IsNull(place.Right);
            Assert.IsNull(place.Bottom);

            var player = new Player();

            var card = new Card(Guid.NewGuid(), "Lorem card", 1000)
            {
                Left = 2,
                Top = 3,
                Right = 4,
                Bottom = 5,
                Element = Element.Water
            };

            place.PutCard(player, card);

            Assert.AreEqual(card.Left - 1, place.Left);
            Assert.AreEqual(card.Top - 1, place.Top);
            Assert.AreEqual(card.Right - 1, place.Right);
            Assert.AreEqual(card.Bottom - 1, place.Bottom);
        }

        [TestMethod]
        public void CardWithoutElement()
        {
            var configuration = new Configuration();
            var place = new Place(0, 0, configuration)
            {
                Element = Element.Fire
            };

            Assert.IsNull(place.Left);
            Assert.IsNull(place.Top);
            Assert.IsNull(place.Right);
            Assert.IsNull(place.Bottom);

            var player = new Player();

            var card = new Card(Guid.NewGuid(), "Lorem card", 1000)
            {
                Left = 2,
                Top = 3,
                Right = 4,
                Bottom = 5
            };

            place.PutCard(player, card);

            Assert.AreEqual(card.Left, place.Left);
            Assert.AreEqual(card.Top, place.Top);
            Assert.AreEqual(card.Right, place.Right);
            Assert.AreEqual(card.Bottom, place.Bottom);
        }

        [TestMethod]
        public void PlaceWithoutElement()
        {
            var configuration = new Configuration();
            var place = new Place(0, 0, configuration);

            Assert.IsNull(place.Left);
            Assert.IsNull(place.Top);
            Assert.IsNull(place.Right);
            Assert.IsNull(place.Bottom);

            var player = new Player();

            var card = new Card(Guid.NewGuid(), "Lorem card", 1000)
            {
                Left = 2,
                Top = 3,
                Right = 4,
                Bottom = 5,
                Element = Element.Fire
            };

            place.PutCard(player, card);

            Assert.AreEqual(card.Left, place.Left);
            Assert.AreEqual(card.Top, place.Top);
            Assert.AreEqual(card.Right, place.Right);
            Assert.AreEqual(card.Bottom, place.Bottom);
        }

        [TestMethod]
        public void Empty()
        {
            var configuration = new Configuration();
            var place = new Place(0, 0, configuration);

            Assert.IsTrue(place.Empty);

            var player = new Player();

            var card = new Card(Guid.NewGuid(), "Lorem card", 1000)
            {
                Left = 2,
                Top = 3,
                Right = 4,
                Bottom = 5
            };

            place.PutCard(player, card);

            Assert.IsFalse(place.Empty);
        }

        [TestMethod]
        public void Index()
        {
            var configuration = new Configuration();
            var place = new Place(0, 0, configuration);

            Assert.IsNull(place[0]);
            Assert.IsNull(place[1]);
            Assert.IsNull(place[2]);
            Assert.IsNull(place[3]);

            var player = new Player();

            var card = new Card(Guid.NewGuid(), "Lorem card", 1000)
            {
                Left = 2,
                Top = 3,
                Right = 4,
                Bottom = 5
            };

            place.PutCard(player, card);

            Assert.AreEqual(place[0], place.Left);
            Assert.AreEqual(place[1], place.Top);
            Assert.AreEqual(place[2], place.Right);
            Assert.AreEqual(place[3], place.Bottom);
        }
    }
}