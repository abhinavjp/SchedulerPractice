using System;
using System.Collections.Generic;
using SchedulerPractice.CoreAuthenticationHelper.Interfaces;

namespace SchedulerPractice.CoreAuthenticationHelper.Models
{
    public class AuthenticationBlockingDisplayDetailServiceModel
    {
        public AuthenticationBlockingType AuthenticationBlockingMessageType { get; set; }
        public string DisplayMessage { get; set; }
        public List<Func<IUserSettingsServiceModel, string>> MessagePropertyGetters { get; set; }
    }
}
