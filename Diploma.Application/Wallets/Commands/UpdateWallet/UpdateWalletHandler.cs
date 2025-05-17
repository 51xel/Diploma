using Diploma.Application.Wallets.Interfaces;
using Diploma.Domain.Wallets;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Wallets.Commands.UpdateWallet
{
    class UpdateWalletHandler : IRequestHandler<UpdateWalletCommand, ErrorOr<Wallet>>
    {
        private readonly IWalletRepository _walletRepository;

        public UpdateWalletHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<ErrorOr<Wallet>> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
        {
            return await _walletRepository.UpdateWalletAsync(request.Wallet, cancellationToken);
        }
    }
}
