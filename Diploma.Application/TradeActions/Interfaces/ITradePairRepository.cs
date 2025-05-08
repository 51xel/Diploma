using Diploma.Domain.TradeActions;

namespace Diploma.Application.TradeActions.Interfaces
{
    public interface ITradePairRepository
    {
        Task CreateAsync(TradePair tradePair);
    }
}
