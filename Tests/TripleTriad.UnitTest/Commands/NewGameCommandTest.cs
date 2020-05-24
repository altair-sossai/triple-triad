using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripleTriad.Commands;

namespace TripleTriad.UnitTest.Commands
{
    [TestClass]
    public class NewGameCommandTest
    {
        [TestMethod]
        public void Rows()
        {
            var command = new NewGameCommand();

            for (var rows = -1000; rows <= 0; rows++)
            {
                command.Rows = rows;
                Assert.AreEqual(1, command.Rows);
            }

            for (var rows = 1; rows <= 1000; rows++)
            {
                command.Rows = rows;
                Assert.AreEqual(rows, command.Rows);
            }
        }

        [TestMethod]
        public void Columns()
        {
            var command = new NewGameCommand();

            for (var columns = -1000; columns <= 0; columns++)
            {
                command.Columns = columns;
                Assert.AreEqual(1, command.Columns);
            }

            for (var columns = 1; columns <= 1000; columns++)
            {
                command.Columns = columns;
                Assert.AreEqual(columns, command.Columns);
            }
        }

        [TestMethod]
        public void ProbabilityOfElementary()
        {
            var command = new NewGameCommand();

            for (var probability = -1000d; probability <= 0; probability += 0.1246)
            {
                command.ProbabilityOfElementary = probability;
                Assert.AreEqual(0, command.ProbabilityOfElementary);
            }

            for (var probability = 0d; probability <= 1; probability += 0.1246)
            {
                command.ProbabilityOfElementary = probability;
                Assert.AreEqual(probability, command.ProbabilityOfElementary);
            }

            for (var probability = 1d; probability <= 1000; probability += 0.1246)
            {
                command.ProbabilityOfElementary = probability;
                Assert.AreEqual(1, command.ProbabilityOfElementary);
            }
        }
    }
}