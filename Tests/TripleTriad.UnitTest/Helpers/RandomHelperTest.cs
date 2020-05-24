using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripleTriad.Helpers;

namespace TripleTriad.UnitTest.Helpers
{
    [TestClass]
    public class RandomHelperTest
    {
        [TestMethod]
        public void Lorem()
        {
            var anyTrue = false;
            var anyFalse = false;

            for (var i = 0; i < 1000; i++)
            {
                var value = RandomHelper.NextBool(0.5);

                anyTrue |= value;
                anyFalse |= !value;
            }

            Assert.IsTrue(anyTrue);
            Assert.IsTrue(anyFalse);
        }
    }
}