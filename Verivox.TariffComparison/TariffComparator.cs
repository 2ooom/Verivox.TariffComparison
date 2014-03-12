using System.Collections.Generic;
using System.Linq;

namespace Verivox.TariffComparison
{
    public class TariffComparator : ITariffComparator
    {
        private readonly IEnumerable<ITariff> _tariffs;

        public TariffComparator()
        {
            _tariffs = new List<ITariff>
            {
                new BasicTariff(),
                new PackagedTariff()
            };
        }

        public IEnumerable<TariffComparisonInfo> Compare(decimal consumption)
        {
            return _tariffs.Select(tariff => new TariffComparisonInfo
            {
                AnnnualCost = tariff.GetAnnualCost(consumption),
                TariffName = tariff.Name
            });
        }
    }
}
