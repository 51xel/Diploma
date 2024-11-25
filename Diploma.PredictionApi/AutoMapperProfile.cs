using AutoMapper;
using Diploma.Contracts.Predictions;
using Diploma.Domain.Predictions;

namespace Diploma.PredictionApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Prediction, PredictPriceResponse>();
        }
    }
}
