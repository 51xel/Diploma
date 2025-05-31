using Diploma.Application.Wallets.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Domain.Wallets;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Dal.EntityFramework.Wallets
{
    class WalletRepository : IWalletRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public WalletRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateAsync(Wallet wallet, CancellationToken cancellationToken)
        {
            _applicationDbContext.Wallets.Add(wallet);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteWalletAsync(Wallet wallet, CancellationToken cancellationToken)
        {
            _applicationDbContext.Wallets.Remove(wallet);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Wallet?> GetWalletAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Wallets.FirstOrDefaultAsync(wallet => wallet.UserId == userId, cancellationToken);
        }

        public async Task<Wallet> UpdateWalletAsync(Wallet wallet, CancellationToken cancellationToken)
        {
            _applicationDbContext.Wallets.Update(wallet);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return wallet;
        }
    }
}
