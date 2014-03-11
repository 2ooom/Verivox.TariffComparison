namespace Verivox.TariffComparison
{
    public class BasicTariff : ITariff
    {
        private const string ProductName = "Basic electricity tariff";
        private const decimal BaseAnnualCost = 5 * 12;
        private const decimal CostPerkWh = 0.22m;
        public BasicTariff()
        {
            Name = ProductName;
        }

        public string Name { get; private set; }
        public decimal GetAnnualCost(decimal consumption)
        {
            return BaseAnnualCost + CostPerkWh*consumption;
        }
    }
}
