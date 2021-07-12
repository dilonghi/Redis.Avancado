using StackExchange.Redis;
using System;

namespace Diego.Redis.WebApi.RedisService
{
    public interface IRedisService
    {
        IDatabase GetDatabase();
    }
}
