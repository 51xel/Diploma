namespace Diploma.Dal.RedisCache.Common.Settings
{
    class RedisCacheSettings
    {
        public required TimeSpan ExpirationTime { get; init; }
    }
}
