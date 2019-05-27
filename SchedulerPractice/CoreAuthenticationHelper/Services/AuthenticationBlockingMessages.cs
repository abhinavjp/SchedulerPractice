using System;
using System.Collections.Generic;
using SchedulerPractice.CoreAuthenticationHelper.Interfaces;
using SchedulerPractice.CoreAuthenticationHelper.Models;

namespace SchedulerPractice.CoreAuthenticationHelper.Services
{
    public static class AuthenticationBlockingMessages
    {
        public static readonly List<AuthenticationBlockingDisplayDetailServiceModel> AuthenticationBlockingDisplayDetails;
        static AuthenticationBlockingMessages()
        {
            AuthenticationBlockingDisplayDetails = new List<AuthenticationBlockingDisplayDetailServiceModel>
            {
                new AuthenticationBlockingDisplayDetailServiceModel
                {
                    AuthenticationBlockingMessageType = AuthenticationBlockingType.IndefiniteBlock,
                    DisplayMessage = "You cannot login now. Please try again later. Please contact system administrator to know further."
                },
                new AuthenticationBlockingDisplayDetailServiceModel
                {
                    AuthenticationBlockingMessageType = AuthenticationBlockingType.PeriodicBlock,
                    DisplayMessage = "You cannot login now. Please try again after {0} minutes. Please contact system administrator to know further.",
                    MessagePropertyGetters = new List<Func<IUserSettingsServiceModel, string>>{u => u.AuthenticationBlockedPeriod.ToString()}
                },
                new AuthenticationBlockingDisplayDetailServiceModel
                {
                    AuthenticationBlockingMessageType = AuthenticationBlockingType.ScheduledTimeBlock,
                    DisplayMessage = "You cannot login now. Please try again on {0}. Please contact system administrator to know further.",
                    MessagePropertyGetters = new List<Func<IUserSettingsServiceModel, string>>{u => u.AuthenticationBlockedPeriod.ToString("dd MMMM hh:mm tt")}
                }
            };
        }
    }
}
