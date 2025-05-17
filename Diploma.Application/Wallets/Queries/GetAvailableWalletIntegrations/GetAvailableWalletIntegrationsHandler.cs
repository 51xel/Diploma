using Diploma.Domain.Wallets;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Wallets.Queries.GetAvailableWalletIntegrations
{
    class GetAvailableWalletIntegrationsHandler : 
        IRequestHandler<GetAvailableWalletIntegrationsQuery, ErrorOr<IEnumerable<Integration>>>
    {
        public Task<ErrorOr<IEnumerable<Integration>>> Handle(GetAvailableWalletIntegrationsQuery request, CancellationToken cancellationToken)
        {
            var integrations = Enum.GetValues(typeof(Integration))
                .Cast<Integration>()
                .Where(i => i != Integration.None);

            return Task.FromResult(integrations.ToErrorOr());
        }
    }
}
