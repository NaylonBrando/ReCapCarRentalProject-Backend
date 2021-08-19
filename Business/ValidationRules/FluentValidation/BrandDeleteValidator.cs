using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandDeleteValidator : AbstractValidator<Brand>
    {
        public BrandDeleteValidator()
        {
            RuleFor(p => p.BrandId).NotEmpty();
        }
    }
}