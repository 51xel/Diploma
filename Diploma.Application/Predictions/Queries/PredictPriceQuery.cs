using Diploma.Domain.Predictions;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Predictions.Queries
{
    public record PredictPriceQuery(Guid ModelId, DateTime From, DateTime To) : 
        IRequest<ErrorOr<IEnumerable<Prediction>>>;
}
