namespace Diploma.Dal.RedisCache.Common.Settings
{
    internal class RedisCacheSettings
    {
        public required TimeSpan ExpirationTime { get; init; }
    }
}
