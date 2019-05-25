using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerPractice.CoreAuthenticationHelper.Models;

namespace SchedulerPractice.CoreAuthenticationHelper.Services
{
    public static class CacheAuthenticationService
    {
        public static bool Authenticate(ITokenServiceModel token)
        {
            try
            {
                var userSettings = UserSettingsService.GetUserSettings(token);
                var masterSettings = MasterSettingsService.GetMasterSettings();
                return Authenticate(token, masterSettings, userSettings);
            }
            catch
            {
                return false;
            }
        }

        public static bool Authenticate(ITokenServiceModel token, MasterSettingsServiceModel masterSettings, UserSettingsServiceModel userSettings)
        {
            return !masterSettings.IsAuthenticationBlocked &&
                userSettings.IsLoggedIn && userSettings.IsActive &&
                (!userSettings.CanTokenExpire || userSettings.ExpiryDateTime > DateTime.UtcNow);
        }
    }
}
