using Diploma.Domain.Models;
using Diploma.Tests.Common.Models;

namespace Diploma.Tests.Common.TestConstants
{
    public static partial class Constants
    {
        public static class Models
        {
            public static readonly string DefaultName = "Default Model";
            public static readonly ModelType DefaultType = ModelType.SARIMA;
            public static readonly Domain.Models.TrainingTimeRange DefaultTimeRange = TrainingTimeRangeFactory.CreateDefault();
        }
    }
}
