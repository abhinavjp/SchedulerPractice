using Newtonsoft.Json;
using SchedulerPractice.CacheHelper.Interfaces;
using SchedulerPractice.CacheHelper.Models;
using System;
using System.Collections.Generic;

namespace SchedulerPractice.CacheHelper.Services
{
    public class MemoryCacheHelper : ICacheHelper
    {
        private readonly Dictionary<string, string> _memoryCache;
        private static ICacheHelper _instance;
        private static object _lockObject = new object();
        private MemoryCacheHelper()
        {
            _memoryCache = new Dictionary<string, string>();
        }
        public static ICacheHelper Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_lockObject)
                    {
                        if(_instance == null)
                        {
                            _instance = new MemoryCacheHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        public CacheType CacheType => CacheType.Memory;

        public void SetCache<T>(string key, T value)
        {
            var jsonValue = JsonConvert.SerializeObject(value);
            _memoryCache[key] = jsonValue;
        }

        public T GetCache<T>(string key)
        {
            if (!_memoryCache.ContainsKey(key))
                return default;
            return JsonConvert.DeserializeObject<T>(_memoryCache[key]);
        }
    }
}
