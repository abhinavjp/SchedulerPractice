using System;
using SchedulerPractice.CacheHelper.Interfaces;
using SchedulerPractice.CacheHelper.Models;

namespace SchedulerPractice.CacheHelper.Services
{
    public static class CacheHelperFactory
    {
        public static ICacheHelper GetCacheHelper(CacheType cacheType)
        {
            switch (cacheType)
            {
                case CacheType.Memory:
                default:
                    return MemoryCacheHelper.Instance;
            }
        }

        public static ICacheHelper GetDefinedCacheHelper()
        {
            if(!Enum.TryParse<CacheType>(System.Configuration.ConfigurationManager.AppSettings.Get("CacheType"), true, out var cacheType))
            {
                cacheType = CacheType.Memory;
            }
            return GetCacheHelper(cacheType);
        }
    }
}
