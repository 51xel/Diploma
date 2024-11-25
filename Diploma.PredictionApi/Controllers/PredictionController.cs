using AutoMapper;
using Diploma.Application.Predictions.Queries;
using Diploma.Contracts.Predictions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> PredictPriceAsync([FromBody][Required] PredictPriceRequest predictPriceRequest)
        {
            var query = new PredictPriceQuery(
                predictPriceRequest.ModelId, 
                predictPriceRequest.From, 
                predictPriceRequest.To);

            var predictedPrices = await _mediator.Send(query);

            if (predictedPrices.IsError)
            {
                return Problem(predictedPrices.Errors);
            }

            return Ok(_mapper.Map<IEnumerable<PredictPriceResponse>>(predictedPrices.Value));
        }
    }
}
