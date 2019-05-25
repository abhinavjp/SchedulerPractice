using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerPractice.CoreAuthenticationHelper.Interfaces
{
    public interface IUserSettingsServiceModel
    {
        int? AccountId { get; set; }
        string CacheKey { get; set; }
        bool CanTokenExpire { get; set; }
        int CurrentProcessingTaxYear { get; set; }
        string DomainName { get; set; }
        int EntityId { get; set; }
        string EntityType { get; set; }
        string EnvironmentName { get; set; }
        DateTime ExpiryDateTime { get; set; }
        bool IsActive { get; set; }
        bool IsAdmin { get; set; }
        bool IsCacheSet { get; set; }
        bool IsLoggedIn { get; set; }
        DateTime LastApiRequestTime { get; set; }
        string PortalType { get; set; }
        string UserEmail { get; set; }
        int UserId { get; set; }
        string Username { get; set; }
        string UserRole { get; set; }
        string UserType { get; set; }
    }
}
