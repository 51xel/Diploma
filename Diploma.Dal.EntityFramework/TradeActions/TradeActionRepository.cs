using Diploma.Application.TradeActions.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Domain.Actions;

namespace Diploma.Dal.EntityFramework.TradeActions
{
    class TradeActionRepository : ITradeActionRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TradeActionRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateAsync(TradeAction tradeAction)
        {
            await _applicationDbContext.TradeActions.AddAsync(tradeAction);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
