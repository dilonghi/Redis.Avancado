using StackExchange.Redis;
using System;

namespace Diego.Redis.WebApps.RedisService
{
    public interface IRedisService
    {
        IDatabase GetDatabase();
    }
}
