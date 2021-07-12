﻿using System;

namespace Diego.Redis.WebApps.RedisService
{
    public interface ICache
    {
        bool Add(string key, object obj, TimeSpan? expiry = null);

        T Get<T>(string key);

        bool Delete(string key);

        TimeSpan? KeyTimeToLive(string key);
    }
}
