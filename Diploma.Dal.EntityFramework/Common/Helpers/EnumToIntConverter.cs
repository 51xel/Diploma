using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diploma.Dal.EntityFramework.Common.Helpers
{
    internal class EnumToIntConverter<T> : EnumToNumberConverter<T, int> where T : struct, Enum {}
}
