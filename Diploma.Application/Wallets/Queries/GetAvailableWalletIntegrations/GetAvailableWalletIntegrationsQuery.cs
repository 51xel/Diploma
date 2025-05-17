using Diploma.Domain.Wallets;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Wallets.Queries.GetAvailableWalletIntegrations
{
    public record GetAvailableWalletIntegrationsQuery() :
        IRequest<ErrorOr<IEnumerable<Integration>>>;
}
