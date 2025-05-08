using Castle.Core.Logging;
using Diploma.Application.Algotihms.Commands.ProcessAlgorithm;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmProcessing.Functions
{
    public class AlgorithmProcessing
    {
        private readonly ISender _mediator;

        public AlgorithmProcessing(ISender mediator)
        {
            _mediator = mediator;
        }


        [FunctionName("AlgorithmProcessing")]
        public async Task Run(
            [TimerTrigger("* * 12 * * *"
            #if DEBUG
            , RunOnStartup=true
            #endif
            )] TimerInfo myTimer,
            Microsoft.Extensions.Logging.ILogger log, 
            CancellationToken cancellationToken)
        {
            var command = new ProcessAlgorithmsCommand();

            try
            {
                await _mediator.Send(command, cancellationToken);
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
            }
        }
    }
}
