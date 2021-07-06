using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.ModelYear).GreaterThan(2015);
            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage("Araba fiyati 0dan büyük olmalidir!");
            RuleFor(p => p.CarName).MinimumLength(2).WithMessage("Araba ismi 2 karakterden uzun olmalidir");
        }
    }
}