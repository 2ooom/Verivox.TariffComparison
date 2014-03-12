using System.Collections.Generic;

namespace Verivox.TariffComparison
{
    /// <summary>
    /// Interface for comparator, which provides tariff comparison functionality
    /// </summary>
    public interface ITariffComparator
    {
        /// <summary>
        /// Claculates consumpton for all available tariffs and return list of <seealso cref="TariffComparisonInfo"/>
        /// items for each available tariff
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns></returns>
        IEnumerable<TariffComparisonInfo> Compare(decimal consumption);
    }
}
