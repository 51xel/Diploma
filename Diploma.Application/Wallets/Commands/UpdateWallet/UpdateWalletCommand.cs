using Diploma.Domain.Wallets;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Wallets.Commands.UpdateWallet
{
    public record UpdateWalletCommand(Wallet Wallet) :
        IRequest<ErrorOr<Wallet>>;
}
