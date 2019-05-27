using System;
using System.Collections.Generic;
using System.Linq;
using SchedulerPractice.CacheHelper.Services;
using SchedulerPractice.CoreAuthenticationHelper.Interfaces;
using SchedulerPractice.CoreAuthenticationHelper.Models;

namespace SchedulerPractice.CoreAuthenticationHelper.Services
{
    public static class UserSettingsManipulatorService
    {
        public static List<IUserSettingsViewModel> GetAllUsers()
        {
            return GetUsers(null);
        }

        public static List<IUserSettingsViewModel> GetLoggedInUsers()
        {
            return GetUsers(f => f.IsLoggedIn);
        }

        public static List<IUserSettingsViewModel> GetPortalTypeUsers(string portalType)
        {
            return GetUsers(f => f.PortalType == portalType);
        }

        public static List<IUserSettingsViewModel> GetAccountWiseUsers(int accountId)
        {
            return GetUsers(f => f.AccountId == accountId);
        }

        public static List<IUserSettingsViewModel> GetUsers(Func<IUserSettingsViewModel, bool> userSettingsFilterCondition)
        {
            return GetUsers<IUserSettingsViewModel>(userSettingsFilterCondition);
        }

        public static List<T> GetUsers<T>(Func<T, bool> userSettingsFilterCondition) where T: class, IUserSettingsViewModel
        {
            var cacheHelper = CacheHelperFactory.GetDefinedCacheHelper();
            var userSettings = new List<T>();
            var userSettingsKeys = cacheHelper.GetCacheKeys().Where(w => w.Contains(Constants.UserSettingsCacheName));
            foreach (var key in userSettingsKeys)
            {
                var userSetting = UserSettingsService.GetUserSettings(key) as T;
                if (!(userSettingsFilterCondition?.Invoke(userSetting)) ?? true)
                {
                    continue;
                }
                userSettings.Add(userSetting);
            }
            return userSettings;
        }

        public static void SetPropertyForUsers(Action<IUserSettingsServiceModel> userSettingsDataModifier, Func<IUserSettingsServiceModel, bool> userSettingsFilterCondition)
        {
            if (userSettingsDataModifier == null)
                return;
            var users = GetUsers(userSettingsFilterCondition);
            users.ForEach(userSettingsDataModifier);
        }
    }
}
