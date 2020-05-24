using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripleTriad.Builders;
using TripleTriad.Extensions;

namespace TripleTriad.UnitTest.Extensions
{
    [TestClass]
    public class PlayerExtensionsTest
    {
        [TestMethod]
        public void AllHaveDifferentColors()
        {
            Assert.IsTrue(new List<Player>().AllHaveDifferentColors());

            Assert.IsTrue(new List<Player>
            {
                new Player {Color = Color.Red}
            }.AllHaveDifferentColors());

            Assert.IsTrue(new List<Player>
            {
                new Player {Color = Color.Black},
                new Player {Color = Color.Red}
            }.AllHaveDifferentColors());

            Assert.IsTrue(new List<Player>
            {
                new Player {Color = Color.Black},
                new Player {Color = Color.White},
                new Player {Color = Color.Red}
            }.AllHaveDifferentColors());

            Assert.IsFalse(new List<Player>
            {
                new Player {Color = Color.Black},
                new Player {Color = Color.Black}
            }.AllHaveDifferentColors());

            Assert.IsFalse(new List<Player>
            {
                new Player {Color = Color.Black},
                new Player {Color = Color.White},
                new Player {Color = Color.Black}
            }.AllHaveDifferentColors());
        }

        [TestMethod]
        public void AllHaveTheCorrectNumberOfCards()
        {
            Assert.IsTrue(new List<Player>
            {
                new Player
                {
                    Cards = new List<Card>
                    {
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid())
                    }
                },
                new Player
                {
                    Cards = new List<Card>
                    {
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid())
                    }
                }
            }.AllHaveTheCorrectNumberOfCards(3, 3));


            Assert.IsFalse(new List<Player>
            {
                new Player
                {
                    Cards = new List<Card>
                    {
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid())
                    }
                },
                new Player
                {
                    Cards = new List<Card>
                    {
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid())
                    }
                }
            }.AllHaveTheCorrectNumberOfCards(3, 3));

            Assert.IsFalse(new List<Player>
            {
                new Player
                {
                    Cards = new List<Card>
                    {
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid())
                    }
                },
                new Player
                {
                    Cards = new List<Card>
                    {
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid()),
                        CardBuilder.Build(Guid.NewGuid())
                    }
                }
            }.AllHaveTheCorrectNumberOfCards(3, 3));
        }

        [TestMethod]
        public void Contains()
        {
            var players = new List<Player>
            {
                new Player {Id = new Guid("DC862B93-D809-4C91-92FC-03881CD0F603")},
                new Player {Id = new Guid("3FA8A80B-7F38-4650-9FB1-0E490A2940F0")},
                new Player {Id = new Guid("DAC079E5-3746-42E9-BD80-E00B39ED68AF")},
                new Player {Id = new Guid("D4DA3175-DCAF-4A63-A665-02709020861C")}
            };

            foreach (var player in players)
                Assert.IsTrue(players.Contains(player.Id));

            for (var i = 0; i < 1000; i++)
                Assert.IsFalse(players.Contains(Guid.NewGuid()));
        }

        [TestMethod]
        public void Random()
        {
            var players = new List<Player>
            {
                new Player {Id = new Guid("DC862B93-D809-4C91-92FC-03881CD0F603")},
                new Player {Id = new Guid("3FA8A80B-7F38-4650-9FB1-0E490A2940F0")},
                new Player {Id = new Guid("DAC079E5-3746-42E9-BD80-E00B39ED68AF")},
                new Player {Id = new Guid("D4DA3175-DCAF-4A63-A665-02709020861C")}
            };

            for (var i = 0; i < 1000; i++)
            {
                var random = players.Random();
                Assert.IsTrue(players.Contains(random.Id));
            }
        }

        [TestMethod]
        public void Next()
        {
            var players = new List<Player>
            {
                new Player {Id = new Guid("DC862B93-D809-4C91-92FC-03881CD0F603")},
                new Player {Id = new Guid("3FA8A80B-7F38-4650-9FB1-0E490A2940F0")},
                new Player {Id = new Guid("DAC079E5-3746-42E9-BD80-E00B39ED68AF")},
                new Player {Id = new Guid("D4DA3175-DCAF-4A63-A665-02709020861C")}
            };

            var currentPlayer = players.First();

            for (int i = 0, j = 1; i < 1000; i++, j = j == players.Count - 1 ? 0 : j + 1)
            {
                var next = currentPlayer = players.Next(currentPlayer);

                Assert.AreEqual(next.Id, players[j].Id);
            }
        }
    }
}