namespace SchedulerPractice.CoreAuthenticationHelper.Models
{
    public class MasterSettingsServiceModel
    {
        public bool IsAuthenticationBlocked { get; set; }
        public bool IsAuthenticationBlockedIndefinitely { get; set; }
        public int AuthenticationBlockedTimeInMinutes { get; set; }
    }
}
