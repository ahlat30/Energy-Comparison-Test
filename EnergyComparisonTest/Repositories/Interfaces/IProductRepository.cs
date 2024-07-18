using EnergyComparisonTest.Model;

namespace EnergyComparisonTest.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<ProductDto> CompareCosts(PowerConsumptionRequest consumptionRequest);
    }
}
