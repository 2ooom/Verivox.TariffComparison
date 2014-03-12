using System.Collections.Generic;
using System.Linq;

namespace Verivox.TariffComparison
{
    public class TariffComparator : ITariffComparator
    {
        public IEnumerable<ITariff> Tariffs;

        public TariffComparator(IEnumerable<ITariff> tariffs)
        {
            Tariffs = tariffs;
        }

        public IEnumerable<TariffComparisonInfo> Compare(decimal consumption)
        {
            return Tariffs.Select(tariff => new TariffComparisonInfo
            {
                AnnnualCost = tariff.GetAnnualCost(consumption),
                TariffName = tariff.Name
            });
        }
    }
}
