using Diploma.Domain.Users;
using Diploma.Domain.Wallets;

namespace Diploma.Application.Wallets.Interfaces
{
    public interface IWalletRepository
    {
        Task CreateAsync(Wallet wallet, CancellationToken cancellationToken);
        Task<Wallet?> GetWalletAsync(Guid userId, CancellationToken cancellationToken);
        Task<Wallet> UpdateWalletAsync(Wallet wallet, CancellationToken cancellationToken);
        Task DeleteWalletAsync(Wallet wallet, CancellationToken cancellationToken);
    }
}
