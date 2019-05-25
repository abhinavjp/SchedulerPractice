using System;

namespace SchedulerPractice.CoreAuthenticationHelper.Interfaces
{
    public interface IUserSettingsViewModel
    {
        int UserId { get; set; }
        int? AccountId { get; set; }
        int EntityId { get; set; }
        string EntityType { get; set; }
        bool IsLoggedIn { get; set; }
        DateTime LastApiRequestTime { get; set; }
        bool CanTokenExpire { get; set; }
        string DomainName { get; set; }
        string EnvironmentName { get; set; }
        string UserRole { get; set; }
        string UserType { get; set; }
        string PortalType { get; set; }
        DateTime ExpiryDateTime { get; set; }
    }
}
