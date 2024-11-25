using Diploma.Domain.Common.Models;
using Diploma.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diploma.Dal.EntityFramework.Common.Helpers
{
    internal static class ValueConverterHelper
    {
        public static ValueConverter<ModelType, string> GetConverterForModelType()
        {
            return new ValueConverter<ModelType, string>(
                v => ((int)v).ToString(),
                v => (ModelType)Enum.Parse(typeof(ModelType), v)
            );
        }

        public static ValueConverter<TimeRangeType, string> GetConverterForTrainingTimeRangeType()
        {
            return new ValueConverter<TimeRangeType, string>(
                v => ((int)v).ToString(),
                v => (TimeRangeType)Enum.Parse(typeof(TimeRangeType), v)
            );
        }
    }
}
