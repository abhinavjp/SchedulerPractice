using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerPractice.Models
{
    public class BackgroundJobServerModel
    {
        public string ServerName { get; set; }
        public BackgroundJobServer BackgroundJobServer { get; set; }
    }
}
