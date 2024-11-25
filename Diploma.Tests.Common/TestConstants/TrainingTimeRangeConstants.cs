using Diploma.Domain.Common.Models;

namespace Diploma.Tests.Common.TestConstants
{
    public static partial class Constants 
    {
        public static class TrainingTimeRange
        {
            public static readonly DateTime DefaultFrom = DateTime.Now.AddDays(-7);
            public static readonly DateTime DefaultTo = DateTime.Now;
            public static readonly TimeRangeType DefaultTimeRangeType = TimeRangeType.ByDays;
            public static IEnumerable<object[]> ValidationData => new List<object[]>
            {   
                //                                      d   h  m  sf st
                new object[] { TimeRangeType.BySeconds, -5, 0, 0, 0, 1, true },
                new object[] { TimeRangeType.BySeconds, 0, 0, 0, 0, 0.9, false },
                new object[] { TimeRangeType.ByMinutes, -1, 0, 0, 0, 60, true },
                new object[] { TimeRangeType.ByMinutes, -1, 0, 0, 0, 59, false },
                new object[] { TimeRangeType.ByHours, 0, -2, 0, 0, 3600, true },
                new object[] { TimeRangeType.ByHours, 0, -1, 0, 0, 3599, false },
                new object[] { TimeRangeType.ByDays, -7, 0, 0, 0, 86400, true },
                new object[] { TimeRangeType.ByDays, -1, 0.5, 0, 0, 60, false },
            };
        }
    }
}
