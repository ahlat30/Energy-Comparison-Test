using EnergyComparisonTest.Model;
using EnergyComparisonTest.Validations;

namespace EnergyComparisonTest.Helpers
{
    public class FluentValidation
    {
        public static async Task ValidateConsumptionRequest(PowerConsumptionRequest request)
        {
            var validator = await new PowerConsumptionRequestValidation().ValidateAsync(request);
            if (!validator.IsValid)
                throw new ArgumentException(validator.ToString());
        }
    }
}
