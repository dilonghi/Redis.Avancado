//using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Diego.Redis.WebApi.RedisService
{
    public class RedisCache: ICache
    {
        private readonly IDatabase redis;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisCache(IConnectionMultiplexer connectionMultiplexer)
        { 
            this.redis = connectionMultiplexer.GetDatabase();
            _connectionMultiplexer = connectionMultiplexer;
        }


        #region STRING

        public bool Add(string key, object obj, TimeSpan? expiry = null)
            => redis.StringSet(key, JsonSerializer.Serialize(obj), expiry);

        public T Get<T>(string key)
        {
            var objSerialized = redis.StringGet(key);
            if (objSerialized.IsNull)
                return default;
            return JsonSerializer.Deserialize<T>(objSerialized);
        }

        #endregion


        #region LISTA

        public void AddList<T>(string key, IEnumerable<T> collection)
        {
            redis.ListRightPush(key, collection.Select(x => (RedisValue)JsonSerializer.Serialize(x)).ToArray());
        }

        public void AddListFirst<T>(string key, T item)
        {
            redis.ListLeftPush(key, JsonSerializer.Serialize(item));
        }
        
        public void AddListLast<T>(string key, T item)
        {
            redis.ListRightPush(key, JsonSerializer.Serialize(item));
        }

        public IEnumerable<T> GetList<T>(string key)
        {
            var lista = new List<T>();

            foreach (var item in redis.ListRange(key))
            {
                var itemObj = JsonSerializer.Deserialize<T>(item.ToString());
                lista.Add(itemObj);
            }

            return lista;
        }

        public T GetListFirst<T>(string key)
        {
            var obj = redis.ListRange(key, 0)[0];
            return JsonSerializer.Deserialize<T>(obj.ToString());
        }

        public T GetListLast<T>(string key)
        {
            var obj = redis.ListRange(key, -1)[0];
            return JsonSerializer.Deserialize<T>(obj.ToString());
        }

        #endregion


        #region HASH


        #endregion


        public string[] GetKeys(string filtro)
        {
            var endpoint = (System.Net.DnsEndPoint)_connectionMultiplexer.GetEndPoints()[0];
            var server = _connectionMultiplexer.GetServer(endpoint.Host, endpoint.Port);

            var keys = server.Keys(pattern: $"{ filtro }*").ToArray();

            var keysList = new List<string>();

            foreach (var key in keys)
            {
                keysList.Add(key.ToString());
            }

            return keysList.ToArray();
        }


        public bool Delete(string key)
            => redis.KeyDelete(key);

        public TimeSpan? KeyTimeToLive(string key)
            => redis.KeyTimeToLive(key);



    }
}
