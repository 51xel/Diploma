using Diploma.Domain.Wallets;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Wallets.Commands.CreateWallet
{
    public record CreateWalletCommand(Guid UserId, Integration Integration, string ApiKey) :
        IRequest<ErrorOr<Wallet>>;
}
