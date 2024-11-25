using Diploma.Domain.Models;
using Diploma.Tests.Common.TestConstants;

namespace Diploma.Tests.Common.Models
{
    public static class TrainingTimeRangeFactory
    {
        public static TrainingTimeRange CreateDefault()
        {
            return new TrainingTimeRange(
                Constants.TrainingTimeRange.DefaultTimeRangeType,
                Constants.TrainingTimeRange.DefaultFrom,
                Constants.TrainingTimeRange.DefaultTo);
        }
    }
}
