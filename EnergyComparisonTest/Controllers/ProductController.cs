using EnergyComparisonTest.Model;
using EnergyComparisonTest.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static EnergyComparisonTest.Helpers.FluentValidation;
namespace EnergyComparisonTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("TariffCosts")]
        [HttpGet]
        public async Task<List<ProductDto>> CompareCostsAsync([FromQuery] PowerConsumptionRequest Request)
        {
            await ValidateConsumptionRequest(Request);
            var data =  _productRepository.CompareCosts(Request);
            return data;
        }
    }
}
