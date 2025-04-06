using AutoMapper;
using Diploma.Application.Predictions.Queries.PredictPrice;
using Diploma.Contracts.Predictions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        [HttpPost]
        [SwaggerOperation("Predicts the price of an asset based on the provided model and time range.")]
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
