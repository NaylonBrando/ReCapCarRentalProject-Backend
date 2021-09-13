using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FindeksScoreValidator : AbstractValidator<FindeksScore>
    {
        public FindeksScoreValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.Score).NotEmpty().InclusiveBetween(0,2000);
        }
    }
}