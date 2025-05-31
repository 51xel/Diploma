using Diploma.Application.Wallets.Interfaces;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Wallets.Commands.DeleteWallet
{
    class DeleteWalletHandler : IRequestHandler<DeleteWalletCommand, ErrorOr<Success>>
    {
        private readonly IWalletRepository _walletRepository;

        public DeleteWalletHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<ErrorOr<Success>> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            await _walletRepository.DeleteWalletAsync(request.Wallet, cancellationToken);

            return new Success();
        }
    }
}
