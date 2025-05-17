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
            _applicationDbContext.TradePairs.Add(tradePair);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
