using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerPractice.CacheHelper.Services;
using SchedulerPractice.CoreAuthenticationHelper.Models;

namespace SchedulerPractice.CoreAuthenticationHelper.Services
{
    public static class MasterSettingsService
    {
        public const string MasterSettingsKey = "MasterSettings";

        public static MasterSettingsServiceModel GetMasterSettings()
        {
            var cacheHelper = CacheHelperFactory.GetDefinedCacheHelper();
            return cacheHelper.GetCache<MasterSettingsServiceModel>(MasterSettingsKey);
        }

        public static void SetMasterSettings(MasterSettingsServiceModel masterSettings)
        {
            var cacheHelper = CacheHelperFactory.GetDefinedCacheHelper();
            cacheHelper.SetCache(MasterSettingsKey, masterSettings);
        }
    }
}
