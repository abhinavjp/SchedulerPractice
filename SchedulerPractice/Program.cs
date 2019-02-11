using Hangfire;
using Hangfire.Common;
using Hangfire.Logging;
using Hangfire.SqlServer;
using System;

namespace SchedulerPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration();
            // Jobs
            //using (var server = new BackgroundJobServer(SetOptions(), new SqlServerStorage("HangfireConnection2")))
            //{
            Console.WriteLine("Hangfire Server started. Press any key to exit...");
            //    //BackgroundMethods();
            //    //DelayedBackgroubdJobs();
            //    RemoveRecurringJobs();
            AddRecurringJobs();
                Console.ReadKey();
            //}

            Console.ReadKey();
        }

        private static BackgroundJobServerOptions SetOptions()
        {
            return new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromSeconds(1)                
            };
        }

        private static void Configuration()
        {
            GlobalConfiguration.Configuration
                  .UseColouredConsoleLogProvider()
                  .UseSqlServerStorage("HangfireConnection");
                  //.UseSqlServerStorage("HangfireConnection2")
                  //.UseSqlServerStorage("HangfireConnection3");
            LogProvider.SetCurrentLogProvider(null);
        }

        private static void BackgroundMethods()
        {
            IBackgroundJobClient backgroundJobClient = new BackgroundJobClient();
            backgroundJobClient.Enqueue(() => Console.WriteLine("Instant Background Methods"));
        }

        private static void DelayedBackgroubdJobs()
        {
            BackgroundJob.Schedule(() => Console.WriteLine("Delayed Background Methods"), TimeSpan.FromMilliseconds(5000));
        }

        private static void AddRecurringJobs()
        {
            //RecurringJob.AddOrUpdate("ev-min-recur", () => Console.WriteLine("Recurring Background Methods"), Cron.Minutely);
            var jobManager = new RecurringJobManager(new SqlServerStorage("HangfireConnection"));
            jobManager.AddOrUpdate("ev-min-recur",
                Job.FromExpression(() => Console.WriteLine("Recurring Background Methods")),
                Cron.Minutely());
        }

        private static void RemoveRecurringJobs()
        {
            RecurringJob.RemoveIfExists("Console.Write");
            RecurringJob.RemoveIfExists("ev-min-recur");
        }
    }
}
