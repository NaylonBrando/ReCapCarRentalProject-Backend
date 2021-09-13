using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FindeksScoreDeleteValidator : AbstractValidator<FindeksScore>
    {
        public FindeksScoreDeleteValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}