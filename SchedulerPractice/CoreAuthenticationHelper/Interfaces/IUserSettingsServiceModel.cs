namespace SchedulerPractice.CoreAuthenticationHelper.Interfaces
{
    public interface IUserSettingsServiceModel: IUserSettingsViewModel
    {
        string CacheKey { get; set; }
        int CurrentProcessingTaxYear { get; set; }
        bool IsActive { get; set; }
        bool IsAdmin { get; set; }
        bool IsCacheSet { get; set; }
        string UserEmail { get; set; }
        string Username { get; set; }
    }
}
