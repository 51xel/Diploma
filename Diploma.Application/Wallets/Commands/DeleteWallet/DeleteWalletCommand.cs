using Diploma.Domain.Wallets;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Wallets.Commands.DeleteWallet
{
    public record DeleteWalletCommand(Wallet Wallet) :
        IRequest<ErrorOr<Success>>;
}
