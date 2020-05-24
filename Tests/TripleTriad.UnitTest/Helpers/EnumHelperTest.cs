using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripleTriad.Helpers;

namespace TripleTriad.UnitTest.Helpers
{
    [TestClass]
    public class EnumHelperTest
    {
        [TestMethod]
        public void RandomValue()
        {
            var enums = EnumHelper.GetValues<Element>().ToList();

            for (var i = 0; i < 1000; i++)
            {
                var enumValue = EnumHelper.RandomValue<Element>();

                Assert.IsTrue(enums.Contains(enumValue));
            }
        }

        [TestMethod]
        public void GetValues()
        {
            var enums = EnumHelper.GetValues<Element>();

            Assert.AreNotEqual(0, enums.Count());
        }
    }
}