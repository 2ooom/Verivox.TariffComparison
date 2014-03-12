using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Verivox.TariffComparison.Tests
{
    [TestClass]
    public class TariffComparatorTests
    {
        private TariffComparator _subject;
        private BasicTariff _basicTariff;
        private PackagedTariff _packagedTariff;

        [TestInitialize]
        public void Initialize()
        {
            _basicTariff = new BasicTariff();
            _packagedTariff = new PackagedTariff();
            _subject = new TariffComparator(new List<ITariff>
            {
                _basicTariff,
                _packagedTariff,
            });
        }

        [TestMethod]
        public void Compare_for_two_tariffs_returns_two_results()
        {
            var results = _subject.Compare(3500).ToList();
            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);
        }

        [TestMethod]
        public void Compare_for_one_tariff_returns_one_results()
        {
            _subject.Tariffs = new List<ITariff>{new BasicTariff()};
            var results = _subject.Compare(3500).ToList();
            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void Compare_for_consumption_3500()
        {
            var results = _subject.Compare(3500).ToList();
            var basicCost = GetBasicTariffCost(results);
            Assert.AreEqual(830, basicCost);
            var packagedCost = GetPackagedTariffCost(results);
            Assert.AreEqual(800, packagedCost);
        }


        [TestMethod]
        public void Compare_for_consumption_4500()
        {
            var results = _subject.Compare(4500).ToList();
            var basicCost = GetBasicTariffCost(results);
            Assert.AreEqual(1050, basicCost);
            var packagedCost = GetPackagedTariffCost(results);
            Assert.AreEqual(950, packagedCost);
        }

        [TestMethod]
        public void Compare_for_consumption_6000()
        {
            var results = _subject.Compare(6000).ToList();
            var basicCost = GetBasicTariffCost(results);
            Assert.AreEqual(1380, basicCost);
            var packagedCost = GetPackagedTariffCost(results);
            Assert.AreEqual(1400, packagedCost);
        }

        #region Helpers

        private decimal GetPackagedTariffCost(IEnumerable<TariffComparisonInfo> results)
        {
            return GetTariffCostByName(results, _packagedTariff.Name);
        }

        private decimal GetBasicTariffCost(IEnumerable<TariffComparisonInfo> results)
        {
            return GetTariffCostByName(results, _basicTariff.Name);
        }
        private static decimal GetTariffCostByName(IEnumerable<TariffComparisonInfo> results, string tarifName)
        {
            var tariffInfo = results.FirstOrDefault(t => t.TariffName == tarifName);
            Assert.IsNotNull(tariffInfo);
            return tariffInfo.AnnnualCost;
        }

        #endregion
    }
}
