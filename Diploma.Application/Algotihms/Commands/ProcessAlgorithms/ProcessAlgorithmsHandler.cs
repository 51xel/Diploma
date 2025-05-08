using Diploma.Application.Algotihms.Interfaces;
using Diploma.Application.TradeActions.Interfaces;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Algotihms.Commands.ProcessAlgorithm
{
    class ProcessAlgorithmsHandler : IRequestHandler<ProcessAlgorithmsCommand, ErrorOr<Success>>
    {
        private readonly IAlgorithmService _algorithmService;
        private readonly IAlgorithmProcessorFactory _algorithmProcessorFactory;
        private readonly ITradeActionRepository _tradeActionRepository;
        private readonly ITradePairRepository _tradePairRepository;

        public ProcessAlgorithmsHandler(
            IAlgorithmService algorithmService,
            IAlgorithmProcessorFactory algorithmProcessorFactory,
            ITradeActionRepository tradeActionRepository,
            ITradePairRepository tradePairRepository)
        {
            _algorithmService = algorithmService;
            _algorithmProcessorFactory = algorithmProcessorFactory;
            _tradeActionRepository = tradeActionRepository;
            _tradePairRepository = tradePairRepository;
        }

        public async Task<ErrorOr<Success>> Handle(ProcessAlgorithmsCommand request, CancellationToken cancellationToken)
        {
            var availableAlgorithms = await _algorithmService.GetAvailableAlgorithmsForProcessingAsync();

            foreach (var algorithm in availableAlgorithms)
            {
                var tradePair = await _algorithmProcessorFactory
                    .GetAlgorithmProcessor(algorithm.Type)
                    .ProcessAlgorithmAsync(algorithm);

                if (tradePair is null)
                {
                    continue;
                }

                await _tradeActionRepository.CreateAsync(tradePair.BuyAction);
                await _tradeActionRepository.CreateAsync(tradePair.SellAction);
                await _tradePairRepository.CreateAsync(tradePair);
            }

            return new Success();
        }
    }
}
