namespace Verivox.TariffComparison
{
    /// <summary>
    /// Base interface for electricity plan products
    /// </summary>
    public interface ITariff
    {
        /// <summary>
        /// Gets tarif name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Calculates annual costs for current tariff and consumption (€/year)
        /// </summary>
        /// <param name="consumption">Annual consumption (kWh/year)</param>
        /// <returns>Annual costs for current tariff and consumption (€/year)</returns>
        decimal GetAnnualCost(decimal consumption);
    }
}
