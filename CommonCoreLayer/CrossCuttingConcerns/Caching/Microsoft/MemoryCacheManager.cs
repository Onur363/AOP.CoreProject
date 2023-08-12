using CommonCoreLayer.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Linq;

namespace CommonCoreLayer.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private IMemoryCache memoryCache;
        public MemoryCacheManager()
        {   
            // Microsoft.Extension.DependencyIjection paketinin yüklenmesi gerekir.
            memoryCache= ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public void Add(string key, object data, int duration)
        {
            //Memory cache e set Metodu ile verilen data yı atıyoruz.
            memoryCache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public void Add(string key, string data, int duration)
        {
            memoryCache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            //C# ta helen yeni özellik ile out referans tipinin nüşüne ihtiyaç duymuyorsak "_" iişareti ile geçebiliyoruz.
            return memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(x => regex.IsMatch(x.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                memoryCache.Remove(key);
            }
        }
    }
}
