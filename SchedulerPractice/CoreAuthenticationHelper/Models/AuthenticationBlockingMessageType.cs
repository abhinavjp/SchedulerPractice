using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerPractice.CoreAuthenticationHelper.Models
{
    public enum AuthenticationBlockingType
    {
        IndefiniteBlock,
        ScheduledTimeBlock,
        PeriodicBlock
    }
}
