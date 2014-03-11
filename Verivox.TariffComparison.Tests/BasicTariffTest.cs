using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Verivox.TariffComparison.Tests
{
    [TestClass]
    public class BasicTariffTest
    {
        private BasicTariff _subject;

        [TestInitialize]
        public void Initialize()
        {
            _subject = new BasicTariff();
        }

        [TestMethod]
        public void Name_Is_Correct()
        {
            Assert.AreEqual("Basic electricity tariff", _subject.Name);
        }

        [TestMethod]
        public void GetAnnualCost_for_consumption_3500()
        {
            var cost = _subject.GetAnnualCost(3500);
            Assert.AreEqual(830, cost);
        }

        [TestMethod]
        public void GetAnnualCost_for_consumption_4500()
        {
            var cost = _subject.GetAnnualCost(4500);
            Assert.AreEqual(1050, cost);
        }

        [TestMethod]
        public void GetAnnualCost_for_consumption_6000()
        {
            var cost = _subject.GetAnnualCost(6000);
            Assert.AreEqual(1380, cost);
        }
    }
}
