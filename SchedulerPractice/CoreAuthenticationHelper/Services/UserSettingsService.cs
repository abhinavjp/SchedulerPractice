using System.Text;
using SchedulerPractice.CacheHelper.Services;
using SchedulerPractice.CoreAuthenticationHelper.Models;

namespace SchedulerPractice.CoreAuthenticationHelper.Services
{
    public static class UserSettingsService
    {
        public static UserSettingsServiceModel GetUserSettings(ITokenServiceModel token)
        {
            return GetUserSettings(token.UserSettingsKey);
        }
        public static UserSettingsServiceModel GetUserSettings(string userSettingsKey)
        {
            var cacheHelper = CacheHelperFactory.GetDefinedCacheHelper();
            return cacheHelper.GetCache<UserSettingsServiceModel>(userSettingsKey);
        }

        public static T SetUserSettings<T>(UserSettingsServiceModel userSettings) where T : ITokenServiceModel, new()
        {
            var userSettingsKey = GenerateUserSettingsKey(userSettings);
            return SetUserSettings<T>(userSettingsKey, userSettings);
        }

        public static T SetUserSettings<T>(string userSettingsKey, UserSettingsServiceModel userSettings) where T : ITokenServiceModel, new()
        {
            var token = new T
            {
                UserId = userSettings.UserId,
                UserSettingsKey = userSettingsKey
            };
            return SetUserSettings(token, userSettings);
        }

        public static T SetUserSettings<T>(T token, UserSettingsServiceModel userSettings) where T : ITokenServiceModel, new()
        {
            var cacheHelper = CacheHelperFactory.GetDefinedCacheHelper();
            cacheHelper.SetCache(token.UserSettingsKey, userSettings);
            return token;
        }

        private static string GenerateUserSettingsKey(UserSettingsServiceModel userSettings)
        {
            var keyBuilder = new StringBuilder();
            if (userSettings.UserId != default)
            {
                keyBuilder.Append($"_{userSettings.UserId}");
            }
            if (userSettings.AccountId != default)
            {
                keyBuilder.Append($"_{userSettings.AccountId}");
            }
            if (userSettings.PortalType != default)
            {
                keyBuilder.Append($"_{userSettings.PortalType}");
            }
            if (userSettings.EnvironmentName != default)
            {
                keyBuilder.Append($"_{userSettings.EnvironmentName}");
            }
            if (userSettings.UserRole != default)
            {
                keyBuilder.Append($"_{userSettings.UserRole}");
            }
            if (userSettings.UserType != default)
            {
                keyBuilder.Append($"_{userSettings.UserType}");
            }
            if (userSettings.DomainName != default)
            {
                keyBuilder.Append($"_{userSettings.DomainName}");
            }
            return keyBuilder.ToString();
        }
    }
}
