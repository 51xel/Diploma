using Diploma.Domain.Actions;

namespace Diploma.Application.TradeActions.Interfaces
{
    public interface ITradeActionRepository
    {
        Task CreateAsync(TradeAction tradeAction);
    }
}
