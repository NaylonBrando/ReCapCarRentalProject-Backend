using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorDeleteValidator : AbstractValidator<Color>
    {
        public ColorDeleteValidator()
        {
            RuleFor(p => p.ColorId).NotEmpty();
        }
    }
}