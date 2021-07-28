using System;
using System.Collections.Generic;

namespace Diego.Redis.WebApi.RedisService
{
    public interface ICache
    {
        bool Add(string key, object obj, TimeSpan? expiry = null);

        T Get<T>(string key);

        string[] GetKeys(string filtro);

        bool Delete(string key);

        TimeSpan? KeyTimeToLive(string key);


        void AddList<T>(string key, IEnumerable<T> collection);
        void AddListFirst<T>(string key, T item);
        void AddListLast<T>(string key, T item);
        IEnumerable<T> GetList<T>(string key);
        T GetListFirst<T>(string key);
        T GetListLast<T>(string key);
        

    }
}
