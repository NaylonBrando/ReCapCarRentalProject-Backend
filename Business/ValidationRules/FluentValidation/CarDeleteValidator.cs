using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarDeleteValidator : AbstractValidator<Car>
    {
        public CarDeleteValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
        }
    }
}