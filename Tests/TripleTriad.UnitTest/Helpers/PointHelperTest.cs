using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripleTriad.Helpers;

namespace TripleTriad.UnitTest.Helpers
{
    [TestClass]
    public class PointHelperTest
    {
        [TestMethod]
        public void MaxMin()
        {
            for (var point = -1000; point <= 0; point++)
            {
                Assert.AreEqual(0, PointHelper.MaxMin(point));
                Assert.AreEqual(0, (int?) PointHelper.MaxMin(point));
            }

            for (var point = 0; point <= 10; point++)
            {
                Assert.AreEqual(point, PointHelper.MaxMin(point));
                Assert.AreEqual(point, (int?) PointHelper.MaxMin(point));
            }

            for (var point = 10; point <= 1000; point++)
            {
                Assert.AreEqual(10, PointHelper.MaxMin(point));
                Assert.AreEqual(10, (int?) PointHelper.MaxMin(point));
            }

            Assert.IsNull(PointHelper.MaxMin(null));
        }
    }
}