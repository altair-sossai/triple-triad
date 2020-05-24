using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TripleTriad.UnitTest
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void ProbabilityOfElementary()
        {
            var configuration = new Configuration();

            for (var probability = -1000d; probability <= 0; probability += 0.1246)
            {
                configuration.ProbabilityOfElementary = probability;
                Assert.AreEqual(0, configuration.ProbabilityOfElementary);
            }

            for (var probability = 0d; probability <= 1; probability += 0.1246)
            {
                configuration.ProbabilityOfElementary = probability;
                Assert.AreEqual(probability, configuration.ProbabilityOfElementary);
            }

            for (var probability = 1d; probability <= 1000; probability += 0.1246)
            {
                configuration.ProbabilityOfElementary = probability;
                Assert.AreEqual(1, configuration.ProbabilityOfElementary);
            }
        }
    }
}