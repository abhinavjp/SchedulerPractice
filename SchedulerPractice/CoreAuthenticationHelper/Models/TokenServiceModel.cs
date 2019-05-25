namespace SchedulerPractice.CoreAuthenticationHelper.Models
{
    public interface ITokenServiceModel
    {
        int UserId { get; set; }
        string UserSettingsKey { get; set; }
    }
}
