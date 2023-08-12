using CommonCoreLayer.Abstract;
using CommonCoreLayer.Extenions;
using CommonCoreLayer.Utilities.Results;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonCoreLayer.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private IDistributedCache distributedCache;
        private IConfiguration configuration;
        public RedisCacheManager(IDistributedCache distributedCache,IConfiguration configuration)
        {
            this.distributedCache = distributedCache;
            this.configuration = configuration;
        }

        public void Add(string key, object data, int duration)
        {
            var jsonData = JsonConvert.SerializeObject(data);

            distributedCache.SetString(key, jsonData, SetDistributedCacheOption(duration));
        }

        public T Get<T>(string key)
        {
            var redisData = distributedCache.Get(key);
            return DeSerializeData<T>(redisData);
        }

        public object Get(string key)
        {
            var redisData=distributedCache.Get(key);
            return DeSerializeData(redisData);
        }

        public bool IsAdd(string key)
        {
            var redisData = distributedCache.Get(key);
            if (redisData != null)
            {
                return true;
            }
            return false;
        }

        public void Remove(string key)
        {
            distributedCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var redisConection = ConnectionMultiplexer.Connect(configuration.GetSection("RedisConnection").Get<string>());
            var redisServer = redisConection.GetServer(redisConection.GetEndPoints().First());
            var redisDataBase = redisConection.GetDatabase();

            foreach (var key in redisServer.Keys(pattern: pattern))
            {
                redisDataBase.KeyDelete(key);
            }
        }

        private JObject DeSerializeData(byte[] data)
        {
            var jsonData = Encoding.UTF8.GetString(data);
            //jsonData = jsonData.Substring(1, jsonData.Length-1).Substring(0,jsonData.Length-2);
            var value = (JObject)JsonConvert.DeserializeObject(jsonData);

            return value;
        }

        private T DeSerializeData<T>(byte[] data)
        {
            var jsonData = Encoding.UTF8.GetString(data);
            var value = JsonConvert.DeserializeObject<T>(jsonData);

            return value;
        }

        private DistributedCacheEntryOptions SetDistributedCacheOption(int duration)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(duration)
            };

            return options;
        }
    }
}
