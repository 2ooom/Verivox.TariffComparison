namespace Verivox.TariffComparison
{
    public class PackagedTariff : ITariff
    {
        private const string ProductName = "Packaged tariff";
        private const decimal PrepaidAnnualCost = 800;
        private const decimal PrepaidkWhLimit = 4000;
        private const decimal ExtraConsumptionCostPerkWh = 0.3m;
        public PackagedTariff()
        {
            Name = ProductName;
        }

        public string Name { get; private set; }
        public decimal GetAnnualCost(decimal consumption)
        {
            if (consumption <= PrepaidkWhLimit)
            {
                return PrepaidAnnualCost;
            }
            return PrepaidAnnualCost + (consumption - PrepaidkWhLimit)*ExtraConsumptionCostPerkWh;
        }
    }
}
