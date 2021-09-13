using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FindeksScoreUpdateValidator : AbstractValidator<FindeksScore>
    {
        public FindeksScoreUpdateValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.Score).NotEmpty().InclusiveBetween(0, 2000);
        }
    }
}