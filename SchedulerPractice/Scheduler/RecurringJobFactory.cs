using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerPractice.Scheduler
{
    public class RecurringJobFactory
    {
        public List<IRecurringJobManager> RecurringJobManagers { get; set; }
    }
}
