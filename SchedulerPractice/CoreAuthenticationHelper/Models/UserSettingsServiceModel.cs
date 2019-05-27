using System;
using SchedulerPractice.CoreAuthenticationHelper.Interfaces;

namespace SchedulerPractice.CoreAuthenticationHelper.Models
{
    public class UserSettingsServiceModel : IUserSettingsServiceModel
    {
        public bool IsCacheSet { get; set; }
        public string CacheKey { get; set; }
        public int UserId { get; set; }
        public int? AccountId { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public int CurrentProcessingTaxYear { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsLoggedIn { get; set; }
        public DateTime LastApiRequestTime { get; set; }
        public bool CanTokenExpire { get; set; } = true;
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string DomainName { get; set; }
        public string EnvironmentName { get; set; }
        public string UserRole { get; set; }
        public string UserType { get; set; }
        public string PortalType { get; set; }
        public DateTime ExpiryDateTime { get; set; }
        public bool IsAuthenticationBlocked { get; set; }
        public string ErrorDisplayMessage { get; set; }
        public string WarningDisplayMessage { get; set; }
        public string InfoDisplayMessage { get; set; }
        public DateTime AuthenticationBlockedOn { get; set; }
        public AuthenticationBlockingType AuthenticationBlockingType { get; set; }
        public decimal AuthenticationBlockedPeriod { get; set; }
    }
}
