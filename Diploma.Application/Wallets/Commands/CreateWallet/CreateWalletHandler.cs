using Diploma.Application.Users.Interfaces;
using Diploma.Application.Wallets.Interfaces;
using Diploma.Domain.Wallets;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Wallets.Commands.CreateWallet
{
    class CreateWalletHandler : IRequestHandler<CreateWalletCommand, ErrorOr<Wallet>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;

        public CreateWalletHandler(
            IUserRepository userRepository,
            IWalletRepository walletRepository)
        {
            _userRepository = userRepository;
            _walletRepository = walletRepository;
        }

        public async Task<ErrorOr<Wallet>> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.UserId, cancellationToken);

            if (user is null)
            {
                return Error.Failure(description: "User is not exists");
            }

            var newWallet = new Wallet(user.Id, request.Integration, request.ApiKey);

            var userWallet = await _walletRepository.GetWalletAsync(user.Id, cancellationToken);

            if (userWallet is not null)
            {
                return Error.Failure(description: "Wallet is already exists");
            }

            await _walletRepository.CreateAsync(newWallet, cancellationToken);

            return newWallet;
        }
    }
}
