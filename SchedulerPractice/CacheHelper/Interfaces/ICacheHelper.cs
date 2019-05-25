using SchedulerPractice.CacheHelper.Models;

namespace SchedulerPractice.CacheHelper.Interfaces
{
    public interface ICacheHelper
    {
        CacheType CacheType { get; }
        void SetCache<T>(string key, T value);
        T GetCache<T>(string key);
    }
}
