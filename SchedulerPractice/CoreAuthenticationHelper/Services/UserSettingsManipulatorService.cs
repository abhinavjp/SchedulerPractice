using System;
using System.Collections.Generic;
using SchedulerPractice.CoreAuthenticationHelper.Interfaces;

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
            throw new NotImplementedException();
        }
    }
}
