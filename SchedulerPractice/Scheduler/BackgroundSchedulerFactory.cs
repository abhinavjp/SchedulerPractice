using Hangfire;
using SchedulerPractice.Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerPractice.Scheduler
{
    public class BackgroundSchedulerFactory : IDisposable
    {
        public List<BackgroundJobServerModel> BackgroundJobServers { get; set; }

        public void Add(string serverName, BackgroundJobServer backgroundJobServer)
        {
            InitializeJobServers();
            BackgroundJobServers.Add(new BackgroundJobServerModel
            {
                ServerName = serverName,
                BackgroundJobServer = backgroundJobServer
            });
        }

        public void Add(string serverName, JobStorage jobStorage)
        {
            Add(serverName, new BackgroundJobServer(jobStorage));
        }

        public void Dispose()
        {
            if (BackgroundJobServers == null) return;
            BackgroundJobServers.ForEach(f => f.BackgroundJobServer.Dispose());
        }

        private void InitializeJobServers()
        {
            if (BackgroundJobServers != null) return;
            BackgroundJobServers = new List<BackgroundJobServerModel>();
        }
    }
}
