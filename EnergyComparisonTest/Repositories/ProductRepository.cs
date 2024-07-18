using EnergyComparisonTest.Domain.Interfaces;
using EnergyComparisonTest.Domain;
using EnergyComparisonTest.Model;
using EnergyComparisonTest.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EnergyComparisonTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {

        }

        public List<ProductDto> CompareCosts(PowerConsumptionRequest consumptionRequest)
        {
            List<ProductDto> product = new List<ProductDto>();

            SampleProducts().ForEach(data =>
            {
                product.Add(new ProductDto()
                {
                    AnnualCosts = data.ProductProcessor.GetAnnualCosts(data, consumptionRequest.Consumption),
                    TariffName = data.TariffName
                });
            });

            //sorted by costs in ascending order.
            return product.OrderBy(x => x.AnnualCosts).ToList();
        }

        /// <summary>
        /// TODO: Sample products for testing
        /// </summary>
        public List<ITariff> SampleProducts()
        {

            List<ITariff> tariff = new List<ITariff>
            {
                new Basic {TariffName="Basic electricity tariff",Amount=5,Base=12,PricePerKwh=0.22m },
                new Packaged {TariffName="Packaged tariff",Amount=800,Base=1,PricePerKwh=0.30m },
            };

            return tariff;
        }
    }
}
