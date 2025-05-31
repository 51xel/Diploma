using Diploma.Domain.Wallets;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Wallets.Queries.GetUserWallet
{
    public record GetUserWalletQuery(Guid UserId) :
        IRequest<ErrorOr<Wallet?>>;
}
