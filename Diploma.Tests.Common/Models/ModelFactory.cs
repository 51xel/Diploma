using Diploma.Domain.Algorithms;
using Diploma.Domain.Models;
using Diploma.Tests.Common.TestConstants;

namespace Diploma.Tests.Common.Models
{
    public static class ModelFactory
    {
        public static Model CreateDefaultModel(
            string? name = null,
            ModelType? type = null,
            TrainingTimeRange? trainingTimeRange = null,
            List<Algorithm>? algorithms = null,
            Guid? id = null)
        {
            return new Model(
                name: name ?? Constants.Models.DefaultName,
                type: type ?? Constants.Models.DefaultType,
                trainingTimeRange: trainingTimeRange ?? Constants.Models.DefaultTimeRange,
                algorithms: algorithms ?? Constants.Models.DefaultAlgorithms.ToList(),
                id: id ?? Guid.NewGuid());
        }
    }
}
