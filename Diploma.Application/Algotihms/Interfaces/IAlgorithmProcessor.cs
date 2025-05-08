using Diploma.Domain.Algorithms;
using Diploma.Domain.TradeActions;

namespace Diploma.Application.Algotihms.Interfaces
{
    public interface IAlgorithmProcessor
    {
        public AlgorithmType Type { get; }

        public Task<TradePair?> ProcessAlgorithmAsync(Algorithm algorithm);
    }
}
