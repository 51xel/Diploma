using AutoMapper;
using Diploma.Application.Predictions.Queries.PredictPrice;
using Diploma.Contracts.Predictions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Diploma.PredictionApi.Controllers
{
    [Route("api/prediction")]
    [ApiController]
    public class PredictionController : ApiControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public PredictionController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Predicts the price of an asset based on the provided model and time range.
        /// </summary>
        /// <param name="predictPriceRequest">The request containing the model ID and time range.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>
        /// Returns a list of predicted prices or an error response.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<PredictPriceResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PredictPriceAsync(
            [FromBody][Required] PredictPriceRequest predictPriceRequest,
            CancellationToken cancellationToken)
        {
            var query = new PredictPriceQuery(
                predictPriceRequest.ModelId,
                predictPriceRequest.From,
                predictPriceRequest.To);

            var predictedPrices = await _mediator.Send(query, cancellationToken);

            if (predictedPrices.IsError)
            {
                return Problem(predictedPrices.Errors);
            }

            return Ok(_mapper.Map<IEnumerable<PredictPriceResponse>>(predictedPrices.Value));
        }
    }
}
