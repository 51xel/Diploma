using Diploma.Application.Wallets.Interfaces;
using Diploma.Application.Wallets.Queries.GetAvailableWalletIntegrations;
using Diploma.Domain.Wallets;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Wallets.Queries.GetUserWallet
{
    class GetUserWalletHandler : IRequestHandler<GetUserWalletQuery, ErrorOr<Wallet?>>
    {
        private readonly IWalletRepository _walletRepository;

        public GetUserWalletHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<ErrorOr<Wallet?>> Handle(GetUserWalletQuery request, CancellationToken cancellationToken)
        {
            return await _walletRepository.GetWalletAsync(request.UserId, cancellationToken);
        }
    }
}
