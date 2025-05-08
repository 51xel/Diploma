using Diploma.Application.TradeActions.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Domain.Actions;
using Diploma.Domain.TradeActions;

namespace Diploma.Dal.EntityFramework.TradeActions
{
    class TradePairRepository : ITradePairRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TradePairRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateAsync(TradePair tradePair)
        {
            await _applicationDbContext.TradePairs.AddAsync(tradePair);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
