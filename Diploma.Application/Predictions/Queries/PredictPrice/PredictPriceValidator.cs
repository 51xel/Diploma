using FluentValidation;

namespace Diploma.Application.Predictions.Queries.PredictPrice
{
    internal class PredictPriceValidator : AbstractValidator<PredictPriceQuery>
    {
        public PredictPriceValidator()
        {
            RuleFor(query => query.From)
                .LessThan(query => query.To)
                .WithMessage("'From' date must be earlier than 'To' date.");
        }
    }
}
