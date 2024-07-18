using EnergyComparisonTest.Controllers;
using EnergyComparisonTest.Model;
using EnergyComparisonTest.Repositories;
using EnergyComparisonTest.Repositories.Interfaces;
using NUnit.Framework;
using Xunit;

namespace EnergyComparison.Test
{
    public class UnitTest1
    {
        private readonly IProductRepository _mockRepo;
        ProductController _controller;
        public UnitTest1()
        {
            _mockRepo = new ProductRepository();
            _controller = new ProductController(_mockRepo);
        }
        [Test]
        public async Task TestPrice()
        {
            //Arrange
            //Act
            var result = await _controller.CompareCostsAsync(new PowerConsumptionRequest() { Consumption=3500 });

            // Assert
            Xunit.Assert.IsType<List<ProductDto>>(result);
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(2, result.Count);
        }
    }
}